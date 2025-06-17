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
using YamlDotNet.Serialization;

namespace WhoTmIsConflict
{
    public partial class WhoTmConflict : Form
    {
        private List<Tuple<string, string>> vanillaText;
        private List<Tuple<string, string>> modText;


        public WhoTmConflict()
        {
            InitializeComponent();
        }

        private void ImportDataFromFolder(string dialogTitle, ref List<Tuple<string, string>> importedData)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = dialogTitle;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowserDialog.SelectedPath;
                    importedData = ImportDataFromYMLFiles(folderPath);
                    MessageBox.Show($"成功导入{importedData.Count}个键值。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private List<Tuple<string, string>> ImportDataFromYMLFiles(string folderPath)
        {
            List<Tuple<string, string>> data = new List<Tuple<string, string>>();

            foreach (string filePath in Directory.GetFiles(folderPath, "*.yml"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            int indexOfColon = line.IndexOf(":");
                            if (indexOfColon != -1)
                            {
                                if(line.Substring(0, indexOfColon) != "l_english")
                                {
                                    string extractedValue = line.Substring(0, indexOfColon).Trim();
                                    data.Add(new Tuple<string, string>(extractedValue, filePath));
                                }
                                
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"在处理文件{filePath}时发生错误：{ex.Message}", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            foreach (string subFolderPath in Directory.GetDirectories(folderPath))
            {
                data.AddRange(ImportDataFromYMLFiles(subFolderPath));
            }

            return data;
        }

        private List<Tuple<string, string, string>> CompareData(List<Tuple<string, string>> firstData, List<Tuple<string, string>> secondData)
        {
            List<Tuple<string, string, string>> conflicts = new List<Tuple<string, string, string>>();

            foreach (var firstTuple in firstData)
            {
                foreach (var secondTuple in secondData)
                {
                    if (firstTuple.Item1 == secondTuple.Item1)
                    {
                        conflicts.Add(new Tuple<string, string, string>(
                            firstTuple.Item1,
                            firstTuple.Item2,
                            secondTuple.Item2
                        ));
                    }
                }
            }

            return conflicts;
        }

        private void importVanillaTextButton_Click(object sender, EventArgs e)
        {
            ImportDataFromFolder("请选择原版文本所在文件夹，选择english或simp_chinese文件夹", ref vanillaText);

        }

        private void importModTextButton_Click(object sender, EventArgs e)
        {
            ImportDataFromFolder("请选择Mod文本所在文件夹，选择english或simp_chinese文件夹", ref modText);

        }

        private void compareTextButton_Click(object sender, EventArgs e)
        {
            if (vanillaText == null || modText == null)
            {
                MessageBox.Show("请先导入原版文本与Mod文本！", "缺少文本", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Tuple<string, string, string>> conflicts = CompareData(vanillaText, modText);

            if (conflicts.Count > 0)
            {
                // 冲突存在，输出到文件
                using (StreamWriter writer = new StreamWriter("冲突键值.txt"))
                {
                    foreach (var conflict in conflicts)
                    {
                        writer.WriteLine($"{conflict.Item1}\t{Path.GetFileName(conflict.Item2)}\t{Path.GetFileName(conflict.Item3)}");
                    }
                }

                MessageBox.Show("存在冲突，键值与文件已输出到冲突键值.txt文件中。", "存在冲突", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("无键值冲突！", "没冲突", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
