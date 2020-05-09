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

            buscador.Add("Calculadora", "Aparato para cálculos matemáticos");
            buscador.Add("Teclado", "Aparato electrónico para escribir");
            buscador.Add("CPU", "Unidad Central de Proceso");
            buscador.Add("Software", "Conjunto de programas, instrucciones y reglas informáticas para ejecutar ciertas tareas en una computadora");
            buscador.Add("Hardware", "Conjunto de aparatos de una computadora");
            buscador.Add("RAM", "Memoria de Acceso Aleatorio");
            buscador.Add("Camara", "Sala o pieza principal de una casa");
            buscador.Add("Celular", "Número que se asigna a cada teléfono celular");
            buscador.Add("Programa", "Conjunto de operaciones ejecutadas por una máquina");
            buscador.Add("Programacion", "Acción y efecto de programar");
            buscador.Add("Cuaderno", "Conjunto o agregado de algunos pliegos de papel, doblados y cosidos en forma de libro");
            buscador.Add("Libro", "Conjunto de muchas hojas de papel u otro material semejante que, encuadernadas, forman un volumen");
            buscador.Add("Papel", "Hoja delgada hecha con pasta de fibras vegetales");
            buscador.Add("Madera", "Material obtenido de un árbol");
            buscador.Add("Jabon", "Producto soluble en agua");
            buscador.Add("Agua", "Líquido transparente, incoloro, inodoro e insípido");
            buscador.Add("Fuego", "Fenómeno caracterizado por la emisión de calor y de luz");
            buscador.Add("Universidad", "Institución de enseñanza superior");
            buscador.Add("Colegio", "Institución de enseñanza básica");
            buscador.Add("Estudiante", "Persona que cursa estudios en un establecimiento de enseñanza");
            buscador.Add("Profesor", "Persona que ejerce o enseña una ciencia o arte");
            buscador.Add("Asignatura", "Cada una de las materias que se enseñan en un centro docente");
            buscador.Add("Hora", "Tiempo que equivale a 60 minutos");
            buscador.Add("Minuto", "Tiempo que equivale a 60 segundos");
            buscador.Add("Segundo", "Unidad de tiempo del sistema internacional");
        }

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
            }
            else
            {
                MessageBox.Show(palabra + ": " + buscador[palabra]);
            }
            Limpiar();
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
                try
                {
                    buscador.Add(palabra, desc);
                    MessageBox.Show("Nuevo término agregado");
                }
                catch
                {
                    MessageBox.Show("Palabra ya existente");
                }
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

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Hay " + buscador.Count.ToString() + " palabras en el diccionario");
        }
    }
}
