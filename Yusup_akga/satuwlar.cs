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
    public partial class satuwlar : Form
    {
        string sene;
        string gun;
        int productID;
        string name;
        double mukdar;
        double alnanBahasy;
        double satuwBahasy;
        double girdeyji;
        double arasssaGirdeyji;
        double chykdajy;
        string yagdayy;
        double galanMukdary;
        public satuwlar()
        {
            InitializeComponent();
        }
        MySqlConnection bag = new MySqlConnection("server=127.0.0.1; port=3306; username=root; password=; database=ashop;");
        void kabulEt()
        {
            sene = textBox3.Text.ToString();
            name = cmbGunisayla.Text.ToString();
            mukdar = Convert.ToDouble(textBox1.Text);
            yagdayy = cmbYagdayy.Text.ToString();
            MySqlDataAdapter daa = new MySqlDataAdapter();
            try
            {
                if (yagdayy == "satdym")
                {
                    satuwBahasy = Convert.ToDouble(textBox2.Text);
                    girdeyji = mukdar * satuwBahasy;
                    chykdajy = mukdar * alnanBahasy;
                    arasssaGirdeyji = girdeyji - chykdajy;

                    daa.InsertCommand = new MySqlCommand("insert into satylan (productID,name,mukdar,alnanBahasy,satuwBahasy,girdeyji,arassaGirdeyji,sene,yagdayy) Values ('" + productID + "','" + name + "', '" + mukdar + "', '" + alnanBahasy + "', '" + satuwBahasy + "', '" + girdeyji + "', '" + arasssaGirdeyji + "', '" + sene + "', '" + yagdayy + "')", bag);
                    bag.Open();
                    daa.InsertCommand.ExecuteNonQuery();
                    bag.Close();
                    double sonkyMukdar = galanMukdary - mukdar;
                    daa.InsertCommand = new MySqlCommand("update products set mukdar='" + sonkyMukdar + "' where name='" + name + "';", bag);
                    bag.Open();
                    daa.InsertCommand.ExecuteNonQuery();
                    bag.Close();
                    lbl_Status.Text = "Kabul edildi!";
                    lbl_Status.ForeColor = Color.Green;
                    tamamla();
                }
                else
                {
                    alnanBahasy = Convert.ToDouble(textBox2.Text);
                    girdeyji = mukdar * satuwBahasy;
                    chykdajy = mukdar * alnanBahasy;
                    arasssaGirdeyji = girdeyji - chykdajy;

                    daa.InsertCommand = new MySqlCommand("insert into satylan (productID,name,mukdar,alnanBahasy,satuwBahasy,girdeyji,arassaGirdeyji,sene,yagdayy) Values ('" + productID + "','" + name + "', '" + mukdar + "', '" + alnanBahasy + "', '" + satuwBahasy + "', '" + girdeyji + "', '" + arasssaGirdeyji + "', '" + sene + "', '" + yagdayy + "')", bag);
                    bag.Open();
                    daa.InsertCommand.ExecuteNonQuery();
                    bag.Close();
                    lbl_Status.Text = "Kabul edildi!";
                    lbl_Status.ForeColor = Color.Green;
                    tamamla();

                    double sonkyMukdar = galanMukdary + mukdar;
                    daa.InsertCommand = new MySqlCommand("update products set alnanBahasy='" + alnanBahasy + "', mukdar='" + sonkyMukdar + "' where name='" + name + "';", bag);
                    bag.Open();
                    daa.InsertCommand.ExecuteNonQuery();
                    bag.Close();
                }
            }
            catch (Exception ex)
            {
                lbl_Status.Text = "Kabul edilmedi! Täzeden synanyşyp görüň!";
                lbl_Status.ForeColor = Color.Red;
                tamamla();
                MessageBox.Show(ex.ToString());
            }
        }

        private void tamamla()
        {
            cmbGunisayla.Text = null;
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void bugun_update()
        {
            gun = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
            MySqlDataAdapter daa = new MySqlDataAdapter();
            daa.InsertCommand = new MySqlCommand("update bugun set baha='" + gun + "' where ady='bugun';", bag);
            bag.Open();
            daa.InsertCommand.ExecuteNonQuery();
            bag.Close();
        }

        void doldur()
        {
            cmbYagdayy.SelectedIndex = 0;
            gun = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
            textBox3.Text = gun.ToString();
            try
            {
                bag.Open();
                System.Data.DataTable dtt = new System.Data.DataTable();
                MySqlDataAdapter daa = new MySqlDataAdapter("select name from products order by no ASC", bag);
                daa.Fill(dtt);
                grdGuniSayla.DataSource = dtt.DefaultView;
                cmbGunisayla.Text = "Harydy saýlaň";
                for (int i = 0; i < (grdGuniSayla.Rows.Count-1); i++)
                    {
                        cmbGunisayla.Items.Add(grdGuniSayla.Rows[i].Cells[0].Value.ToString());
                    }
                bag.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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

        private void satuwlar_Load(object sender, EventArgs e)
        {
            doldur();
            bugun_update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbGunisayla.Text == "Harydy saýlaň" || textBox1.Text == "" || textBox2.Text == "")
            {
                lbl_Status.Text = "Maglumatlary doly giriziň!";
                lbl_Status.ForeColor = Color.Yellow;
            }
            else
                kabulEt();
        }

        private void cmbGunisayla_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from products where name='" + cmbGunisayla.Text + "' ", bag);
                cmd.CommandType = CommandType.Text;
                bag.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    if (cmbYagdayy.Text == "satdym")
                    {
                        double satuwBaha = 0;
                        productID = Convert.ToInt32(rd[1].ToString());
                        alnanBahasy = Convert.ToDouble(rd[3].ToString());
                        satuwBaha = Convert.ToDouble(rd[4].ToString());
                        galanMukdary = Convert.ToDouble(rd[5].ToString());
                        textBox2.Text = satuwBaha.ToString();
                    }
                    else
                    {
                        double alnanBaha;
                        productID = Convert.ToInt32(rd[1].ToString());
                        alnanBaha = Convert.ToDouble(rd[3].ToString());
                        satuwBahasy = Convert.ToDouble(rd[4].ToString());
                        galanMukdary = Convert.ToDouble(rd[5].ToString());
                        textBox2.Text = alnanBaha.ToString();
                    }
                }
                bag.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbYagdayy_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from products where name='" + cmbGunisayla.Text + "' ", bag);
                cmd.CommandType = CommandType.Text;
                bag.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    if (cmbYagdayy.Text == "satdym")
                    {
                        double satuwBaha = 0;
                        productID = Convert.ToInt32(rd[1].ToString());
                        alnanBahasy = Convert.ToDouble(rd[3].ToString());
                        satuwBaha = Convert.ToDouble(rd[4].ToString());
                        galanMukdary = Convert.ToDouble(rd[5].ToString());
                        textBox2.Text = satuwBaha.ToString();
                    }
                    else
                    {
                        double alnanBaha;
                        productID = Convert.ToInt32(rd[1].ToString());
                        alnanBaha = Convert.ToDouble(rd[3].ToString());
                        satuwBahasy = Convert.ToDouble(rd[4].ToString());
                        galanMukdary = Convert.ToDouble(rd[5].ToString());
                        textBox2.Text = alnanBaha.ToString();
                    }
                }
                bag.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
