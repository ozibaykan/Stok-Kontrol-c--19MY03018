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
    public partial class Form3 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        public Form3()
        {
            InitializeComponent();
        }

        void KullaniciGetir()
        {
            baglanti = new SqlConnection("server=.;Initial Catalog=StokKontrol;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("Select *FROM Kayit", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            //DataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            KullaniciGetir();
        }
    }
}
