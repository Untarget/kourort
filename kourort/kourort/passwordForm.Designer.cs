namespace kourort
{
    partial class passwordForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 25);
            this.label6.TabIndex = 29;
            this.label6.Text = "Введите новый пароль:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(29, 81);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(239, 33);
            this.passwordTextBox.TabIndex = 28;
            this.passwordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F);
            this.button1.Location = new System.Drawing.Point(29, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 32);
            this.button1.TabIndex = 30;
            this.button1.Text = "Обновить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // passwordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 198);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.passwordTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "passwordForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Восстановление пароля";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.passwordForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button button1;
    }
}