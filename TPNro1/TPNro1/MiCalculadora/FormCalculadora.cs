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
    public partial class FormCalculadora : Form
    {
        bool ResultadoEsBinario = false;
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblResultado.Text) && !ResultadoEsBinario)
            {
                lblResultado.Text = new Operando().DecimalBinario(lblResultado.Text);
                ResultadoEsBinario = true;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (ResultadoEsBinario)
            {
                lblResultado.Text = new Operando().BinarioDecimal(lblResultado.Text);
                ResultadoEsBinario = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            ResultadoEsBinario = false;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text,cmbOperador.SelectedItem.ToString()).ToString();
            ResultadoEsBinario = false;
            if (cmbOperador.SelectedItem.ToString() == " ")
            {
                lstOperaciones.Items.Add($"{txtNumero1.Text} + {txtNumero2.Text} = {lblResultado.Text}");
            }
            else
            {
                lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.SelectedItem.ToString()} {txtNumero2.Text} = {lblResultado.Text}");
            }
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
            cmbOperador.SelectedIndex = 0;
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e) 
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que desea salir?", "Form Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }



        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), char.Parse(operador));
        }


    }
}
