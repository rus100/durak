using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Durak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
        }
        Rules rul = new Rules();
        int level =2;
        Logic log = new Logic();
        bool otbilsya_pc = false;
        bool neotbilsya_igrok = false;
        int k = 0;
        int c;
        int nomer;
        private void button1_Click(object sender, EventArgs e)//БЕРУ
        {
            if (rul.win1 != true)
            {
                if (rul.hodpc == true)
                {
                    if (neotbilsya_igrok)
                    {
                        rul.karti_igrok.AddRange(rul.pole);
                        rul.pole.Clear();
                        rul.nachalo_igri = false;
                        anim_pole();
                        rul.razdacha();
                        anim_kart();
                        rul.hodpc = true;
                        rul.win();
                    }
                    rul.poisk_kart_for_hod_pc();

                    if (level == 1) { k = log.nomer_karti(rul); }
                    if (level == 2) { k = log.nomer_karti1(rul); }
                    if (rul.vozmojnye_karti_pc.Count > 0)
                    {
                        rul.pole.Add(rul.vozmojnye_karti_pc[k]);
                        anim_pole();
                        rul.karti_pc.Remove(rul.vozmojnye_karti_pc[k]);
                        anim_kart();
                        rul.poisk_kart_for_hod_igrok();
                    }
                    else
                    {
                        MessageBox.Show("Бита");
                        rul.nachalo_igri = false;
                        log.uchet_bita(rul);
                        rul.pole.Clear();
                        anim_pole();
                        rul.razdacha();
                        anim_kart();
                        rul.hodpc = false;
                        rul.win();
                    }
                    rul.poisk_kart_for_hod_igrok();
                }
            }
            
           
        }
        private void button2_Click(object sender, EventArgs e)//БИТА
        {
            if (rul.win1 != true)
            {
                if (rul.hodpc == false)
                {
                    if (otbilsya_pc)
                    {
                        rul.nachalo_igri = false;
                        log.uchet_bita(rul);
                        rul.pole.Clear();
                        anim_pole();
                        rul.razdacha();
                        anim_kart();
                        rul.hodpc = true;
                    }
                }
                rul.poisk_kart_for_hod_igrok();
                rul.poisk_kart_for_hod_pc();
                if (level == 1) { k = log.nomer_karti(rul); }
                if (level == 2) { k = log.nomer_karti1(rul); }
                if (rul.vozmojnye_karti_pc.Count > 0)
                {
                    rul.pole.Add(rul.vozmojnye_karti_pc[k]);
                    anim_pole();
                    rul.karti_pc.Remove(rul.vozmojnye_karti_pc[k]);
                    anim_kart();
                    rul.poisk_kart_for_hod_igrok();
                    rul.win();
                }
                else
                {
                    MessageBox.Show("Бита");
                    rul.nachalo_igri = false;
                    log.uchet_bita(rul);
                    rul.pole.Clear();
                    anim_pole();
                    rul.razdacha();
                    anim_kart();
                    rul.hodpc = false;
                    rul.win();
                }
                rul.poisk_kart_for_hod_igrok();
            }
            
           

        }
        string[] sootvet = new string[36];

        void anim_pole()
        {

            pictureBox3.Controls.Clear();

            for (int i = 0; i < rul.pole.Count; i++)
            {
                Panel pn2 = new Panel();
                if (rul.hodpc == false)
                {
                    if (i % 2 == 0)
                    {
                        pn2.Left = (i / 2) * 75;
                        pn2.Width = 71;
                        pn2.Height = 96;
                        pn2.Top = 50;
                    }
                    else
                    {
                        pn2.Left = ((i - 1) / 2) * 75;
                        pn2.Width = 71;
                        pn2.Height = 96;
                        pn2.Top = 0;
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        pn2.Left = (i / 2) * 75;
                        pn2.Width = 71;
                        pn2.Height = 96;
                        pn2.Top = 0;
                    }
                    else
                    {
                        pn2.Left = ((i - 1) / 2) * 75;
                        pn2.Width = 71;
                        pn2.Height = 96;
                        pn2.Top = 50;
                    }

                }

                for (int j = 0; j < 36; j++)
                {

                    if (sootvet[j].Contains(rul.pole[i] + " "))
                    {
                        string fn = sootvet[j].Substring(rul.pole[i].Length);
                        Image bmp = Image.FromFile(fn);

                        pn2.BackgroundImage = bmp;
                        pictureBox3.Controls.Add(pn2);
                    }
                }
                pictureBox3.Controls.Add(pn2);

            }
        }
        void anim_kart()
        {
            pictureBox1.Controls.Clear();
            pictureBox2.Controls.Clear();
            for (int i = 0; i < rul.karti_pc.Count; i++)
            {
                Panel pn1 = new Panel();
                pn1.Left = i * (500 - 71) / rul.karti_pc.Count;
                pn1.Width = 71;
                pn1.Height = 96;
                pn1.Top = 0;
                Image bmp = Image.FromFile(Application.StartupPath + "/kard/" + "single.bmp");
                pn1.BackgroundImage = bmp;
                pictureBox2.Controls.Add(pn1);
            }
            for (int i = 0; i < rul.karti_igrok.Count; i++)
            {
                Panel pn = new Panel();
                pn.Left = i * (500 - 71) / rul.karti_igrok.Count;
                pn.Width = 71;
                pn.Height = 96;
                pn.Top = 14;
                for (int j = 0; j < 36; j++)
                {
                    if (sootvet[j].Contains(rul.karti_igrok[i] + " "))
                    {
                        string fn = sootvet[j].Substring(rul.karti_igrok[i].Length);
                        Image bmp = Image.FromFile(fn);
                        pn.BackgroundImage = bmp;
                        pn.MouseDoubleClick += pn_MouseDoubleClick;
                        pn.MouseEnter += pn_MouseEnter;
                        pictureBox1.Controls.Add(pn);
                    }
                }
            }
        }
        private void pn_MouseEnter(object sender, EventArgs e)
        {
            rul.poisk_kart_for_hod_igrok();
            karti_nelzya();
        
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rul.nachalo_igri = true;
            rul.kolodi.Clear();
            rul.karti_pc.Clear();
            rul.karti_igrok.Clear();
            pictureBox1.Controls.Clear();
            pictureBox2.Controls.Clear();
            pictureBox3.Controls.Clear();
            rul.kolodi_init();
            rul.win1 = false;
            button1.Enabled = false;
            button2.Enabled = false;
            rul.hodpc=false;
            rul.poisk_kart_for_hod_igrok();
            label1.Text = "Козырь";
            string filename1 = Application.StartupPath;
            for (int i = 0; i < 36; i++)
            {
                string filename = "";
                switch (i / 9)
                {
                    case 0:
                        filename = filename1 + "\\kard\\2-" + ((i - (i / 9) * 9) + 6).ToString() + ".bmp";
                        sootvet[i] = rul.kolodi[i] + " " + filename;
                        break;
                    case 1:
                        filename = filename1 + "\\kard\\3-" + ((i - (i / 9) * 9) + 6).ToString() + ".bmp";
                        sootvet[i] = rul.kolodi[i] + " " + filename;
                        break;
                    case 2:
                        filename = filename1 + "\\kard\\1-" + ((i - (i / 9) * 9) + 6).ToString() + ".bmp";
                        sootvet[i] = rul.kolodi[i] + " " + filename;
                        break;
                    case 3:
                        filename = filename1 + "\\kard\\4-" + ((i - (i / 9) * 9) + 6).ToString() + ".bmp";
                        sootvet[i] = rul.kolodi[i] + " " + filename;
                        break;
                }
            }

            rul.peremes_kolodi();
            rul.razdacha();
            anim_kart();
            int kolvokozirpc = 0;
            int kolvokozirigrok = 0;
            for (int i = 0; i < rul.karti_igrok.Count; i++)
            {
                if (rul.karti_igrok[i][rul.karti_igrok[i].Length - 1].ToString() == rul.kozir)
                {
                    kolvokozirigrok++;

                }
                if (rul.karti_pc[i][rul.karti_pc[i].Length - 1].ToString() == rul.kozir)
                {
                    kolvokozirpc++;

                }

            }
            if ((kolvokozirigrok == 0))
            {
                rul.hodpc = false;

            }
            if ((kolvokozirpc == 0) && (kolvokozirigrok > 0))
            {
                rul.hodpc = true;

            }
            int minkozirpc = 100;
            int minkozirigrok = 100;
            if ((kolvokozirpc > 0) && (kolvokozirigrok > 0))
            {
                log.cennost_kozir(rul);
                log.cennost_kozir_igrok(rul);
                for (int i = 0; i < log.cennost_kart_pc.Count; i++)
                {
                    if (minkozirpc <= log.cennost_kart_pc[i])
                    {
                        minkozirpc = log.cennost_kart_pc[i];

                    }
                }



                for (int i = 0; i < log.cennost_kart_igrok.Count; i++)
                {
                    if (minkozirigrok <= log.cennost_kart_igrok[i])
                    {
                        minkozirpc = log.cennost_kart_igrok[i];

                    } 
                }
            }
            string minkozir = "";
            if (minkozirpc < minkozirigrok) {
                timer1.Start();
                timer1.Interval = 1000;
                rul.hodpc = true;
                if (minkozirpc <= 10) {
                    minkozir = minkozirpc.ToString() + rul.kozir;
                
                }
                if (minkozirpc > 10) {
                    switch (minkozirpc) {
                        case 11:
                            minkozir = "J" + rul.kozir;
                            break;
                        case 12:
                            minkozir = "Q" + rul.kozir;
                            break;
                        case 13:
                            minkozir = "K" + rul.kozir;
                            break;
                        
                    }
                
                }
                int i2 = 0;
                for (int i = 0; i < rul.karti_pc.Count; i++) {
                    if (rul.karti_pc[i] == minkozir) { 
                     for (int j = 0; j < 36; j++)
                {
                    if (sootvet[j].Contains(minkozir + " "))
                    {
                        string fn = sootvet[j].Substring(minkozir.Length);
                        Image bmp = Image.FromFile(fn);
                        pictureBox2.Controls[i].BackgroundImage = bmp;
                        i2 = i;
                    }
                    

                }
                    
                    }

                
                }
                  if (time >= 10) {
                    timer1.Stop();
                    Image bmp = Image.FromFile(Application.StartupPath + "/kard/" + "single.bmp");
                    pictureBox2.Controls[i2].BackgroundImage = bmp;   
                }
               
            }
                    for (int j = 0; j < 36; j++)
                    {
                        if (sootvet[j].Contains(rul.d + " "))
                        {
                            string fn = sootvet[j].Substring(rul.d.Length);
                            Image bmp = Image.FromFile(fn);
                            pictureBox4.BackgroundImage = bmp;
                        }
                    }
                    label2.Text = "Карт в колоде" + " " + rul.kolodi.Count.ToString();
                    if (rul.hodpc == true)
                    {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        rul.poisk_kart_for_hod_pc();
                        if (level == 1) { k = log.nomer_karti(rul); }
                        if (level == 2) { k = log.nomer_karti1(rul); }
                        if (rul.vozmojnye_karti_pc.Count > 0)
                        {
                            rul.pole.Add(rul.vozmojnye_karti_pc[k]);
                            anim_pole();
                            rul.karti_pc.Remove(rul.vozmojnye_karti_pc[k]);
                            anim_kart();
                            rul.poisk_kart_for_hod_igrok();
                            neotbilsya_igrok = true;
                            button1.Enabled = true;
                            button2.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Бита");
                            rul.nachalo_igri = false;
                            rul.pole.Clear();
                            anim_pole();
                            rul.razdacha();
                            anim_kart();
                            rul.hodpc = false;
                            button1.Enabled = false;
                            button2.Enabled = false;
                        }
                    }
                }
        void karti_nelzya() {

            for (int i = 0; i < rul.karti_igrok.Count; i++) {
                if (rul.vozmojnye_karti_igrok.Contains(rul.karti_igrok[i]))
                {
                    pictureBox1.Controls[i].Enabled = true;

                }
                else { pictureBox1.Controls[i].Enabled = false ; }
            
            }
        
        
        }
        private void pn_MouseDoubleClick(object sender, MouseEventArgs e) //не изменять
        {
            
            if (rul.win1 != true) {
                if (bolshe6 == false)
                {
                    nomer = pictureBox1.Controls.GetChildIndex((Control)sender);

                    rul.poisk_kart_for_hod_igrok();
                    if (rul.hodpc == false)
                    {
                        rul.poisk_kart_for_hod_igrok();
                       
                        if (rul.vozmojnye_karti_igrok.Count > 0)
                        {     
                            if (rul.vozmojnye_karti_igrok.Contains(rul.karti_igrok[nomer]))
                            {
                                rul.tekych_card = rul.karti_igrok[nomer];
                                rul.pole.Add(rul.karti_igrok[nomer]);
                                rul.karti_igrok.RemoveAt(nomer);
                                anim_pole();
                                anim_kart();
                            }
                           
                        }
                        else
                        {
                            MessageBox.Show("Бита");
                            rul.nachalo_igri = false;
                            log.uchet_bita(rul);
                            rul.pole.Clear();
                            anim_pole();
                            rul.razdacha();
                            anim_kart();
                            rul.hodpc = true;
                        }
                        rul.poisk_kart_for_hod_pc();
                        if (level == 1) {k = log.nomer_karti(rul); }
                        if (level == 2) { k = log.nomer_karti1(rul); }
                       if ((rul.vozmojnye_karti_pc.Count > 0)&&(log.nevzyat))
                        {     rul.pole.Add(rul.vozmojnye_karti_pc[k]);
                            anim_pole();
                            rul.karti_pc.Remove(rul.vozmojnye_karti_pc[k]);
                            anim_kart();
                            
                            otbilsya_pc = true;
                            button1.Enabled = false;
                            button2.Enabled = true;
                            rul.win();
                        }
                        else
                        {
                            MessageBox.Show("Беру");//берет ПК
                            rul.nachalo_igri = false;
                            if (log.nevzyat == false) {
                                rul.karti_pc.AddRange(rul.pole);
                                rul.pole.Clear();
                                
                            }
                            anim_pole();
                            rul.razdacha();
                            anim_kart();
                            rul.hodpc = false;
                            button1.Enabled = false;
                            button2.Enabled = false;   
                           rul.win();
                        }
                    }
                    else
                    {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        rul.poisk_kart_for_hod_igrok();
                        //nomer=pictureBox1.Controls.GetChildIndex((Control)sender);
                        
                        if (rul.vozmojnye_karti_igrok.Count > 0)
                        {
                            if (rul.vozmojnye_karti_igrok.Contains(rul.karti_igrok[nomer]))
                            {
                                rul.pole.Add(rul.karti_igrok[nomer]);
                                anim_pole();
                                rul.karti_igrok.RemoveAt(nomer);
                                anim_kart();
                                rul.win();
                            }
                        
                        }
                        else
                        {
                            MessageBox.Show("Беру"); //беру я
                            rul.nachalo_igri = false;
                            anim_pole();
                            rul.razdacha();
                            anim_kart();
                            rul.hodpc = true;
                            button1.Enabled = false;
                            button2.Enabled = false;
                            rul.win();
                        }
                        rul.poisk_kart_for_hod_pc();
                        // neotbilsya_igrok = true;
                        if (level == 1) { k = log.nomer_karti(rul); }
                        if (level == 2) { k = log.nomer_karti1(rul); }
                        if ((rul.vozmojnye_karti_pc.Count > 0)&&(log.nebitii))
                        {
                            rul.pole.Add(rul.vozmojnye_karti_pc[k]);
                            anim_pole();
                            rul.karti_pc.Remove(rul.vozmojnye_karti_pc[k]);
                            anim_kart();
                            rul.poisk_kart_for_hod_igrok();
                          
                            button1.Enabled = true;
                            button2.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Бита");
                            rul.nachalo_igri = false;
                            log.uchet_bita(rul);
                            rul.pole.Clear();
                            anim_pole();
                            rul.razdacha();
                            anim_kart();
                            rul.hodpc = false;
                            button1.Enabled = false;
                            button2.Enabled = false;
                        }
                        rul.poisk_kart_for_hod_igrok();
                    }
               
                }
                label2.Text = "Карт в колоде" + " " + rul.kolodi.Count.ToString(); }
            if (rul.kolodi.Count == 0)
            {
                pictureBox4.BackgroundImage = null;
                label1.Text = "";
            }
           
            
        }
        bool bolshe6 = false;
        private void pictureBox3_ControlAdded(object sender, ControlEventArgs e)
        {

           
            if (rul.hodpc == false)
            {
                if (rul.pole.Count < 12)
                {
                    bolshe6 = false;
                }
                else { bolshe6 = true; }
            }
            else
            {
                if (rul.pole.Count < 12)
                {
                    bolshe6 = false;
                }
                else { bolshe6 = true; }
            }
            label2.Text = "Карт в колоде" + " " + rul.kolodi.Count.ToString();
            if (rul.hodpc == true)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                neotbilsya_igrok = true;
                if (rul.vozmojnye_karti_pc.Count > 0)
                {
                    
                    c = k;
                    rul.tekych_card = rul.vozmojnye_karti_pc[k];
                   
                }
            }
            else
            {
              
                button1.Enabled = false;
                button2.Enabled = false;
            }
            
        }
       

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = 1;
            easyToolStripMenuItem.Checked = true;
            hardToolStripMenuItem.Checked = false;
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = 2;
            easyToolStripMenuItem.Checked = false;
            hardToolStripMenuItem.Checked = true;

        }
        int time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор игры инженер-электрик Ахметов Р.Р.");
        }

       

        
       
    }
}
