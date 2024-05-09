using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace RemoveFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<string> _listFileDelete = new List<string>();

        public List<string> FilterUniqueLinks(List<string> links)
        {
            // Tạo một HashSet để lưu trữ các đường link duy nhất
            HashSet<string> uniqueLinks = new HashSet<string>();

            // Lặp qua từng đường link trong danh sách và thêm vào HashSet
            foreach (var link in links)
            {
                uniqueLinks.Add(link);
            }

            // Chuyển đổi HashSet thành List và trả về
            return uniqueLinks.ToList();
        }
        public List<string> ExtractAndFilterUniqueLinks(string fileInput)
        {
            List<string> links = new List<string>();

            string text = File.ReadAllText(fileInput);

            // Biểu thức chính quy để tìm các đường link
            string pattern = @"https?://\S+";

            // Tìm các đường link trong văn bản sử dụng biểu thức chính quy
            MatchCollection matches = Regex.Matches(text, pattern);

            // Lấy các đường link từ các kết quả tìm được
            foreach (Match match in matches)
            {
                links.Add(match.Value);
            }

            // Lọc các đường link duy nhất bằng cách chuyển danh sách thành HashSet
            HashSet<string> uniqueLinks = new HashSet<string>(links);

            // Chuyển đổi HashSet thành List và trả về
            return uniqueLinks.ToList();
        }
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
        public void DeleteFilesWithOutListInDirectory(List<string> filesToDelete, string directoryPath)
        {
            try
            {
                // Kiểm tra xem thư mục tồn tại không
                if (!Directory.Exists(directoryPath))
                {
                    lbstatus.Text = "Thư mục không tồn tại.";
                    return;
                }

                // Lặp qua tất cả các tệp trong thư mục
                foreach (string filePath in Directory.GetFiles(directoryPath))
                {
                    // Lấy tên tệp từ đường dẫn
                    string fileName = Path.GetFileName(filePath);

                    // Nếu tên tệp không nằm trong danh sách cho phép, xóa tệp đó
                    if (!filesToDelete.Contains(fileName))
                    {
                        File.Delete(filePath);
                        lbstatus.Text = $"Đã xóa tệp !";
                    }
                }
                lbstatus.Text = "Hoàn thành.";
            }
            catch (Exception ex)
            {
                lbstatus.Text = "Lỗi: " + ex.Message;
            }
        }

        public List<string> GetLinksFromHtml(string filePath)
        {
            List<string> links = new List<string>();

            try
            {
                // Tạo một đối tượng HtmlDocument và tải nội dung từ tệp HTML
                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.Load(filePath);

                // Sử dụng XPath để chọn tất cả các phần tử "a" (liên kết) trong tài liệu HTML
                HtmlNodeCollection linkNodes = htmlDoc.DocumentNode.SelectNodes("//a[@href]");

                // Lặp qua các phần tử "a" và lấy giá trị của thuộc tính "href" (URL)
                if (linkNodes != null)
                {
                    foreach (HtmlNode linkNode in linkNodes)
                    {
                        string hrefValue = linkNode.GetAttributeValue("href", "");
                        if (!string.IsNullOrEmpty(hrefValue))
                        {
                            links.Add(hrefValue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbstatus.Text = "Lỗi: " + ex.Message;
            }

            return links;
        }

        public List<string> GetLinksContainingKeyword(string htmlFile, string keyword)
        {
            List<string> links = new List<string>();

            // Load HTML từ tệp
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.Load(htmlFile);

            // Tìm tất cả các thuộc tính trong HTML
            var linkNodes = htmlDoc.DocumentNode.Descendants()
                .SelectMany(node => node.Attributes)
                .Where(attr => attr.Value.StartsWith(keyword))
                .Select(attr => attr.Value);

            foreach (var link in linkNodes)
            {
                links.Add(link);
            }
            return links;
        }


        public void SaveListToFile(List<string> list, string filePath)
        {
            try
            {
                // Tạo một đối tượng StreamWriter để ghi vào tệp văn bản
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    // Lặp qua danh sách và ghi từng chuỗi vào tệp
                    foreach (string item in list)
                    {
                        sw.WriteLine(item);
                    }
                }

                lbstatus.Text = "Danh sách đã được lưu vào tệp: " + filePath;
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
                _listFileDelete = new List<string>();
                _listFileDelete = ReadFileLinesToList(txtInputList.Text);
                DeleteFilesInDirectory(_listFileDelete, txtFolderDelete.Text);
            }
        }

        private void btnDeleteFileWithOutList_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolderDelete.Text))
            {
                MessageBox.Show(" Thư mục không tồn tại ");
            }
            else
            {
                _listFileDelete = new List<string>();
                _listFileDelete = ReadFileLinesToList(txtInputList.Text);
                DeleteFilesWithOutListInDirectory(_listFileDelete, txtFolderDelete.Text);
            }
        }

        private void btnExtractLink_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolderDelete.Text))
            {
                MessageBox.Show(" Thư mục không tồn tại ");
            }
            else
            {
                var listlink = GetLinksContainingKeyword(txtInputList.Text,txtKeywordFinder.Text);
                SaveListToFile(listlink, txtFolderDelete.Text + "\\ExtractLinks.txt");
            }
        }

        private void btnFilterLink_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolderDelete.Text))
            {
                MessageBox.Show(" Thư mục không tồn tại ");
            }
            else
            {
                _listFileDelete = new List<string>();
                _listFileDelete = ExtractAndFilterUniqueLinks(txtInputList.Text);
                SaveListToFile(_listFileDelete, txtFolderDelete.Text + "\\FilterLinks.txt");
            }
        }

     
    }
}
