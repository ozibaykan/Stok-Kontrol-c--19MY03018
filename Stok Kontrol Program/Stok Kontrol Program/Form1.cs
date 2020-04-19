using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stok_Kontrol_Program
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-URMO5JR\\MSSQLSERVER02; Initial Catalog=StokKontrol; Integrated Security=TRUE");




        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool move;
        int mouse_x;
        int mouse_y;

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {


            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adı";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '*';
            }
        }
        char? none = null;
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
                textBox2.PasswordChar = Convert.ToChar(none);
            }
        }

        //private void button2_Click(object sender, EventArgs e)

        //{

        //    {

        //    }

        //}
        bool isThere;
        private void button2_Click_1(object sender, EventArgs e)
        {
            //            Form1.ActiveForm.Visible = false;
            //            Form3 formax = new Stok_Kontrol_Program.Form3();
            //            formax.Show();

            //            string Kullanici_Adi = textBox1.Text;
            //            string Sifre = textBox2.Text;
            //            string cnstr = "Data Source=DESKTOP-URMO5JR\\MSSQLSERVER02;Initial Catalog=StokKontrol;Integrated Security=True";
            //            SqlConnection con = new SqlConnection(cnstr);
            //            cmd = new SqlCommand();
            //            con.Open();
            //            cmd.Connection = con;
            //            cmd.CommandText = "SELECT * FROM dbo.Kayit where Kullanici_Adi='" + textBox1.Text + "' AND Sifre='" + textBox2.Text + "'";
            //            dr = cmd.ExecuteReader();
            //            if (dr.Read())
            //            {
            //                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.");
            //            }
            //            else
            //            {
            //                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");


            //            }

            //            con.Close();
            //        }


            //    }
            //}

            string Kullanici_Adi = textBox1.Text; ;
            string Sifre = textBox2.Text;


            connection.Open();
            SqlCommand command = new SqlCommand("Select *from Kayit", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (Kullanici_Adi == reader["Kullanici_Adi"].ToString().TrimEnd() && Sifre == reader["Sifre"].ToString().TrimEnd())
                {
                    isThere = true;
                    break;
                }

                else
                {
                    isThere = false;
                }

            }

            connection.Close();

            if (isThere)
            {
                MessageBox.Show("Giriş yaptınız!", "Program");

                Form1.ActiveForm.Visible = false;
                Form4 formax = new Form4();
                formax.Show();

            }

            else
            {
                MessageBox.Show("Bilgileriniz Hatalı", "Program");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Form5 formax = new Form5();
            formax.ShowDialog();
        }
    }
}