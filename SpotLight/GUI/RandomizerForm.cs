using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Spotlight.GUI
{
    public partial class RandomizerForm : Form
    {
        /**
         *  Object data for randomizing (loaded from the JSON files)
         */
        public class RandoObject
        {
            public string Name { get; set; } // Object name
            public List<string> Classes { get; set; } // Possible class names that are used in 3D world for this object
            public List<string> Models { get; set; } // Possible model names that are used in 3D world for this object
            public int GpuPower { get; set; } // A guesstamation of the risk of how likely a large number of these objects may cause lagging/crashing
            public RandoSafety Safety { get; set; }
            public int Difficulty { get; set; } // How much easier/harder this object may make the game (50 is neutral, < 50 is easier, > 50 is harder)
            public List<RandoProp> Properties { get; set; }
        }

        /**
         * A guesstamation of the odds that this 3D world object may make the level un-beatable
         */
        public class RandoSafety
        {
            public int Source { get; set; } // If the object is being replaced
            public int Destination { get; set; } // If the object is replacing another
        }

        /**
         * Randomization info for a prop used for an object
         */
        public class RandoProp
        {
            public string Name { get; set; }
            public string Type { get; set; } // Data type
            public List<string> Values { get; set; } // List of possible values that are used for this property throughout the 3D world game
        }

        /**
         * Randomization settings that the user gets to set
         */
        public class RandoSettings
        {
            public int Version { get; set; } // Int to indicate the version of the spotlight randomizer. Not used now, but may be used in the future if there ever is an update to the randomizer.
            public int Beatable { get; set; }
            public int Demand { get; set; }
            public int Difficulty { get; set; }
            public double MinSize { get; set; }
            public double MaxSize { get; set; }
            public bool ScaleRatio { get; set; }
            public bool XRotation { get; set; }
            public bool YRotation { get; set; }
            public bool ZRotation { get; set; }
            public bool BeConsistent { get; set; }
            public bool UseRange { get; set; }
            public List<string> SelectedObjects { get; set; }
            public List<string> SelectedLevels { get; set; }
            public string SaveDir { get; set; } // The last directory that the user saved the randomized levels to
        }

        private readonly StageList stageList;

        private readonly string SETTINGS_FILE_NAME = "randomizerSettings.json";
        private readonly int SETTINGS_VERSION = 1;
        public RandoSettings settings;

        public DialogResult doIt; // If the user has confirmed to randomize

        public List<RandoObject> selectedObjs;
        public List<LevelParam> selectedLevels;

        public List<RandoObject> objects;

        public string finishingMessage;

        public RandomizerForm(StageList stageList)
        {
            InitializeComponent();

            this.stageList = stageList;

            this.selectedLevels = new List<LevelParam>();
            this.selectedObjs = new List<RandoObject>();

            this.objects = new List<RandoObject>();

            finishingMessage = "Randomization Complete";
        }

        private void RandomizerForm_Load(object sender, EventArgs e)
        {
            // Load randomizable objects
            string dir = Directory.GetCurrentDirectory() + "\\randomizerData\\";
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                int periodPosition = file.Name.IndexOf('.');
                string name = file.Name.Substring(0, periodPosition); // For removing the extension
                clbObjects.Items.Add(name);

                // De-serialization
                string objSerialized = File.ReadAllText(dir + file.Name);
                RandoObject randoObject = JsonSerializer.Deserialize<RandoObject>(objSerialized);
                randoObject.Name = name;
                objects.Add(randoObject);
            }
            for (int i = 0; i < clbObjects.Items.Count; i++)
            {
                clbObjects.SetItemChecked(i, true);
            }

            // Add levels to the list
            for (int i = 0; i < this.stageList.Worlds.Count; i++)
            {
                foreach (LevelParam level in this.stageList.Worlds[i].Levels)
                {
                    int world = i + 1;
                    clbLevels.Items.Add("World " + world + " - " + level.StageName);
                }
            }
            for (int i = 0; i < clbLevels.Items.Count; i++)
            {
                clbLevels.SetItemChecked(i, true);
            }

            // Load the settings JSON file
            string settingsFile = Directory.GetCurrentDirectory() + "\\" + SETTINGS_FILE_NAME;
            if (File.Exists(settingsFile))
            {
                string settingsJson = File.ReadAllText(settingsFile);
                settings = JsonSerializer.Deserialize<RandoSettings>(settingsJson);
                ApplySettingsToInput();
            }
            else
            {
                settings = new RandoSettings();
                LoadSettingsFromInput();
                settings.SaveDir = Directory.GetCurrentDirectory();
            }

            DateTime wut = new(DateTime.Today.Year, 5, 4, 0, 0, 0);
            int huh = DateTime.Compare(wut, DateTime.Today);
            if (huh == 0)
            {
                btnRandomize.Text = "Do It";
            }
        }

        private void clbLevels_Check(object sender, EventArgs e)
        {
            CheckSwitchingSelectAllButton(btnDeselectAll, clbLevels);
        }

        private void clbObjects_Check(object sender, EventArgs e)
        {
            CheckSwitchingSelectAllButton(btnDeselectAll2, clbObjects);
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbLevels.Items.Count; i++)
            {
                clbLevels.SetItemChecked(i, btnDeselectAll.Text == "Select All");
            }
            CheckSwitchingSelectAllButton(btnDeselectAll, clbLevels);
        }

        private void btnDeselectAll2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbObjects.Items.Count; i++)
            {
                clbObjects.SetItemChecked(i, btnDeselectAll2.Text == "Select All");
            }
            CheckSwitchingSelectAllButton(btnDeselectAll2, clbObjects);
        }

        /**
         * Changes button text to Select/Deselect based upon whether more options are selected or unselected
         */
        public void CheckSwitchingSelectAllButton(Button btn, CheckedListBox clb)
        {
            if (clb.CheckedItems.Count > clb.Items.Count / 2)
            {
                btn.Text = "Deselect All";
            }
            else
            {
                btn.Text = "Select All";
            }
        }

        /**
         * Keeps the user from setting a min size greater than the max size
         */
        private void nudMin_ValueChanged(object sender, EventArgs e)
        {
            if (nudMin.Value > nudMax.Value)
            {
                nudMin.Value = nudMax.Value;
            }
        }

        /**
         * Keeps the user from setting a max size less than the min size
         */
        private void nudMax_ValueChanged(object sender, EventArgs e)
        {
            if (nudMin.Value > nudMax.Value)
            {
                nudMax.Value = nudMin.Value;
            }
        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderChooser = new()
            {
                Description = "Choose the folder to save the randomized level files:",
                SelectedPath = settings.SaveDir
            };
            DialogResult folderChoice = folderChooser.ShowDialog();

            if (folderChoice == DialogResult.OK)
            {
                settings.SaveDir = folderChooser.SelectedPath;

                // It's some older code sir, but it seems to check out
                string highGround = "I don't know";
                string tr8_tr = "It's not the modder way.\n\n\"Yes\" = Randomize it. Now.\n\"No\" = I want to go home and re-think my life.";
                string rise = "You have done well, my young modder. Rise.";
                DateTime wut = new DateTime(DateTime.Today.Year, 5, 4, 0, 0, 0);
                int huh = DateTime.Compare(wut, DateTime.Today);
                if (huh != 0)
                {
                    highGround = "Confirm";
                    tr8_tr = "Begin randomization? (saving randomized files to " + settings.SaveDir + ", overwriting existing files)";
                    rise = "Randomization Complete";
                }
                finishingMessage = rise;

                doIt = MessageBox.Show(tr8_tr, highGround, MessageBoxButtons.YesNo);

                if (doIt == DialogResult.Yes)
                {
                    LoadSettingsFromInput();

                    // Save the settings the user set for next time
                    string jsonSettings = JsonSerializer.Serialize(settings);
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + SETTINGS_FILE_NAME, jsonSettings);

                    LoadChecked();

                    this.Close();
                }
            }
        }

        /**
         * Loads the settings data currently input by the user
         */
        private void LoadSettingsFromInput()
        {
            settings.Version = SETTINGS_VERSION;
            settings.Beatable = trkBeatable.Value;
            settings.Demand = trkDemanding.Value;
            settings.Difficulty = trkAdjustDifficulty.Value;
            settings.MinSize = decimal.ToDouble(nudMin.Value);
            settings.MaxSize = decimal.ToDouble(nudMax.Value);
            settings.ScaleRatio = chkScaleRatio.Checked;
            settings.XRotation = chkX.Checked;
            settings.YRotation = chkY.Checked;
            settings.ZRotation = chkZ.Checked;
            settings.BeConsistent = chkConsistency.Checked;
            settings.UseRange = chkUseRange.Checked;

            settings.SelectedObjects = new();
            foreach (string item in clbObjects.CheckedItems)
            {
                settings.SelectedObjects.Add(item);
            }

            settings.SelectedLevels = new();
            foreach (string item in clbLevels.CheckedItems)
            {
                settings.SelectedLevels.Add(item);
            }
        }

        /**
         * Applies the current settings in the settings object to the input controls
         */
        private void ApplySettingsToInput()
        {
            trkBeatable.Value = settings.Beatable;
            trkDemanding.Value = settings.Demand;
            trkAdjustDifficulty.Value = settings.Difficulty;
            nudMin.Value = (decimal)settings.MinSize;
            nudMax.Value = (decimal)settings.MaxSize;
            chkScaleRatio.Checked = settings.ScaleRatio;
            chkX.Checked = settings.XRotation;
            chkY.Checked = settings.YRotation;
            chkZ.Checked = settings.ZRotation;
            chkConsistency.Checked = settings.BeConsistent;
            chkUseRange.Checked = settings.UseRange;

            int i = 0;
            for (int j = 0; j < clbObjects.Items.Count; j++)
            {
                if (i < settings.SelectedObjects.Count && (string)clbObjects.Items[j] == settings.SelectedObjects[i])
                {
                    clbObjects.SetItemChecked(j, true);
                    i++;
                }
                else
                {
                    clbObjects.SetItemChecked(j, false);
                }
            }

            i = 0;
            for (int j = 0; j < clbLevels.Items.Count; j++)
            {
                if (i < settings.SelectedLevels.Count && (string)clbLevels.Items[j] == settings.SelectedLevels[i])
                {
                    clbLevels.SetItemChecked(j, true);
                    i++;
                }
                else
                {
                    clbLevels.SetItemChecked(j, false);
                }
            }
        }

        /**
         * Loads the objects for the items the user has checked in the checkbox lists
         */
        private void LoadChecked()
        {
            int objIndex = 0;
            foreach (string item in clbObjects.CheckedItems)
            {
                for (int j = objIndex; j < objects.Count; j++)
                {
                    if (objects[j].Name == item)
                    {
                        selectedObjs.Add(objects[j]);
                        j = objects.Count;
                    }
                    objIndex++;
                }
            }

            int currentWorld = 0;
            int currentLevel = 0;
            foreach (string item in clbLevels.CheckedItems)
            {
                for (int i = currentWorld; i < this.stageList.Worlds.Count; i++)
                {
                    var world = this.stageList.Worlds[i];
                    for (int j = currentLevel; j < world.Levels.Count; j++)
                    {
                        var level = world.Levels[j];
                        if (item.Contains((i + 1).ToString()) && item.Contains(level.StageName))
                        {
                            selectedLevels.Add(level);
                        }
                    }
                }
            }
        }
    }
}
