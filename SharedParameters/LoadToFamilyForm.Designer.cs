namespace RevitHandyTools.SharedParameters
{
    partial class LoadToFamilyForm
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
            this.ParameterBinding = new System.Windows.Forms.GroupBox();
            this.InstanceCheck = new System.Windows.Forms.CheckBox();
            this.TypeCheck = new System.Windows.Forms.CheckBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.GroupParameterUnder = new System.Windows.Forms.GroupBox();
            this.GroupParameterUnderComboBox = new System.Windows.Forms.ComboBox();
            this.SharedParameterList = new System.Windows.Forms.GroupBox();
            this.ParameterList = new System.Windows.Forms.ListBox();
            this.SharedParameterGroup = new System.Windows.Forms.GroupBox();
            this.GroupSelectComboBox = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.ParameterBinding.SuspendLayout();
            this.GroupParameterUnder.SuspendLayout();
            this.SharedParameterList.SuspendLayout();
            this.SharedParameterGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParameterBinding
            // 
            this.ParameterBinding.Controls.Add(this.InstanceCheck);
            this.ParameterBinding.Controls.Add(this.TypeCheck);
            this.ParameterBinding.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterBinding.Location = new System.Drawing.Point(340, 101);
            this.ParameterBinding.Name = "ParameterBinding";
            this.ParameterBinding.Size = new System.Drawing.Size(307, 98);
            this.ParameterBinding.TabIndex = 27;
            this.ParameterBinding.TabStop = false;
            this.ParameterBinding.Text = "Parameter Binding";
            // 
            // InstanceCheck
            // 
            this.InstanceCheck.AutoSize = true;
            this.InstanceCheck.Location = new System.Drawing.Point(20, 61);
            this.InstanceCheck.Name = "InstanceCheck";
            this.InstanceCheck.Size = new System.Drawing.Size(84, 22);
            this.InstanceCheck.TabIndex = 1;
            this.InstanceCheck.Text = "Instance";
            this.InstanceCheck.UseVisualStyleBackColor = true;
            this.InstanceCheck.CheckedChanged += new System.EventHandler(this.InstanceCheck_CheckedChanged);
            // 
            // TypeCheck
            // 
            this.TypeCheck.AutoSize = true;
            this.TypeCheck.Location = new System.Drawing.Point(20, 32);
            this.TypeCheck.Name = "TypeCheck";
            this.TypeCheck.Size = new System.Drawing.Size(60, 22);
            this.TypeCheck.TabIndex = 0;
            this.TypeCheck.Text = "Type";
            this.TypeCheck.UseVisualStyleBackColor = true;
            this.TypeCheck.CheckedChanged += new System.EventHandler(this.TypeCheck_CheckedChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(489, 534);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(142, 29);
            this.CancelButton.TabIndex = 26;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // GroupParameterUnder
            // 
            this.GroupParameterUnder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupParameterUnder.Controls.Add(this.GroupParameterUnderComboBox);
            this.GroupParameterUnder.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupParameterUnder.Location = new System.Drawing.Point(340, 16);
            this.GroupParameterUnder.Name = "GroupParameterUnder";
            this.GroupParameterUnder.Size = new System.Drawing.Size(307, 70);
            this.GroupParameterUnder.TabIndex = 25;
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
            // SharedParameterList
            // 
            this.SharedParameterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SharedParameterList.Controls.Add(this.ParameterList);
            this.SharedParameterList.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SharedParameterList.Location = new System.Drawing.Point(12, 101);
            this.SharedParameterList.Name = "SharedParameterList";
            this.SharedParameterList.Size = new System.Drawing.Size(311, 418);
            this.SharedParameterList.TabIndex = 24;
            this.SharedParameterList.TabStop = false;
            this.SharedParameterList.Text = "Shared Parameter List";
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
            this.ParameterList.Sorted = true;
            this.ParameterList.TabIndex = 2;
            // 
            // SharedParameterGroup
            // 
            this.SharedParameterGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SharedParameterGroup.Controls.Add(this.GroupSelectComboBox);
            this.SharedParameterGroup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SharedParameterGroup.Location = new System.Drawing.Point(12, 16);
            this.SharedParameterGroup.Name = "SharedParameterGroup";
            this.SharedParameterGroup.Size = new System.Drawing.Size(311, 71);
            this.SharedParameterGroup.TabIndex = 23;
            this.SharedParameterGroup.TabStop = false;
            this.SharedParameterGroup.Text = "Select Shared Parameter Group";
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
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(303, 534);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(171, 30);
            this.AddButton.TabIndex = 22;
            this.AddButton.Text = "Add Parameter";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // LoadToFamilyForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(659, 581);
            this.Controls.Add(this.ParameterBinding);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.GroupParameterUnder);
            this.Controls.Add(this.SharedParameterList);
            this.Controls.Add(this.SharedParameterGroup);
            this.Controls.Add(this.AddButton);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoadToFamilyForm";
            this.Text = "Load To Family";
            this.ParameterBinding.ResumeLayout(false);
            this.ParameterBinding.PerformLayout();
            this.GroupParameterUnder.ResumeLayout(false);
            this.SharedParameterList.ResumeLayout(false);
            this.SharedParameterGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ParameterBinding;
        private System.Windows.Forms.CheckBox InstanceCheck;
        private System.Windows.Forms.CheckBox TypeCheck;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox GroupParameterUnder;
        private System.Windows.Forms.ComboBox GroupParameterUnderComboBox;
        private System.Windows.Forms.GroupBox SharedParameterList;
        private System.Windows.Forms.ListBox ParameterList;
        private System.Windows.Forms.GroupBox SharedParameterGroup;
        private System.Windows.Forms.ComboBox GroupSelectComboBox;
        private System.Windows.Forms.Button AddButton;
    }
}