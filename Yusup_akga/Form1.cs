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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection bag = new MySqlConnection("server=127.0.0.1; port=3306; username=root; password=; database=ashop;");
        void synansh()
        {
            MySqlDataAdapter daa = new MySqlDataAdapter();
            try
            {
                daa.InsertCommand = new MySqlCommand("insert into satylan (no,productID,name,mukdar,alnanBahasy,satuwBahasy,girdeyji,arassaGirdeyji) Values ('1','1','bugday', '100', '3', '3.5', '3500', '500')", bag);
                bag.Open();
                daa.InsertCommand.ExecuteNonQuery();
                bag.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new Admin().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            synansh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://127.0.0.1:8080/yusupAkga");
            //new Hasabat().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new satuwlar().Show();
        }
    }
}
