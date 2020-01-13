namespace AddSharedParameters
{
    partial class SharedParameterForm
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
            this.ParameterList = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.GroupSelectComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ParameterList
            // 
            this.ParameterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParameterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterList.FormattingEnabled = true;
            this.ParameterList.ItemHeight = 20;
            this.ParameterList.Location = new System.Drawing.Point(12, 75);
            this.ParameterList.Name = "ParameterList";
            this.ParameterList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ParameterList.Size = new System.Drawing.Size(298, 364);
            this.ParameterList.TabIndex = 2;
            this.ParameterList.SelectedIndexChanged += new System.EventHandler(this.ParameterList_SelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(202, 448);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(108, 30);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add Parameter";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // GroupSelectComboBox
            // 
            this.GroupSelectComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupSelectComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupSelectComboBox.FormattingEnabled = true;
            this.GroupSelectComboBox.Location = new System.Drawing.Point(161, 29);
            this.GroupSelectComboBox.Name = "GroupSelectComboBox";
            this.GroupSelectComboBox.Size = new System.Drawing.Size(149, 28);
            this.GroupSelectComboBox.TabIndex = 5;
            this.GroupSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupSelectComboBox_SelectedIndexChanged);
            // 
            // SharedParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 490);
            this.Controls.Add(this.GroupSelectComboBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ParameterList);
            this.Name = "SharedParameterForm";
            this.Text = "SharedParameterForm";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox ParameterList;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox GroupSelectComboBox;
    }
}