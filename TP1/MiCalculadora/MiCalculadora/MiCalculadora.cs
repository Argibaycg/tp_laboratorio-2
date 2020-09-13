using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class MiCalculadora : Form
    {
        public MiCalculadora()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Limpia lblResultado y los dos txtNumero
        /// </summary>
        /// <param name="calculadora"></param>
        private static void Limpiar(Form calculadora)
        {
            foreach (Control control in calculadora.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
                
                if(control is Label)
                {
                    control.Text = "";
                }            
            }
        }


        /// <summary>
        /// Utilizando el metodo estatico Operar calcula el resultado
        /// y valida que los campos de numeros no esten vacios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if(txtNumeroUno.Text != "" && txtNumeroDos.Text != "")
            {
                lblResultado.Text = Operar(txtNumeroUno.Text, txtNumeroDos.Text, cmbOperator.Text).ToString();
            }
            else
            {
                lblResultado.Text = "Debes ingresar numeros";
            }
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }


        /// <summary>
        /// recibe los dos números y el operador para luego llamar al método Operar de Calculadora
        /// </summary>
        /// <param name="numero1">Primero numero</param>
        /// <param name="numero2">Segundo numero</param>
        /// <param name="operador">Operador</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);

            return Calculadora.Operar(numeroUno, numeroDos, operador);

        }


        /// <summary>
        /// LLama a la funcion que limpia el label y los txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(this);
            cmbOperator.SelectedIndex = -1;
        }


        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Llama al metodo que convierte numero decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (txtNumeroUno.Text != "" && txtNumeroDos.Text != "")
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
                btnConvertirADecimal.Enabled = true;
                btnConvertirABinario.Enabled = false;
            }
            else
            {
                lblResultado.Text = "Debes ingresar numeros";
            }

        }


        /// <summary>
        /// Llama al metodo que convierte binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (txtNumeroUno.Text != "" && txtNumeroDos.Text != "")
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;
            }
            else
            {
                lblResultado.Text = "Debes ingresar numeros";
            }
        }
    }
}
