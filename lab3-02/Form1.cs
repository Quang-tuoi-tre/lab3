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
using System.Drawing.Text;

namespace lab3_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                richTextBox1.Clear();
                richTextBox1.Font = new Font("Tahoma", 14);
            }

        }

        



        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDLG = new FontDialog();
            fontDLG.ShowColor = true;
            fontDLG.ShowApply = true;
            fontDLG.ShowEffects = true;
            fontDLG.ShowHelp = true;
            if(fontDLG.ShowDialog()!= DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDLG.Color;
                richTextBox1.Font = fontDLG.Font;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14);
        }


        private void btnB_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont; // Lấy font hiện tại của vùng văn bản đang được chọn

            FontStyle newFontStyle;
            if (currentFont.Bold)
            {
                newFontStyle = currentFont.Style & ~FontStyle.Bold; // Loại bỏ in đậm
            }
            else
            {
                newFontStyle = currentFont.Style | FontStyle.Bold; // In đậm
            }

            richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle); // Cập nhật font với font style mới
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont; // Lấy font hiện tại của vùng văn bản đang được chọn

            FontStyle newFontStyle;
            if (currentFont.Italic)
            {
                newFontStyle = currentFont.Style & ~FontStyle.Italic; // Loại bỏ in nghiêng
            }
            else
            {
                newFontStyle = currentFont.Style | FontStyle.Italic; // In nghiêng
            }

            richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle); // Cập nhật font với font style mới
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            {
                // Kiểm tra trạng thái của nút Underline
                bool isUnderline = toolStripButton5.Checked;

                // Thiết lập Font gạch chân cho vùng văn bản đã chọn
                if (isUnderline)
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Underline);
                }
                else
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);
                }
                toolStripButton5.CheckOnClick = true;
            }
        }
            private void LuuNoiDungVanBan(string filePath)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(richTextBox1.Text);
                }
            }
        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Lưu Tập Tin Văn Bản";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Tập tin văn bản|*.txt";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDialog.FileName;
                try
                {
                    richTextBox1.SaveFile(selectedFileName, RichTextBoxStreamType.UnicodePlainText);
                    MessageBox.Show("Tập tin đã được lưu thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình lưu tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cbTahoma_Click(object sender, EventArgs e)
        {
            {
                var installedFonts = new System.Drawing.Text.InstalledFontCollection();
                var fontFamilies = installedFonts.Families;

                // Thêm các font chữ vào ComboBox
                foreach (var font in fontFamilies)
                {
                    cbTahoma.Items.Add(font.Name);
                    cbTahoma.SelectedItem = "Tahoma";
                }
            }

        }

        private void comboBox_FrontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            float choose = Convert.ToSingle(this.comboBox_FrontSize.SelectedItem.ToString());
            this.richTextBox1.Font = new Font(this.richTextBox1.Font.FontFamily, choose, this.richTextBox1.Font.Style);

        }

        private void cbTahoma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choose = this.cbTahoma.SelectedItem.ToString();
            this.richTextBox1.Font = new Font(choose, richTextBox1.Font.Size, this.richTextBox1.Font.Style);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ForeColor = Color.Green;
        }
    }
}
