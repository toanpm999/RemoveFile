namespace RemoveFile
{
    partial class Form1
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
            this.txtInputList = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenList = new System.Windows.Forms.Button();
            this.txtFolderDelete = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.lbstatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInputList
            // 
            this.txtInputList.Location = new System.Drawing.Point(154, 23);
            this.txtInputList.Name = "txtInputList";
            this.txtInputList.Size = new System.Drawing.Size(296, 20);
            this.txtInputList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh Sách File Cần Xóa";
            // 
            // btnOpenList
            // 
            this.btnOpenList.Location = new System.Drawing.Point(476, 21);
            this.btnOpenList.Name = "btnOpenList";
            this.btnOpenList.Size = new System.Drawing.Size(75, 23);
            this.btnOpenList.TabIndex = 2;
            this.btnOpenList.Text = "Open";
            this.btnOpenList.UseVisualStyleBackColor = true;
            this.btnOpenList.Click += new System.EventHandler(this.btnOpenList_Click);
            // 
            // txtFolderDelete
            // 
            this.txtFolderDelete.Location = new System.Drawing.Point(154, 62);
            this.txtFolderDelete.Name = "txtFolderDelete";
            this.txtFolderDelete.Size = new System.Drawing.Size(296, 20);
            this.txtFolderDelete.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thư Mục File Cần Xóa";
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(26, 128);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(525, 23);
            this.btnDeleteFile.TabIndex = 5;
            this.btnDeleteFile.Text = "DeleteFile";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // lbstatus
            // 
            this.lbstatus.AutoSize = true;
            this.lbstatus.Location = new System.Drawing.Point(24, 101);
            this.lbstatus.Name = "lbstatus";
            this.lbstatus.Size = new System.Drawing.Size(16, 13);
            this.lbstatus.TabIndex = 6;
            this.lbstatus.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 171);
            this.Controls.Add(this.lbstatus);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFolderDelete);
            this.Controls.Add(this.btnOpenList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInputList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenList;
        private System.Windows.Forms.TextBox txtFolderDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Label lbstatus;
    }
}

