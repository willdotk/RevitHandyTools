namespace RevitHandyTools.CustomForms
{
    partial class WarningForm
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
            this.WarningLabel1 = new System.Windows.Forms.Label();
            this.WarningLabel2 = new System.Windows.Forms.Label();
            this.LoadYes = new System.Windows.Forms.Button();
            this.LoadCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // WarningLabel1
            // 
            this.WarningLabel1.AutoSize = true;
            this.WarningLabel1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLabel1.Location = new System.Drawing.Point(128, 34);
            this.WarningLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WarningLabel1.Name = "WarningLabel1";
            this.WarningLabel1.Size = new System.Drawing.Size(342, 20);
            this.WarningLabel1.TabIndex = 1;
            this.WarningLabel1.Text = "This will overwrite any parameters with the same names.";
            // 
            // WarningLabel2
            // 
            this.WarningLabel2.AutoSize = true;
            this.WarningLabel2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLabel2.Location = new System.Drawing.Point(128, 57);
            this.WarningLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WarningLabel2.Name = "WarningLabel2";
            this.WarningLabel2.Size = new System.Drawing.Size(194, 20);
            this.WarningLabel2.TabIndex = 2;
            this.WarningLabel2.Text = " Would you like to to preceed?";
            // 
            // LoadYes
            // 
            this.LoadYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.LoadYes.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadYes.Location = new System.Drawing.Point(251, 105);
            this.LoadYes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LoadYes.Name = "LoadYes";
            this.LoadYes.Size = new System.Drawing.Size(101, 29);
            this.LoadYes.TabIndex = 3;
            this.LoadYes.Text = "Yes";
            this.LoadYes.UseVisualStyleBackColor = true;
            this.LoadYes.Click += new System.EventHandler(this.LoadYes_Click);
            // 
            // LoadCancel
            // 
            this.LoadCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LoadCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadCancel.Location = new System.Drawing.Point(368, 105);
            this.LoadCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LoadCancel.Name = "LoadCancel";
            this.LoadCancel.Size = new System.Drawing.Size(101, 29);
            this.LoadCancel.TabIndex = 3;
            this.LoadCancel.Text = "Cancel";
            this.LoadCancel.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RevitHandyTools.Properties.Resources.warning_img_75x75;
            this.pictureBox1.Location = new System.Drawing.Point(30, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Warning
            // 
            this.AcceptButton = this.LoadYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.LoadCancel;
            this.ClientSize = new System.Drawing.Size(494, 146);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoadCancel);
            this.Controls.Add(this.LoadYes);
            this.Controls.Add(this.WarningLabel2);
            this.Controls.Add(this.WarningLabel1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Warning";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warning";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WarningLabel1;
        private System.Windows.Forms.Label WarningLabel2;
        private System.Windows.Forms.Button LoadYes;
        private System.Windows.Forms.Button LoadCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}