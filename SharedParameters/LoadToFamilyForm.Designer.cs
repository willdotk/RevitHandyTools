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
            this.ParameterBinding.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterBinding.Location = new System.Drawing.Point(302, 112);
            this.ParameterBinding.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ParameterBinding.Name = "ParameterBinding";
            this.ParameterBinding.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ParameterBinding.Size = new System.Drawing.Size(273, 109);
            this.ParameterBinding.TabIndex = 27;
            this.ParameterBinding.TabStop = false;
            this.ParameterBinding.Text = "Parameter Binding";
            // 
            // InstanceCheck
            // 
            this.InstanceCheck.AutoSize = true;
            this.InstanceCheck.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstanceCheck.Location = new System.Drawing.Point(18, 68);
            this.InstanceCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InstanceCheck.Name = "InstanceCheck";
            this.InstanceCheck.Size = new System.Drawing.Size(77, 24);
            this.InstanceCheck.TabIndex = 1;
            this.InstanceCheck.Text = "Instance";
            this.InstanceCheck.UseVisualStyleBackColor = true;
            this.InstanceCheck.CheckedChanged += new System.EventHandler(this.InstanceCheck_CheckedChanged);
            // 
            // TypeCheck
            // 
            this.TypeCheck.AutoSize = true;
            this.TypeCheck.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeCheck.Location = new System.Drawing.Point(18, 35);
            this.TypeCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TypeCheck.Name = "TypeCheck";
            this.TypeCheck.Size = new System.Drawing.Size(58, 24);
            this.TypeCheck.TabIndex = 0;
            this.TypeCheck.Text = "Type";
            this.TypeCheck.UseVisualStyleBackColor = true;
            this.TypeCheck.CheckedChanged += new System.EventHandler(this.TypeCheck_CheckedChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(449, 592);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(126, 32);
            this.CancelButton.TabIndex = 26;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // GroupParameterUnder
            // 
            this.GroupParameterUnder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupParameterUnder.Controls.Add(this.GroupParameterUnderComboBox);
            this.GroupParameterUnder.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupParameterUnder.Location = new System.Drawing.Point(302, 18);
            this.GroupParameterUnder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupParameterUnder.Name = "GroupParameterUnder";
            this.GroupParameterUnder.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupParameterUnder.Size = new System.Drawing.Size(273, 78);
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
            this.GroupParameterUnderComboBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupParameterUnderComboBox.FormattingEnabled = true;
            this.GroupParameterUnderComboBox.Location = new System.Drawing.Point(18, 34);
            this.GroupParameterUnderComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupParameterUnderComboBox.Name = "GroupParameterUnderComboBox";
            this.GroupParameterUnderComboBox.Size = new System.Drawing.Size(241, 28);
            this.GroupParameterUnderComboBox.TabIndex = 0;
            // 
            // SharedParameterList
            // 
            this.SharedParameterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SharedParameterList.Controls.Add(this.ParameterList);
            this.SharedParameterList.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SharedParameterList.Location = new System.Drawing.Point(11, 112);
            this.SharedParameterList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SharedParameterList.Name = "SharedParameterList";
            this.SharedParameterList.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SharedParameterList.Size = new System.Drawing.Size(276, 465);
            this.SharedParameterList.TabIndex = 24;
            this.SharedParameterList.TabStop = false;
            this.SharedParameterList.Text = "Shared Parameter List";
            // 
            // ParameterList
            // 
            this.ParameterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParameterList.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterList.FormattingEnabled = true;
            this.ParameterList.HorizontalScrollbar = true;
            this.ParameterList.ItemHeight = 20;
            this.ParameterList.Location = new System.Drawing.Point(14, 35);
            this.ParameterList.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ParameterList.Name = "ParameterList";
            this.ParameterList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ParameterList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ParameterList.Size = new System.Drawing.Size(249, 404);
            this.ParameterList.Sorted = true;
            this.ParameterList.TabIndex = 2;
            // 
            // SharedParameterGroup
            // 
            this.SharedParameterGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SharedParameterGroup.Controls.Add(this.GroupSelectComboBox);
            this.SharedParameterGroup.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SharedParameterGroup.Location = new System.Drawing.Point(11, 18);
            this.SharedParameterGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SharedParameterGroup.Name = "SharedParameterGroup";
            this.SharedParameterGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SharedParameterGroup.Size = new System.Drawing.Size(276, 79);
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
            this.GroupSelectComboBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupSelectComboBox.FormattingEnabled = true;
            this.GroupSelectComboBox.Location = new System.Drawing.Point(14, 34);
            this.GroupSelectComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 3, 4);
            this.GroupSelectComboBox.Name = "GroupSelectComboBox";
            this.GroupSelectComboBox.Size = new System.Drawing.Size(246, 28);
            this.GroupSelectComboBox.TabIndex = 5;
            this.GroupSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupSelectComboBox_SelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(283, 592);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(152, 33);
            this.AddButton.TabIndex = 22;
            this.AddButton.Text = "Add Parameter";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // LoadToFamilyForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 646);
            this.Controls.Add(this.ParameterBinding);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.GroupParameterUnder);
            this.Controls.Add(this.SharedParameterList);
            this.Controls.Add(this.SharedParameterGroup);
            this.Controls.Add(this.AddButton);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoadToFamilyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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