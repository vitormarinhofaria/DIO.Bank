using System;
using System.Collections.Generic;
using DIO.Bank.Classes;

namespace DIO.Bank
{
    class Program
    {
        public static List<Conta> contas = new List<Conta>();
        static void Main(string[] args)
        {
            Console.WriteLine("#############################");
            Console.WriteLine("# DIO Bank a seu dispor!!   #");
            Console.WriteLine("# Informe a opção desejada: #");

            string userCommand = GetUserCommand();
            while (userCommand != "X")
            {
                switch (userCommand)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                }
                userCommand = GetUserCommand();
            }

        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < contas.Count; i++)
            {
                var conta = contas[i];
                Console.WriteLine($"{i + 1} - {conta}");
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = Double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = Double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tpConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            contas.Add(novaConta);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            contas[indiceOrigem].Transferir(valorTransferencia, contas[indiceDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            contas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            contas[indiceConta].Depositar(valorDeposito);
        }

        static string GetUserCommand()
        {
            Console.WriteLine();
            Console.WriteLine("#---------------------------#");
            Console.WriteLine("# 1 - Listar contas         #");
            Console.WriteLine("# 2 - Inserir nova conta    #");
            Console.WriteLine("# 3 - Transferir            #");
            Console.WriteLine("# 4 - Sacar                 #");
            Console.WriteLine("# 5 - Depositar             #");
            Console.WriteLine("# C - Limpar tela           #");
            Console.WriteLine("# X - Sair                  #");
            Console.WriteLine("#---------------------------#");

            string userCommand = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userCommand;
        }
    }
}
