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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-URMO5JR\\MSSQLSERVER02; Initial Catalog=StokKontrol; Integrated Security=TRUE");
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();


                string kayit = "INSERT INTO Kayit(Kullanici_Adi,Sifre,Sifre_Tekrar) VALUES (@Kullanici_Adi,@Sifre,@Sifre_Tekrar)";

                SqlCommand komut = new SqlCommand(kayit, connection);

                komut.Parameters.AddWithValue("Kullanici_Adi", textBox1.Text);
                komut.Parameters.AddWithValue("Sifre", Convert.ToInt32(textBox2.Text));
                komut.Parameters.AddWithValue("Sifre_Tekrar", Convert.ToInt32(textBox2.Text));

                komut.ExecuteNonQuery();
 
                connection.Close();
               
                MessageBox.Show("Müşteri Kayıt İşlemi Gerçekleşti.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                Form5.ActiveForm.Visible = false;
                Form1 formax = new Form1();
                formax.Show();
            }
        }
        }
}
