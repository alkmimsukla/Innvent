using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innvent
{
    class Program
    {
        static void Main(string[] args)
        {
            GerUser gUser = new GerUser();

            int menuPrinc, menuAcessoConta, menuGerenciaConta, menuRelatorios, menuSelecionaConta, menuSelecionaCategoria;

            do
            {
                gUser.Apresentacao();
                Console.WriteLine(" 1 - Cadastro de Usuário");
                Console.WriteLine(" 2 - Acessar Usuário Existente");
                Console.WriteLine(" 0 - Sair");
                Console.WriteLine("\nEntre com a opção desejada:");
                menuPrinc = int.Parse(Console.ReadLine());

                switch (menuPrinc)
                {
                    case 0:
                        break;
                    case 1:
                        gUser.createUser();
                        break;

                    case 2:
                        if (!gUser.validaUser())
                        {
                            Console.ReadKey();
                            break;
                        }

                        do
                        {
                            gUser.Apresentacao();
                            Console.WriteLine(" 1 - Gerenciar Conta");
                            Console.WriteLine(" 2 - Associar Nova Conta ao Usuário");
                            Console.WriteLine(" 0 - Voltar ao Menu Principal");
                            Console.WriteLine("\nEntre com a opção desejada:");
                            menuAcessoConta = int.Parse(Console.ReadLine());

                            switch (menuAcessoConta)
                            {
                                case 0:
                                    break;
                                case 1:
                                    do
                                    {
                                        gUser.Apresentacao();
                                        gUser.listConta();
                                        Console.WriteLine(" 0 - Voltar ao Menu Anterior");
                                        Console.WriteLine("\nEntre com a opção desejada:");
                                        menuSelecionaConta = int.Parse(Console.ReadLine());
                                        if (menuSelecionaConta == 0)
                                            break;
                                        if (menuSelecionaConta > gUser.qntContasUser())
                                        {
                                            Console.WriteLine("\n\n\tOpção selecionada inválida!! Por favor, tente novamente..");
                                            Console.ReadKey();
                                            break;
                                        }

                                        do
                                        {
                                            gUser.Apresentacao();
                                            Console.WriteLine(" 1 - Visualizar Saldo");
                                            Console.WriteLine(" 2 - Criar Novo Lançamento");
                                            Console.WriteLine(" 3 - Transferência Entre Contas de Mesmo Titular");
                                            Console.WriteLine(" 4 - Gerar Relatórios");
                                            Console.WriteLine(" 0 - Voltar ao Menu Anterior");
                                            Console.WriteLine("\nEntre com a opção desejada:");
                                            menuGerenciaConta = int.Parse(Console.ReadLine());

                                            switch (menuGerenciaConta)
                                            {
                                                case 0:
                                                    menuSelecionaConta = 0;
                                                    break;
                                                case 1:
                                                    gUser.Apresentacao();
                                                    gUser.exibeSaldo(menuSelecionaConta - 1);

                                                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                                                    Console.ReadKey();
                                                    break;
                                                case 2:
                                                    gUser.Apresentacao();
                                                    gUser.createLanc(menuSelecionaConta - 1);
                                                    break;
                                                case 3:
                                                    if (gUser.qntContasUser() == 1)
                                                    {
                                                        gUser.Apresentacao();
                                                        Console.WriteLine("\tNão foi possível realizar a operação!\n\tO usuário possui apenas a conta 'Padrão'.");
                                                        Console.ReadKey();
                                                        break;
                                                    }

                                                    gUser.transfValores(menuSelecionaConta - 1);
                                                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                                                    Console.ReadKey();
                                                    break;
                                                case 4:
                                                    do
                                                    {
                                                        gUser.Apresentacao();
                                                        Console.WriteLine(" 1 - Exibir Lançamentos Ordenados por Data");
                                                        Console.WriteLine(" 2 - Exibir Lançamentos por Categoria");
                                                        Console.WriteLine(" 3 - Exibir Lançamentos por Período Específico");
                                                        Console.WriteLine(" 4 - Exibir Lançamentos por Tipo (RECEITA/DESPESA)");
                                                        Console.WriteLine(" 0 - Voltar ao Menu Anterior");
                                                        Console.WriteLine("\nEntre com a opção desejada:");
                                                        menuRelatorios = int.Parse(Console.ReadLine());
                                                        switch (menuRelatorios)
                                                        {
                                                            case 0:
                                                                break;
                                                            case 1:
                                                                gUser.Apresentacao();
                                                                gUser.lancData(menuSelecionaConta - 1);

                                                                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                                                                Console.ReadKey();
                                                                break;
                                                            case 2:
                                                                gUser.Apresentacao();
                                                                gUser.listCategorias(menuSelecionaConta - 1);
                                                                Console.WriteLine(" 0 - Voltar ao Menu Anterior");
                                                                Console.WriteLine("\nEntre com a opção desejada:");
                                                                menuSelecionaCategoria = int.Parse(Console.ReadLine());

                                                                if (menuSelecionaCategoria == 0)
                                                                    break;
                                                                if (menuSelecionaCategoria > gUser.qntCategorias())
                                                                {
                                                                    Console.WriteLine("\n\n\tOpção selecionada inválida!! Por favor, tente novamente..");
                                                                    Console.ReadKey();
                                                                    break;
                                                                }

                                                                gUser.Apresentacao();
                                                                gUser.lancCategoria(menuSelecionaConta - 1, menuSelecionaCategoria - 1);
                                                                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                                                                Console.ReadKey();
                                                                break;
                                                            case 3:
                                                                gUser.Apresentacao();
                                                                gUser.lancPeriodo(menuSelecionaConta - 1);

                                                                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                                                                Console.ReadKey();
                                                                break;
                                                            case 4:
                                                                gUser.Apresentacao();
                                                                gUser.lancTipo(menuSelecionaConta - 1);

                                                                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                                                                Console.ReadKey();
                                                                break;
                                                            default:
                                                                Console.WriteLine("\n\n\tOpção selecionada inválida!! Por favor, tente novamente..");
                                                                Console.ReadKey();
                                                                break;
                                                        }
                                                    } while (menuRelatorios != 0);
                                                    break;

                                                default:
                                                    break;
                                            }
                                        } while (menuGerenciaConta != 0);

                                    } while (menuSelecionaConta != 0);
                                    break;
                                case 2:
                                    gUser.addContaUser();
                                    break;

                                default:
                                    Console.WriteLine("\n\n\tOpção selecionada inválida!! Por favor, tente novamente..");
                                    Console.ReadKey();
                                    break;
                            }

                        } while (menuAcessoConta != 0);
                        break;

                    default:
                        Console.WriteLine("\n\n\tOpção selecionada inválida!! Por favor, tente novamente..");
                        Console.ReadKey();
                        break;
                }

            } while (menuPrinc != 0);
        }
    }
}
