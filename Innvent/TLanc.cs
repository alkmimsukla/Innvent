using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innvent
{
    class TLanc
    {
        private int tipo;
        private double valor;
        private TCat categ;
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public TCat Categ
        {
            get { return categ; }
            set { categ = value; }
        }
    }
}
