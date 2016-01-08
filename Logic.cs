using System;
using System.Collections.Generic;
using System.Text;
namespace Durak
{
    public class Logic
    {
        //Ходим на пк
        public List<int>cennost_kart_pc=new List<int>();
        public List<int> cennost_kart_igrok = new List<int>();
        public bool nebitii=true;
        public bool nevzyat = true;
        List<string> bitaC = new List<string>();//крести бита
        List<string> bitaD = new List<string>();//буби бита
        List<string> bitaS = new List<string>();//пики бита
        List<string> bitaH = new List<string>();//черви бита
        List<int> cennost_kart_pc_1 = new List<int>();
        List<int> nomera_kart = new List<int>();
        string[] masti = new string[4]; 
        int[] kolvo_mast = new int[4]; //первое крести, второе буби, третье пики, четвертое черви
        int[] kolvo_mast_sort = new int[4];
      public int nomer_karti(Durak.Rules rul)
            {   
            cennost_kart_pc.Clear();
          int min=0;
          int nomer=0;
                bool s=false;
                bool vsekozir=true;
                if (rul.hodpc == false)
                { //защита   
                    
                        if (rul.vozmojnye_karti_pc.Count > 0)
                        {
                            for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++)
                            {
                                if (rul.podkinut(rul.vozmojnye_karti_pc[i])) //идем парными
                                {
                                    if (rul.vozmojnye_karti_pc[i][rul.vozmojnye_karti_pc[i].Length - 1].ToString() != rul.kozir) {
                                        s = true; 
                                        //есть парные не козырные
                                    nomer = i;
                                    break;
                                    }
                                }
                            }
                            if (s == false)
                            {
                                for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++) //идем не козырными
                                {
                                    if (rul.vozmojnye_karti_pc[i][rul.vozmojnye_karti_pc[i].Length - 1].ToString() != rul.kozir)
                                    {
                                        vsekozir = false; //есть некозырные
                                        nomer = i;
                                        break;
                                    }
                                }
                                if (vsekozir)
                                {
                                    //cennost_kart_pc.Clear();
                                    cennost_kozir(rul);
                                     min = 10000;
                                    for (int i = 0; i < cennost_kart_pc.Count; i++) {
                                        if (cennost_kart_pc[i] <= min) {
                                            min = cennost_kart_pc[i];
                                            nomer = i;
                                        }
                                    }
                                }
                            }
                        }
                }
                else
                {
                    //нападение
                    
                    if (rul.pole.Count == 0)
                    { // cennost_kart_pc.Clear();

                        cennost_prostih_i_kozir(rul);
                         min = 10000;
                        for (int i = 0; i < cennost_kart_pc.Count; i++)
                        {
                            if (cennost_kart_pc[i] <= min)
                            {
                                min = cennost_kart_pc[i];
                                nomer = i;
                            }
                        }
                    }
                    else {
                        //cennost_kart_pc.Clear();

                        cennost_prostih_i_kozir(rul);
                        min = 10000;
                        for (int i = 0; i < cennost_kart_pc.Count; i++)
                        {
                            if (cennost_kart_pc[i] <= min)
                            {
                                min = cennost_kart_pc[i];
                                nomer = i;
                            }
                        }
                        if (min >= 30) {     //не кидаем козыри
                            nebitii = false;
                        }
                    }  
                }
        return nomer;
    }
     public void cennost_kozir(Durak.Rules rul)     
      {
          //cennost_kart_pc.Clear();
          for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++) //идем  козырными минимальной ценности
          {

              if ((rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "A") && (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "K") && (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "Q") && (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "J"))
              {
                  cennost_kart_pc.Add(int.Parse(rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1)) * 5);
              }
              else
              {
                  if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "A")
                  {
                      cennost_kart_pc.Add(70);
                  }
                  if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "K")
                  {
                      cennost_kart_pc.Add(65);
                  }
                  if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "Q")
                  {
                      cennost_kart_pc.Add(60);
                  }
                  if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "J")
                  {
                      cennost_kart_pc.Add(55);
                  }
              }
          }
      }
     public void cennost_kozir_igrok(Durak.Rules rul)
     {
         //cennost_kart_pc.Clear();
         for (int i = 0; i < rul.vozmojnye_karti_igrok.Count; i++) //идем  козырными минимальной ценности
         {

             if ((rul.vozmojnye_karti_igrok[i].Substring(0, rul.vozmojnye_karti_igrok[i].Length - 1) != "A") && (rul.vozmojnye_karti_igrok[i].Substring(0, rul.vozmojnye_karti_igrok[i].Length - 1) != "K") && (rul.vozmojnye_karti_igrok[i].Substring(0, rul.vozmojnye_karti_igrok[i].Length - 1) != "Q") && (rul.vozmojnye_karti_igrok[i].Substring(0, rul.vozmojnye_karti_igrok[i].Length - 1) != "J"))
             {
                 cennost_kart_igrok.Add(int.Parse(rul.vozmojnye_karti_igrok[i].Substring(0, rul.vozmojnye_karti_igrok[i].Length - 1)) * 5);
             }
             else
             {
                 if (rul.vozmojnye_karti_igrok[i].Substring(0, rul.vozmojnye_karti_igrok[i].Length - 1) == "A")
                 {
                     cennost_kart_igrok.Add(70);
                 }
                 if (rul.vozmojnye_karti_igrok[i].Substring(0, rul.vozmojnye_karti_igrok[i].Length - 1) == "K")
                 {
                     cennost_kart_igrok.Add(65);
                 }
                 if (rul.vozmojnye_karti_igrok[i].Substring(0, rul.vozmojnye_karti_igrok[i].Length - 1) == "Q")
                 {
                     cennost_kart_igrok.Add(60);
                 }
                 if (rul.vozmojnye_karti_igrok[i].Substring(0, rul.vozmojnye_karti_igrok[i].Length - 1) == "J")
                 {
                     cennost_kart_igrok.Add(55);
                 }
             }
         }
     }
     public void cennost_prostih_i_kozir(Durak.Rules rul)
     {
         //cennost_kart_pc.Clear();
          for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++)
          {

             

              if (rul.vozmojnye_karti_pc[i][rul.vozmojnye_karti_pc[i].Length - 1].ToString() != rul.kozir) //идем не козырными
              {
                  if ((rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "A") && (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "K") && (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "Q") && (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "J"))
                  {
                      cennost_kart_pc.Add(int.Parse(rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1)));

                  }
                  else
                  {
                      if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "A")
                      {
                          cennost_kart_pc.Add(14);
                      }
                      if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "K")
                      {
                          cennost_kart_pc.Add(13);
                      }
                      if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "Q")
                      {
                          cennost_kart_pc.Add(12);
                      }
                      if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "J")
                      {
                          cennost_kart_pc.Add(11);
                      }
                  }
              }
              else
              {
                  if ((rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "A") && (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "K") && (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "Q") && (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) != "J"))
                  {
                      cennost_kart_pc.Add(int.Parse(rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1)) * 5);
                  }
                  else
                  {
                      if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "A")
                      {
                          cennost_kart_pc.Add(70);
                      }
                      if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "K")
                      {
                          cennost_kart_pc.Add(65);
                      }
                      if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "Q")
                      {
                          cennost_kart_pc.Add(60);
                      }
                      if (rul.vozmojnye_karti_pc[i].Substring(0, rul.vozmojnye_karti_pc[i].Length - 1) == "J")
                      {
                          cennost_kart_pc.Add(55);
                      }
                  }
              }
          }
      }
    public void uchet_bita(Durak.Rules rul) {
        bitaC.Clear();
        bitaD.Clear();
        bitaS.Clear();
        bitaH.Clear();
         for (int i = 0; i < rul.pole.Count; i++) {
             switch (rul.pole[i][rul.pole[i].Length - 1].ToString()) { 
                 case "C":
                     bitaC.Add(rul.pole[i]);
                     break; 
                 case "D":
                     bitaD.Add(rul.pole[i]);
                     break; 
                 case "S":
                     bitaS.Add(rul.pole[i]);
                     break;
                 case "H":
                     bitaH.Add(rul.pole[i]);
                     break;
             }
         }
     }
    public int nomer_karti1(Durak.Rules rul) {//
        int nomer = 0;
        bool s = false;
        bool vsekozir = true;
        cennost_kart_pc.Clear();
        int min = 0;
        for (int i = 0; i < kolvo_mast.Length; i++) {
            kolvo_mast[i] = 0;
        }
                    for (int j = 0; j < rul.karti_pc.Count; j++) {
                switch (rul.karti_pc[j][rul.karti_pc[j].Length - 1].ToString())
                {   case "C":
                        kolvo_mast[0]++;
                        break;  
                    case "D":
                        kolvo_mast[1]++;
                        break;   
                    case "S":
                        kolvo_mast[2]++; 
                        break;
                    case "H":
                        kolvo_mast[3]++;
                        break;
                }
           }
        kolvo_mast[0] = kolvo_mast[0] + bitaC.Count;
        kolvo_mast[1] = kolvo_mast[1] + bitaD.Count;
        kolvo_mast[2] = kolvo_mast[2] + bitaS.Count;
        kolvo_mast[3] = kolvo_mast[3] + bitaH.Count;
        kolvo_mast_sort[0] = kolvo_mast[0];
        kolvo_mast_sort[1] = kolvo_mast[1];
        kolvo_mast_sort[2] = kolvo_mast[2];
        kolvo_mast_sort[3] = kolvo_mast[3];
        Array.Sort(kolvo_mast_sort);
        Array.Reverse(kolvo_mast_sort);
        for (int j = 0; j <4; j++) {
            for (int i = 0; i < 4; i++) {
                if (kolvo_mast_sort[j]==kolvo_mast[i]  ) {
                    switch (i) { 
                        case 0:
                            masti[i] = "C";
                            break;
                        case 1:
                            masti[i] = "D";
                            break;
                        case 2:
                            masti[i] = "S";
                            break;
                        case 3:
                            masti[i] = "H";
                            break;
                    
                    }

                }

            }
        
        }

        if (rul.hodpc)
        {
             
            
            if (rul.pole.Count == 0)
            {
                nomera_kart.Clear();
                cennost_kart_pc_1.Clear();
           
                for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++) //идем не козырными
                {
                    if (rul.vozmojnye_karti_pc[i][rul.vozmojnye_karti_pc[i].Length - 1].ToString() != rul.kozir)
                    {
                        vsekozir = false; //есть некозырные
                        
                        break;
                    }
                }
                if (vsekozir == false)
                {   cennost_prostih_i_kozir(rul);
                    for (int j = 0; j < 4; j++)
                    {
                        if (masti[j] != rul.kozir) {
                            for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++)
                        {
                            if (rul.vozmojnye_karti_pc[i][rul.vozmojnye_karti_pc[i].Length - 1].ToString() == masti[j])
                            {
                               

                                    cennost_kart_pc_1.Add(cennost_kart_pc[i]);
                                    nomera_kart.Add(i);
                                
                            }
                        } }
                        
                        if (cennost_kart_pc_1.Count > 0) { break; }

                    }
                }
                else
                {
                    cennost_kozir(rul);
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++)
                        {
                            if (rul.vozmojnye_karti_pc[i][rul.vozmojnye_karti_pc[i].Length - 1].ToString() == masti[j])
                            {
                                    cennost_kart_pc_1.Add(cennost_kart_pc[i]);
                                    nomera_kart.Add(i);
                            }
                        }
                        if (cennost_kart_pc_1.Count > 0) { break; }

                    }
                }
                
                min = 10000;
                int nomer1=0;
                for (int i = 0; i < cennost_kart_pc_1.Count; i++) {
                    if (min <= cennost_kart_pc_1[i]) {
                        min = cennost_kart_pc_1[i];
                        nomer1 = i;
                    
                    }
                
                
                }
               
                nomer = nomera_kart[nomer1];

            }
            else
            {

                nomera_kart.Clear();
                cennost_kart_pc_1.Clear();
                if (rul.vozmojnye_karti_pc.Count > 0) {
                    for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++) //идем не козырными
                {
                    if (rul.vozmojnye_karti_pc[i][rul.vozmojnye_karti_pc[i].Length - 1].ToString() != rul.kozir)
                    {
                        vsekozir = false; //есть некозырные

                        break;
                    }
                }
                if (vsekozir == false)
                {   cennost_prostih_i_kozir(rul);
                    for (int j = 0; j < 4; j++)
                    {
                        if (masti[j] != rul.kozir) {
                            for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++)
                        {
                            if (rul.vozmojnye_karti_pc[i][rul.vozmojnye_karti_pc[i].Length - 1].ToString() == masti[j])
                            {
                                

                                    cennost_kart_pc_1.Add(cennost_kart_pc[i]);
                                    nomera_kart.Add(i);
                            }
                        } }
                        
                        if (cennost_kart_pc_1.Count > 0) { break; }

                    }
                }
                else
                {
                    cennost_kozir(rul);
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++)
                        {
                            if (rul.vozmojnye_karti_pc[i][rul.vozmojnye_karti_pc[i].Length - 1].ToString() == masti[j])
                            {

                                cennost_kart_pc_1.Add(cennost_kart_pc[i]);
                                nomera_kart.Add(i);

                            }
                        }
                        if (cennost_kart_pc_1.Count > 0) { break; }
                    }
                }
                min = 10000;
                int nomer1 = 0;
                for (int i = 0; i < cennost_kart_pc_1.Count; i++)
                {
                    if (min <= cennost_kart_pc_1[i])
                    {
                        min = cennost_kart_pc_1[i];
                        nomer1 = i;

                    }
                }
                nomer = nomera_kart[nomer1];
                if (min >= 30)
                {     //не кидаем козыри
                    nebitii = false;
                } }
            }
        }
        else
        {
            if (rul.vozmojnye_karti_pc.Count > 0)
            {
                for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++)
                {
                    if (rul.podkinut(rul.vozmojnye_karti_pc[i])) //идем парными
                    {
                        if (rul.vozmojnye_karti_pc[i][rul.vozmojnye_karti_pc[i].Length - 1].ToString() != rul.kozir)
                        {
                            s = true;
                            //есть парные не козырные
                            nomer = i;
                            break;
                        }
                    }
                }
                if (s == false)
                {
                    for (int i = 0; i < rul.vozmojnye_karti_pc.Count; i++) //идем не козырными
                    {
                        if (rul.vozmojnye_karti_pc[i][rul.vozmojnye_karti_pc[i].Length - 1].ToString() != rul.kozir)
                        {
                            vsekozir = false; //есть некозырные
                            nomer = i;
                            break;
                        }
                    }
                    if (vsekozir)
                    {
                        cennost_kozir(rul);
                        min = 10000;
                        for (int i = 0; i < cennost_kart_pc.Count; i++)
                        {
                            if (cennost_kart_pc[i] <= min)
                            {
                                min = cennost_kart_pc[i];
                                nomer = i;
                            }
                        }
                    }
                    if ((min >= 60) && (rul.karti_pc.Count < 10) && (rul.kolodi.Count >= 5)) { nevzyat = false; }
                    else { nevzyat = true; }

                }
            }
        }
        return nomer; 
    
    }
    }
}
