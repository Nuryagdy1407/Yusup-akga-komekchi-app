using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Yusup_akga
{
    public partial class Hasabat : Form
    {
        public Hasabat()
        {
            InitializeComponent();
        }
        MySqlConnection bag = new MySqlConnection("server=127.0.0.1; port=3306; username=root; password=; database=ashop;");

        private void tablisanyDoldur()
        {
            try
            {
                bag.Open();
                System.Data.DataTable dtt = new System.Data.DataTable();
                MySqlDataAdapter daa = new MySqlDataAdapter("select * from satylan order by no ASC", bag);
                daa.Fill(dtt);
                dataGridView1.DataSource = dtt.DefaultView;
                dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);

                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].Width = 80;
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[6].Width = 80;
                dataGridView1.Columns[7].Width = 80;

                //dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Height = 30;
                    dataGridView1.Rows[i].Selected = false;
                }
                for (int k = 0; k < dataGridView1.Rows.Count; k++) { dataGridView1.Rows[k].Selected = false; }
                bag.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Yza_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Yza_Button_MouseLeave(object sender, EventArgs e)
        {
            Yza_Button.BackColor = Color.White;
        }

        private void Yza_Button_MouseEnter(object sender, EventArgs e)
        {
            Yza_Button.BackColor = Color.Purple;
        }

        private void Hasabat_Load(object sender, EventArgs e)
        {
            tablisanyDoldur();
        }
    }
}
