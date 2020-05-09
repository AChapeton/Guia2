using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Ejemplo1_Gui9
{
    public partial class Form1 : Form
    {

       
        int xo, yo, tam; 
        bool ec = false; 
        bool estado = false; 
        int n = 0,  i = 1;  
        
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(txtnumeros.Text);

                Array.Resize<int>(ref Arreglo_numeros, i + 1); 
                Arreglo_numeros[i] = num; 
                Array.Resize<Button>(ref Arreglo, i + 1);
                Arreglo[i] = new Button();
               
                Arreglo[i].Text = Arreglo_numeros[i].ToString(); 
                Arreglo[i].Height = 40; 
                Arreglo[i].Width = 40; 
                Arreglo[i].BackColor = Color.DarkViolet;
                Arreglo[i].ForeColor=Color.White ;
                Arreglo[i].Font = new Font("Century Gothic", 12);
                Arreglo[i].Location = new Point(xo, yo) + new Size(-20, 0); 

                

                if ((i + 1) == Math.Pow(2, n + 1)) 
                {
                    n++;
                    tam = tam / 2; 
                    xo = tam;
                    yo += 60;
                }
                else
                {
                    xo += (2 * tam);

                }

                i++; 
                estado = true; 
                ec = false;
                tabPage1.Refresh(); 
                txtnumeros.Clear(); 
                txtnumeros.Focus();
            }
            catch
            {
                MessageBox.Show("Valor no valido"); //error
            }
        }

        //EVENTO LIMPIAR
        private void button2_Click(object sender, EventArgs e)
        {
            //LIMPIAMOS LA PANTALLA 
            n = 0;
            i = 1;
            tam = tabPage1.Width / 2;
            xo = tam;
            yo = 20;
            tabPage1.Controls.Clear();
            tabPage1.Refresh();
            Array.Resize<int>(ref Arreglo_numeros, 1);
            Array.Resize<Button>(ref Arreglo, 1);

        }

        //EVENTO ORDENAR
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                n = 0;

                int contador = 0;
                float promedioso = 0;
                tam = tabPage1.Width / 2;
                xo = tam;
                yo = 20;
                tabPage1.Controls.Clear();
                tabPage1.Refresh();

                Array.Resize<Button>(ref Arreglo, 1);
                for (int k = 0; k < Arreglo_numeros.Length; k++)
                {
                    promedioso += Arreglo_numeros[k];
                }
  
                promedioso = promedioso / (Arreglo_numeros.Length-1);

                for (int k = 0; k < Arreglo_numeros.Length - 1; k++)
                {
                    if (promedioso >= Arreglo_numeros[k])
                    {
                        contador++;
                    }
                }

                for (int j = 0; j < Arreglo_numeros.Length; j++)
                {
                    for (int k = 0; k < Arreglo_numeros.Length - 1; k++)
                    {
                        if (contador >= Arreglo_numeros.Length - 1 - contador)
                        {
                            if (Arreglo_numeros[k] > Arreglo_numeros[k + 1])
                            {
                                int aux = Arreglo_numeros[k];
                                Arreglo_numeros[k] = Arreglo_numeros[k + 1];
                                Arreglo_numeros[k + 1] = aux;
                            }
                        }
                        else
                        {
                            if (Arreglo_numeros[k] != 0)
                            {
                                if (Arreglo_numeros[k] < Arreglo_numeros[k + 1])
                                {
                                    int aux = Arreglo_numeros[k];
                                    Arreglo_numeros[k] = Arreglo_numeros[k + 1];
                                    Arreglo_numeros[k + 1] = aux;
                                }
                            }

                        }
                    }
                }


                for (int j = 0; j < Arreglo_numeros.Length; j++)
                {
                    Array.Resize<Button>(ref Arreglo, j + 1);
                    Arreglo[j] = new Button();

                    Arreglo[j].Text = Arreglo_numeros[j].ToString();
                    Arreglo[j].Height = 40;
                    Arreglo[j].Width = 40;
                    Arreglo[j].BackColor = Color.DarkViolet;
                    Arreglo[j].ForeColor = Color.White;
                    Arreglo[j].Font = new Font("Century Gothic", 12);
                    if (j == 1) { Arreglo[j].Location = new Point(xo / 3, yo) + new Size(-20, 0); }
                    else
                    {
                        Arreglo[j].Location = new Point(xo, yo) + new Size(-20, 0);
                    }



                    if ((j + 1) == Math.Pow(2, n + 1))
                    {
                        n++;
                        tam = tam / 2;
                        xo = tam;
                        yo += 60;
                    }
                    else
                    {
                        xo += (2 * tam);

                    }


                    estado = true;
                    ec = false;
                    tabPage1.Refresh();
                    txtnumeros.Clear();
                    txtnumeros.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Lamentamos informarle que en este preciso espacio tiempo, todavia no hay ningun dato ingresado sobre el cual poder decidir un orden, le ruego de favor ingrese un valor para poder llevar acabo dicha accion, sin nada mas que agregar y esperando pueda seguir llevando a cabo la ejecucion del programa sin ningun tipo de problema, nos despedimos.\n ATT. Johan y Andres","FATAL_ERROR x0000058", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        public void intercambio(ref Button[] botones, int a, int b)
        {
            string tem = botones[a].Text;
            Point pa = botones[a].Location;
            Point pb = botones[b].Location;

            int diferenciaX = Math.Abs(pa.X - pb.X);
            int diferenciaY = Math.Abs(pa.Y - pb.Y);

            int x = 10;
            int y = 10;
            int t = 70;

            while (y != diferenciaY + 10)
            {
                Thread.Sleep(t);
                botones[a].Location += new Size(0, -10);
                botones[b].Location += new Size(0, +10);
                y += 10;
            }

            while (x != diferenciaX - diferenciaX % 10 + 10)
            {
                if (pa.X < pb.X)
                {
                    Thread.Sleep(t);
                    botones[a].Location += new Size(+10, 0);
                    botones[b].Location += new Size(-10, 0);
                    x += 10;
                }

                else
                {
                    Thread.Sleep(t);
                    botones[a].Location += new Size(-10, 0);
                    botones[b].Location += new Size(+10, 0);
                    x += 10;
                }
            }
            botones[a].Text = botones[b].Text;
            botones[b].Text = tem;
            botones[b].Location = pb;
            botones[a].Location = pa;
            estado = true;
            tabControl1.Refresh();

        }

       

        public void Dibujar_Arreglo(ref Button[] botones, ref TabPage tb)
        {
            for (int j = 1; j < botones.Length; j++)
            {
                tb.Controls.Add(this.Arreglo[j]);
            }
        }

        public void Dibujar_ramas(ref Button[] botones, ref TabPage tb, PaintEventArgs e)
        {
            Pen lapiz = new Pen(Color.Gray, 1.5f);
            Graphics g;
            g = e.Graphics;

            for (int j = 1; j < Arreglo.Length; j++)
            {
                if (Arreglo[(2 * j)] != null)
                {
                    g.DrawLine(lapiz, Arreglo[j].Location.X, Arreglo[j].Location.Y + 20, Arreglo[(2 * j)].Location.X + 20, Arreglo[(2 * j)].Location.Y);
                }

                if (Arreglo[(2 * j)] != null)
                {
                    g.DrawLine(lapiz, Arreglo[j].Location.X + 40, Arreglo[j].Location.Y + 20, Arreglo[(2 * j)].Location.X + 20, Arreglo[(2 * j) + 1].Location.Y);
                }
            }
        }

        public void HPN()
        {
            int temp;
            int x = Arreglo_numeros.Length;

            for (int i = x - 1; i >= 1; i--)
            {
                intercambio(ref Arreglo, i, 1);
                temp = Arreglo_numeros[i];
                Arreglo_numeros[i] = Arreglo_numeros[1];
                Arreglo_numeros[1] = temp;
                x--;
            }

        }

        public void Heap_Num()
        {
            ec = true;
            int x = Arreglo.Length;
            for (int i = (x) / 2; i > 0; i--) ;




        }
        public void Heap_MinNum()
        {
            ec = true;

            int x = Arreglo.Length;

            for (int i = (x) / 2; i > 0; i--)
                Min_Num(Arreglo_numeros, x, i, ref Arreglo);
        }

        public void Max_Num(int[] a, int x, int indice, ref Button[] botones)
        {
            int izquierdo = (indice) * 2;
            int derecho = (indice) * 2 + 1;
            int mayor = 0;
            if (izquierdo < x && a[izquierdo] > a[indice])
            {
                mayor = izquierdo;
            }
            else
            {
                mayor = indice;
            }
            if (derecho < x && a[derecho] > a[mayor])
            {
                mayor = derecho;
            }

            if (mayor != indice)
            {
                int tem = a[indice];
                a[indice] = a[mayor];
                a[mayor] = tem;

                intercambio(ref Arreglo, mayor, indice);
                Max_Num(a, x, mayor, ref botones);

            }


        }

        public void Min_Num(int[] a, int x, int indice, ref Button[] botones)
        {
            
        }
        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            if (estado)
            {
                try
                {
                    Dibujar_Arreglo(ref Arreglo, ref tabPage1);
                    Dibujar_ramas(ref Arreglo, ref tabPage1, e);
                }
                catch
                {

                }
                estado = false;
            }

        }

        int[] Arreglo_numeros; //Arreglo de numeros ingresado
        Button[] Arreglo; //arreglo de botones  para simular valores ingresador 

        //Inicializacion del formulario 
        public Form1()
        {
            InitializeComponent();
            tam = tabPage1.Width / 2;
            xo = tam;  // el valor inicial de x sera la mitad del ancho del tabpage 
            yo = 20; //el valor incial en y y sera en 20 
            txtnumeros.Focus(); //Cursor en textbox
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (i == 1)
                MessageBox.Show("No hay elementos que ordenar");
            else
            {
                btnagregar.Enabled = false;
                btnlimpiar.Enabled = false;
                btnordenar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (!ec)
                {
                    Heap_MinNum();
                }
                else
                {
                    HPN();
                }

                btnagregar.Enabled = true;
                btnlimpiar.Enabled = true;
                
                this.Cursor = Cursors.Default;
            }
        }


    }

}
