using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interfaz_Lab_4
{
    public partial class FormSetting : Form
    {


        public FormSetting()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int16.Parse(textBox2.Text) < 0 || Int16.Parse(textBox2.Text) > 101 || Int16.Parse(textBox3.Text) < 0 || Int16.Parse(textBox3.Text) > 181 || Int16.Parse(textBox4.Text) < 0 || Int16.Parse(textBox4.Text) > 101 || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Ingrese un valor de 0 a 100 ó de 0 a 180 para el control de la llama porfavor.");
                }
                else
                {

                    if (Int16.Parse(textBox2.Text) < 10)
                    {
                        textBox2.Text = "00" + textBox2.Text;
                    }
                    else if (Int16.Parse(textBox2.Text) < 100)
                    {
                        textBox2.Text = "0" + textBox2.Text;
                    }
                    if (Int16.Parse(textBox3.Text) < 10)
                    {
                        textBox3.Text = "00" + textBox3.Text;
                    }
                    else if (Int16.Parse(textBox3.Text) < 100)
                    {
                        textBox3.Text = "0" + textBox3.Text;
                    }
                    if (Int16.Parse(textBox4.Text) < 10)
                    {
                        textBox4.Text = "00" + textBox4.Text;
                    }
                    else if (Int16.Parse(textBox4.Text) < 100)
                    {
                        textBox4.Text = "0" + textBox4.Text;
                    }
                    Datos.setpoint = textBox2.Text;
                    Datos.flame = textBox3.Text;
                    Datos.cooling = textBox4.Text;
                    Datos.trama = "A" + Datos.setpoint + "B" + Datos.flame + "C" + Datos.cooling;
                    if (Datos.trama.Length < 9)
                    {
                        Datos.trama = "A00" + Datos.setpoint + "B00" + Datos.flame + "C00" + Datos.cooling;
                    }
                    else if (Datos.trama.Length < 12)
                    {
                        Datos.trama = "A0" + Datos.setpoint + "B0" + Datos.flame + "C0" + Datos.cooling;
                    }
                    this.Hide();
                    FormStart formulario = new FormStart();
                    formulario.Show();
                }
            }
            catch
            {
                MessageBox.Show("Algo salio mal, porfavor verifique todos los datos ingresados");
                Datos.setpoint = "050";
                Datos.flame = "090";
                Datos.cooling = "050";
                Datos.trama = "A" + Datos.setpoint + "B" + Datos.flame + "C" + Datos.cooling;
                this.Hide();
                FormStart formulario = new FormStart();
                formulario.Show();
            }
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            //Datos.setpoint = "50";
            //Datos.flame = "50";
            //Datos.cooling = "50";
            //Datos.trama = "A0" + Datos.setpoint + "B0" + Datos.flame + "C0" + Datos.cooling;
        }
    }
}
