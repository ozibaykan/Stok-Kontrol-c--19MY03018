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
    public partial class Form4 : Form


    {
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, connection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-URMO5JR\\MSSQLSERVER02; Initial Catalog=StokKontrol; Integrated Security=TRUE");
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();


                string kayit = "INSERT INTO Stoklar(Kofte125,Kofte150,Kofte90,Kofte45,MarulKesilmisPoset,DomatesKasa,KucukEkmek,OrtaEkmek,BuyukEkmek,Sos1,Sos2,Sos3) VALUES (@Kofte125,@Kofte150,@Kofte90,@Kofte45,@MarulKesilmisPoset,@DomatesKasa,@KucukEkmek,@OrtaEkmek,@BuyukEkmek,@Sos1,@Sos2,@Sos3)";

                SqlCommand komut = new SqlCommand(kayit, connection);

                komut.Parameters.AddWithValue("@Kofte125", Convert.ToInt32( textBox1.Text));
                komut.Parameters.AddWithValue("@Kofte150", Convert.ToInt32(textBox2.Text));
                komut.Parameters.AddWithValue("@Kofte90", Convert.ToInt32(textBox3.Text));
                komut.Parameters.AddWithValue("@Kofte45", Convert.ToInt32(textBox4.Text));
                komut.Parameters.AddWithValue("@MarulKesilmisPoset", Convert.ToInt32(textBox5.Text));
                komut.Parameters.AddWithValue("@DomatesKasa", Convert.ToInt32(textBox6.Text));
                komut.Parameters.AddWithValue("@KucukEkmek", Convert.ToInt32(textBox7.Text));
                komut.Parameters.AddWithValue("@OrtaEkmek", Convert.ToInt32(textBox8.Text));
                komut.Parameters.AddWithValue("@BuyukEkmek", Convert.ToInt32(textBox9.Text));
                komut.Parameters.AddWithValue("@Sos1", Convert.ToInt32(textBox10.Text));
                komut.Parameters.AddWithValue("@Sos2", Convert.ToInt32(textBox11.Text));
                komut.Parameters.AddWithValue("@Sos3", Convert.ToInt32(textBox12.Text));


                komut.ExecuteNonQuery();

                connection.Close();
                verilerigoster("Select * From Stoklar");
                MessageBox.Show("Müşteri Kayıt İşlemi Gerçekleşti.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string kayit = "UPDATE Stoklar SET Kofte125=@Kofte125,Kofte150=@Kofte150,Kofte90=@Kofte90, Kofte45=@Kofte45, MarulKesilmisPoset=@MarulKesilmisPoset, DomatesKasa=@DomatesKasa, KucukEkmek=@KucukEkmek, OrtaEkmek=@OrtaEkmek, BuyukEkmek=@BuyukEkmek, Sos1=@Sos1, Sos2=@Sos2, Sos3=@Sos3 WHERE Kofte125=@Kofte125";
            SqlCommand komut = new SqlCommand(kayit, connection);

            komut.Parameters.AddWithValue("@Kofte125", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@Kofte150", Convert.ToInt32(textBox2.Text));
            komut.Parameters.AddWithValue("@Kofte90", Convert.ToInt32(textBox3.Text));
            komut.Parameters.AddWithValue("@Kofte45", Convert.ToInt32(textBox4.Text));
            komut.Parameters.AddWithValue("@MarulKesilmisPoset", Convert.ToInt32(textBox5.Text));
            komut.Parameters.AddWithValue("@DomatesKasa", Convert.ToInt32(textBox6.Text));
            komut.Parameters.AddWithValue("@KucukEkmek", Convert.ToInt32(textBox7.Text));
            komut.Parameters.AddWithValue("@OrtaEkmek", Convert.ToInt32(textBox8.Text));
            komut.Parameters.AddWithValue("@BuyukEkmek", Convert.ToInt32(textBox9.Text));
            komut.Parameters.AddWithValue("@Sos1", Convert.ToInt32(textBox10.Text));
            komut.Parameters.AddWithValue("@Sos2", Convert.ToInt32(textBox11.Text));
            komut.Parameters.AddWithValue("@Sos3", Convert.ToInt32(textBox12.Text));

            komut.ExecuteNonQuery();

            connection.Close();
            verilerigoster("Select * From Stoklar");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verilerigoster("Select * From Stoklar");
        }
    }
    }

