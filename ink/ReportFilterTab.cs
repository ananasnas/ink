﻿using System;
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
    public partial class ReportFilterTab : Form
    {
        public ReportFilterTab()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].Visible = false;
        }
        public int flag_;
        public Employees textbo = new Employees();
        public List<Report> list = new List<Report>();
        public void getTable()
        {
            int nomber = 0;
            dataGridView1.Rows.Clear();
            foreach (Report apl in list)
            {
                nomber++;
                dataGridView1.Rows.Add(Convert.ToString(nomber), DateTime.Now.ToShortDateString(), apl.application.field.name_, apl.application.repair.name_,
                    "Показать список", apl.application.sumNominal.ToString(), apl.application.sumReal.ToString(), apl.application.ID.ToString());
            }
        }

        private void ReportFilterTab_Load(object sender, EventArgs e)
        {
            this.Font = Properties.Settings.Default.FormFont;
            getTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 4) // список оборудования
            {
                EquipList el = new EquipList();
                Applications apl = (Applications)new Applications().findByID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value.ToString()));
                List<Equipments> equipList = apl.equipment;
                string[] mas = apl.count.Split(',');
                int nom = 0;
                int nomber = 0;
                for (int k = 0; k < equipList.Count; k++)
                {
                    nomber++;
                    nom = k;
                    el.dataGridView1.Rows.Add(nomber, equipList[k].name_, mas[nom]);
                }
                el.ShowDialog();

            }

        }

        private void button1Create_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateReport cr = new CreateReport();
            cr.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_M menu = new Main_M();
            menu.employee = this.textbo;
            menu.ShowDialog();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Params pr = new Params();
            if (pr.ShowDialog() == DialogResult.OK)
            {
                //присваиваем значение шрифта
                this.Font = Properties.Settings.Default.FormFont = pr.GetFormFont;
                //сохраняем настройки
                Properties.Settings.Default.Save();
            }
        }

        private void ReportFilterTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormFont = this.Font;
            //сохранение настроек
            Properties.Settings.Default.Save();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getTable();
            toolStripStatusLabel1.Text = "Таблица успешно обновлена";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }   
    }
}  
