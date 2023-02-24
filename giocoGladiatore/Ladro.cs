using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace giocoGladiatore
{
    internal class Ladro : player
    {
        public Ladro(string Nome, double Hp, double ValoreDiAttacco, double ValoreDiDifesa, bool Malvagio, int mana, int manaRegen, int manaCost) : base(Nome, Hp, ValoreDiAttacco, ValoreDiDifesa, Malvagio, mana, manaRegen, manaCost)
        {

        }

        public Ladro() : base()
        {

        }


        public override double attaccoSpeciale(int risDado)
        {
            return risDado;
        }

        public override double attaccoRicevuto(double attacco)
        {
            Random random = new Random();
            int numeroGenerato = random.Next(0, 100);

            if (numeroGenerato < 33)
            {
                
                play = new System.Media.SoundPlayer("C:\\Users\\39351\\source\\repos\\giocoGladiatore\\giocoGladiatore\\NewFolder1\\mixkit-air-in-a-hit.wav");
                play.Play();
                return -2;
            }

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
            bool validChoice = true;


            switch (choice)
            {

                case "1":

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("C:\\Users\\39351\\source\\repos\\giocoGladiatore\\giocoGladiatore\\NewFolder1\\mixkit-sword-blade-attack.wav");
                    player.Play();

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

                    if (this.mana >= this.manaCost)
                    {
                        Console.Write(this.Nome);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" pugnala ");
                        Console.ResetColor();

                        Console.Write(gladiatoreAvversario.Nome + "\n");


                        int ris = (int)this.attaccoSpeciale(lancioDado());
                        this.mana -= this.manaCost;
                        Console.WriteLine(this.mana);

                        if (ris == -2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(gladiatoreAvversario.Nome + " Ha schivato l'attacco.");
                            Console.ResetColor();

                            player = new System.Media.SoundPlayer("C:\\Users\\39351\\source\\repos\\giocoGladiatore\\giocoGladiatore\\NewFolder1\\mixkit-air-in-a-hit.wav");
                            player.Play();
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
                    }
                    else
                    {
                        return -1;
                        break;
                    }


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
