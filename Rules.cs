using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Durak
{
    
     public class Rules
        {
            public bool win1 = false;
            public string kozir = "";
            public bool bito = false;
            public bool hodpc = false;
            public List<string> kolodi = new List<string>();
            public string[] peremes_kolod = new string[36];
            public List<string> karti_igrok = new List<string>();
            public List<string> karti_pc = new List<string>();
            public List<string> pole = new List<string>();
            public bool nachalo_igri = false;
            public string tekych_card = "";
            public bool podkin = false;
            public List<string> vozmojnye_karti_pc = new List<string>();
            public List<string> vozmojnye_karti_igrok = new List<string>();
            public bool bita_pc = false;
            public bool beru_pc = false;
            public bool bita_igrok = false;
            public bool beru_igrok = false;
            public string d = "";
            public bool biet(string kardpc, string kardigrok, bool hodpc) //проверка бьет ли одна карта другую в зависимости от хода
            {
                bito = false;
                string karta_igrok = "";
                string karta_pc = "";
                string mast_igrok = "";
                string mast_pc = "";

                mast_pc = kardpc[kardpc.Length - 1].ToString(); //масть карты пк
                mast_igrok = kardigrok[kardigrok.Length - 1].ToString();//масть карты игрока
                karta_pc = kardpc.Substring(0, kardpc.Length - 1);//сама карта пк
                karta_igrok = kardigrok.Substring(0, kardigrok.Length - 1); //сама карта игрока
                if (hodpc == true) //ходит пк на меня
                {
                    if ((mast_igrok.ToString() == kozir) && (mast_pc.ToString() != kozir))//козырь
                    {
                        bito = true;
                    }
                    if (mast_igrok.ToString() == mast_pc.ToString()) //одной масти
                    {
                        if ((karta_igrok.ToString() != "J") && (karta_igrok.ToString() != "Q") && (karta_igrok.ToString() != "K") && (karta_igrok.ToString() != "A"))
                        {
                            if ((karta_pc.ToString() != "J") && (karta_pc.ToString() != "Q") && (karta_pc.ToString() != "K") && (karta_pc.ToString() != "A"))
                            {
                                if (int.Parse(karta_igrok.ToString()) > int.Parse(karta_pc.ToString()))
                                {
                                    bito = true;

                                }
                            }
                        }
                        if ((karta_igrok.ToString() == "J") || (karta_igrok.ToString() == "Q") || (karta_igrok.ToString() == "K") || (karta_igrok.ToString() == "A"))
                        {
                            if ((karta_pc.ToString() != "J") && (karta_pc.ToString() != "Q") && (karta_pc.ToString() != "K") && (karta_pc.ToString() != "A"))
                            {
                                bito = true;
                            }
                        }
                        if ((karta_igrok.ToString() == "J") || (karta_igrok.ToString() == "Q") || (karta_igrok.ToString() == "K") || (karta_igrok.ToString() == "A"))
                        {
                            if ((karta_pc.ToString() == "J") || (karta_pc.ToString() == "Q") || (karta_pc.ToString() == "K") || (karta_pc.ToString() == "A"))
                            {
                                if (karta_igrok.ToString() == "Q")
                                {
                                    if (karta_pc.ToString() == "J")
                                    {
                                        bito = true;
                                    }
                                }
                                if (karta_igrok.ToString() == "K")
                                {
                                    if ((karta_pc.ToString() == "J") || (karta_pc.ToString() == "Q"))
                                    {
                                        bito = true;
                                    }
                                }
                                if (karta_igrok.ToString() == "A")
                                {
                                    if ((karta_pc.ToString() == "J") || (karta_pc.ToString() == "Q") || (karta_pc.ToString() == "K"))
                                    {
                                        bito = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (hodpc == false)//ходит игрок на пк;
                {
                    if ((mast_igrok.ToString() != kozir) && (mast_pc.ToString() == kozir))//у ПК козырь
                    {
                        bito = true;
                    }
                    if (mast_igrok.ToString() == mast_pc.ToString())//одной масти
                    {
                        if ((karta_igrok.ToString() != "J") && (karta_igrok.ToString() != "Q") && (karta_igrok.ToString() != "K") && (karta_igrok.ToString() != "A"))
                        {
                            if ((karta_pc.ToString() != "J") && (karta_pc.ToString() != "Q") && (kardpc[0].ToString() != "K") && (karta_pc.ToString() != "A"))
                            {
                                if (int.Parse(karta_igrok.ToString()) < int.Parse(karta_pc.ToString()))
                                {
                                    bito = true;
                                }
                            }
                        }
                        if ((karta_pc.ToString() == "J") || (karta_pc.ToString() == "Q") || (karta_pc.ToString() == "K") || (karta_pc.ToString() == "A"))
                        {
                            if ((karta_igrok.ToString() != "J") && (karta_igrok.ToString() != "Q") && (karta_igrok.ToString() != "K") && (karta_igrok.ToString() != "A"))
                            {
                                bito = true;
                            }
                        }
                        if ((karta_igrok.ToString() == "J") || (karta_igrok.ToString() == "Q") || (karta_igrok.ToString() == "K") || (karta_igrok.ToString() == "A"))
                        {
                            if ((karta_pc.ToString() == "J") || (karta_pc.ToString() == "Q") || (karta_pc.ToString() == "K") || (karta_pc.ToString() == "A"))
                            {
                                if (karta_pc.ToString() == "Q")
                                {
                                    if (karta_igrok.ToString() == "J")
                                    {
                                        bito = true;
                                    }
                                }
                                if (karta_pc.ToString() == "K")
                                {
                                    if ((karta_igrok.ToString() == "J") || (karta_igrok.ToString() == "Q"))
                                    {
                                        bito = true;
                                    }
                                }
                                if (karta_pc.ToString() == "A")
                                {
                                    if ((karta_igrok.ToString() == "J") || (karta_igrok.ToString() == "Q") || (karta_igrok.ToString() == "K"))
                                    {
                                        bito = true;
                                    }
                                }
                            }
                        }
                    }
                }

                return bito;
            }
            public void kolodi_init()//создание колоды
            {
                //H-черви,S-пики,D-буби,С-крести A-туз,K-король,Q-дама,J-валет
                string kard = "";
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        kard = "";
                        if (j < 5)
                        {
                            switch (i)
                            {
                                case 0:
                                    kard = (j + 6).ToString() + "H";
                                    kolodi.Add(kard);
                                    break;
                                case 1:
                                    kard = (j + 6).ToString() + "D";
                                    kolodi.Add(kard);
                                    break;

                                case 2:
                                    kard = (j + 6).ToString() + "S";
                                    kolodi.Add(kard);
                                    break;
                                case 3:
                                    kard = (j + 6).ToString() + "C";
                                    kolodi.Add(kard);
                                    break;
                            }
                        }
                        else
                        {
                            switch (j)
                            {
                                case 5:
                                    kard = "J";
                                    switch (i)
                                    {
                                        case 0:
                                            kard = kard + "H";
                                            kolodi.Add(kard);
                                            break;
                                        case 1:
                                            kard = kard + "D";
                                            kolodi.Add(kard);
                                            break;
                                        case 2:
                                            kard = kard + "S";
                                            kolodi.Add(kard);
                                            break;
                                        case 3:
                                            kard = kard + "C";
                                            kolodi.Add(kard);
                                            break;
                                    }
                                    break;
                                case 6:
                                    kard = "Q";
                                    switch (i)
                                    {
                                        case 0:
                                            kard = kard + "H";
                                            kolodi.Add(kard);
                                            break;
                                        case 1:
                                            kard = kard + "D";
                                            kolodi.Add(kard);
                                            break;
                                        case 2:
                                            kard = kard + "S";
                                            kolodi.Add(kard);
                                            break;
                                        case 3:
                                            kard = kard + "C";
                                            kolodi.Add(kard);
                                            break;
                                    }
                                    break;
                                case 7:
                                    kard = "K";
                                    switch (i)
                                    {
                                        case 0:
                                            kard = kard + "H";
                                            kolodi.Add(kard);
                                            break;
                                        case 1:
                                            kard = kard + "D";
                                            kolodi.Add(kard);
                                            break;
                                        case 2:
                                            kard = kard + "S";
                                            kolodi.Add(kard);
                                            break;
                                        case 3:
                                            kard = kard + "C";
                                            kolodi.Add(kard);
                                            break;
                                    }
                                    break;
                                case 8:
                                    kard = "A";
                                    switch (i)
                                    {
                                        case 0:
                                            kard = kard + "H";
                                            kolodi.Add(kard);
                                            break;
                                        case 1:
                                            kard = kard + "D";
                                            kolodi.Add(kard);
                                            break;
                                        case 2:
                                            kard = kard + "S";
                                            kolodi.Add(kard);
                                            break;
                                        case 3:
                                            kard = kard + "C";
                                            kolodi.Add(kard);
                                            break;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            public void peremes_kolodi() //перемеш колоды
            {
                for (int i = 0; i < 36; i++)
                {
                    peremes_kolod[i] = kolodi[i];
                }
                kolodi.Clear();
                Random rnd1 = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    int i1 = rnd1.Next(35);
                    int i2 = rnd1.Next(35);
                    string b = peremes_kolod[i2];
                    peremes_kolod[i2] = peremes_kolod[i1];
                    peremes_kolod[i1] = b;
                }
                for (int i = 0; i < 36; i++)
                {
                    kolodi.Add(peremes_kolod[i]);
                }
                Random rnd2 = new Random();
                d = kolodi[rnd2.Next(35)]; 
                kolodi.Remove(d);
                kozir = d[d.Length - 1].ToString();
                kolodi.Add(d);
            }
            public void razdacha()//раздача карт во время игры
            {
                int c = karti_igrok.Count;
                int d = karti_pc.Count;
                int k;
                if (nachalo_igri) // раздача карт в начале
                {
                    for (int i = 0; i < 6; i++)
                    {
                        karti_igrok.Add(kolodi[i]);
                        kolodi.RemoveAt(i);
                        continue;
                    }
                    for (int j = 0; j < 6; j++)
                    {
                        karti_pc.Add(kolodi[j]);
                        kolodi.RemoveAt(j);
                        continue;
                    }
                }
                else //послед игра
                {
                    try
                    {
                        k = kolodi.Count;
                        if (hodpc == false)
                        {
                            if (6 - c <= k)
                            {
                                if (karti_igrok.Count < 6)
                                {
                                    for (int i = 0; i < 6 - c; i++)
                                    {
                                        karti_igrok.Add(kolodi[i]);
                                        kolodi.RemoveAt(i);
                                    }
                                }
                            }
                            else
                            {
                                k = kolodi.Count;
                                
                                    if (karti_igrok.Count < 6)
                                {
                                    for (int i = 0; i < k; i++)
                                    {
                                        karti_igrok.Add(kolodi[i]);
                                        kolodi.RemoveAt(i);
                                    }
                                } 
                                
                            }
                            k = kolodi.Count;
                            if (6 - d <= k)
                            {
                                if (karti_pc.Count < 6)
                                {
                                    for (int i = 0; i < 6 - d; i++)
                                    {
                                        karti_pc.Add(kolodi[i]);
                                        kolodi.RemoveAt(i);
                                    }
                                }

                            }
                            else
                            {
                                k = kolodi.Count;
                             
                                    if (karti_pc.Count < 6)
                                {
                                    for (int i = 0; i < k; i++)
                                    {
                                        karti_pc.Add(kolodi[i]);
                                        kolodi.RemoveAt(i);

                                    }
                                } 
                                
                            }

                        }
                        if (hodpc == true)
                        {
                            k = kolodi.Count;
                            if (6 - d <= k)
                            {
                                if (karti_pc.Count < 6)
                                {
                                    for (int i = 0; i < 6 - d; i++)
                                    {
                                        karti_pc.Add(kolodi[i]);
                                        kolodi.RemoveAt(i);
                                    }
                                }
                            }
                            else
                            {
                                k = kolodi.Count;
                                if (karti_pc.Count < 6)
                                {
                                    for (int i = 0; i < k; i++)
                                    {
                                        karti_pc.Add(kolodi[i]);

                                        kolodi.RemoveAt(i);

                                    }
                                }
                            }
                            k = kolodi.Count;
                            if (6 - c <= k)
                            {
                                if (karti_igrok.Count < 6)
                                {
                                    for (int i = 0; i < 6 - c; i++)
                                    {
                                        karti_igrok.Add(kolodi[i]);
                                        kolodi.RemoveAt(i);
                                    }
                                }
                            }
                            else
                            {
                                k = kolodi.Count;
                                if (karti_igrok.Count < 6)
                                {
                                    for (int i = 0; i < k; i++)
                                    {
                                        karti_igrok.Add(kolodi[i]);
                                        kolodi.RemoveAt(i);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            public bool podkinut(string kard)
            {
                podkin = false;
                for (int i = 0; i < pole.Count; i++)
                {
                    if (kard.Substring(0, kard.Length - 1) == pole[i].Substring(0, pole[i].Length - 1))
                    {
                        podkin = true;
                    }
                }
                return podkin;
            }
            public void poisk_kart_for_hod_igrok()
            {
                vozmojnye_karti_igrok.Clear();
                if (hodpc == false)
                {
                    if (pole.Count == 0)
                    {
                        //ходим мы карт на столе нет
                        for (int i = 0; i < karti_igrok.Count; i++)
                        {
                            vozmojnye_karti_igrok.Add(karti_igrok[i]);
                        }
                        }
                     if (pole.Count != 0)
                    {
                        //ходим мы подкидываем
                        for (int i = 0; i < karti_igrok.Count; i++)
                        {
                            if (podkinut(karti_igrok[i]) == true)
                            {
                                vozmojnye_karti_igrok.Add(karti_igrok[i]);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < karti_igrok.Count; i++)
                    {
                        if (biet(tekych_card, karti_igrok[i], true) == true)
                        { //подкорректировать кард пк
                            vozmojnye_karti_igrok.Add(karti_igrok[i]);
                        }
                    }
                    if (vozmojnye_karti_igrok.Count == 0)  //берем карты
                    {
                        karti_igrok.AddRange(pole);
                        pole.Clear();
                    }
                }
            }
            public void poisk_kart_for_hod_pc()
            {
                vozmojnye_karti_pc.Clear();
                if (hodpc == false)
                {
                    for (int i = 0; i < karti_pc.Count; i++)
                    {
                        if (biet(karti_pc[i], tekych_card, false) == true)
                        { //подкорректировать кард пк
                            vozmojnye_karti_pc.Add(karti_pc[i]);
                        }
                    }
                    if ((vozmojnye_karti_pc.Count == 0))
                    { //берет карты пк
                        karti_pc.AddRange(pole);
                        pole.Clear();

                    }
                }
                else
                {
                    if (pole.Count == 0)
                    {
                        //ходит пк карт на столе нет
                        for (int i = 0; i < karti_pc.Count; i++)
                        {
                            vozmojnye_karti_pc.Add(karti_pc[i]);
                        }
                    } if (pole.Count != 0)
                    {
                        for (int i = 0; i < karti_pc.Count; i++)
                        {
                            if (podkinut(karti_pc[i]) == true)
                            {
                                vozmojnye_karti_pc.Add(karti_pc[i]);
                            }

                        }
                    }
                }

            }        
        
            public void win()
            {      
                if (kolodi.Count == 0)
                {
                    if ((karti_igrok.Count == 0) && (karti_pc.Count > 0))
                    {
                       MessageBox.Show("Игрок выиграл");
                       hodpc = false;
                        win1 = true;
                       
                    }
                    if ((karti_igrok.Count > 0) && (karti_pc.Count == 0))
                    {
                        MessageBox.Show("Компьютер выиграл");
                        hodpc = true;
                        win1 = true;
                        MessageBox.Show("На дурака ходят");
                        
                    }
                    //ничью дописать
                    if ((karti_igrok.Count == 0) && (karti_pc.Count == 0))
                    {
                        MessageBox.Show("Ничья");
                        hodpc = false;
                        win1 = true;
                        
                    }
                }
    }
    }}
