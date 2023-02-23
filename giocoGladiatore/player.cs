﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace giocoGladiatore
{
    public abstract class player
    {
        public string Nome { get; set; }
        public double ValoreDiAttacco { get; set; }
        public double Hp { get; set; }
        public double ValoreDiDifesa { get; set; }
        public bool Malvagio { get; set; }
        public System.Media.SoundPlayer play;

        public player(string Nome, double Hp, double ValoreDiAttacco, double ValoreDiDifesa, bool Malvagio)
        {
            this.Nome = Nome;
            this.Hp = Hp;
            this.ValoreDiAttacco = ValoreDiAttacco;
            this.ValoreDiDifesa = ValoreDiDifesa;
            this.Malvagio = Malvagio;
        }
        public player()
        {
            this.Nome = "a";
            this.Hp = 0;
            this.ValoreDiAttacco = 0;
            this.ValoreDiDifesa = 0;
            this.Malvagio = true;

        }


        public double attaccoBase(int risDado)
        {
            if (risDado < 1 || risDado > 20)
            {
                Console.WriteLine("valore dado non valido");
                return -1;
            }
            double ris = 0;


            ris = ValoreDiAttacco + risDado;
            return ris;
        }

        abstract public double attaccoSpeciale(int risDado);


        public abstract double attaccoRicevuto(double attacco);





        public abstract void chooseAttack(string choice, player gladiatoreAvversario);



        //ritorna numero da 1 a 20 (dado 20 facce)
        public static int lancioDado()
        {
            Random random = new Random();

            int numeroGenerato = random.Next(1, 20);

            return numeroGenerato;
        }




        public string attacks()
        {
            return " 1 : Attacco Normale" + "\n 2 : Attacco Speciale" + "\n q : Esci dal gioco";
        }

        override public string ToString()
        {
            return "\n E' il turno di: " + this.Nome + "\n HP: " + this.Hp + "\n Attacco: " + this.ValoreDiAttacco + "\n Difesa: " + this.ValoreDiDifesa + "\n Malvagio: " + this.Malvagio;
        }



    }
}

