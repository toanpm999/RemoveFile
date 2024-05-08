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

            // Tìm tất cả các thẻ <a> trong HTML
            HtmlNodeCollection linkNodes = htmlDoc.DocumentNode.SelectNodes("//a[@href]");

            if (linkNodes != null)
            {
                foreach (HtmlNode linkNode in linkNodes)
                {
                    string href = linkNode.GetAttributeValue("href", "").ToLower();

                    // Kiểm tra xem liên kết có chứa từ khóa được chỉ định không
                    if (href.Contains(keyword))
                    {
                        // Kiểm tra xem đường dẫn là đường dẫn tuyệt đối hay tương đối
                        if (!Uri.IsWellFormedUriString(href, UriKind.Absolute))
                        {
                            // Nếu đường dẫn không phải là đường dẫn tuyệt đối, thì chuyển đổi nó thành đường dẫn tuyệt đối
                            Uri baseUri = new Uri(htmlFile, UriKind.RelativeOrAbsolute);
                            href = new Uri(baseUri, href).AbsoluteUri;
                        }
                        links.Add(href);
                    }
                }
            }

            return links;
        }

        public List<string> FindLinksByPartialUrl(string htmlFile, string partialUrl)
        {
            List<string> links = new List<string>();

            // Đọc toàn bộ nội dung của tệp HTML
            string htmlContent = File.ReadAllText(htmlFile);

            // Tìm các đường link trong nội dung HTML bằng biểu thức chính quy
            Regex regex = new Regex(@"<a\s+(?:[^>]*?\s+)?href=([""'])(.*?)\1", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(htmlContent);

            // Lặp qua các kết quả tìm thấy
            foreach (Match match in matches)
            {
                string href = match.Groups[2].Value;

                // Kiểm tra nếu đường link chứa phần của đường link được chỉ định
                if (href.Contains(partialUrl))
                {
                    links.Add(href);
                }
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
                _listFileDelete = ReadFileLinesToList(txtInputList.Text);
                DeleteFilesInDirectory(_listFileDelete, txtFolderDelete.Text);
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
                var listlink = FindLinksByPartialUrl(txtInputList.Text,txtKeywordFinder.Text);
                SaveListToFile(listlink, txtFolderDelete.Text + "\\savelink.txt");
            }
        }
    }
}
