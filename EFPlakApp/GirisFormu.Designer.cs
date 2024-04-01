namespace EFPlakApp
{
    partial class GirisFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisFormu));
            giris_buton = new Button();
            kayit_buton = new Button();
            sifre_textBox = new TextBox();
            email_textBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // giris_buton
            // 
            giris_buton.Location = new Point(213, 370);
            giris_buton.Margin = new Padding(3, 4, 3, 4);
            giris_buton.Name = "giris_buton";
            giris_buton.Size = new Size(148, 31);
            giris_buton.TabIndex = 19;
            giris_buton.Text = "GİRİŞ";
            giris_buton.UseVisualStyleBackColor = true;
            giris_buton.Click += giris_buton_Click;
            // 
            // kayit_buton
            // 
            kayit_buton.Location = new Point(398, 370);
            kayit_buton.Margin = new Padding(3, 4, 3, 4);
            kayit_buton.Name = "kayit_buton";
            kayit_buton.Size = new Size(152, 31);
            kayit_buton.TabIndex = 18;
            kayit_buton.Text = "KAYIT OL";
            kayit_buton.UseVisualStyleBackColor = true;
            kayit_buton.Click += kayit_buton_Click;
            // 
            // sifre_textBox
            // 
            sifre_textBox.Location = new Point(213, 323);
            sifre_textBox.Margin = new Padding(3, 4, 3, 4);
            sifre_textBox.Name = "sifre_textBox";
            sifre_textBox.Size = new Size(337, 27);
            sifre_textBox.TabIndex = 17;
            // 
            // email_textBox
            // 
            email_textBox.Location = new Point(213, 272);
            email_textBox.Margin = new Padding(3, 4, 3, 4);
            email_textBox.Name = "email_textBox";
            email_textBox.Size = new Size(337, 27);
            email_textBox.TabIndex = 16;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.Location = new Point(156, 324);
            label3.Name = "label3";
            label3.Size = new Size(50, 31);
            label3.TabIndex = 15;
            label3.Text = "Sifre:";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.Location = new Point(99, 274);
            label4.Name = "label4";
            label4.Size = new Size(107, 25);
            label4.TabIndex = 14;
            label4.Text = "Kullanıcı Adı: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label2.Location = new Point(249, 166);
            label2.Name = "label2";
            label2.Size = new Size(141, 31);
            label2.TabIndex = 13;
            label2.Text = "Hoşgeldiniz";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(140, 116);
            label1.Name = "label1";
            label1.Size = new Size(413, 38);
            label1.TabIndex = 12;
            label1.Text = "Plak Dükkânı Yönetici Modülü";
            // 
            // GirisFormu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(692, 516);
            Controls.Add(giris_buton);
            Controls.Add(kayit_buton);
            Controls.Add(sifre_textBox);
            Controls.Add(email_textBox);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GirisFormu";
            Text = "GirisFormu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button giris_buton;
        private Button kayit_buton;
        private TextBox sifre_textBox;
        private TextBox email_textBox;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
    }
}