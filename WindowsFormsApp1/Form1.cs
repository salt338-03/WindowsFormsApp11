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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void btnLoadFile_Click_1(object sender, EventArgs e)
        {
            // 파일 선택 다이얼로그 호출
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    try
                    {
                        string fileContent = await ReadFileAsync(filePath);
                        txtFileContent.Text = fileContent;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"오류가 발생했습니다");
                    }
                }
            }
        }

        private async Task<string> ReadFileAsync(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private void btnLoadFile2_Click(object sender, EventArgs e)
        {
            // 파일 선택 다이얼로그 호출
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    try
                    {
                        string fileContent = ReadFile(filePath);
                        txtFileContent.Text = fileContent;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"오류가 발생했습니다");
                    }
                }
            }
        }
        private string ReadFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }


        private void txtFileContent_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
