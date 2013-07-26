using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innvent
{
    class TUser
    {
        private string nome;
        private long cpf;
        private List<TConta> conta;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public long Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public List<TConta> Conta
        {
            get { return conta; }
            set { conta = value; }
        }
    }
}
