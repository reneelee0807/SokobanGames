namespace SokobanExampleSolution
{
    partial class GameForm
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
            this.Load_btn = new System.Windows.Forms.Button();
            this.GameDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.Start_btn = new System.Windows.Forms.Button();
            this.Undo_btn = new System.Windows.Forms.Button();
            this.Count_label = new System.Windows.Forms.Label();
            this.count_output = new System.Windows.Forms.TextBox();
            this.Rest_btn = new System.Windows.Forms.Button();
            this.historyLabel = new System.Windows.Forms.Label();
            this.MoveHistoryOutput = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.save_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Load_btn
            // 
            this.Load_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Load_btn.Location = new System.Drawing.Point(36, 543);
            this.Load_btn.Name = "Load_btn";
            this.Load_btn.Size = new System.Drawing.Size(75, 30);
            this.Load_btn.TabIndex = 0;
            this.Load_btn.Text = "Load";
            this.Load_btn.UseVisualStyleBackColor = false;
            this.Load_btn.Click += new System.EventHandler(this.Load_btn_Click);
            // 
            // GameDisplay
            // 
            this.GameDisplay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GameDisplay.ColumnCount = 10;
            this.GameDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GameDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GameDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GameDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GameDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GameDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GameDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GameDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GameDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GameDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GameDisplay.Location = new System.Drawing.Point(36, 50);
            this.GameDisplay.Name = "GameDisplay";
            this.GameDisplay.RowCount = 10;
            this.GameDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GameDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GameDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GameDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GameDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GameDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GameDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GameDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GameDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GameDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GameDisplay.Size = new System.Drawing.Size(399, 357);
            this.GameDisplay.TabIndex = 1;
            // 
            // Start_btn
            // 
            this.Start_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Start_btn.Location = new System.Drawing.Point(155, 543);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(75, 30);
            this.Start_btn.TabIndex = 2;
            this.Start_btn.Text = "Start";
            this.Start_btn.UseVisualStyleBackColor = false;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // Undo_btn
            // 
            this.Undo_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Undo_btn.Location = new System.Drawing.Point(376, 543);
            this.Undo_btn.Name = "Undo_btn";
            this.Undo_btn.Size = new System.Drawing.Size(78, 30);
            this.Undo_btn.TabIndex = 3;
            this.Undo_btn.Text = "Undo";
            this.Undo_btn.UseVisualStyleBackColor = false;
            this.Undo_btn.Click += new System.EventHandler(this.Undo_btn_Click);
            // 
            // Count_label
            // 
            this.Count_label.AutoSize = true;
            this.Count_label.Location = new System.Drawing.Point(33, 25);
            this.Count_label.Name = "Count_label";
            this.Count_label.Size = new System.Drawing.Size(68, 13);
            this.Count_label.TabIndex = 4;
            this.Count_label.Text = "Move Count:";
            // 
            // count_output
            // 
            this.count_output.Location = new System.Drawing.Point(119, 22);
            this.count_output.Name = "count_output";
            this.count_output.Size = new System.Drawing.Size(31, 20);
            this.count_output.TabIndex = 5;
            this.count_output.Text = "0";
            // 
            // Rest_btn
            // 
            this.Rest_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Rest_btn.Location = new System.Drawing.Point(264, 543);
            this.Rest_btn.Name = "Rest_btn";
            this.Rest_btn.Size = new System.Drawing.Size(76, 30);
            this.Rest_btn.TabIndex = 6;
            this.Rest_btn.TabStop = false;
            this.Rest_btn.Text = "Reset";
            this.Rest_btn.UseVisualStyleBackColor = false;
            this.Rest_btn.Click += new System.EventHandler(this.Rest_btn_Click);
            // 
            // historyLabel
            // 
            this.historyLabel.AutoSize = true;
            this.historyLabel.Location = new System.Drawing.Point(261, 25);
            this.historyLabel.Name = "historyLabel";
            this.historyLabel.Size = new System.Drawing.Size(69, 13);
            this.historyLabel.TabIndex = 7;
            this.historyLabel.Text = "Move History";
            // 
            // MoveHistoryOutput
            // 
            this.MoveHistoryOutput.Location = new System.Drawing.Point(359, 22);
            this.MoveHistoryOutput.Name = "MoveHistoryOutput";
            this.MoveHistoryOutput.Size = new System.Drawing.Size(106, 20);
            this.MoveHistoryOutput.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.save_btn.Enabled = false;
            this.save_btn.Location = new System.Drawing.Point(484, 543);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(78, 30);
            this.save_btn.TabIndex = 9;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 606);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.MoveHistoryOutput);
            this.Controls.Add(this.historyLabel);
            this.Controls.Add(this.Rest_btn);
            this.Controls.Add(this.count_output);
            this.Controls.Add(this.Count_label);
            this.Controls.Add(this.Undo_btn);
            this.Controls.Add(this.Start_btn);
            this.Controls.Add(this.GameDisplay);
            this.Controls.Add(this.Load_btn);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Load_btn;
        private System.Windows.Forms.TableLayoutPanel GameDisplay;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.Button Undo_btn;
        private System.Windows.Forms.Label Count_label;
        private System.Windows.Forms.TextBox count_output;
        private System.Windows.Forms.Button Rest_btn;
        private System.Windows.Forms.Label historyLabel;
        private System.Windows.Forms.TextBox MoveHistoryOutput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button save_btn;
    }
}