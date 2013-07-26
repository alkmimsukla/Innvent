using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innvent
{
    class GerUser
    {
        private ListUser lUser = new ListUser();
        private TUser itemUser;
        private TConta itemConta;
        private TLanc itemLanc;
        private long cpf;

        List<string> categorias = new List<string>();

        public void Apresentacao()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t --- FINANÇAS PESSOAIS ---\n");
        }

        public void createUser()
        {
            itemUser = new TUser();
            itemConta = new TConta();
            itemUser.Conta = new List<TConta>();

            Console.WriteLine("\nEntre com o nome do usuário:");
            itemUser.Nome = Console.ReadLine();
            Console.WriteLine("Entre com o CPF do usuário:");
            itemUser.Cpf = long.Parse(Console.ReadLine());
            itemConta.NomeId = "Padrão";
            itemConta.Saldo = 0;
            itemConta.Lanc = new List<TLanc>();

            lUser.User.Add(itemUser);
            itemUser.Conta.Add(itemConta);
        }

        public bool validaUser()
        {
            if (lUser.User.Count == 0)
            {
                Console.WriteLine("\n\n\tNão existem usuários cadastrados!!\n\tFavor cadastrar um novo usuário para prosseguir!");
                return false;
            }
            else
            {
                if (searchUser())
                    return true;

                Console.WriteLine("\n\n\tO usuário buscado não foi encontrado!!\n\tFavor procurar novamente ou cadastrar um novo usuário!");
                return false;
            }
        }

        private bool searchUser()
        {
            Console.WriteLine("\nEntre com o CPF do usuário:");
            this.cpf = long.Parse(Console.ReadLine());

            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                    return true;
            }

            return false;
        }

        public void listConta()
        {
            int i = 1;
            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                {
                    foreach (TConta iConta in iUser.Conta)
                    {
                        Console.WriteLine(" {0} - {1}", i, iConta.NomeId);
                        i++;
                    }
                }
            }
        }

        public void addContaUser()
        {
            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                {
                    itemConta = new TConta();

                    Console.WriteLine("\nEntre com o nome da conta que deseja inserir:");
                    itemConta.NomeId = Console.ReadLine();
                    itemConta.Saldo = 0;
                    itemConta.Lanc = new List<TLanc>();

                    iUser.Conta.Add(itemConta);
                }
            }
        }

        public int qntContasUser()
        {
            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                    return iUser.Conta.Count;
            }

            return 1;
        }

        public void exibeSaldo(int position)
        {
            int i = 0;
            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                {
                    foreach (TConta iConta in iUser.Conta)
                    {
                        if (i == position)
                        {
                            Console.WriteLine("\nTitular da conta: {0}", iUser.Nome);
                            Console.WriteLine("Tipo da conta: {0}", iConta.NomeId);
                            Console.WriteLine("Saldo: R${0}", iConta.Saldo);
                            Console.WriteLine("Data: {0:D2}/{1:D2}/{2}", DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
                        }
                        i++;
                    }
                }
            }
        }

        public void createLanc(int position)
        {
            int i = 0;
            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                {
                    foreach (TConta iConta in iUser.Conta)
                    {
                        if (i == position)
                        {
                            itemLanc = new TLanc();
                            itemLanc.Categ = new TCat();

                            Console.WriteLine(" 1 - Receita");
                            Console.WriteLine(" 2 - Despesa");
                            Console.WriteLine("\nEntre com o tipo de lançamento:");
                            itemLanc.Tipo = int.Parse(Console.ReadLine());
                            Console.WriteLine("\nEntre com o valor:");
                            itemLanc.Valor = int.Parse(Console.ReadLine());
                            Console.WriteLine("Entre com a data de lançamento: (DD/MM/AAAA)");
                            itemLanc.Date = DateTime.Parse(Console.ReadLine());

                            if (itemLanc.Date <= DateTime.Today)
                            {
                                if (itemLanc.Tipo == 2)
                                    iConta.Saldo -= itemLanc.Valor;
                                else if (itemLanc.Tipo == 1)
                                    iConta.Saldo += itemLanc.Valor;
                            }

                            Console.WriteLine("Entre com a categoria:");
                            itemLanc.Categ.Nome = Console.ReadLine();
                            Console.WriteLine("Entre com a sub-categoria:");
                            itemLanc.Categ.SubCateg = Console.ReadLine();

                            iConta.Lanc.Add(itemLanc);
                        }
                        i++;
                    }
                }
            }
        }

        public void transfValores(int position)
        {
            int i = 0;
            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                {
                    foreach (TConta iConta in iUser.Conta)
                    {
                        if (i == position)
                        {
                            itemLanc = new TLanc();
                            itemLanc.Categ = new TCat();

                            Apresentacao();
                            listConta();
                            Console.WriteLine("\nEnre com a opção desejada:");
                            int selecContaTransf = int.Parse(Console.ReadLine());

                            Console.WriteLine("\nEntre com o valor:");
                            itemLanc.Valor = int.Parse(Console.ReadLine());
                            Console.WriteLine("Entre com a data de lançamento: (DD/MM/AAAA)");
                            itemLanc.Date = DateTime.Parse(Console.ReadLine());

                            if (itemLanc.Date <= DateTime.Today)
                            {
                                iConta.Saldo -= itemLanc.Valor;
                                iUser.Conta[selecContaTransf - 1].Saldo += itemLanc.Valor;
                            }

                            itemLanc.Tipo = 2;
                            itemLanc.Categ.Nome = "Transferência";
                            itemLanc.Categ.SubCateg = iUser.Conta[selecContaTransf - 1].NomeId;

                            iConta.Lanc.Add(itemLanc);
                        }
                        i++;
                    }
                }
            }
        }

        public void lancData(int position)
        {
            int i = 0;
            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                {
                    foreach (TConta iConta in iUser.Conta)
                    {
                        if (i == position)
                        {
                            iConta.Lanc.Sort((x, y) => DateTime.Compare(x.Date, y.Date));

                            foreach (TLanc iLanc in iConta.Lanc)
                            {
                                if (iLanc.Tipo == 1)
                                    Console.WriteLine("\n\tTipo: Receita");
                                else if (iLanc.Tipo == 2)
                                    Console.WriteLine("\n\tTipo: Despesa");
                                Console.WriteLine("\tData: {0:D2}/{1:D2}/{2}\t\tValor: R${3}", iLanc.Date.Day, iLanc.Date.Month, iLanc.Date.Year, iLanc.Valor);
                                Console.WriteLine("\tCategoria: {0} \t\tSub-categoria: {1}", iLanc.Categ.Nome, iLanc.Categ.SubCateg);
                            }
                        }
                        i++;
                    }
                }
            }
        }

        public void listCategorias(int position)
        {
            int i = 0;
            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                {
                    foreach (TConta iConta in iUser.Conta)
                    {
                        if (i == position)
                        {
                            categorias.Clear();
                            foreach (TLanc iLanc in iConta.Lanc)
                            {
                                categorias.Add(iLanc.Categ.Nome);
                            }
                        }
                        i++;
                    }
                }
            }

            removeCategoriasDuplicadas();
        }

        private void removeCategoriasDuplicadas()
        {
            categorias = categorias.Distinct().ToList();
            int i = 1;

            foreach (string nomeCat in categorias)
            {
                Console.WriteLine(" {0} - {1}", i, nomeCat);
                i++;
            }
        }

        public int qntCategorias()
        {
            return categorias.Count;
        }

        public void lancCategoria(int position, int lancCat)
        {
            int i = 0;
            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                {
                    foreach (TConta iConta in iUser.Conta)
                    {
                        if (i == position)
                        {
                            foreach (TLanc iLanc in iConta.Lanc)
                            {
                                if (iLanc.Categ.Nome == categorias[lancCat])
                                {
                                    if (iLanc.Tipo == 1)
                                        Console.WriteLine("\n\tTipo: Receita");
                                    else if (iLanc.Tipo == 2)
                                        Console.WriteLine("\n\tTipo: Despesa");
                                    Console.WriteLine("\tData: {0:D2}/{1:D2}/{2}\t\tValor: R${3}", iLanc.Date.Day, iLanc.Date.Month, iLanc.Date.Year, iLanc.Valor);
                                    Console.WriteLine("\tCategoria: {0} \t\tSub-categoria: {1}", iLanc.Categ.Nome, iLanc.Categ.SubCateg);
                                }
                            }
                        }
                        i++;
                    }
                }
            }

        }

        public void lancPeriodo(int position)
        {
            int i = 0;
            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                {
                    foreach (TConta iConta in iUser.Conta)
                    {
                        if (i == position)
                        {
                            Console.WriteLine("Entre com a data inicial: (DD/MM/AAAA)");
                            DateTime dataInicial = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Entre com a data final: (DD/MM/AAAA)");
                            DateTime dataFinal = DateTime.Parse(Console.ReadLine());

                            Apresentacao();
                            foreach (TLanc iLanc in iConta.Lanc)
                            {
                                if (iLanc.Date >= dataInicial && iLanc.Date <= dataFinal)
                                {
                                    if (iLanc.Tipo == 1)
                                        Console.WriteLine("\n\tTipo: Receita");
                                    else if (iLanc.Tipo == 2)
                                        Console.WriteLine("\n\tTipo: Despesa");
                                    Console.WriteLine("\tData: {0:D2}/{1:D2}/{2}\t\tValor: R${3}", iLanc.Date.Day, iLanc.Date.Month, iLanc.Date.Year, iLanc.Valor);
                                    Console.WriteLine("\tCategoria: {0} \t\tSub-categoria: {1}", iLanc.Categ.Nome, iLanc.Categ.SubCateg);
                                }
                            }
                        }
                        i++;
                    }
                }
            }
        }

        public void lancTipo(int position)
        {
            int i = 0;
            foreach (TUser iUser in lUser.User)
            {
                if (iUser.Cpf == this.cpf)
                {
                    foreach (TConta iConta in iUser.Conta)
                    {
                        if (i == position)
                        {
                            Console.WriteLine(" 1 - Receita");
                            Console.WriteLine(" 2 - Despesa");
                            Console.WriteLine("\nEntre com o tipo de lançamento:");
                            int tipoLanc = int.Parse(Console.ReadLine());

                            Apresentacao();
                            foreach (TLanc iLanc in iConta.Lanc)
                            {
                                if (iLanc.Tipo == tipoLanc)
                                {
                                    if (iLanc.Tipo == 1)
                                        Console.WriteLine("\n\tTipo: Receita");
                                    else if (iLanc.Tipo == 2)
                                        Console.WriteLine("\n\tTipo: Despesa");
                                    Console.WriteLine("\tData: {0:D2}/{1:D2}/{2}\t\tValor: R${3}", iLanc.Date.Day, iLanc.Date.Month, iLanc.Date.Year, iLanc.Valor);
                                    Console.WriteLine("\tCategoria: {0} \t\tSub-categoria: {1}", iLanc.Categ.Nome, iLanc.Categ.SubCateg);
                                }
                            }
                        }
                        i++;
                    }
                }
            }
        }


    }
}
