using Spotlight.GUI;
using Spotlight.Level;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Spotlight
{
    /**
     * The progress bar for when randomization occurs
     * 
     * This also provides the asyncronous operations for randomizing levels
     */
    public partial class RandomProgressForm : Form
    {
        private RandomizerForm randomizerForm;

        private BackgroundWorker worker;

        // The current data being randomized
        private SM3DWorldZone currentZone;
        private int currentIndex;
        private string currentFileName;

        // The progress to advance for each level randomized
        private int progressPerLevel;

        public RandomProgressForm(RandomizerForm randomizerForm)
        {
            InitializeComponent();
            CenterToParent();

            progressPerLevel = 100 / randomizerForm.selectedLevels.Count;

            this.randomizerForm = randomizerForm;
        }

        /**
         * Begin randomization for the level at the given index in the SELECTED levels list
         * 
         * Will recursively randomize the next level if there is another to randomize
         */
        public void Randomize(int i)
        {
            currentIndex = i;

            currentFileName = $"{randomizerForm.selectedLevels[i].StageName}{SM3DWorldZone.COMBINED_SUFFIX}";

            string path1 = Program.TryGetPathViaProject("StageData", $"{randomizerForm.selectedLevels[i].StageName}{SM3DWorldZone.MAP_SUFFIX}");
            string path2 = Program.TryGetPathViaProject("StageData", currentFileName);

            // Whether or not this is the last level to be randomized
            bool isLastOne = i == randomizerForm.selectedLevels.Count - 1;

            if (SM3DWorldZone.TryOpen(path1, out var zone))
                StartIt(zone, isLastOne);
            else if (SM3DWorldZone.TryOpen(path2, out zone))
                StartIt(zone, isLastOne);
        }

        /**
         * Start the randomization worker for the zone given
         */
        private void StartIt(SM3DWorldZone zone, bool finalCountdown)
        {
            currentZone = zone;
            Text = "Randomizing " + currentZone.LevelName + "...";

            worker = new();
            worker.DoWork += new DoWorkEventHandler(RandomizeFile);
            if (finalCountdown)
            {
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FinalFinishIt);
            }
            else
            {
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FinishIt);
            }
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }

        /**
         * For when the worker finishes randomizing a level, but there is still another to randomize
         */
        private void FinishIt(object sender, RunWorkerCompletedEventArgs e)
        {
            MainProgressBar.Value += progressPerLevel;
            Randomize(currentIndex + 1);
        }

        /**
         * For when the worker finished randomizing the last level
         */
        private void FinalFinishIt(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
            MessageBox.Show(randomizerForm.finishingMessage);
        }

        private void RandomizeFile(object sender, DoWorkEventArgs e)
        {
            Randomizer randomizer = new(currentZone, randomizerForm);
            randomizer.Randomize();

            currentZone.Save(randomizerForm.settings.SaveDir + "\\" + currentFileName);
        }
    }
}
