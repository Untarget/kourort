namespace kourort
{
    partial class GeneralUserForm
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
            this.registrationChildButton = new System.Windows.Forms.Button();
            this.secondnameLabel = new System.Windows.Forms.Label();
            this.firstnameLabel = new System.Windows.Forms.Label();
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registrationChildButton
            // 
            this.registrationChildButton.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationChildButton.Location = new System.Drawing.Point(14, 128);
            this.registrationChildButton.Name = "registrationChildButton";
            this.registrationChildButton.Size = new System.Drawing.Size(762, 113);
            this.registrationChildButton.TabIndex = 0;
            this.registrationChildButton.Text = "Подать заявление";
            this.registrationChildButton.UseVisualStyleBackColor = true;
            this.registrationChildButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // secondnameLabel
            // 
            this.secondnameLabel.AutoSize = true;
            this.secondnameLabel.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondnameLabel.Location = new System.Drawing.Point(10, 19);
            this.secondnameLabel.Name = "secondnameLabel";
            this.secondnameLabel.Size = new System.Drawing.Size(91, 25);
            this.secondnameLabel.TabIndex = 1;
            this.secondnameLabel.Text = "Фамилия";
            // 
            // firstnameLabel
            // 
            this.firstnameLabel.AutoSize = true;
            this.firstnameLabel.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnameLabel.Location = new System.Drawing.Point(10, 49);
            this.firstnameLabel.Name = "firstnameLabel";
            this.firstnameLabel.Size = new System.Drawing.Size(49, 25);
            this.firstnameLabel.TabIndex = 2;
            this.firstnameLabel.Text = "Имя";
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnameLabel.Location = new System.Drawing.Point(9, 82);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(93, 25);
            this.lastnameLabel.TabIndex = 3;
            this.lastnameLabel.Text = "Отчество";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(763, 113);
            this.button2.TabIndex = 4;
            this.button2.Text = "Просмотреть мои заявки";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GeneralUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 372);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lastnameLabel);
            this.Controls.Add(this.firstnameLabel);
            this.Controls.Add(this.secondnameLabel);
            this.Controls.Add(this.registrationChildButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralUserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GeneralUserForm_FormClosing);
            this.Load += new System.EventHandler(this.GeneralUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registrationChildButton;
        private System.Windows.Forms.Label secondnameLabel;
        private System.Windows.Forms.Label firstnameLabel;
        private System.Windows.Forms.Label lastnameLabel;
        private System.Windows.Forms.Button button2;
    }
}