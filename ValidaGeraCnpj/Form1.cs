using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ValidaGeraCnpj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///cnpj
            Random randNum = new Random();
            string _cnpj = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                _cnpj += randNum.Next(999).ToString().PadLeft(3, '0');
            }


            Cnpj objCnpj = new Cnpj(_cnpj);
            _cnpj += Cnpj.GeraDigito(_cnpj);
            _cnpj += Cnpj.GeraDigito(_cnpj);


            //cpf

            Random randNum2 = new Random();
            string _cpf = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                _cpf += randNum2.Next(999).ToString().PadLeft(3, '0');
            }


            Cpf objCpf = new Cpf(_cpf);
            _cpf += Cpf.GerarDigito(_cpf);
            _cpf += Cpf.GerarDigito(_cpf);

            textBox1.Text = _cnpj;
            textBox2.Text = _cpf;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string cnpj = textBox1.Text;
                cnpj = Cnpj.MontarMascara(cnpj);
                bool cnpjCorreto = Cnpj.Validar(cnpj);
                if (!cnpjCorreto)
                errorProvider1.SetError(textBox1, "Cnpj não é Valido!");
            }

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                string cpf = textBox2.Text;
                cpf = Cpf.MontarMascara(cpf);
                bool cpfCorreto = Cpf.Validar(cpf);
                if (!cpfCorreto)
                    errorProvider1.SetError(textBox2, "Cpf não é Valido!");
            }
        }
    }
}
