namespace AppConexionSGBDR
{
    partial class TreeViewMySQL
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
            this.tvData = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvData
            // 
            this.tvData.Location = new System.Drawing.Point(12, 12);
            this.tvData.Name = "tvData";
            this.tvData.Size = new System.Drawing.Size(191, 449);
            this.tvData.TabIndex = 0;
            this.tvData.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvData_AfterSelect);
            this.tvData.DoubleClick += new System.EventHandler(this.tvData_DoubleClick);
            // 
            // TreeViewMySQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 473);
            this.Controls.Add(this.tvData);
            this.Name = "TreeViewMySQL";
            this.Text = "TreeViewMySQL";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvData;
    }
}