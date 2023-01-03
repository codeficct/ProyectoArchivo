using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoArchivo
{
    public partial class Form1 : Form
    {
        Vector v1, v2;
        FileSec F1, F2, F3;
        SaveFileDialog SaveFileDialog1, SaveFileDialog2;
        OpenFileDialog OpenFileDialog1, OpenFileDialog2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            v1 = new Vector(); v2 = new Vector();
            F1 = new FileSec(); F2 = new FileSec(); F3 = new FileSec();
            SaveFileDialog1 = new SaveFileDialog(); OpenFileDialog1 = new OpenFileDialog();
            SaveFileDialog2 = new SaveFileDialog(); OpenFileDialog2 = new OpenFileDialog();
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") throw new ArgumentException("Datos incorrectos o faltantes.");
                v1.SetNumbers(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Cargar.");
            }
        }

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text = v1.GetNumbers();
        }

        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog1.ShowDialog();
            if (SaveFileDialog1.FileName.Length > 0)
                v1.Grabar(SaveFileDialog1.FileName, ref F1);
            else
                MessageBox.Show("No has creado ningún archivo para grabar.", "Grabar", MessageBoxButtons.OK);
        }

        private void accesarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.ShowDialog();
            if (OpenFileDialog1.FileName.Length > 0)
                v1.Read(OpenFileDialog1.FileName, ref F1);
            else
                MessageBox.Show("No has seleccionado ningún archivo para leer.", "Accesar", MessageBoxButtons.OK);
        }

        private void elementosConDígitosIgualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog2.ShowDialog();
            if (SaveFileDialog2.FileName.Length > 0)
            {
                F1.Exercise1(SaveFileDialog2.FileName, ref F2);
                v1.Read(SaveFileDialog2.FileName, ref F2);
                textBox5.Text = v1.GetNumbers();
            }
            else
                MessageBox.Show("No has creado ningún archivo para Grabar los elementos con digitos iguales.", "Ejercicio 1", MessageBoxButtons.OK);
        }

        private void elementosConDígitosDiferentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog2.ShowDialog();
            if (SaveFileDialog2.FileName.Length > 0)
            {
                F1.Exercise2(SaveFileDialog2.FileName, ref F2);
                v1.Read(SaveFileDialog2.FileName, ref F2);
                textBox5.Text = v1.GetNumbers();
            }
            else
                MessageBox.Show("No has creado ningún archivo para Grabar los elementos con digitos diferentes.", "Ejercicio 2", MessageBoxButtons.OK);
        }

        private void dígitosOrdenadosAscODescConRazónDe1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog2.ShowDialog();
                if (SaveFileDialog2.FileName.Length > 0)
                {
                    if (txtReason.Text == "") throw new ArgumentException("Debe especificar una razón para verificar el orden Asc. o Desc. de los dígitos.");
                    F1.Exercise3(SaveFileDialog2.FileName, ref F2, int.Parse(txtReason.Text));
                    v1.Read(SaveFileDialog2.FileName, ref F2);
                    textBox5.Text = v1.GetNumbers();
                }
                else
                    MessageBox.Show("No has creado ningún archivo para Grabar los elementos con digitos ordenados.", "Ejercicio 3", MessageBoxButtons.OK);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ejercicio 3");
            }
        }

        private void ordenarVectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v1.SortVector();
            textBox4.Text = v1.GetNumbers();
        }

        private void unir2ArchOrdEnUn3erArchOrdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string cancelMsg = "Has cancelado la operación del ejercicio 4.";
                // First File
                DialogResult dialogResult1 = MessageBox.Show("Leer el primer archivo ordenado", "Leer 1", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    OpenFileDialog1.ShowDialog();
                    if (OpenFileDialog1.FileName.Length == 0)
                        throw new ArgumentException("No has seleccionado ningún archivo. " + cancelMsg);

                    v1.Read(OpenFileDialog1.FileName, ref F3);
                    if (!v1.IsOrder()) throw new ArgumentException("Debes ordenar el archivo 1 que has seleccionado. " + cancelMsg);
                }
                else if (dialogResult1 == DialogResult.No)
                    throw new ArgumentException(cancelMsg);

                // Second File
                DialogResult dialogResult2 = MessageBox.Show("Leer el segundo archivo ordenado", "Leer 2", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    OpenFileDialog2.ShowDialog();
                    if (OpenFileDialog2.FileName.Length == 0)
                        throw new ArgumentException("No has seleccionado ningún archivo. " + cancelMsg);

                    v1.Read(OpenFileDialog2.FileName, ref F3);
                    if (!v1.IsOrder()) throw new ArgumentException("Debes ordenar el archivo 2 que has seleccionado. " + cancelMsg);
                }
                else if (dialogResult2 == DialogResult.No)
                    throw new ArgumentException(cancelMsg);

                // Third File
                DialogResult dialogResult3 = MessageBox.Show("Crear el archivo resultado (ordenado) para la unión de dos archivos ordenados", "Crear archivo", MessageBoxButtons.YesNo);
                if (dialogResult3 == DialogResult.Yes)
                {
                    SaveFileDialog1.ShowDialog();
                    if (SaveFileDialog1.FileName.Length == 0)
                        throw new ArgumentException("No has creado ningún archivo. " + cancelMsg);
                }
                else if (dialogResult3 == DialogResult.No)
                    throw new ArgumentException(cancelMsg);

                F1.Exercise4(OpenFileDialog1.FileName, OpenFileDialog2.FileName, SaveFileDialog1.FileName, ref F2, ref F3);

                v1.Read(SaveFileDialog1.FileName, ref F3);
                textBox6.Text = v1.GetNumbers();

                v1.Read(OpenFileDialog2.FileName, ref F3);
                textBox5.Text = v1.GetNumbers();

                v1.Read(OpenFileDialog1.FileName, ref F3);
                textBox4.Text = v1.GetNumbers();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ejercicio 4", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
