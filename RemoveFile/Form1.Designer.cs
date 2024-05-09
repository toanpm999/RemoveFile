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
            this.btnDeleteFileInList = new System.Windows.Forms.Button();
            this.lbstatus = new System.Windows.Forms.Label();
            this.btnExtractLink = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKeywordFinder = new System.Windows.Forms.TextBox();
            this.btnFilterLink = new System.Windows.Forms.Button();
            this.btnDeleteFileWithOutList = new System.Windows.Forms.Button();
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
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "List Link Đầu Vào";
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
            // btnDeleteFileInList
            // 
            this.btnDeleteFileInList.Location = new System.Drawing.Point(25, 130);
            this.btnDeleteFileInList.Name = "btnDeleteFileInList";
            this.btnDeleteFileInList.Size = new System.Drawing.Size(227, 23);
            this.btnDeleteFileInList.TabIndex = 5;
            this.btnDeleteFileInList.Text = "Xóa File Theo List";
            this.btnDeleteFileInList.UseVisualStyleBackColor = true;
            this.btnDeleteFileInList.Click += new System.EventHandler(this.btnDeleteFile_Click);
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
            // btnExtractLink
            // 
            this.btnExtractLink.Location = new System.Drawing.Point(25, 205);
            this.btnExtractLink.Name = "btnExtractLink";
            this.btnExtractLink.Size = new System.Drawing.Size(525, 23);
            this.btnExtractLink.TabIndex = 7;
            this.btnExtractLink.Text = "Lọc Link ";
            this.btnExtractLink.UseVisualStyleBackColor = true;
            this.btnExtractLink.Click += new System.EventHandler(this.btnExtractLink_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "KeyWord Tìm kiếm";
            // 
            // txtKeywordFinder
            // 
            this.txtKeywordFinder.Location = new System.Drawing.Point(154, 170);
            this.txtKeywordFinder.Name = "txtKeywordFinder";
            this.txtKeywordFinder.Size = new System.Drawing.Size(296, 20);
            this.txtKeywordFinder.TabIndex = 8;
            // 
            // btnFilterLink
            // 
            this.btnFilterLink.Location = new System.Drawing.Point(25, 251);
            this.btnFilterLink.Name = "btnFilterLink";
            this.btnFilterLink.Size = new System.Drawing.Size(525, 23);
            this.btnFilterLink.TabIndex = 10;
            this.btnFilterLink.Text = "Lọc Link Trùng Lặp";
            this.btnFilterLink.UseVisualStyleBackColor = true;
            this.btnFilterLink.Click += new System.EventHandler(this.btnFilterLink_Click);
            // 
            // btnDeleteFileWithOutList
            // 
            this.btnDeleteFileWithOutList.Location = new System.Drawing.Point(310, 130);
            this.btnDeleteFileWithOutList.Name = "btnDeleteFileWithOutList";
            this.btnDeleteFileWithOutList.Size = new System.Drawing.Size(227, 23);
            this.btnDeleteFileWithOutList.TabIndex = 11;
            this.btnDeleteFileWithOutList.Text = "Xóa File Khác List";
            this.btnDeleteFileWithOutList.UseVisualStyleBackColor = true;
            this.btnDeleteFileWithOutList.Click += new System.EventHandler(this.btnDeleteFileWithOutList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 310);
            this.Controls.Add(this.btnDeleteFileWithOutList);
            this.Controls.Add(this.btnFilterLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKeywordFinder);
            this.Controls.Add(this.btnExtractLink);
            this.Controls.Add(this.lbstatus);
            this.Controls.Add(this.btnDeleteFileInList);
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
        private System.Windows.Forms.Button btnDeleteFileInList;
        private System.Windows.Forms.Label lbstatus;
        private System.Windows.Forms.Button btnExtractLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKeywordFinder;
        private System.Windows.Forms.Button btnFilterLink;
        private System.Windows.Forms.Button btnDeleteFileWithOutList;
    }
}

