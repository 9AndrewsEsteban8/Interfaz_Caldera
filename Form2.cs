using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Interfaz_Lab_4

{
   
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }


        private void FormStart_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            serialPort1.Write(Datos.trama);
            textBox2.Text = Datos.setpoint;
            textBox3.Text = Datos.flame;
            textBox4.Text = Datos.cooling;
            serialPort1.ReceivedBytesThreshold = 1; // Activar el evento DataReceived tan pronto como llegue el primer byte
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }

 

    private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string data = " "+serialPort1.ReadExisting();
        BeginInvoke(new Action(() =>
        {
            textBox1.AppendText(data);
        }));
    }



    private void button2_Click(object sender, EventArgs e)
        {
            Datos.trama = "0" + Datos.setpoint + "B" + Datos.flame + "C" + Datos.cooling;
            serialPort1.Write(Datos.trama);
            serialPort1.Close();
            this.Hide();
            FormSetting formulario = new FormSetting();
            formulario.Show();
        }
    }
}