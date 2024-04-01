using MaratonApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFPlakApp
{
    public partial class KayitEkrani : Form
    {

        MaratonAppDbContext MaratonAppDbContext = new MaratonAppDbContext();

        public KayitEkrani()
        {
            InitializeComponent();
        }



        private void kayit_buton_Click(object sender, EventArgs e)
        {


            Kullanici kullanici = new Kullanici();

            if (!AlanKontrol(ad_textBox.Text))
            {
                MessageBox.Show("Lütfen adinizi giriniz.");
                return;
            }
            kullanici.Adi = ad_textBox.Text;

            if (!AlanKontrol(soyAd_textbox.Text))
            {
                MessageBox.Show("Lütfen soyadinizi giriniz.");
                return;
            }
            kullanici.Soyadi = soyAd_textbox.Text;

            if (!AlanKontrol(kullaniciAd_textbox.Text))
            {
                MessageBox.Show("Lütfen kullanici adinizi giriniz.");
                return;
            }
            kullanici.KullaniciAdi = kullaniciAd_textbox.Text;


            if (PasswordControl())
            {
                kullanici.Sifre = Program.Sha256Hash(sifre_textbox.Text);

                MaratonAppDbContext.Kullanicilar.Add(kullanici);
                MaratonAppDbContext.SaveChanges();

                MessageBox.Show("Kullanıcı başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


                ad_textBox.Text = "";
                soyAd_textbox.Text = "";
                kullaniciAd_textbox.Text = "";
                sifre_textbox.Text = "";
                sifreTekrari_textbox.Text = "";
            }
            else
            {
                MessageBox.Show("Sifre kontrolünüz basarili olamadi, kayit islemi iptal edilmistir.");
                return;
            }


        }

        public static bool AlanKontrol(string alan)
        {
            if (string.IsNullOrWhiteSpace(alan))
                return false;
            return true;
        }


        private bool PasswordControl()
        {
            string psswrd = sifre_textbox.Text;

            if (psswrd != null && psswrd.Length >= 8)
            {
                int uppercaseCount = psswrd.Count(char.IsUpper);
                int lowercaseCount = psswrd.Count(char.IsLower);
                int specialCharacterCount = Regex.Matches(psswrd, @"[!:+*]").Count;

                if (uppercaseCount < 2)
                {
                    MessageBox.Show("En az 2 büyük harf içermelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (lowercaseCount < 3)
                {
                    MessageBox.Show("En az üç küçük harf içermelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (specialCharacterCount < 2)
                {
                    MessageBox.Show("En az iki özel karakter (!:+*) içermelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (sifre_textbox.Text != sifreTekrari_textbox.Text)
                {
                    MessageBox.Show("Şifreler birbiri ile uyuşmuyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("Sifre en az 8 karakter içermelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void giris_buton_Click(object sender, EventArgs e)
        {
            GirisFormu girisFormu = new GirisFormu();
            girisFormu.Show();
            this.Hide();
        }
    }
}
