using System.Diagnostics;

namespace ori_save_mover
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        const string DefaultLabelText = "Choose file to shift";

        /// <summary>
        ///  Clean up any resources being used.
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

        private OpenFileDialog openFileDialog1;

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.readOnlyPathTextBox = new System.Windows.Forms.TextBox();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.shiftDownwardsButton = new System.Windows.Forms.Button();
            this.shiftUpwardsButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.readOnlyPathTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chooseFileButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.shiftDownwardsButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.shiftUpwardsButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.infoLabel, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 111);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // readOnlyPathTextBox
            // 
            this.readOnlyPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readOnlyPathTextBox.HideSelection = false;
            this.readOnlyPathTextBox.Location = new System.Drawing.Point(11, 11);
            this.readOnlyPathTextBox.Name = "readOnlyPathTextBox";
            this.readOnlyPathTextBox.ReadOnly = true;
            this.readOnlyPathTextBox.Size = new System.Drawing.Size(262, 23);
            this.readOnlyPathTextBox.TabIndex = 0;
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chooseFileButton.Location = new System.Drawing.Point(11, 30);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(262, 13);
            this.chooseFileButton.TabIndex = 1;
            this.chooseFileButton.Text = "Choose File";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFile_Click);
            // 
            // shiftDownwardsButton
            // 
            this.shiftDownwardsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shiftDownwardsButton.Location = new System.Drawing.Point(11, 49);
            this.shiftDownwardsButton.Name = "shiftDownwardsButton";
            this.shiftDownwardsButton.Size = new System.Drawing.Size(262, 13);
            this.shiftDownwardsButton.TabIndex = 2;
            this.shiftDownwardsButton.Text = "Shift Downwards";
            this.shiftDownwardsButton.UseVisualStyleBackColor = true;
            this.shiftDownwardsButton.Click += new System.EventHandler(this.shiftDownwardsButton_Click);
            // 
            // shiftUpwardsButton
            // 
            this.shiftUpwardsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shiftUpwardsButton.Location = new System.Drawing.Point(11, 68);
            this.shiftUpwardsButton.Name = "shiftUpwardsButton";
            this.shiftUpwardsButton.Size = new System.Drawing.Size(262, 13);
            this.shiftUpwardsButton.TabIndex = 4;
            this.shiftUpwardsButton.Text = "Shift Upwards";
            this.shiftUpwardsButton.UseVisualStyleBackColor = true;
            this.shiftUpwardsButton.Click += new System.EventHandler(this.shiftUpwardsButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLabel.Location = new System.Drawing.Point(11, 84);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(262, 19);
            this.infoLabel.TabIndex = 3;
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.infoLabel.Click += new System.EventHandler(this.infoLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 100);
            this.Name = "Form1";
            this.Text = "Ori Save Shifter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox readOnlyPathTextBox;
        private Button chooseFileButton;
        private Button shiftDownwardsButton;
        private Label infoLabel;
        private Button shiftUpwardsButton;
    }
}