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
    public partial class Admin : Form
    {
        int id;
        string name;
        double alnanBaha;
        double satuwBaha;
        double mukdar;
        public Admin()
        {
            InitializeComponent();
        }
        MySqlConnection bag = new MySqlConnection("server=127.0.0.1; port=3306; username=root; password=; database=ashop;");

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void Yza_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Yza_Button_MouseEnter(object sender, EventArgs e)
        {
            Yza_Button.BackColor = Color.Purple;
        }

        private void Yza_Button_MouseLeave(object sender, EventArgs e)
        {
            Yza_Button.BackColor = Color.White;
        }
        public void maglAlweugrat()
        {
            maglAl();
            ugrat();
        }
        private void maglAl()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from products where productID='" + id + "' ", bag);
                cmd.CommandType = CommandType.Text;
                bag.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    name = rd[2].ToString();
                    alnanBaha = Convert.ToDouble(rd[3].ToString());
                    satuwBaha = Convert.ToDouble(rd[4].ToString());
                    mukdar = Convert.ToDouble(rd[5].ToString());
                }
                bag.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ugrat()
        {
            Products p = new Products();
            p.id = id;
            p.ady = name;
            p.alnanBahasy = alnanBaha;
            p.satuwBahasy = satuwBaha;
            p.galanMukdary = mukdar;
            p.Show();
        }

        private void pictureBox_kepek_Click(object sender, EventArgs e)
        {
            id = 1;
            maglAlweugrat();
        }

        private void pictureBox_bugdayGalyndy2_Click(object sender, EventArgs e)
        {
            id = 2;
            maglAlweugrat();
        }

        private void pictureBox_arpa_Click(object sender, EventArgs e)
        {
            id = 3;
            maglAlweugrat();

        }

        private void pictureBox_bugdayGalyndy1_Click(object sender, EventArgs e)
        {
            id = 4;
            maglAlweugrat();
        }

        private void pictureBox_shulha_Click(object sender, EventArgs e)
        {
            id = 5;
            maglAlweugrat();
        }

        private void pictureBox_maryShrop_Click(object sender, EventArgs e)
        {
            id = 6;
            maglAlweugrat();
        }

        private void pictureBox_bugday_Click(object sender, EventArgs e)
        {
            id = 7;
            maglAlweugrat();
        }

        private void pictureBox_charjewShrop_Click(object sender, EventArgs e)
        {
            id = 8;
            maglAlweugrat();
        }

        private void pictureBox_sement_Click(object sender, EventArgs e)
        {
            id = 9;
            maglAlweugrat();
        }

        private void pictureBox_hek_Click(object sender, EventArgs e)
        {
            id = 10;
            maglAlweugrat();
        }

        private void pictureBox_chagyl_Click(object sender, EventArgs e)
        {
            id = 11;
            maglAlweugrat();
        }

        private void pictureBox_myty_Click(object sender, EventArgs e)
        {
            id = 12;
            maglAlweugrat();
        }
    }
}
