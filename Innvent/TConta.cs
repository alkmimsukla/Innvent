using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innvent
{
    class TConta
    {
        private string nomeId;
        private double saldo;
        private List<TLanc> lanc;

        public string NomeId
        {
            get { return nomeId; }
            set { nomeId = value; }
        }

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public List<TLanc> Lanc
        {
            get { return lanc; }
            set { lanc = value; }
        }
    }
}
