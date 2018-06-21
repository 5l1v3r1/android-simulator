using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Configuration;//xml dosyası icin kullnıyoruz, app.config
using System.Drawing.Drawing2D;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Resources;



namespace Arduino
{
    public partial class Form1 : Form
    {
        bool baglanti;
        String[] ports;
        SerialPort portt;
        string gelen;
        string[] gelenler;
        Color p1;
        Color p2;
        Color p3;
        Color p4;
        Color p5;
        Color p6;
        Color p7;
        Color p8;
        Color p9;
        Color p10;
        Color p11;
        Color p12;
        Color p13;
        Color p14;
        Color p15;
        Color p16;
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            ports = SerialPort.GetPortNames();
            
            foreach (string port in ports)
            {
                seriport.Items.Add(port);    
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            metinleriYazdir();
            tipler.Items.Add("NANO");
            tipler.Items.Add("UNO");

            baudratee.Items.Add("300");
            baudratee.Items.Add("1200");
            baudratee.Items.Add("2400");
            baudratee.Items.Add("4800");
            baudratee.Items.Add("9600");
            baudratee.Items.Add("19200");
            baudratee.Items.Add("38400");
            baudratee.Items.Add("57600");
            baudratee.Items.Add("74880");
            baudratee.Items.Add("115200");
            baudratee.Items.Add("230400");
            baudratee.Items.Add("250000");
            baudratee.Items.Add("500000");
            baudratee.Items.Add("1000000");
            baudratee.Items.Add("2000000");

            textbox_listeleme();

            tipler.Text = ConfigurationManager.AppSettings["model"];
            baudratee.Text = ConfigurationManager.AppSettings["baud"];
            seriport.Text = ConfigurationManager.AppSettings["port"];
            textBox1.Text=ConfigurationManager.AppSettings["led1"];
            textBox2.Text = ConfigurationManager.AppSettings["high1"];          
            textBox3.Text = ConfigurationManager.AppSettings["low1"];  
            textBox6.Text = ConfigurationManager.AppSettings["led2"];
            textBox5.Text = ConfigurationManager.AppSettings["high2"];
            textBox4.Text = ConfigurationManager.AppSettings["low2"];
            textBox9.Text = ConfigurationManager.AppSettings["relay"];
            textBox8.Text = ConfigurationManager.AppSettings["high3"];
            textBox7.Text = ConfigurationManager.AppSettings["low3"];
            textBox10.Text = ConfigurationManager.AppSettings["led3"];
            textBox11.Text = ConfigurationManager.AppSettings["high4"];
            textBox12.Text = ConfigurationManager.AppSettings["low4"];
            textBox13.Text = ConfigurationManager.AppSettings["led4"];
            textBox14.Text = ConfigurationManager.AppSettings["high5"];
            textBox15.Text = ConfigurationManager.AppSettings["low5"];
            textBox16.Text = ConfigurationManager.AppSettings["led5"];
            textBox17.Text = ConfigurationManager.AppSettings["high6"];
            textBox18.Text = ConfigurationManager.AppSettings["low6"];
            textBox19.Text = ConfigurationManager.AppSettings["led6"];
            textBox20.Text = ConfigurationManager.AppSettings["high7"];
            textBox21.Text = ConfigurationManager.AppSettings["low7"];
            textBox22.Text = ConfigurationManager.AppSettings["led7"];
            textBox23.Text = ConfigurationManager.AppSettings["high8"];
            textBox24.Text = ConfigurationManager.AppSettings["low8"];
            picturebox_sekil();
           
           
            p1 = Color.Red;
            p4 = Color.Red;
            p6 = Color.Red;
            p2 = Color.Green;
            p3 = Color.Green;
            p5 = Color.Green;

        }
        
        private void calistir_Click(object sender, EventArgs e)
        {
    
            if(calistir.Text=="ÇALIŞTIR")
            {
                calistir.Text = "DURDUR";
                ArduinoBaglantisi();
                portt.DataReceived += new SerialDataReceivedEventHandler(portt_DataReceived);       
            }
            else if (calistir.Text == "DURDUR")
            {
                portt.Close();
                calistir.Text = "ÇALIŞTIR";
            }
            
          
 
        }
       
    
        private void ArduinoBaglantisi()
        {
            baglanti = true;
            string secilenport = seriport.GetItemText(seriport.SelectedItem);
            int secilenbaud = Convert.ToInt32(baudratee.SelectedItem);
            portt = new SerialPort(secilenport, secilenbaud, Parity.None, 8, StopBits.One);
            portt.Open();
           baglanti_bilgisi.Text = seriport.Text + Localization.label4; 
        }
        private void portt_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            gelen = portt.ReadExisting();
            ayristirma(gelen);
        }

        private void ayristirma(string gelen) 
        {
            pictureBox1.BackColor = Color.Silver;
            pictureBox2.BackColor = Color.Silver;
            pictureBox3.BackColor = Color.Silver;
            pictureBox4.BackColor = Color.Silver;
            pictureBox5.BackColor = Color.Silver;
            pictureBox6.BackColor = Color.Silver;
            pictureBox7.BackColor = Color.Silver;
            pictureBox8.BackColor = Color.Silver;
            pictureBox9.BackColor = Color.Silver;
            pictureBox10.BackColor = Color.Silver;
            pictureBox11.BackColor = Color.Silver;
            pictureBox12.BackColor = Color.Silver;
            pictureBox13.BackColor = Color.Silver;
            pictureBox14.BackColor = Color.Silver;
            pictureBox15.BackColor = Color.Silver;
            pictureBox16.BackColor = Color.Silver;

            char[] ayraclar=new char[] {',','\r','\n'};
            gelenler=gelen.Split(ayraclar);

            if (gelenler[0] != "")
            {
                p1_p2();
                if (gelenler[3] != "")
                {
                    p3_p4();
                    if (gelenler[6] != "")
                    {
                        p5_p6();
                        if (gelenler[9] != "")
                        {
                            p7_p8();
                            if (gelenler[12] != "")
                            {
                                p9_p10();
                                if (gelenler[15] != "")
                                {
                                    p11_p12();
                                    if (gelenler[18] != "")
                                    {
                                        p13_p14();
                                        if (gelenler[21] != "")
                                            p15_p16();
                                        else return;
                                    }
                                    else return;
                                }
                                else return;
                            }
                            else return;
                        }
                        else return;
                    }
                    else return;
                }
                else return;
            }
            else return;
        }

       
        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            p1 = colorDialog1.Color;      
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            p2 = colorDialog1.Color;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            p4 = colorDialog1.Color;
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            p3 = colorDialog1.Color;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            p6 = colorDialog1.Color;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            p5 = colorDialog1.Color;
        }

        private void temizle_Click(object sender, EventArgs e)
        {
            if (calistir.Text == "ÇALIŞTIR")
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                textBox20.Clear();
                textBox21.Clear();
                textBox22.Clear();
                textBox23.Clear();
                textBox24.Clear();
               
                pictureBox1.BackColor = Color.Silver;
                pictureBox2.BackColor = Color.Silver;
                pictureBox3.BackColor = Color.Silver;
                pictureBox4.BackColor = Color.Silver;
                pictureBox5.BackColor = Color.Silver;
                pictureBox6.BackColor = Color.Silver;
                pictureBox7.BackColor = Color.Silver;
                pictureBox8.BackColor = Color.Silver;
                pictureBox9.BackColor = Color.Silver;
                pictureBox10.BackColor = Color.Silver;
                pictureBox11.BackColor = Color.Silver;
                pictureBox12.BackColor = Color.Silver; 
                pictureBox13.BackColor = Color.Silver;
                pictureBox14.BackColor = Color.Silver;
                pictureBox15.BackColor = Color.Silver;
                pictureBox16.BackColor = Color.Silver;
            }
            else if (calistir.Text == "RUN")
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                textBox20.Clear();
                textBox21.Clear();
                textBox22.Clear();
                textBox23.Clear();
                textBox24.Clear();

                pictureBox1.BackColor = Color.Silver;
                pictureBox2.BackColor = Color.Silver;
                pictureBox3.BackColor = Color.Silver;
                pictureBox4.BackColor = Color.Silver;
                pictureBox5.BackColor = Color.Silver;
                pictureBox6.BackColor = Color.Silver;
                pictureBox7.BackColor = Color.Silver;
                pictureBox8.BackColor = Color.Silver;
                pictureBox9.BackColor = Color.Silver;
                pictureBox10.BackColor = Color.Silver;
                pictureBox11.BackColor = Color.Silver;
                pictureBox12.BackColor = Color.Silver;
                pictureBox13.BackColor = Color.Silver;
                pictureBox14.BackColor = Color.Silver;
                pictureBox15.BackColor = Color.Silver;
                pictureBox16.BackColor = Color.Silver;
            }
            else
                this.Close();
        }

       

        private void calistir_Click_1(object sender, EventArgs e)
        {
           
            if (calistir.Text == "ÇALIŞTIR")
            {
                calistir.Text = "DURDUR";
                secilimodel.Text = "Model:\t" + tipler.Text;
                secilibaud.Text = "Baudrate:\t" + baudratee.Text;
                seciliport.Text = "Port:\t" + seriport.Text;
                ArduinoBaglantisi();
                portt.DataReceived += new SerialDataReceivedEventHandler(portt_DataReceived);
            }

            else if (calistir.Text == "DURDUR")
            {
                portt.Close();
                calistir.Text = "ÇALIŞTIR";
            }
            else if (calistir.Text == "RUN")
            {
                calistir.Text = "STOP";
                secilimodel.Text = "Model:\t" + tipler.Text;
                secilibaud.Text = "Baudrate:\t" + baudratee.Text;
                seciliport.Text = "Port:\t" + seriport.Text;
                ArduinoBaglantisi();
                portt.DataReceived += new SerialDataReceivedEventHandler(portt_DataReceived);
            }

            else if (calistir.Text == "STOP")
            {
                portt.Close();
                calistir.Text = "RUN";
            }
        }

        private void kapat_Click_1(object sender, EventArgs e)
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration("Arduino.exe");
                config.AppSettings.Settings.Remove("model");
                config.AppSettings.Settings.Add("model", tipler.Text);

                config.AppSettings.Settings.Remove("baud");
                config.AppSettings.Settings.Add("baud", baudratee.Text);

                config.AppSettings.Settings.Remove("port");
                config.AppSettings.Settings.Add("port", seriport.Text);
                 
                config.AppSettings.Settings.Remove("led1");
                config.AppSettings.Settings.Add("led1", textBox1.Text);

                config.AppSettings.Settings.Remove("HIGH1");
                config.AppSettings.Settings.Add("HIGH1", textBox2.Text);

                config.AppSettings.Settings.Remove("LOW1");
                config.AppSettings.Settings.Add("LOW1", textBox3.Text);

                config.AppSettings.Settings.Remove("LOW2");
                config.AppSettings.Settings.Add("LOW2", textBox4.Text);

                config.AppSettings.Settings.Remove("HIGH2");
                config.AppSettings.Settings.Add("HIGH2", textBox5.Text);

                config.AppSettings.Settings.Remove("led2");
                config.AppSettings.Settings.Add("led2", textBox6.Text);

                config.AppSettings.Settings.Remove("LOW3");
                config.AppSettings.Settings.Add("LOW3", textBox7.Text);

                config.AppSettings.Settings.Remove("HIGH3");
                config.AppSettings.Settings.Add("HIGH3", textBox8.Text);

                config.AppSettings.Settings.Remove("relay");
                config.AppSettings.Settings.Add("relay", textBox9.Text);

            config.AppSettings.Settings.Remove("led3");
            config.AppSettings.Settings.Add("led3", textBox10.Text);

            config.AppSettings.Settings.Remove("HIGH4");
            config.AppSettings.Settings.Add("HIGH4", textBox11.Text);

            config.AppSettings.Settings.Remove("LOW4");
            config.AppSettings.Settings.Add("LOW4", textBox12.Text);

            config.AppSettings.Settings.Remove("led4");
            config.AppSettings.Settings.Add("led4", textBox13.Text);

            config.AppSettings.Settings.Remove("HIGH5");
            config.AppSettings.Settings.Add("HIGH5", textBox14.Text);

            config.AppSettings.Settings.Remove("LOW5");
            config.AppSettings.Settings.Add("LOW5", textBox15.Text);

            config.AppSettings.Settings.Remove("led5");
            config.AppSettings.Settings.Add("led5", textBox16.Text);

            config.AppSettings.Settings.Remove("HIGH6");
            config.AppSettings.Settings.Add("HIGH6", textBox17.Text);

            config.AppSettings.Settings.Remove("LOW6");
            config.AppSettings.Settings.Add("LOW6", textBox18.Text);

            config.AppSettings.Settings.Remove("led6");
            config.AppSettings.Settings.Add("led6", textBox19.Text);

            config.AppSettings.Settings.Remove("HIGH7");
            config.AppSettings.Settings.Add("HIGH7", textBox20.Text);

            config.AppSettings.Settings.Remove("LOW7");
            config.AppSettings.Settings.Add("LOW7", textBox21.Text);

            config.AppSettings.Settings.Remove("led7");
            config.AppSettings.Settings.Add("led7", textBox22.Text);

            config.AppSettings.Settings.Remove("HIGH8");
            config.AppSettings.Settings.Add("HIGH8", textBox23.Text);

            config.AppSettings.Settings.Remove("LOW8");
            config.AppSettings.Settings.Add("LOW8", textBox24.Text);
            config.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection("appSettings");
                config.Save();
           
            this.Close();
        }

        
        private void metinleriYazdir() 
        {
            if (Properties.Settings.Default.dil == "İngilizce")
                Localization.Culture = new CultureInfo("en-US");
            else if (Properties.Settings.Default.dil == "Türkçe")
                Localization.Culture = new CultureInfo("");
            tip.Text = Localization.tip;
            baudrate.Text = Localization.baudrate;
            port.Text = Localization.port;
            calistir.Text = Localization.calistir;
            kapat.Text = Localization.kapat;
            temizle.Text = Localization.temizle;
            baglanti_bilgisi.Text = Localization.bilgi;
            dosyaToolStripMenuItem.Text = Localization.dosya;
            türkçeToolStripMenuItem.Text = Localization.türkçe;
            ingilizceToolStripMenuItem.Text = Localization.ingilizce;
            yardımToolStripMenuItem.Text = Localization.yardım;
            yardımıAçınToolStripMenuItem.Text = Localization.yardımaç;
            yardımToolStripMenuItem1.Text = Localization.yardım1;
            
        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            tarih_bilgisi.Text = DateTime.Now.ToString();
        }

        private void türkçeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Localization.Culture = new CultureInfo("");
            Properties.Settings.Default.dil = "Türkçe";
            Properties.Settings.Default.Save();
            metinleriYazdir();
        }

        private void ingilizceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Localization.Culture = new CultureInfo("en-US");
            Properties.Settings.Default.dil = "İngilizce";
            Properties.Settings.Default.Save();
            metinleriYazdir();
        }

        private void yardımıAçınToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mesebilisim.com/tr/");
        }

        private void yardımToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            AboutBox2 hakkinda = new AboutBox2();
            hakkinda.Show();
        }
        private void picturebox_sekil()
        {
            System.Drawing.Drawing2D.GraphicsPath gp1 = new System.Drawing.Drawing2D.GraphicsPath();
            gp1.AddEllipse(0, 0, pictureBox1.Width - 2, pictureBox1.Height - 2);
            Region rg1 = new Region(gp1);
            pictureBox1.Region = rg1;


            System.Drawing.Drawing2D.GraphicsPath gp2 = new System.Drawing.Drawing2D.GraphicsPath();
            gp2.AddEllipse(0, 0, pictureBox2.Width - 2, pictureBox2.Height - 2);
            Region rg2 = new Region(gp2);
            pictureBox2.Region = rg2;

            System.Drawing.Drawing2D.GraphicsPath gp3 = new System.Drawing.Drawing2D.GraphicsPath();
            gp3.AddEllipse(0, 0, pictureBox3.Width - 2, pictureBox3.Height - 2);
            Region rg3 = new Region(gp3);
            pictureBox3.Region = rg3;

            System.Drawing.Drawing2D.GraphicsPath gp4 = new System.Drawing.Drawing2D.GraphicsPath();
            gp4.AddEllipse(0, 0, pictureBox4.Width - 2, pictureBox4.Height - 2);
            Region rg4 = new Region(gp4);
            pictureBox4.Region = rg4;

            System.Drawing.Drawing2D.GraphicsPath gp5 = new System.Drawing.Drawing2D.GraphicsPath();
            gp5.AddEllipse(0, 0, pictureBox5.Width - 2, pictureBox5.Height - 2);
            Region rg5 = new Region(gp5);
            pictureBox5.Region = rg5;

            System.Drawing.Drawing2D.GraphicsPath gp6 = new System.Drawing.Drawing2D.GraphicsPath();
            gp6.AddEllipse(0, 0, pictureBox6.Width - 2, pictureBox6.Height - 2);
            Region rg6 = new Region(gp6);
            pictureBox6.Region = rg6;

            System.Drawing.Drawing2D.GraphicsPath gp7 = new System.Drawing.Drawing2D.GraphicsPath();
            gp7.AddEllipse(0, 0, pictureBox7.Width - 2, pictureBox7.Height - 2);
            Region rg7 = new Region(gp7);
            pictureBox7.Region = rg7;

            System.Drawing.Drawing2D.GraphicsPath gp8 = new System.Drawing.Drawing2D.GraphicsPath();
            gp8.AddEllipse(0, 0, pictureBox8.Width - 2, pictureBox8.Height - 2);
            Region rg8 = new Region(gp8);
            pictureBox8.Region = rg8;

            System.Drawing.Drawing2D.GraphicsPath gp9 = new System.Drawing.Drawing2D.GraphicsPath();
            gp9.AddEllipse(0, 0, pictureBox9.Width - 2, pictureBox9.Height - 2);
            Region rg9 = new Region(gp9);
            pictureBox9.Region = rg9;

            System.Drawing.Drawing2D.GraphicsPath gp10 = new System.Drawing.Drawing2D.GraphicsPath();
            gp10.AddEllipse(0, 0, pictureBox10.Width - 2, pictureBox10.Height - 2);
            Region rg10 = new Region(gp10);
            pictureBox10.Region = rg10;
          
            System.Drawing.Drawing2D.GraphicsPath gp11 = new System.Drawing.Drawing2D.GraphicsPath();
            gp11.AddEllipse(0, 0, pictureBox11.Width - 2, pictureBox11.Height - 2);
            Region rg11 = new Region(gp11);
            pictureBox11.Region = rg11;

            System.Drawing.Drawing2D.GraphicsPath gp12 = new System.Drawing.Drawing2D.GraphicsPath();
            gp12.AddEllipse(0, 0, pictureBox12.Width - 2, pictureBox12.Height - 2);
            Region rg12 = new Region(gp12);
            pictureBox12.Region = rg12;

            System.Drawing.Drawing2D.GraphicsPath gp13 = new System.Drawing.Drawing2D.GraphicsPath();
            gp13.AddEllipse(0, 0, pictureBox13.Width - 2, pictureBox13.Height - 2);
            Region rg13 = new Region(gp13);
            pictureBox13.Region = rg13;

            System.Drawing.Drawing2D.GraphicsPath gp14 = new System.Drawing.Drawing2D.GraphicsPath();
            gp14.AddEllipse(0, 0, pictureBox14.Width - 2, pictureBox14.Height - 2);
            Region rg14 = new Region(gp14);
            pictureBox14.Region = rg14;

            System.Drawing.Drawing2D.GraphicsPath gp15 = new System.Drawing.Drawing2D.GraphicsPath();
            gp15.AddEllipse(0, 0, pictureBox15.Width - 2, pictureBox15.Height - 2);
            Region rg15 = new Region(gp15);
            pictureBox15.Region = rg15;

            System.Drawing.Drawing2D.GraphicsPath gp16 = new System.Drawing.Drawing2D.GraphicsPath();
            gp16.AddEllipse(0, 0, pictureBox16.Width - 2, pictureBox16.Height - 2);
            Region rg16 = new Region(gp16);
            pictureBox16.Region = rg16;
        }
        private void textbox_listeleme()
        {
            string[] degerler = { "led1Pin", "led2Pin", "LOW", "HIGH", "relayPin" };
            AutoCompleteStringCollection deger = new AutoCompleteStringCollection();
            deger.AddRange(degerler);
            textBox1.AutoCompleteCustomSource = deger;
            textBox2.AutoCompleteCustomSource = deger;
            textBox3.AutoCompleteCustomSource = deger;
            textBox4.AutoCompleteCustomSource = deger;
            textBox5.AutoCompleteCustomSource = deger;
            textBox6.AutoCompleteCustomSource = deger;
            textBox7.AutoCompleteCustomSource = deger;
            textBox8.AutoCompleteCustomSource = deger;
            textBox9.AutoCompleteCustomSource = deger;
            textBox10.AutoCompleteCustomSource = deger;
            textBox11.AutoCompleteCustomSource = deger;
            textBox12.AutoCompleteCustomSource = deger;
            textBox13.AutoCompleteCustomSource = deger;
            textBox14.AutoCompleteCustomSource = deger;
            textBox15.AutoCompleteCustomSource = deger;
            textBox16.AutoCompleteCustomSource = deger;
            textBox17.AutoCompleteCustomSource = deger;
            textBox18.AutoCompleteCustomSource = deger;
            textBox19.AutoCompleteCustomSource = deger;
            textBox20.AutoCompleteCustomSource = deger;
            textBox21.AutoCompleteCustomSource = deger;
            textBox22.AutoCompleteCustomSource = deger;
            textBox23.AutoCompleteCustomSource = deger;
            textBox24.AutoCompleteCustomSource = deger;

        }
        private void p1_p2()
        {
            if (gelenler[0] == textBox1.Text)
            {
                if (gelenler[1] == textBox2.Text)
                    pictureBox1.BackColor = p1;

                else if (gelenler[1] == textBox3.Text)
                    pictureBox2.BackColor = p2;

            }
        }
        private void p3_p4()
        {
               if (gelenler[3] == textBox6.Text)
            {
                if (gelenler[4] == textBox5.Text)
                    pictureBox4.BackColor = p4;
                else if (gelenler[4] == textBox4.Text)
                    pictureBox3.BackColor = p3;

            }
        }
        private void p5_p6()
        {
            if (gelenler[6] == textBox9.Text)
            {
                if (gelenler[7] == textBox8.Text)
                    pictureBox6.BackColor = p6;
                else if (gelenler[7] == textBox7.Text)
                    pictureBox5.BackColor = p5;

            }
        }
        private void p7_p8()
        {
            if (gelenler[9] == textBox10.Text)
            {
                if (gelenler[10] == textBox11.Text)
                    pictureBox7.BackColor = p7;
                else if (gelenler[10] == textBox12.Text)
                    pictureBox8.BackColor = p8;
            }
        }
        private void p9_p10()
        {
            if (gelenler[12] == textBox13.Text)
            {
                if (gelenler[13] == textBox14.Text)
                    pictureBox9.BackColor = p9;
                else if (gelenler[13] == textBox15.Text)
                    pictureBox10.BackColor = p10;
            }
        }
        private void p11_p12()
        {
            if (gelenler[15] == textBox16.Text)
            {
                if (gelenler[16] == textBox17.Text)
                    pictureBox11.BackColor = p11;
                else if (gelenler[16] == textBox18.Text)
                    pictureBox12.BackColor = p12;
            }
        }
        private void p13_p14()
        {
              if (gelenler[18] == textBox19.Text)
            {
                if (gelenler[19] == textBox20.Text)
                    pictureBox13.BackColor = p13;
                else if (gelenler[19] == textBox21.Text)
                    pictureBox14.BackColor = p14;
            }

        }
        private void p15_p16()
        {
             if (gelenler[21] == textBox22.Text)
            {
                if (gelenler[22] == textBox23.Text)
                    pictureBox15.BackColor = p15;
                else if (gelenler[22] == textBox24.Text)
                    pictureBox16.BackColor = p16;
            }
        }
    }
   
    }
   

