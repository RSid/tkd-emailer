﻿namespace TKD.Emailer
{
    partial class ComposeEmailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComposeEmailForm));
            this.body = new System.Windows.Forms.RichTextBox();
            this.subject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveMessageAndPickRecipients = new System.Windows.Forms.Button();
            this.iconAttributionLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // body
            // 
            this.body.Location = new System.Drawing.Point(12, 65);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(800, 361);
            this.body.TabIndex = 0;
            this.body.Text = "";
            // 
            // subject
            // 
            this.subject.Location = new System.Drawing.Point(12, 26);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(801, 20);
            this.subject.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Body";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Subject";
            // 
            // saveMessageAndPickRecipients
            // 
            this.saveMessageAndPickRecipients.Location = new System.Drawing.Point(12, 432);
            this.saveMessageAndPickRecipients.Name = "saveMessageAndPickRecipients";
            this.saveMessageAndPickRecipients.Size = new System.Drawing.Size(218, 22);
            this.saveMessageAndPickRecipients.TabIndex = 4;
            this.saveMessageAndPickRecipients.Text = "Save Email and Select Recipients";
            this.saveMessageAndPickRecipients.UseVisualStyleBackColor = true;
            this.saveMessageAndPickRecipients.Click += new System.EventHandler(this.saveMessageAndPickRecipients_Click);
            // 
            // iconAttributionLink
            // 
            this.iconAttributionLink.ActiveLinkColor = System.Drawing.Color.BlueViolet;
            this.iconAttributionLink.AutoSize = true;
            this.iconAttributionLink.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconAttributionLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconAttributionLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.iconAttributionLink.LinkColor = System.Drawing.Color.Gray;
            this.iconAttributionLink.Location = new System.Drawing.Point(497, 441);
            this.iconAttributionLink.Name = "iconAttributionLink";
            this.iconAttributionLink.Size = new System.Drawing.Size(316, 13);
            this.iconAttributionLink.TabIndex = 5;
            this.iconAttributionLink.TabStop = true;
            this.iconAttributionLink.Text = "TKD.Emailer icon by Alfredo Hernandez, licensed under CC BY 3.0";
            this.iconAttributionLink.VisitedLinkColor = System.Drawing.Color.Gray;
            this.iconAttributionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iconAttributionLink_LinkClicked);
            // 
            // ComposeEmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 463);
            this.Controls.Add(this.iconAttributionLink);
            this.Controls.Add(this.saveMessageAndPickRecipients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.body);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComposeEmailForm";
            this.Text = "ComposeEmail";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ComposeEmailForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox body;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveMessageAndPickRecipients;
        private System.Windows.Forms.LinkLabel iconAttributionLink;
    }
}