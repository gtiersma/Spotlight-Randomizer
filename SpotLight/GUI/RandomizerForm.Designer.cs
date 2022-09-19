namespace Spotlight.GUI
{
    partial class RandomizerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandomizerForm));
            this.trkAdjustDifficulty = new System.Windows.Forms.TrackBar();
            this.lblMoreBeatable = new System.Windows.Forms.Label();
            this.lblEasy = new System.Windows.Forms.Label();
            this.lblHard = new System.Windows.Forms.Label();
            this.trkBeatable = new System.Windows.Forms.TrackBar();
            this.lblMoreRandom = new System.Windows.Forms.Label();
            this.lblLessDemanding = new System.Windows.Forms.Label();
            this.lblMoreRandom2 = new System.Windows.Forms.Label();
            this.trkDemanding = new System.Windows.Forms.TrackBar();
            this.lblMinSize = new System.Windows.Forms.Label();
            this.lblMaxSize = new System.Windows.Forms.Label();
            this.chkX = new System.Windows.Forms.CheckBox();
            this.grpRandomizeRotation = new System.Windows.Forms.GroupBox();
            this.chkZ = new System.Windows.Forms.CheckBox();
            this.chkY = new System.Windows.Forms.CheckBox();
            this.clbLevels = new System.Windows.Forms.CheckedListBox();
            this.lblLevels = new System.Windows.Forms.Label();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.lblObjects = new System.Windows.Forms.Label();
            this.clbObjects = new System.Windows.Forms.CheckedListBox();
            this.btnDeselectAll2 = new System.Windows.Forms.Button();
            this.btnRandomize = new System.Windows.Forms.Button();
            this.chkConsistency = new System.Windows.Forms.CheckBox();
            this.lblMinX = new System.Windows.Forms.Label();
            this.lblMaxX = new System.Windows.Forms.Label();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.nudMax = new System.Windows.Forms.NumericUpDown();
            this.chkScaleRatio = new System.Windows.Forms.CheckBox();
            this.grpSize = new System.Windows.Forms.GroupBox();
            this.chkUseRange = new System.Windows.Forms.CheckBox();
            this.tlp = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trkAdjustDifficulty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBeatable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkDemanding)).BeginInit();
            this.grpRandomizeRotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
            this.grpSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // trkAdjustDifficulty
            // 
            this.trkAdjustDifficulty.LargeChange = 10;
            this.trkAdjustDifficulty.Location = new System.Drawing.Point(104, 119);
            this.trkAdjustDifficulty.Maximum = 100;
            this.trkAdjustDifficulty.Name = "trkAdjustDifficulty";
            this.trkAdjustDifficulty.RightToLeftLayout = true;
            this.trkAdjustDifficulty.Size = new System.Drawing.Size(388, 45);
            this.trkAdjustDifficulty.TabIndex = 1;
            this.trkAdjustDifficulty.TickFrequency = 10;
            this.tlp.SetToolTip(this.trkAdjustDifficulty, "Attempts to adjust the difficulty of the level.\r\n\r\nPut the slider in the middle t" +
        "o try to keep the difficulty the same as before.");
            this.trkAdjustDifficulty.Value = 50;
            // 
            // lblMoreBeatable
            // 
            this.lblMoreBeatable.AutoSize = true;
            this.lblMoreBeatable.Location = new System.Drawing.Point(27, 20);
            this.lblMoreBeatable.Name = "lblMoreBeatable";
            this.lblMoreBeatable.Size = new System.Drawing.Size(76, 13);
            this.lblMoreBeatable.TabIndex = 3;
            this.lblMoreBeatable.Text = "More Beatable";
            // 
            // lblEasy
            // 
            this.lblEasy.AutoSize = true;
            this.lblEasy.Location = new System.Drawing.Point(73, 119);
            this.lblEasy.Name = "lblEasy";
            this.lblEasy.Size = new System.Drawing.Size(30, 13);
            this.lblEasy.TabIndex = 4;
            this.lblEasy.Text = "Easy";
            // 
            // lblHard
            // 
            this.lblHard.AutoSize = true;
            this.lblHard.Location = new System.Drawing.Point(498, 119);
            this.lblHard.Name = "lblHard";
            this.lblHard.Size = new System.Drawing.Size(30, 13);
            this.lblHard.TabIndex = 5;
            this.lblHard.Text = "Hard";
            // 
            // trkBeatable
            // 
            this.trkBeatable.LargeChange = 10;
            this.trkBeatable.Location = new System.Drawing.Point(104, 20);
            this.trkBeatable.Maximum = 100;
            this.trkBeatable.Name = "trkBeatable";
            this.trkBeatable.RightToLeftLayout = true;
            this.trkBeatable.Size = new System.Drawing.Size(388, 45);
            this.trkBeatable.TabIndex = 7;
            this.trkBeatable.TickFrequency = 10;
            this.tlp.SetToolTip(this.trkBeatable, "MORE BEATABLE increases the odds that the level will still be completable at the " +
        "expense of limiting randomness.\r\n\r\nMORE RANDOM will ignore how completable the l" +
        "evel may be to keep things random.");
            this.trkBeatable.Value = 50;
            // 
            // lblMoreRandom
            // 
            this.lblMoreRandom.AutoSize = true;
            this.lblMoreRandom.Location = new System.Drawing.Point(498, 20);
            this.lblMoreRandom.Name = "lblMoreRandom";
            this.lblMoreRandom.Size = new System.Drawing.Size(74, 13);
            this.lblMoreRandom.TabIndex = 8;
            this.lblMoreRandom.Text = "More Random";
            // 
            // lblLessDemanding
            // 
            this.lblLessDemanding.AutoSize = true;
            this.lblLessDemanding.Location = new System.Drawing.Point(17, 68);
            this.lblLessDemanding.Name = "lblLessDemanding";
            this.lblLessDemanding.Size = new System.Drawing.Size(86, 13);
            this.lblLessDemanding.TabIndex = 9;
            this.lblLessDemanding.Text = "Less Demanding";
            // 
            // lblMoreRandom2
            // 
            this.lblMoreRandom2.AutoSize = true;
            this.lblMoreRandom2.Location = new System.Drawing.Point(498, 68);
            this.lblMoreRandom2.Name = "lblMoreRandom2";
            this.lblMoreRandom2.Size = new System.Drawing.Size(74, 13);
            this.lblMoreRandom2.TabIndex = 10;
            this.lblMoreRandom2.Text = "More Random";
            // 
            // trkDemanding
            // 
            this.trkDemanding.LargeChange = 10;
            this.trkDemanding.Location = new System.Drawing.Point(104, 68);
            this.trkDemanding.Maximum = 100;
            this.trkDemanding.Name = "trkDemanding";
            this.trkDemanding.RightToLeftLayout = true;
            this.trkDemanding.Size = new System.Drawing.Size(388, 45);
            this.trkDemanding.TabIndex = 11;
            this.trkDemanding.TickFrequency = 10;
            this.tlp.SetToolTip(this.trkDemanding, resources.GetString("trkDemanding.ToolTip"));
            this.trkDemanding.Value = 50;
            // 
            // lblMinSize
            // 
            this.lblMinSize.AutoSize = true;
            this.lblMinSize.Location = new System.Drawing.Point(15, 27);
            this.lblMinSize.Name = "lblMinSize";
            this.lblMinSize.Size = new System.Drawing.Size(24, 13);
            this.lblMinSize.TabIndex = 12;
            this.lblMinSize.Text = "Min";
            // 
            // lblMaxSize
            // 
            this.lblMaxSize.AutoSize = true;
            this.lblMaxSize.Location = new System.Drawing.Point(15, 53);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(27, 13);
            this.lblMaxSize.TabIndex = 14;
            this.lblMaxSize.Text = "Max";
            // 
            // chkX
            // 
            this.chkX.AutoSize = true;
            this.chkX.Location = new System.Drawing.Point(15, 26);
            this.chkX.Name = "chkX";
            this.chkX.Size = new System.Drawing.Size(33, 17);
            this.chkX.TabIndex = 16;
            this.chkX.Text = "X";
            this.chkX.UseVisualStyleBackColor = true;
            // 
            // grpRandomizeRotation
            // 
            this.grpRandomizeRotation.Controls.Add(this.chkZ);
            this.grpRandomizeRotation.Controls.Add(this.chkY);
            this.grpRandomizeRotation.Controls.Add(this.chkX);
            this.grpRandomizeRotation.Location = new System.Drawing.Point(282, 170);
            this.grpRandomizeRotation.Name = "grpRandomizeRotation";
            this.grpRandomizeRotation.Size = new System.Drawing.Size(181, 58);
            this.grpRandomizeRotation.TabIndex = 17;
            this.grpRandomizeRotation.TabStop = false;
            this.grpRandomizeRotation.Text = "Randomize Rotation";
            this.tlp.SetToolTip(this.grpRandomizeRotation, "Which directions to randomly rotate objects (if random rotations is desired)");
            // 
            // chkZ
            // 
            this.chkZ.AutoSize = true;
            this.chkZ.Location = new System.Drawing.Point(135, 26);
            this.chkZ.Name = "chkZ";
            this.chkZ.Size = new System.Drawing.Size(33, 17);
            this.chkZ.TabIndex = 19;
            this.chkZ.Text = "Z";
            this.chkZ.UseVisualStyleBackColor = true;
            // 
            // chkY
            // 
            this.chkY.AutoSize = true;
            this.chkY.Location = new System.Drawing.Point(75, 26);
            this.chkY.Name = "chkY";
            this.chkY.Size = new System.Drawing.Size(33, 17);
            this.chkY.TabIndex = 18;
            this.chkY.Text = "Y";
            this.chkY.UseVisualStyleBackColor = true;
            // 
            // clbLevels
            // 
            this.clbLevels.FormattingEnabled = true;
            this.clbLevels.Location = new System.Drawing.Point(12, 288);
            this.clbLevels.Name = "clbLevels";
            this.clbLevels.Size = new System.Drawing.Size(240, 184);
            this.clbLevels.TabIndex = 18;
            this.tlp.SetToolTip(this.clbLevels, "Choose which levels to randomize");
            // 
            // lblLevels
            // 
            this.lblLevels.AutoSize = true;
            this.lblLevels.Location = new System.Drawing.Point(9, 270);
            this.lblLevels.Name = "lblLevels";
            this.lblLevels.Size = new System.Drawing.Size(38, 13);
            this.lblLevels.TabIndex = 19;
            this.lblLevels.Text = "Levels";
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Location = new System.Drawing.Point(12, 478);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(240, 23);
            this.btnDeselectAll.TabIndex = 20;
            this.btnDeselectAll.Text = "Deselect All";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // lblObjects
            // 
            this.lblObjects.AutoSize = true;
            this.lblObjects.Location = new System.Drawing.Point(255, 270);
            this.lblObjects.Name = "lblObjects";
            this.lblObjects.Size = new System.Drawing.Size(43, 13);
            this.lblObjects.TabIndex = 21;
            this.lblObjects.Text = "Objects";
            // 
            // clbObjects
            // 
            this.clbObjects.FormattingEnabled = true;
            this.clbObjects.Location = new System.Drawing.Point(258, 288);
            this.clbObjects.Name = "clbObjects";
            this.clbObjects.Size = new System.Drawing.Size(120, 184);
            this.clbObjects.TabIndex = 22;
            this.tlp.SetToolTip(this.clbObjects, "Choose which objects you would like the randomizer to put in the level.");
            // 
            // btnDeselectAll2
            // 
            this.btnDeselectAll2.Location = new System.Drawing.Point(258, 478);
            this.btnDeselectAll2.Name = "btnDeselectAll2";
            this.btnDeselectAll2.Size = new System.Drawing.Size(120, 23);
            this.btnDeselectAll2.TabIndex = 23;
            this.btnDeselectAll2.Text = "Deselect All";
            this.btnDeselectAll2.UseVisualStyleBackColor = true;
            this.btnDeselectAll2.Click += new System.EventHandler(this.btnDeselectAll2_Click);
            // 
            // btnRandomize
            // 
            this.btnRandomize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomize.Location = new System.Drawing.Point(458, 451);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(114, 50);
            this.btnRandomize.TabIndex = 24;
            this.btnRandomize.Text = "Randomize";
            this.btnRandomize.UseVisualStyleBackColor = true;
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click);
            // 
            // chkConsistency
            // 
            this.chkConsistency.AutoSize = true;
            this.chkConsistency.Checked = true;
            this.chkConsistency.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsistency.Location = new System.Drawing.Point(417, 251);
            this.chkConsistency.Name = "chkConsistency";
            this.chkConsistency.Size = new System.Drawing.Size(83, 17);
            this.chkConsistency.TabIndex = 25;
            this.chkConsistency.Text = "Consistency";
            this.tlp.SetToolTip(this.chkConsistency, resources.GetString("chkConsistency.ToolTip"));
            this.chkConsistency.UseVisualStyleBackColor = true;
            // 
            // lblMinX
            // 
            this.lblMinX.AutoSize = true;
            this.lblMinX.Location = new System.Drawing.Point(97, 27);
            this.lblMinX.Name = "lblMinX";
            this.lblMinX.Size = new System.Drawing.Size(12, 13);
            this.lblMinX.TabIndex = 26;
            this.lblMinX.Text = "x";
            // 
            // lblMaxX
            // 
            this.lblMaxX.AutoSize = true;
            this.lblMaxX.Location = new System.Drawing.Point(97, 53);
            this.lblMaxX.Name = "lblMaxX";
            this.lblMaxX.Size = new System.Drawing.Size(12, 13);
            this.lblMaxX.TabIndex = 27;
            this.lblMaxX.Text = "x";
            // 
            // nudMin
            // 
            this.nudMin.DecimalPlaces = 2;
            this.nudMin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudMin.Location = new System.Drawing.Point(45, 25);
            this.nudMin.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMin.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(46, 20);
            this.nudMin.TabIndex = 28;
            this.tlp.SetToolTip(this.nudMin, "The smallest possible size to scale an object.\r\n\r\nLess than 1 is smaller.\r\n1 leav" +
        "es the size the same.\r\nMore than 1 is bigger.");
            this.nudMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMin.ValueChanged += new System.EventHandler(this.nudMin_ValueChanged);
            // 
            // nudMax
            // 
            this.nudMax.DecimalPlaces = 2;
            this.nudMax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudMax.Location = new System.Drawing.Point(45, 51);
            this.nudMax.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMax.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudMax.Name = "nudMax";
            this.nudMax.Size = new System.Drawing.Size(46, 20);
            this.nudMax.TabIndex = 29;
            this.tlp.SetToolTip(this.nudMax, "The largest possible size to scale an object.\r\n\r\nLess than 1 is smaller.\r\n1 leave" +
        "s the size the same.\r\nMore than 1 is bigger.\r\n");
            this.nudMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMax.ValueChanged += new System.EventHandler(this.nudMax_ValueChanged);
            // 
            // chkScaleRatio
            // 
            this.chkScaleRatio.AutoSize = true;
            this.chkScaleRatio.Checked = true;
            this.chkScaleRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScaleRatio.Location = new System.Drawing.Point(127, 26);
            this.chkScaleRatio.Name = "chkScaleRatio";
            this.chkScaleRatio.Size = new System.Drawing.Size(94, 17);
            this.chkScaleRatio.TabIndex = 30;
            this.chkScaleRatio.Text = "Maintain Ratio";
            this.tlp.SetToolTip(this.chkScaleRatio, resources.GetString("chkScaleRatio.ToolTip"));
            this.chkScaleRatio.UseVisualStyleBackColor = true;
            // 
            // grpSize
            // 
            this.grpSize.Controls.Add(this.lblMinSize);
            this.grpSize.Controls.Add(this.chkScaleRatio);
            this.grpSize.Controls.Add(this.nudMin);
            this.grpSize.Controls.Add(this.lblMinX);
            this.grpSize.Controls.Add(this.nudMax);
            this.grpSize.Controls.Add(this.lblMaxSize);
            this.grpSize.Controls.Add(this.lblMaxX);
            this.grpSize.Location = new System.Drawing.Point(12, 170);
            this.grpSize.Name = "grpSize";
            this.grpSize.Size = new System.Drawing.Size(232, 88);
            this.grpSize.TabIndex = 20;
            this.grpSize.TabStop = false;
            this.grpSize.Text = "Randomize Size";
            // 
            // chkUseRange
            // 
            this.chkUseRange.AutoSize = true;
            this.chkUseRange.Location = new System.Drawing.Point(417, 288);
            this.chkUseRange.Name = "chkUseRange";
            this.chkUseRange.Size = new System.Drawing.Size(140, 17);
            this.chkUseRange.TabIndex = 26;
            this.chkUseRange.Text = "Use Range for Numbers";
            this.tlp.SetToolTip(this.chkUseRange, resources.GetString("chkUseRange.ToolTip"));
            this.chkUseRange.UseVisualStyleBackColor = true;
            // 
            // tlp
            // 
            this.tlp.AutoPopDelay = 50000;
            this.tlp.InitialDelay = 500;
            this.tlp.IsBalloon = true;
            this.tlp.ReshowDelay = 50;
            // 
            // RandomizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 513);
            this.Controls.Add(this.chkUseRange);
            this.Controls.Add(this.grpSize);
            this.Controls.Add(this.lblHard);
            this.Controls.Add(this.lblEasy);
            this.Controls.Add(this.trkAdjustDifficulty);
            this.Controls.Add(this.chkConsistency);
            this.Controls.Add(this.btnRandomize);
            this.Controls.Add(this.btnDeselectAll2);
            this.Controls.Add(this.clbObjects);
            this.Controls.Add(this.lblObjects);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.lblLevels);
            this.Controls.Add(this.clbLevels);
            this.Controls.Add(this.grpRandomizeRotation);
            this.Controls.Add(this.trkDemanding);
            this.Controls.Add(this.lblMoreRandom2);
            this.Controls.Add(this.lblLessDemanding);
            this.Controls.Add(this.lblMoreRandom);
            this.Controls.Add(this.trkBeatable);
            this.Controls.Add(this.lblMoreBeatable);
            this.Name = "RandomizerForm";
            this.Text = "Randomizer";
            this.Load += new System.EventHandler(this.RandomizerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkAdjustDifficulty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBeatable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkDemanding)).EndInit();
            this.grpRandomizeRotation.ResumeLayout(false);
            this.grpRandomizeRotation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).EndInit();
            this.grpSize.ResumeLayout(false);
            this.grpSize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trkAdjustDifficulty;
        private System.Windows.Forms.Label lblMoreBeatable;
        private System.Windows.Forms.Label lblEasy;
        private System.Windows.Forms.Label lblHard;
        private System.Windows.Forms.TrackBar trkBeatable;
        private System.Windows.Forms.Label lblMoreRandom;
        private System.Windows.Forms.Label lblLessDemanding;
        private System.Windows.Forms.Label lblMoreRandom2;
        private System.Windows.Forms.TrackBar trkDemanding;
        private System.Windows.Forms.Label lblMinSize;
        private System.Windows.Forms.Label lblMaxSize;
        private System.Windows.Forms.CheckBox chkX;
        private System.Windows.Forms.GroupBox grpRandomizeRotation;
        private System.Windows.Forms.CheckBox chkZ;
        private System.Windows.Forms.CheckBox chkY;
        private System.Windows.Forms.CheckedListBox clbLevels;
        private System.Windows.Forms.Label lblLevels;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Label lblObjects;
        private System.Windows.Forms.CheckedListBox clbObjects;
        private System.Windows.Forms.Button btnDeselectAll2;
        private System.Windows.Forms.Button btnRandomize;
        private System.Windows.Forms.CheckBox chkConsistency;
        private System.Windows.Forms.Label lblMinX;
        private System.Windows.Forms.Label lblMaxX;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.NumericUpDown nudMax;
        private System.Windows.Forms.CheckBox chkScaleRatio;
        private System.Windows.Forms.GroupBox grpSize;
        private System.Windows.Forms.CheckBox chkUseRange;
        private System.Windows.Forms.ToolTip tlp;
    }
}