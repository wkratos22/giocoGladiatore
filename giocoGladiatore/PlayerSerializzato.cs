using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace giocoGladiatore
{
    internal class PlayerSerializzato
    {
        public double ValoreDiAttacco { get; set; }
        public double Hp { get; set; }
        public double ValoreDiDifesa { get; set; }
        public int mana { get; set; }
        public int manaRegen { get; set; }
        public int manaCost { get; set; }
    }
}
