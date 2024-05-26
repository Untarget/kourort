namespace kourort
{
    partial class SelectMindKourortForm
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
            this.ChooseKourotLabel = new System.Windows.Forms.Label();
            this.kourortListBox = new System.Windows.Forms.ListBox();
            this.CreateKourortLabel = new System.Windows.Forms.Label();
            this.CreateKourortTextBox = new System.Windows.Forms.TextBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.KourortCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ChooseKourotLabel
            // 
            this.ChooseKourotLabel.AutoSize = true;
            this.ChooseKourotLabel.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseKourotLabel.Location = new System.Drawing.Point(23, 23);
            this.ChooseKourotLabel.Name = "ChooseKourotLabel";
            this.ChooseKourotLabel.Size = new System.Drawing.Size(159, 25);
            this.ChooseKourotLabel.TabIndex = 0;
            this.ChooseKourotLabel.Text = "Выберете лагерь";
            // 
            // kourortListBox
            // 
            this.kourortListBox.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kourortListBox.FormattingEnabled = true;
            this.kourortListBox.ItemHeight = 25;
            this.kourortListBox.Location = new System.Drawing.Point(28, 60);
            this.kourortListBox.Name = "kourortListBox";
            this.kourortListBox.Size = new System.Drawing.Size(250, 79);
            this.kourortListBox.TabIndex = 1;
            // 
            // CreateKourortLabel
            // 
            this.CreateKourortLabel.AutoSize = true;
            this.CreateKourortLabel.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateKourortLabel.Location = new System.Drawing.Point(23, 165);
            this.CreateKourortLabel.Name = "CreateKourortLabel";
            this.CreateKourortLabel.Size = new System.Drawing.Size(478, 25);
            this.CreateKourortLabel.TabIndex = 2;
            this.CreateKourortLabel.Text = "Вашего лагеря нет? Создайте заявку на регистрацию!";
            // 
            // CreateKourortTextBox
            // 
            this.CreateKourortTextBox.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateKourortTextBox.Location = new System.Drawing.Point(28, 214);
            this.CreateKourortTextBox.Name = "CreateKourortTextBox";
            this.CreateKourortTextBox.Size = new System.Drawing.Size(503, 33);
            this.CreateKourortTextBox.TabIndex = 3;
            this.CreateKourortTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NextButton
            // 
            this.NextButton.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(28, 270);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(503, 71);
            this.NextButton.TabIndex = 4;
            this.NextButton.Text = "Выбрать";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // KourortCheckBox
            // 
            this.KourortCheckBox.AutoSize = true;
            this.KourortCheckBox.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KourortCheckBox.Location = new System.Drawing.Point(347, 60);
            this.KourortCheckBox.Name = "KourortCheckBox";
            this.KourortCheckBox.Size = new System.Drawing.Size(184, 29);
            this.KourortCheckBox.TabIndex = 5;
            this.KourortCheckBox.Text = "Моего лагеря нет";
            this.KourortCheckBox.UseVisualStyleBackColor = true;
            this.KourortCheckBox.CheckedChanged += new System.EventHandler(this.KourortCheckBox_CheckedChanged);
            // 
            // SelectMindKourortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 367);
            this.Controls.Add(this.KourortCheckBox);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.CreateKourortTextBox);
            this.Controls.Add(this.CreateKourortLabel);
            this.Controls.Add(this.kourortListBox);
            this.Controls.Add(this.ChooseKourotLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectMindKourortForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChooseKourotLabel;
        private System.Windows.Forms.ListBox kourortListBox;
        private System.Windows.Forms.Label CreateKourortLabel;
        private System.Windows.Forms.TextBox CreateKourortTextBox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.CheckBox KourortCheckBox;
    }
}