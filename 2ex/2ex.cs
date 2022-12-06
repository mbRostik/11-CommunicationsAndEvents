using System;
using System.Collections.Generic;

internal class Program
{
    static void FindWord(ref string v, ref string temp)
    {
        string b = "";
        for (int i = 0; i < v.Length; i++)
        {
            if (v[i] == ' ')
            {
                v = v.Remove(i, 1);
                break;
            }
            else
            {
                b += v[i];
                v = v.Remove(i, 1);
                i--;
            }
        }
        temp += b;
    }


    delegate string MessageKing(King a);
    delegate string MessageRG(RG a);
    delegate string MessageFootman(Footman a);
    class Unit
    {
        public string Name { get; set; }

    }

    class King : Unit
    {
        public static string GetText(King a)
        { 
            return "King " + a.Name + " is under attack!";
        }
    }

    class RG : Unit
    {
        public static string GetText(RG a)
        {
            return "Royal Guard " + a.Name + " is defending!";
        }
    }


    class Footman : Unit
    {
        public static string GetText(Footman a)
        {
            return "Footman " + a.Name + " is panicking!";
        }
    }


    class Army
    {
        King king = new King();
        List<Footman> footmans=new List<Footman>();
        List<RG> guards = new List<RG>();

        event MessageKing messageKing=null;
        event MessageRG messageRG = null;
        event MessageFootman messageFootMan = null;
        public void SetArmy()
        {
            messageKing += King.GetText;
            messageRG+=RG.GetText;
            messageFootMan+=Footman.GetText;

            string temp=Console.ReadLine();
            king.Name=temp;

            temp=Console.ReadLine();
            while (true)
            {
                if(temp==" " || temp == "")
                {
                    break;
                }
                string temp2 = "";
                FindWord(ref temp, ref temp2);
                int h = 0;
                for(int i=0;i!= guards.Count; i++)
                {
                    if (temp2 == king.Name)
                    {
                        h++;
                        break;
                    }
                    if (guards[i].Name == temp2)
                    {
                        h++;
                        break;
                    }
                }
                if (h == 0)
                {
                    RG temprg = new RG();
                    temprg.Name = temp2;
                    guards.Add(temprg);
                }
                
            }

            temp = Console.ReadLine();

            while (true)
            {
                if (temp == " " || temp == "")
                {
                    break;
                }
                string temp2 = "";
                FindWord(ref temp, ref temp2);
                int h = 0;
                for (int i = 0; i != footmans.Count; i++)
                {
                    if (temp2 == king.Name)
                    {
                        h++;
                        break;
                    }
                    if (footmans[i].Name == temp2)
                    {
                        h++;
                        break;
                    }
                }
                if (h == 0)
                {
                    Footman temprg = new Footman();
                    temprg.Name = temp2;
                    footmans.Add(temprg);
                }
                
            }
        }

        public void GetArmy()
        {
            Console.WriteLine(messageKing(king));
            foreach(RG rg in guards)
            {
                Console.WriteLine(messageRG(rg));
            }
            foreach (Footman ft in footmans)
            {
                Console.WriteLine(messageFootMan(ft));
            }
        }

        public void Start()
        {
            while (true)
            {
                string all = Console.ReadLine();
                if (all == "END")
                {
                    break;
                }
                string temp1 = "";
                FindWord(ref all, ref temp1);

                if (temp1 == "Kill")
                {
                    int h = 0;
                    for(int i = 0; i != guards.Count; i++)
                    {
                        if (all == guards[i].Name)
                        {
                            if (all == guards[i].Name)
                            {
                                h++;
                                guards.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    if (h == 0)
                    {
                        for (int i = 0; i != footmans.Count; i++)
                        {
                            if (all == footmans[i].Name)
                            {
                                if (all == footmans[i].Name)
                                {
                                    footmans.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                    }
                    
                }

                else if(temp1=="Attack")
                {
                    Console.WriteLine();
                    GetArmy();
                    Console.WriteLine();
                }
            }



            GetArmy();
        }
    }
    static void Main()
    {
        Army a = new Army();
        a.SetArmy();
        a.Start();
    }
}

