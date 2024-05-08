using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoveFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<string> _listFileDelete = new List<string>();
        public List<string> ReadFileLinesToList(string filePath)
        {
            List<string> lines = new List<string>();

            try
            {
                // Mở tệp văn bản để đọc
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    // Đọc từng dòng của tệp và thêm vào danh sách
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (Exception){}

            return lines;
        }
        public void DeleteFilesInDirectory(List<string> filesToDelete, string directoryPath)
        {
            try
            {
                // Kiểm tra xem thư mục tồn tại không
                if (!Directory.Exists(directoryPath))
                {
                    lbstatus.Text = "Thư mục không tồn tại.";
                    return;
                }

                // Xóa từng tệp tin trong danh sách
                foreach (string fileName in filesToDelete)
                {
                    string filePath = Path.Combine(directoryPath, fileName);

                    // Kiểm tra xem tệp tin tồn tại không
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        lbstatus.Text = "Đã xóa tệp !";
                    }
                    else
                    {
                        lbstatus.Text = $"Không tìm thấy tệp: {fileName}";
                    }
                }
            }
            catch (Exception ex)
            {
                lbstatus.Text = "Lỗi: " + ex.Message;
            }
        }

        private void btnOpenList_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn File chứa list file cần xóa !";
            openFileDialog.Filter = "TextFile (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInputList.Text = openFileDialog.FileName;
                _listFileDelete = ReadFileLinesToList(openFileDialog.FileName);
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolderDelete.Text))
            {
                MessageBox.Show(" Thư mục không tồn tại ");
            }
            else
            {
                DeleteFilesInDirectory(_listFileDelete, txtFolderDelete.Text);
            }
        }
    }
}
