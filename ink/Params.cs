using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ink
{
    public partial class Params : Form
    {
        public Params()
        {
            InitializeComponent();
        }
        public int flag_;
        Font font;
        private void Params_Load(object sender, EventArgs e)
        {
            font = Properties.Settings.Default.FormFont;
        }

        private void Params_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        public Font GetFormFont
        {
            get { return font; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //загружаем текущие настройки шрифта
            fontDialog1.Font = Properties.Settings.Default.FormFont;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                font = fontDialog1.Font;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
