using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_Basica
{
    public partial class Form1 : Form
    {
        //variables que seguramente se conviertan en estructuras
        //estructura 1
        double numero1 = 0;
        double numero2 = 0;
        char operador;

        //estructura dos, probablemente unos char que sea para igualar los operadores
        char operadorSuma='+';
        char operadorResta='-';
        char operadorMultiplicacion='X';
        char operadorDivision= '∕';
        //estructura tres, operaciones un poco mas complejas
        char operadorRaiz= '√';
        char operadorPotencia = '²';
        //estructura cuatro para los botones de borrar
        int tamanioTexto;
        char punto = '.';
        //probables botones para operadores de logaritmo y porcentaje

        public Form1()
        {
            InitializeComponent();
        }

        private void agregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "";
            }
            txtResultado.Text += boton.Text;
        }
        private void clickOperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            numero1 = Convert.ToDouble(txtResultado.Text);
            operador = Convert.ToChar(boton.Tag);

            if (operador == operadorPotencia)
            {
                numero1 = Math.Pow(numero1, 2);
                txtResultado.Text = numero1.ToString();
            }
            else if (operador == operadorRaiz)
            {
                if (numero1 >= 0)
                {
                    numero1 = Math.Sqrt(numero1);
                    txtResultado.Text = numero1.ToString();
                }
                else
                {
                    MessageBox.Show("¡No existen las raices cuadradas de un número negativo!");
                }
            }
            else
            {
                txtResultado.Text = "0";
            }
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            numero2 = Convert.ToDouble(txtResultado.Text);
            if (operador == operadorSuma)
            {
                txtResultado.Text = (numero1 + numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (operador == operadorResta)
            {
                txtResultado.Text = (numero1 - numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (operador == operadorMultiplicacion)
            {
                txtResultado.Text = (numero1 * numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (operador == operadorDivision)
            {
                if (txtResultado.Text != "0")
                {
                    txtResultado.Text = (numero1 / numero2).ToString();
                    numero1 = Convert.ToDouble(txtResultado.Text);
                }
                else
                {
                    MessageBox.Show("¡No se puede dividir para cero!");

                }

            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            tamanioTexto = txtResultado.Text.Length;
            if (tamanioTexto > 1)
            {
                txtResultado.Text = txtResultado.Text.Substring(0, tamanioTexto - 1);
            }
            else
            {
                txtResultado.Text = "0";
            }
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            numero1 = 0;
            numero2 = 0;
            operador = '\0';
            txtResultado.Text = "0";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains(punto))
            {
                txtResultado.Text += ".";
            }
        }

        private void btnSigno_Click(object sender, EventArgs e)
        {
            numero1 = Convert.ToDouble(txtResultado.Text);
            numero1 *= -1;
            txtResultado.Text = numero1.ToString();

        }
    }
}
