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
    public partial class Products : Form
    {
        public int id;
        public string ady;
        public double alnanBahasy;
        public double satuwBahasy;
        public double galanMukdary;
        double chykdayjy;
        double girdeyji;
        double arassaGirdeyji;

        public Products()
        {
            InitializeComponent();
        }
        MySqlConnection bag = new MySqlConnection("server=127.0.0.1; port=3306; username=root; password=; database=ashop;");
        private void Products_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = new Bitmap("suratlar\\" + id + ".jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            catch (Exception)
            {
                pictureBox1.Visible = false;
            }
            adyTB.Text = ady.ToString();
            alnanBahaTB.Text = alnanBahasy.ToString();
            satuwBahaTB.Text = satuwBahasy.ToString();
            galanMukdarTB.Text = galanMukdary.ToString();
            chykdayjy = alnanBahasy * galanMukdary;
            chykdayjyTB.Text = chykdayjy.ToString();
            girdeyji = galanMukdary * satuwBahasy;
            girdeyjiTB.Text = girdeyji.ToString();
            arassaGirdeyji = girdeyji - chykdayjy;
            arassaGirdeyjiTB.Text = arassaGirdeyji.ToString();
            button1.Enabled = false;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Yellow;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.DodgerBlue;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void alnanBahaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void satuwBahaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void galanMukdarTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void adyTB_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void alnanBahaTB_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void satuwBahaTB_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void galanMukdarTB_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter daa = new MySqlDataAdapter();
            adyTB.Text = ady;
            double AB = Convert.ToDouble(alnanBahaTB.Text.ToString());
            double SB = Convert.ToDouble(satuwBahaTB.Text.ToString());
            double GM = Convert.ToDouble(galanMukdarTB.Text.ToString());
            daa.InsertCommand = new MySqlCommand("update products set name='"+ady+"', alnanBahasy='" + AB + "', satuwBahasy='" + SB + "', mukdar='" + GM + "' where productID='" + id + "';", bag);
            bag.Open();
            daa.InsertCommand.ExecuteNonQuery();
            bag.Close();
            var adminForm = Application.OpenForms.OfType<Admin>().Single();
            adminForm.maglAlweugrat();
        }
    }
}
