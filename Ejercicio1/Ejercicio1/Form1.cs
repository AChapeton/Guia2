using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        Hashtable buscador = new Hashtable();
        
        

        public Form1()
        {
            InitializeComponent();

            buscador.Add("Ter1", "Desc1");
            buscador.Add("Ter2", "Desc2");
            buscador.Add("Ter3", "Desc3");
            buscador.Add("Ter4", "Desc4");
        }

        /*
        private Hashtable nuevoDato()
        {
            buscador.Add("Ter1", "Desc1");
            buscador.Add("Ter2", "Desc2");
            buscador.Add("Ter3", "Desc3");
            buscador.Add("Ter4", "Desc4");
            return buscador;
        }
        */

        /*
        private DataTable llenarTabla(Hashtable buscador)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Palabra");
            dt.Columns.Add("Descripción");

            ICollection keys = buscador.Keys;

            
            foreach(var dato in buscador.Keys)
            {
                dt.Rows.Add(dato);
            }

            
            foreach (var dato in buscador.Values)
            {
                dt.Rows.Add(dato);
            }
            

            for(int i = 0; i < buscador.Count; i++)
            {
                dt.Rows.Add();
            }
            

            return dt;
        }
        */

        private void Form1_Load(object sender, EventArgs e)
        {
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string palabra;
            palabra = txtBuscar.Text;
            if(buscador[palabra] == null)
            {
                MessageBox.Show("La palabra " + palabra + " no está registrada");
                Limpiar();
            }
            else
            {
                MessageBox.Show(palabra + ": " + buscador[palabra]);
                Limpiar();

            }
        }

        public void Limpiar()
        {
            txtBuscar.Text = "";
            txtDesc.Text = "";
            txtPalabra.Text = "";
            txtPalabraEliminar.Text = "";
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string palabra, desc;
            palabra = txtPalabra.Text;
            desc = txtDesc.Text;

            if(txtPalabra.Text == "" && txtDesc.Text == "")
            {
                MessageBox.Show("Falta llenar campos");
            }
            else
            {
                buscador.Add(palabra, desc);
                MessageBox.Show("Nuevo término agregado");
            }
            Limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string palabra = txtPalabraEliminar.Text;

            if(txtPalabraEliminar.Text == "")
            {
                MessageBox.Show("No se ha llenado el campo necesario");
            }
            else if(buscador[palabra] == null)
            {
                MessageBox.Show("La palabra no está registrada");
            }
            else
            {
                buscador.Remove(palabra);
                MessageBox.Show("La palabra " + palabra + " fue eliminada");
            }
            Limpiar();
        }
    }
}
