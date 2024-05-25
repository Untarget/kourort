namespace kourort
{
    partial class GeneralKourortUser
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
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.secondnameLabel = new System.Windows.Forms.Label();
            this.firstnameLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CreatePeoples = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.kourortLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnameLabel.Location = new System.Drawing.Point(12, 90);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(93, 25);
            this.lastnameLabel.TabIndex = 5;
            this.lastnameLabel.Text = "Отчетсво";
            // 
            // secondnameLabel
            // 
            this.secondnameLabel.AutoSize = true;
            this.secondnameLabel.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondnameLabel.Location = new System.Drawing.Point(12, 14);
            this.secondnameLabel.Name = "secondnameLabel";
            this.secondnameLabel.Size = new System.Drawing.Size(91, 25);
            this.secondnameLabel.TabIndex = 4;
            this.secondnameLabel.Text = "Фамилия";
            // 
            // firstnameLabel
            // 
            this.firstnameLabel.AutoSize = true;
            this.firstnameLabel.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnameLabel.Location = new System.Drawing.Point(14, 50);
            this.firstnameLabel.Name = "firstnameLabel";
            this.firstnameLabel.Size = new System.Drawing.Size(49, 25);
            this.firstnameLabel.TabIndex = 3;
            this.firstnameLabel.Text = "Имя";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(19, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 84);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ваш оздоровительный лагерь";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreatePeoples
            // 
            this.CreatePeoples.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatePeoples.Location = new System.Drawing.Point(258, 183);
            this.CreatePeoples.Name = "CreatePeoples";
            this.CreatePeoples.Size = new System.Drawing.Size(211, 84);
            this.CreatePeoples.TabIndex = 7;
            this.CreatePeoples.Text = "Создать места";
            this.CreatePeoples.UseVisualStyleBackColor = true;
            this.CreatePeoples.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(499, 183);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(208, 84);
            this.button3.TabIndex = 8;
            this.button3.Text = "Принять заявки";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(19, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(688, 84);
            this.button2.TabIndex = 9;
            this.button2.Text = "Просмотр принятых";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // kourortLabel
            // 
            this.kourortLabel.AutoSize = true;
            this.kourortLabel.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kourortLabel.Location = new System.Drawing.Point(14, 130);
            this.kourortLabel.Name = "kourortLabel";
            this.kourortLabel.Size = new System.Drawing.Size(73, 25);
            this.kourortLabel.TabIndex = 10;
            this.kourortLabel.Text = "Курорт";
            this.kourortLabel.Click += new System.EventHandler(this.kourortLabel_Click);
            // 
            // GeneralKourortUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 384);
            this.Controls.Add(this.kourortLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.CreatePeoples);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lastnameLabel);
            this.Controls.Add(this.secondnameLabel);
            this.Controls.Add(this.firstnameLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralKourortUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GeneralKourortUser_FormClosing);
            this.Load += new System.EventHandler(this.GeneralKourortUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lastnameLabel;
        private System.Windows.Forms.Label secondnameLabel;
        private System.Windows.Forms.Label firstnameLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CreatePeoples;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label kourortLabel;
    }
}