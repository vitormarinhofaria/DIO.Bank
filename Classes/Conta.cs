using System;

namespace DIO.Bank.Classes
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        public double Credito { get; set; }
        public string Nome { get; set; }

        public Conta(TipoConta tpConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tpConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine($"Saldo Atual de {this.Nome} é {this.Saldo}");
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine($"Saldo atual de {this.Nome} é de {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
		{
            string str = $"TipoConta {this.TipoConta} | Nome {this.Nome} | Saldo {this.Saldo} | Crédito {this.Credito}";
			return str;
		}
    }

    public enum TipoConta
    {
        PessoaFisica = 0,
        PessoaJuridica = 1
    }
}