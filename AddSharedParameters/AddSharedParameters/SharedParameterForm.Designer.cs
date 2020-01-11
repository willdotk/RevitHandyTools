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
            this.GroupSelection = new System.Windows.Forms.ComboBox();
            this.ParameterList = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GroupSelection
            // 
            this.GroupSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupSelection.FormattingEnabled = true;
            this.GroupSelection.Location = new System.Drawing.Point(147, 37);
            this.GroupSelection.Name = "GroupSelection";
            this.GroupSelection.Size = new System.Drawing.Size(159, 28);
            this.GroupSelection.TabIndex = 1;
            this.GroupSelection.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.ParameterList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
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
            // SharedParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 490);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ParameterList);
            this.Controls.Add(this.GroupSelection);
            this.Name = "SharedParameterForm";
            this.Text = "SharedParameterForm";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox GroupSelection;
        private System.Windows.Forms.ListBox ParameterList;
        private System.Windows.Forms.Button AddButton;
    }
}