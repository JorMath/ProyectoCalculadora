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
    //1ra estructura
    public struct VariablesBasicas
    {
        public double numero1;
        public double numero2;
        public char operador;
        public double PI;
    };
    //estructura 2
    public struct operacionesSencillas
    {
        public char operadorSuma;
        public char operadorResta;
        public char operadorMultiplicacion;
        public char operadorDivision;
    };
    //estructura 3
    public struct operacionesComplejas
    {
        public char operadorRaiz;
        public char operadorPotencia;
        public char operadorPI;
    };
    //estructura cuatro
    public struct operadoresAdicionales
    {
        public int tamanioTexto;
        public char punto;
        public char operadorLogaritmo;
        public char operadorPorcentaje;
    };
    public partial class Form1 : Form
    {
        VariablesBasicas variables;
        operacionesSencillas operacionesBasicas;
        operacionesComplejas operacionesSegundoGrado;
        operadoresAdicionales operacionesAdicionales;
        //variables que seguramente se conviertan en estructuras
        //estructura 1
        double numero1 = 0; //
        double numero2 = 0; //
        char operador; //
        double PI = Math.PI; //

        //estructura dos, probablemente unos char que sea para igualar los operadores
        char operadorSuma='+'; //
        char operadorResta='-'; //
        char operadorMultiplicacion='X'; //
        char operadorDivision= '∕'; //
        //estructura tres, operaciones un poco mas complejas
        char operadorRaiz= '√'; //
        char operadorPotencia = '²'; //
        char operadorPI = 'p'; //

        //estructura cuatro para los botones de borrar
        int tamanioTexto;
        char punto = '.';
        char operadorLogaritmo = 'l'; //
        char operadorPorcentaje = '%'; //
        public object CustomMessage { get; private set; }

        //probables botones para operadores de logaritmo y porcentaje

        public Form1()
        {
            InitializeComponent();
        }

        public void agregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "";
            }
            txtResultado.Text += boton.Text;
        }
        public void clickOperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            numero1 = Convert.ToDouble(txtResultado.Text);
            numero2 = Convert.ToDouble(txtResultado.Text);
            operador = Convert.ToChar(boton.Tag);

            variables.numero1 = numero1;
            variables.numero2 = numero2;
            variables.operador = operador;
            variables.PI = PI;

            operacionesSegundoGrado.operadorPotencia = operadorPotencia;
            operacionesSegundoGrado.operadorRaiz = operadorRaiz;
            operacionesSegundoGrado.operadorPI = operadorPI;

            operacionesAdicionales.operadorPorcentaje = operadorPorcentaje;
            operacionesAdicionales.operadorLogaritmo = operadorLogaritmo;

            if (variables.operador == operacionesSegundoGrado.operadorPotencia)
            {
                variables.numero1 = Math.Pow(variables.numero1, 2);
                txtResultado.Text = (variables.numero1).ToString();
            }
            else if (variables.operador == operacionesSegundoGrado.operadorPI)
            {
                variables.numero1 *= PI;
                txtResultado.Text = (variables.numero1).ToString();
            }
            else if (variables.operador == operacionesAdicionales.operadorPorcentaje)
            {
                variables.numero1 /= 100;
                txtResultado.Text = (variables.numero1).ToString();
            }
            else if (variables.operador == operacionesAdicionales.operadorLogaritmo)
            {

                if (variables.numero1 > 0)
                {
                    variables.numero1 = Math.Log10(variables.numero1);
                    txtResultado.Text = (variables.numero1).ToString();
                }
                else
                {
                    MessageBox.Show("No existe logaritmo para numeros menores o iguales que cero");
                }
            }
                else if (variables.operador == operacionesSegundoGrado.operadorRaiz)
                {
                    if (variables.numero1 >= 0)
                    {
                        variables.numero1 = Math.Sqrt(variables.numero1);
                        txtResultado.Text = (variables.numero1).ToString();
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

        public void btnResultado_Click(object sender, EventArgs e)
        {
            numero2 = Convert.ToDouble(txtResultado.Text);
            variables.numero2 = numero2;
            variables.operador = operador;
            operacionesBasicas.operadorSuma = operadorSuma;
            operacionesBasicas.operadorResta = operadorResta;
            operacionesBasicas.operadorMultiplicacion = operadorMultiplicacion;
            operacionesBasicas.operadorDivision = operadorDivision;

            if (variables.operador == operacionesBasicas.operadorSuma)
            {
                txtResultado.Text = (variables.numero1 + variables.numero2).ToString();
                variables.numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (variables.operador == operacionesBasicas.operadorResta)
            {
                txtResultado.Text = (variables.numero1 - variables.numero2).ToString();
                variables.numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (variables.operador == operacionesBasicas.operadorMultiplicacion)
            {
                txtResultado.Text = (variables.numero1 * variables.numero2).ToString();
                variables.numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (variables.operador == operacionesBasicas.operadorDivision)
            {
                if (txtResultado.Text != "0")
                {
                    txtResultado.Text = (variables.numero1 / variables.numero2).ToString();
                    variables.numero1 = Convert.ToDouble(txtResultado.Text);
                }
                else 
                {
                    MessageBox.Show("¡No se puede dividir para cero!");

                }
                

            }
        }

        public void btnQuitar_Click(object sender, EventArgs e)
        {
            operacionesAdicionales.tamanioTexto = txtResultado.Text.Length;
            if (operacionesAdicionales.tamanioTexto > 1)
            {
                txtResultado.Text = txtResultado.Text.Substring(0, operacionesAdicionales.tamanioTexto - 1);
            }
            else
            {
                txtResultado.Text = "0";
            }
        }

        public void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            numero1 = 0;
            numero2 = 0;
            operador = '\0';
            txtResultado.Text = "0";
        }

        public void btnBorrar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }

        public void btnPunto_Click(object sender, EventArgs e)
        {
            operacionesAdicionales.punto = punto;
            if (!txtResultado.Text.Contains(operacionesAdicionales.punto))
            {
                txtResultado.Text += ".";
            }
        }

        public void btnSigno_Click(object sender, EventArgs e)
        {
            numero1 = Convert.ToDouble(txtResultado.Text);
            variables.numero1 = numero1;
            variables.numero1 *= -1;
            txtResultado.Text = variables.numero1.ToString();

        }

        
    }
}
