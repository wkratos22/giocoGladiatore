using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace giocoGladiatore
{
    internal class GuerrieroPersiano : player
    {


        public GuerrieroPersiano(string Nome, double Hp, double ValoreDiAttacco, double ValoreDiDifesa, bool Malvagio, int mana, int manaRegen, int manaCost) : base(Nome, Hp, ValoreDiAttacco, ValoreDiDifesa, Malvagio, mana, manaRegen, manaCost )
        {

        }

        public GuerrieroPersiano() : base()
        {

        }

        public override double attaccoSpeciale(int risDado)
        {
            throw new NotImplementedException();
        }

        public double attaccoSpeciale(int risDado, double enemyDmg)
        {
            /*
            play = new System.Media.SoundPlayer("C:\\Users\\39351\\source\\repos\\giocoGladiatore\\giocoGladiatore\\NewFolder1\\AAAAAAAAAAAAAA.wav");
            play.Play();
            */
            return risDado+enemyDmg;
            
        }

        public override double attaccoRicevuto(double attacco)
        {

            double ris = 0;
            ris = attacco - ValoreDiDifesa;
            if (ris <= 0)
            {
                Console.WriteLine("attacco non ha avuto effetto");
                return -1;
            }


            using (StreamWriter sw = File.AppendText("C:\\Users\\39351\\source\\repos\\giocoGladiatore\\giocoGladiatore\\combatLog.txt"))
            {
                Console.WriteLine(" ");
                sw.WriteLine(this.Nome + " HP iniziale: " + this.Hp + "  hp dopo attacco: " + (this.Hp - ris));

                sw.Close();
            }

            this.Hp -= ris;
            return ris;
        }


        public override int chooseAttack(string choice, player gladiatoreAvversario)
        {
            switch (choice)
            {

                case "1":
                    
                    play = new System.Media.SoundPlayer("C:\\Users\\39351\\source\\repos\\giocoGladiatore\\giocoGladiatore\\NewFolder1\\mixkit-sword-blade-attack.wav");
                    play.Play();
                    
                    Console.WriteLine(this.Nome + " attacca " + gladiatoreAvversario.Nome + " con: Attacco normale");

                    double HpPrima = gladiatoreAvversario.Hp;

                    double danno = gladiatoreAvversario.attaccoRicevuto(this.attaccoBase(lancioDado()));
                    if (danno < 0) danno = 0;
                    Console.Write("HP iniziale: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(HpPrima);
                    Console.ResetColor();
                    Console.Write(" hp dopo attacco: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write((gladiatoreAvversario.Hp));
                    Console.ResetColor();
                    Console.Write(" Danno: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(danno);
                    Console.ResetColor();

                    break;

                case "2":
                    Console.Write(this.Nome);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" ipnotizza, ");
                    Console.ResetColor();

                    Console.Write(gladiatoreAvversario.Nome);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" si colpisce da solo\n");
                    Console.ResetColor();

                    int ris = (int)this.attaccoSpeciale(lancioDado(), gladiatoreAvversario.ValoreDiAttacco);
                    if (ris == -2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(gladiatoreAvversario.Nome + " Ha schivato l'attacco.");
                        Console.ResetColor();
                        
                        play = new System.Media.SoundPlayer("C:\\Users\\39351\\source\\repos\\giocoGladiatore\\giocoGladiatore\\NewFolder1\\mixkit-air-in-a-hit.wav");
                        play.Play();
                        
                    }
                    else
                    {

                        double HpPrima2 = gladiatoreAvversario.Hp;

                        double danno2 = gladiatoreAvversario.attaccoRicevuto(ris);
                        if (danno2 < 0) danno2 = 0;
                        Console.Write("HP iniziale: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(HpPrima2);
                        Console.ResetColor();
                        Console.Write(" hp dopo attacco: ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write((gladiatoreAvversario.Hp));
                        Console.ResetColor();
                        Console.Write(" Danno: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(danno2);
                        Console.ResetColor();


                    }


                    break;
                case "q":
                    Console.WriteLine("Exiting");
                    break;
                default:
                    Console.WriteLine("Input non valido");
                    break;
            }
            return 0;
        }

        
    }
}
