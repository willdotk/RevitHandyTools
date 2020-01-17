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
            this.CategoryCheckList = new System.Windows.Forms.CheckedListBox();
            this.SharedParameterGroup = new System.Windows.Forms.GroupBox();
            this.SharedParameterList = new System.Windows.Forms.GroupBox();
            this.CategoryList = new System.Windows.Forms.GroupBox();
            this.GroupParameterUnder = new System.Windows.Forms.GroupBox();
            this.GroupParameterUnderComboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SharedParameterGroup.SuspendLayout();
            this.SharedParameterList.SuspendLayout();
            this.CategoryList.SuspendLayout();
            this.GroupParameterUnder.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParameterList
            // 
            this.ParameterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParameterList.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterList.FormattingEnabled = true;
            this.ParameterList.HorizontalScrollbar = true;
            this.ParameterList.ItemHeight = 18;
            this.ParameterList.Location = new System.Drawing.Point(16, 32);
            this.ParameterList.Margin = new System.Windows.Forms.Padding(5);
            this.ParameterList.Name = "ParameterList";
            this.ParameterList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ParameterList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ParameterList.Size = new System.Drawing.Size(280, 364);
            this.ParameterList.TabIndex = 2;
            this.ParameterList.SelectedIndexChanged += new System.EventHandler(this.ParameterList_SelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(302, 539);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(171, 30);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add Parameter";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // GroupSelectComboBox
            // 
            this.GroupSelectComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupSelectComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupSelectComboBox.FormattingEnabled = true;
            this.GroupSelectComboBox.Location = new System.Drawing.Point(16, 31);
            this.GroupSelectComboBox.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.GroupSelectComboBox.Name = "GroupSelectComboBox";
            this.GroupSelectComboBox.Size = new System.Drawing.Size(276, 26);
            this.GroupSelectComboBox.TabIndex = 5;
            this.GroupSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupSelectComboBox_SelectedIndexChanged);
            // 
            // CategoryCheckList
            // 
            this.CategoryCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryCheckList.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryCheckList.FormattingEnabled = true;
            this.CategoryCheckList.HorizontalScrollbar = true;
            this.CategoryCheckList.Location = new System.Drawing.Point(20, 32);
            this.CategoryCheckList.Margin = new System.Windows.Forms.Padding(5);
            this.CategoryCheckList.Name = "CategoryCheckList";
            this.CategoryCheckList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CategoryCheckList.Size = new System.Drawing.Size(272, 361);
            this.CategoryCheckList.TabIndex = 7;
            // 
            // SharedParameterGroup
            // 
            this.SharedParameterGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SharedParameterGroup.Controls.Add(this.GroupSelectComboBox);
            this.SharedParameterGroup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SharedParameterGroup.Location = new System.Drawing.Point(11, 21);
            this.SharedParameterGroup.Name = "SharedParameterGroup";
            this.SharedParameterGroup.Size = new System.Drawing.Size(311, 71);
            this.SharedParameterGroup.TabIndex = 9;
            this.SharedParameterGroup.TabStop = false;
            this.SharedParameterGroup.Text = "Select Shared Parameter Group";
            // 
            // SharedParameterList
            // 
            this.SharedParameterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SharedParameterList.Controls.Add(this.ParameterList);
            this.SharedParameterList.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SharedParameterList.Location = new System.Drawing.Point(11, 106);
            this.SharedParameterList.Name = "SharedParameterList";
            this.SharedParameterList.Size = new System.Drawing.Size(311, 418);
            this.SharedParameterList.TabIndex = 10;
            this.SharedParameterList.TabStop = false;
            this.SharedParameterList.Text = "Shared Parameter List";
            // 
            // CategoryList
            // 
            this.CategoryList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryList.Controls.Add(this.CategoryCheckList);
            this.CategoryList.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryList.Location = new System.Drawing.Point(339, 106);
            this.CategoryList.Name = "CategoryList";
            this.CategoryList.Size = new System.Drawing.Size(307, 417);
            this.CategoryList.TabIndex = 11;
            this.CategoryList.TabStop = false;
            this.CategoryList.Text = "Category List";
            // 
            // GroupParameterUnder
            // 
            this.GroupParameterUnder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupParameterUnder.Controls.Add(this.GroupParameterUnderComboBox);
            this.GroupParameterUnder.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupParameterUnder.Location = new System.Drawing.Point(339, 21);
            this.GroupParameterUnder.Name = "GroupParameterUnder";
            this.GroupParameterUnder.Size = new System.Drawing.Size(307, 70);
            this.GroupParameterUnder.TabIndex = 12;
            this.GroupParameterUnder.TabStop = false;
            this.GroupParameterUnder.Text = "Group Parameter Under";
            // 
            // GroupParameterUnderComboBox
            // 
            this.GroupParameterUnderComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupParameterUnderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupParameterUnderComboBox.FormattingEnabled = true;
            this.GroupParameterUnderComboBox.Location = new System.Drawing.Point(20, 31);
            this.GroupParameterUnderComboBox.Name = "GroupParameterUnderComboBox";
            this.GroupParameterUnderComboBox.Size = new System.Drawing.Size(271, 26);
            this.GroupParameterUnderComboBox.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(488, 539);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(142, 29);
            this.CancelButton.TabIndex = 13;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SharedParameterForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(659, 581);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.GroupParameterUnder);
            this.Controls.Add(this.CategoryList);
            this.Controls.Add(this.SharedParameterList);
            this.Controls.Add(this.SharedParameterGroup);
            this.Controls.Add(this.AddButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "SharedParameterForm";
            this.Text = "SharedParameterForm";
            this.TopMost = true;
            this.SharedParameterGroup.ResumeLayout(false);
            this.SharedParameterList.ResumeLayout(false);
            this.CategoryList.ResumeLayout(false);
            this.GroupParameterUnder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox ParameterList;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox GroupSelectComboBox;
        private System.Windows.Forms.CheckedListBox CategoryCheckList;
        private System.Windows.Forms.GroupBox SharedParameterGroup;
        private System.Windows.Forms.GroupBox SharedParameterList;
        private System.Windows.Forms.GroupBox CategoryList;
        private System.Windows.Forms.GroupBox GroupParameterUnder;
        private System.Windows.Forms.ComboBox GroupParameterUnderComboBox;
        private System.Windows.Forms.Button CancelButton;
    }
}