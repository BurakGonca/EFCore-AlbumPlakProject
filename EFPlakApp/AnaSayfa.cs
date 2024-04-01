using MaratonApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFPlakApp
{
    public partial class AnaSayfa : Form
    {
        private MaratonAppDbContext dB;
        Album secilenAlbum= new Album();
        public AnaSayfa()
        {

            dB = new MaratonAppDbContext();
            InitializeComponent();
           

            sanatciAdi_comboBox.DataSource = dB.Sanatcilar.ToList();
            durumu_textbox.DataSource = Enum.GetNames(typeof(Status));

        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            kullanici_lbl.Text = Program.AktifKullanici.Adi;
        }


        private void liste1_buton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dB.Albumler.ToList();
            GosterilmeyecekKolonlar();
        }

        private void liste2_buton_Click(object sender, EventArgs e)
        {
            var satisiDevamEtmeyenler = dB.Albumler.Where(a => a.Status == Status.SatisiDevamEtmiyor)
                                                       .Select(a => new { a.AlbumAdi, Sanatci = a.Sanatci.SanatciAdi })
                                                       .ToList();

            dataGridView1.DataSource = satisiDevamEtmeyenler;
        }

        private void liste3_buton_Click(object sender, EventArgs e)
        {
            var satisiDevamEdenler = dB.Albumler.Where(a => a.Status == Status.SatisiDevamEdiyor)
                                                   .Select(a => new { a.AlbumAdi, Sanatci = a.Sanatci.SanatciAdi })
                                                   .ToList();

            dataGridView1.DataSource = satisiDevamEdenler;
        }

        private void liste4_buton_Click(object sender, EventArgs e)
        {
            var sistemeEnSonEklenen10 = dB.Albumler.OrderByDescending(a => a.Id).Take(10)
                                                 .Select(a => new { a.AlbumAdi, Sanatci = a.Sanatci.SanatciAdi })
                                                 .ToList();

            dataGridView1.DataSource = sistemeEnSonEklenen10;
        }

        private void liste5_buton_Click(object sender, EventArgs e)
        {
            var indirimdekiAlbumler = dB.Albumler.Where(a => a.IndirimOrani > 0)
                                                       .OrderByDescending(a => a.IndirimOrani)
                                                       .Select(a => new { a.AlbumAdi, Sanatci = a.Sanatci.SanatciAdi })
                                                       .ToList();

            dataGridView1.DataSource = indirimdekiAlbumler;
        }

        private void cikisYap_buton_Click(object sender, EventArgs e)
        {
            Program.AktifKullanici = null;
            MessageBox.Show("Cikis yapilmistir.");
            GirisFormu girisFormu = new GirisFormu();
            girisFormu.Show();
            this.Hide();
        }

        private void ekle_buton_Click(object sender, EventArgs e)
        {
            Album album = new Album();
            if (!KayitEkrani.AlanKontrol(albumAdi_textBox.Text))
            {
                MessageBox.Show("Lütfen albüm adını giriniz.");
                return;
            }
            album.AlbumAdi = albumAdi_textBox.Text;

            if (!KayitEkrani.AlanKontrol(fiyati_textbox.Text))
            {
                MessageBox.Show("Lütfen fiyatı giriniz.");
                return;
            }
            album.Fiyat = double.Parse(fiyati_textbox.Text);

            if (!KayitEkrani.AlanKontrol(albumAdi_textBox.Text))
            {
                MessageBox.Show("Lütfen indirim oranını giriniz.");
                return;
            }
            if (indirim_textbox.Text != string.Empty)
                album.IndirimOrani = double.Parse(indirim_textbox.Text);
            else
                album.IndirimOrani = null;


            if (dtpCikisTarihi.Value < DateTime.Now)
            {
                album.CikisTarihi = dtpCikisTarihi.Value;
            }
            else
            {
                MessageBox.Show("Albüm çıkış tarihi bugünden büyük olamaz");
                return;
            }

            album.Sanatci = (Sanatci)sanatciAdi_comboBox.SelectedItem;

            if (durumu_textbox.SelectedText == Status.SatisiDevamEdiyor.ToString())
                album.Status = Status.SatisiDevamEdiyor;
            else 
                album.Status = Status.SatisiDevamEtmiyor;

            dB.Albumler.Add(album);
            dB.SaveChanges();
            MessageBox.Show("ilgili albüm başarıyla eklenmiştir");
            dataGridView1.DataSource = dB.Albumler.ToList();
            GosterilmeyecekKolonlar();

        }

        public void GosterilmeyecekKolonlar()
        {
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             secilenAlbum = (Album)dataGridView1.SelectedRows[0].DataBoundItem;
        }

        private void guncelle_buton_Click(object sender, EventArgs e)
        {
            if (secilenAlbum!=null)
            {
                if (!KayitEkrani.AlanKontrol(albumAdi_textBox.Text))
                {
                    MessageBox.Show("Lütfen albüm adını giriniz.");
                    return;
                }
                secilenAlbum.AlbumAdi = albumAdi_textBox.Text;

                if (!KayitEkrani.AlanKontrol(fiyati_textbox.Text))
                {
                    MessageBox.Show("Lütfen fiyatı giriniz.");
                    return;
                }
                secilenAlbum.Fiyat = double.Parse(fiyati_textbox.Text);

                if (!KayitEkrani.AlanKontrol(albumAdi_textBox.Text))
                {
                    MessageBox.Show("Lütfen indirim oranını giriniz.");
                    return;
                }
                if (indirim_textbox.Text != string.Empty)
                    secilenAlbum.IndirimOrani = double.Parse(indirim_textbox.Text);
                else
                    secilenAlbum.IndirimOrani = null;


                if (dtpCikisTarihi.Value < DateTime.Now)
                {
                    secilenAlbum.CikisTarihi = dtpCikisTarihi.Value;
                }
                else
                {
                    MessageBox.Show("Albüm çıkış tarihi bugünden büyük olamaz");
                    return;
                }

                secilenAlbum.Sanatci = (Sanatci)sanatciAdi_comboBox.SelectedItem;

                if (durumu_textbox.SelectedText == Status.SatisiDevamEdiyor.ToString())
                    secilenAlbum.Status = Status.SatisiDevamEdiyor;
                else
                    secilenAlbum.Status = Status.SatisiDevamEtmiyor;

                dB.Albumler.Update(secilenAlbum);
                dB.SaveChanges();
                MessageBox.Show("ilgili albüm başarıyla güncellenmiştir");
                dataGridView1.DataSource = dB.Albumler.ToList();
                GosterilmeyecekKolonlar();
            }
        }

        private void sil_buton_Click(object sender, EventArgs e)
        {
            if (secilenAlbum!=null)
            {
                dB.Albumler.Remove(secilenAlbum);
                dB.SaveChanges();
                MessageBox.Show("Seçili albüm silindi");
                dataGridView1.DataSource = dB.Albumler.ToList();
                GosterilmeyecekKolonlar();
            }
        }
    }
}
