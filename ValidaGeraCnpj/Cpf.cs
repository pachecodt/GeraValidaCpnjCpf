using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidaGeraCnpj
{
    class Cpf
    {
        private string _cpf;

        public Cpf(string cpf)
        {
            _cpf = cpf;
        }

        public override string ToString()
        {
            return _cpf;
        }

        public static string GerarDigito(string cpf)
        {
            int Peso = 2;
            int Soma = 0;

            for (int i = cpf.Length - 1; i >= 0; i--)
            {
                Soma += Peso * Convert.ToInt32(cpf[i].ToString());
                Peso++;
            }

            int pNumero = 11 - (Soma % 11);

            if (pNumero > 9)
                pNumero = 0;

            return pNumero.ToString();
        }

        public static bool Validar(string cpf)
        {
            // Se for vazio
            if (String.IsNullOrEmpty(cpf.Trim()))
                return false;

            // Retirar todos os caracteres que não sejam numéricos
            string aux = string.Empty;
            for (int i = 0; i < cpf.Length; i++)
            {
                if (char.IsNumber(cpf[i]))
                    aux += cpf[i].ToString();
            }

            // O tamanho do CPF tem que ser 11
            if (aux.Length != 11)
                return false;

            // Guardo o dígito para comparar no final
            string pDigito = aux.Substring(9, 2);
            aux = aux.Substring(0, 9);

            //Cálculo do 1o. digito do CPF
            aux += GerarDigito(aux);

            //Cálculo do 2o. digito do CPF
            aux += GerarDigito(aux);

            return pDigito == aux.Substring(9, 2);
        }

        public static string MontarMascara(string cpf)
        {
            string aux = "";

            // Retirar todos os caracteres que não sejam numéricos
            for (int i = 0; i < cpf.Length; i++)
            {
                if (char.IsNumber(cpf[i]))
                    aux += cpf[i].ToString();
            }

            if (aux.Length != 11)
                return cpf;

            string pmontado = "";
            pmontado = aux.Substring(0, 3) + ".";
            pmontado += aux.Substring(3, 3) + ".";
            pmontado += aux.Substring(6, 3) + "-";
            pmontado += aux.Substring(9, 2);

            return pmontado;
        }
    }
}
