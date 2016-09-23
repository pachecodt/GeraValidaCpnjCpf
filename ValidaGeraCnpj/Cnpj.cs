using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidaGeraCnpj
{
    public class Cnpj
    {
        private string _cnpj;
        public Cnpj(string cnpj)
        {
            _cnpj = cnpj;
        }

        public static string GeraDigito(string cnpj)
        {
            int pPeso = 2;
            int pSoma = 0;

            for (int i = cnpj.Length - 1; i >= 0; i--)
            {
                pSoma += pPeso * Convert.ToInt32(cnpj[i].ToString());
                pPeso++;

                if (pPeso == 10)
                    pPeso = 2;
            }

            int pNumero = (11 - (pSoma % 11));
            if (pNumero > 9)
                pNumero = 0;

            return pNumero.ToString();
        }

        public static bool Validar(string cnpj)
        {
            // Se for vazio
            if (String.IsNullOrEmpty(cnpj.Trim()))
                return false;

            // Retirar todos os caracteres que não sejam numéricos
            string aux = string.Empty;

            for (int i = 0; i < cnpj.Length; i++)
            {
                if (char.IsNumber(cnpj[i]))
                    aux += cnpj[i].ToString();
            }

            // O tamanho do CNPJ tem que ser 14
            if (aux.Length != 14)
                return false;

            // Guardo os dígitos para compará-lo no final
            string pDigito = aux.Substring(12, 2);
            aux = aux.Substring(0, 12);

            //Calculo do 1º digito
            aux += GeraDigito(aux);

            //Calculo do 2º digito
            aux += GeraDigito(aux);


            //Comparo os dígitos calculadoscom os guardados anteriormente

            return pDigito == aux.Substring(12, 2);
        }

        public static string MontarMascara(string cnpj)
        {
            string aux = "";

            // Retirar todos os caracteres que não sejam numéricos
            for (int i = 0; i < cnpj.Length; i++)
            {
                if (char.IsNumber(cnpj[i]))
                    aux += cnpj[i].ToString();
            }

            if (aux.Length != 14)
                return cnpj;

            string pmontado = "";
            pmontado = aux.Substring(0, 2) + ".";
            pmontado += aux.Substring(2, 3) + ".";
            pmontado += aux.Substring(5, 3) + "/";
            pmontado += aux.Substring(8, 4) + "-";
            pmontado += aux.Substring(12, 2);

            return pmontado;
        }

        public override string ToString()
        {
            return _cnpj;
        }
    }
}
