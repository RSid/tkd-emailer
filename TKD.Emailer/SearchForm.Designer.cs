namespace TKD.Emailer
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.searchButton = new System.Windows.Forms.Button();
            this.resultsPanel = new System.Windows.Forms.Panel();
            this.GenderPanel = new System.Windows.Forms.Panel();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.AgePanel = new System.Windows.Forms.Panel();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.ageMaxInput = new System.Windows.Forms.NumericUpDown();
            this.ageMinInput = new System.Windows.Forms.NumericUpDown();
            this.ageRangeButton = new System.Windows.Forms.RadioButton();
            this.Adults = new System.Windows.Forms.RadioButton();
            this.Children = new System.Windows.Forms.RadioButton();
            this.allAgesButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.RankPanel = new System.Windows.Forms.Panel();
            this.beltRangeButton = new System.Windows.Forms.RadioButton();
            this.BlackBeltsRadioButton = new System.Windows.Forms.RadioButton();
            this.ColorBeltsRadioButton = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.dbServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SendEmailToSelectedPanel = new System.Windows.Forms.Panel();
            this.CategoryPanel = new System.Windows.Forms.Panel();
            this.MembershipPanel = new System.Windows.Forms.Panel();
            this.allClubsButton = new System.Windows.Forms.RadioButton();
            this.foundersClubButton = new System.Windows.Forms.RadioButton();
            this.blackBeltClubButton = new System.Windows.Forms.RadioButton();
            this.clubLabel = new System.Windows.Forms.Label();
            this.GenderPanel.SuspendLayout();
            this.AgePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ageMaxInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageMinInput)).BeginInit();
            this.RankPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbServiceBindingSource)).BeginInit();
            this.CategoryPanel.SuspendLayout();
            this.MembershipPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.Location = new System.Drawing.Point(452, 115);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 20);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // resultsPanel
            // 
            this.resultsPanel.Location = new System.Drawing.Point(2, 218);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(550, 293);
            this.resultsPanel.TabIndex = 4;
            // 
            // GenderPanel
            // 
            this.GenderPanel.Controls.Add(this.MaleRadioButton);
            this.GenderPanel.Controls.Add(this.FemaleRadioButton);
            this.GenderPanel.Controls.Add(this.radioButton1);
            this.GenderPanel.Controls.Add(this.label2);
            this.GenderPanel.Location = new System.Drawing.Point(452, 10);
            this.GenderPanel.Name = "GenderPanel";
            this.GenderPanel.Size = new System.Drawing.Size(100, 99);
            this.GenderPanel.TabIndex = 5;
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Location = new System.Drawing.Point(13, 71);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(48, 17);
            this.MaleRadioButton.TabIndex = 3;
            this.MaleRadioButton.Text = "Male";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Location = new System.Drawing.Point(13, 47);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(59, 17);
            this.FemaleRadioButton.TabIndex = 2;
            this.FemaleRadioButton.Text = "Female";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Gender";
            // 
            // AgePanel
            // 
            this.AgePanel.Controls.Add(this.toLabel);
            this.AgePanel.Controls.Add(this.fromLabel);
            this.AgePanel.Controls.Add(this.ageMaxInput);
            this.AgePanel.Controls.Add(this.ageMinInput);
            this.AgePanel.Controls.Add(this.ageRangeButton);
            this.AgePanel.Controls.Add(this.Adults);
            this.AgePanel.Controls.Add(this.Children);
            this.AgePanel.Controls.Add(this.allAgesButton);
            this.AgePanel.Controls.Add(this.label3);
            this.AgePanel.Location = new System.Drawing.Point(146, 10);
            this.AgePanel.Name = "AgePanel";
            this.AgePanel.Size = new System.Drawing.Size(137, 202);
            this.AgePanel.TabIndex = 6;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(21, 157);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(20, 13);
            this.toLabel.TabIndex = 8;
            this.toLabel.Text = "To";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(21, 118);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(30, 13);
            this.fromLabel.TabIndex = 7;
            this.fromLabel.Text = "From";
            // 
            // ageMaxInput
            // 
            this.ageMaxInput.Location = new System.Drawing.Point(23, 173);
            this.ageMaxInput.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ageMaxInput.Name = "ageMaxInput";
            this.ageMaxInput.Size = new System.Drawing.Size(60, 20);
            this.ageMaxInput.TabIndex = 6;
            this.ageMaxInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // ageMinInput
            // 
            this.ageMinInput.Location = new System.Drawing.Point(23, 134);
            this.ageMinInput.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ageMinInput.Name = "ageMinInput";
            this.ageMinInput.Size = new System.Drawing.Size(60, 20);
            this.ageMinInput.TabIndex = 5;
            this.ageMinInput.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ageRangeButton
            // 
            this.ageRangeButton.AutoSize = true;
            this.ageRangeButton.Location = new System.Drawing.Point(4, 98);
            this.ageRangeButton.Name = "ageRangeButton";
            this.ageRangeButton.Size = new System.Drawing.Size(129, 17);
            this.ageRangeButton.TabIndex = 4;
            this.ageRangeButton.TabStop = true;
            this.ageRangeButton.Text = "Age Range (inclusive)";
            this.ageRangeButton.UseVisualStyleBackColor = true;
            // 
            // Adults
            // 
            this.Adults.AutoSize = true;
            this.Adults.Location = new System.Drawing.Point(4, 74);
            this.Adults.Name = "Adults";
            this.Adults.Size = new System.Drawing.Size(54, 17);
            this.Adults.TabIndex = 3;
            this.Adults.Text = "Adults";
            this.Adults.UseVisualStyleBackColor = true;
            // 
            // Children
            // 
            this.Children.AutoSize = true;
            this.Children.Location = new System.Drawing.Point(4, 50);
            this.Children.Name = "Children";
            this.Children.Size = new System.Drawing.Size(63, 17);
            this.Children.TabIndex = 2;
            this.Children.Text = "Children";
            this.Children.UseVisualStyleBackColor = true;
            // 
            // allAgesButton
            // 
            this.allAgesButton.AutoSize = true;
            this.allAgesButton.Checked = true;
            this.allAgesButton.Location = new System.Drawing.Point(4, 26);
            this.allAgesButton.Name = "allAgesButton";
            this.allAgesButton.Size = new System.Drawing.Size(36, 17);
            this.allAgesButton.TabIndex = 1;
            this.allAgesButton.TabStop = true;
            this.allAgesButton.Text = "All";
            this.allAgesButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Age Range";
            // 
            // RankPanel
            // 
            this.RankPanel.Controls.Add(this.beltRangeButton);
            this.RankPanel.Controls.Add(this.BlackBeltsRadioButton);
            this.RankPanel.Controls.Add(this.ColorBeltsRadioButton);
            this.RankPanel.Controls.Add(this.radioButton4);
            this.RankPanel.Controls.Add(this.label4);
            this.RankPanel.Location = new System.Drawing.Point(285, 10);
            this.RankPanel.Name = "RankPanel";
            this.RankPanel.Size = new System.Drawing.Size(161, 202);
            this.RankPanel.TabIndex = 7;
            // 
            // beltRangeButton
            // 
            this.beltRangeButton.AutoSize = true;
            this.beltRangeButton.Location = new System.Drawing.Point(6, 98);
            this.beltRangeButton.Name = "beltRangeButton";
            this.beltRangeButton.Size = new System.Drawing.Size(78, 17);
            this.beltRangeButton.TabIndex = 4;
            this.beltRangeButton.TabStop = true;
            this.beltRangeButton.Text = "Belt Range";
            this.beltRangeButton.UseVisualStyleBackColor = true;
            // 
            // BlackBeltsRadioButton
            // 
            this.BlackBeltsRadioButton.AutoSize = true;
            this.BlackBeltsRadioButton.Location = new System.Drawing.Point(4, 74);
            this.BlackBeltsRadioButton.Name = "BlackBeltsRadioButton";
            this.BlackBeltsRadioButton.Size = new System.Drawing.Size(78, 17);
            this.BlackBeltsRadioButton.TabIndex = 3;
            this.BlackBeltsRadioButton.Text = "Black Belts";
            this.BlackBeltsRadioButton.UseVisualStyleBackColor = true;
            // 
            // ColorBeltsRadioButton
            // 
            this.ColorBeltsRadioButton.AutoSize = true;
            this.ColorBeltsRadioButton.Location = new System.Drawing.Point(4, 51);
            this.ColorBeltsRadioButton.Name = "ColorBeltsRadioButton";
            this.ColorBeltsRadioButton.Size = new System.Drawing.Size(75, 17);
            this.ColorBeltsRadioButton.TabIndex = 2;
            this.ColorBeltsRadioButton.Text = "Color Belts";
            this.ColorBeltsRadioButton.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(4, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(154, 30);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "All \r\n(includes no recorded rank)";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Rank (Belt)";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(3, 0);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(49, 13);
            this.categoryLabel.TabIndex = 3;
            this.categoryLabel.Text = "Category";
            // 
            // SendEmailToSelectedPanel
            // 
            this.SendEmailToSelectedPanel.Location = new System.Drawing.Point(402, 517);
            this.SendEmailToSelectedPanel.Name = "SendEmailToSelectedPanel";
            this.SendEmailToSelectedPanel.Size = new System.Drawing.Size(150, 37);
            this.SendEmailToSelectedPanel.TabIndex = 9;
            // 
            // CategoryPanel
            // 
            this.CategoryPanel.Controls.Add(this.categoryLabel);
            this.CategoryPanel.Location = new System.Drawing.Point(13, 9);
            this.CategoryPanel.Name = "CategoryPanel";
            this.CategoryPanel.Size = new System.Drawing.Size(127, 41);
            this.CategoryPanel.TabIndex = 10;
            // 
            // MembershipPanel
            // 
            this.MembershipPanel.Controls.Add(this.allClubsButton);
            this.MembershipPanel.Controls.Add(this.foundersClubButton);
            this.MembershipPanel.Controls.Add(this.blackBeltClubButton);
            this.MembershipPanel.Controls.Add(this.clubLabel);
            this.MembershipPanel.Location = new System.Drawing.Point(13, 56);
            this.MembershipPanel.Name = "MembershipPanel";
            this.MembershipPanel.Size = new System.Drawing.Size(128, 92);
            this.MembershipPanel.TabIndex = 11;
            // 
            // allClubsButton
            // 
            this.allClubsButton.AutoSize = true;
            this.allClubsButton.Checked = true;
            this.allClubsButton.Location = new System.Drawing.Point(7, 22);
            this.allClubsButton.Name = "allClubsButton";
            this.allClubsButton.Size = new System.Drawing.Size(36, 17);
            this.allClubsButton.TabIndex = 3;
            this.allClubsButton.TabStop = true;
            this.allClubsButton.Text = "All";
            this.allClubsButton.UseVisualStyleBackColor = true;
            // 
            // foundersClubButton
            // 
            this.foundersClubButton.AutoSize = true;
            this.foundersClubButton.Location = new System.Drawing.Point(7, 68);
            this.foundersClubButton.Name = "foundersClubButton";
            this.foundersClubButton.Size = new System.Drawing.Size(93, 17);
            this.foundersClubButton.TabIndex = 2;
            this.foundersClubButton.Text = "Founders Club";
            this.foundersClubButton.UseVisualStyleBackColor = true;
            // 
            // blackBeltClubButton
            // 
            this.blackBeltClubButton.AutoSize = true;
            this.blackBeltClubButton.Location = new System.Drawing.Point(7, 45);
            this.blackBeltClubButton.Name = "blackBeltClubButton";
            this.blackBeltClubButton.Size = new System.Drawing.Size(97, 17);
            this.blackBeltClubButton.TabIndex = 1;
            this.blackBeltClubButton.Text = "Black Belt Club";
            this.blackBeltClubButton.UseVisualStyleBackColor = true;
            // 
            // clubLabel
            // 
            this.clubLabel.AutoSize = true;
            this.clubLabel.Location = new System.Drawing.Point(3, 6);
            this.clubLabel.Name = "clubLabel";
            this.clubLabel.Size = new System.Drawing.Size(88, 13);
            this.clubLabel.TabIndex = 0;
            this.clubLabel.Text = "Club Membership";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 566);
            this.Controls.Add(this.MembershipPanel);
            this.Controls.Add(this.CategoryPanel);
            this.Controls.Add(this.SendEmailToSelectedPanel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.RankPanel);
            this.Controls.Add(this.GenderPanel);
            this.Controls.Add(this.AgePanel);
            this.Controls.Add(this.resultsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchForm";
            this.Text = "TKD Emailer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchForm_FormClosed);
            this.GenderPanel.ResumeLayout(false);
            this.GenderPanel.PerformLayout();
            this.AgePanel.ResumeLayout(false);
            this.AgePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ageMaxInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageMinInput)).EndInit();
            this.RankPanel.ResumeLayout(false);
            this.RankPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbServiceBindingSource)).EndInit();
            this.CategoryPanel.ResumeLayout(false);
            this.CategoryPanel.PerformLayout();
            this.MembershipPanel.ResumeLayout(false);
            this.MembershipPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dbServiceBindingSource;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Panel resultsPanel;
        private System.Windows.Forms.Panel GenderPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel AgePanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel RankPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton Adults;
        private System.Windows.Forms.RadioButton Children;
        private System.Windows.Forms.RadioButton allAgesButton;
        private System.Windows.Forms.RadioButton BlackBeltsRadioButton;
        private System.Windows.Forms.RadioButton ColorBeltsRadioButton;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Panel SendEmailToSelectedPanel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Panel CategoryPanel;
        private System.Windows.Forms.Panel MembershipPanel;
        private System.Windows.Forms.RadioButton foundersClubButton;
        private System.Windows.Forms.RadioButton blackBeltClubButton;
        private System.Windows.Forms.Label clubLabel;
        private System.Windows.Forms.RadioButton allClubsButton;
        private System.Windows.Forms.RadioButton ageRangeButton;
        private System.Windows.Forms.NumericUpDown ageMaxInput;
        private System.Windows.Forms.NumericUpDown ageMinInput;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.RadioButton beltRangeButton;
    }
}

