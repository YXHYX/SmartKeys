using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Ports;

//fix port not showing when usb plugged

namespace SmartKeys
{
    public partial class Form1 : Form
    {
        static int[] baudrates = new int[14] { 110, 150, 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600 };
        public static bool[] buttonClicked = new bool[9] {false, false, false, false, false, false, false, false, false, };
        public static SerialPort serialPort;
        public static string[] portNames = SerialPort.GetPortNames();
        public static string input = "";
        static string s = "";
        public Form1()
        {
            InitializeComponent();
            serialPort = new SerialPort();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            
        }
        public void checkButtons() //check the buttons, if pressed then set the pressed button state to true
        {
            if (serialPort.IsOpen)
            {
                switch (s.Substring(0,1))
                {
                    case "1":
                        buttonClicked[0] = true;
                        textBox1.Invoke(new MethodInvoker(delegate
                        {

                            textBox1.Text = "true";
                        }));
                        break;
                    case "2":
                        buttonClicked[1] = true;
                        textBox1.Invoke(new MethodInvoker(delegate
                        {

                            textBox1.Text = "true";
                        }));
                        break;
                    case "3":
                        textBox1.Invoke(new MethodInvoker(delegate
                        {

                            textBox1.Text = "true";
                        }));
                        buttonClicked[2] = true;
                        break;
                    case "4":
                        textBox1.Invoke(new MethodInvoker(delegate
                        {

                            textBox1.Text = "true";
                        }));
                        buttonClicked[3] = true;
                        break;
                    case "5":
                        textBox1.Invoke(new MethodInvoker(delegate
                        {

                            textBox1.Text = "true";
                        }));
                        buttonClicked[4] = true;
                        break;
                    case "6":
                        textBox1.Invoke(new MethodInvoker(delegate
                        {

                            textBox1.Text = "true";
                        }));
                        buttonClicked[5] = true;
                        break;
                    case "7":
                        textBox1.Invoke(new MethodInvoker(delegate
                        {

                            textBox1.Text = "true";
                        }));
                        buttonClicked[6] = true;
                        break;
                    case "8":
                        textBox1.Invoke(new MethodInvoker(delegate
                        {

                            textBox1.Text = "true";
                        }));
                        buttonClicked[7] = true;
                        break;
                    case "9":
                        textBox1.Invoke(new MethodInvoker(delegate
                        {

                            textBox1.Text = "true";
                        }));
                        buttonClicked[8] = true;
                        break;
                    default:
                        break;
                }
            }
        }
        public void launchAppOnClick()
        {
            for (int i = 0; i < buttonClicked.Length; i++)
            {
                if (buttonClicked[i] == true && SetButtons.buttonsPath[i] != string.Empty)
                {
                    try
                    {
                        Process.Start(SetButtons.buttonsPath[i]);
                    }
                    catch (Win32Exception)
                    {
                        throw;
                    }
                    buttonClicked[i] = false;
                }
            }
        }
        void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            s = serialPort.ReadLine();
            textBox1.Invoke(new MethodInvoker(delegate
            {
                textBox1.Text = s;
            }));
            checkButtons();
            launchAppOnClick();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (int baudrate in baudrates)
            {
                comboBox2.Items.Add(baudrate);
            }
            
            foreach (string port in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(port);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen && serialPort != null)
            {
                serialPort.Open();
                button10.Text = "Disconnect";
            }
            else 
            {
                serialPort.Close();
                button10.Text = "Connect";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetButtons setButtons = new SetButtons();
            setButtons.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //refresh and set the selected port
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = comboBox1.SelectedItem.ToString();
                //if its not refreshed, refresh it
                if (portNames != SerialPort.GetPortNames())
                {
                    comboBox1.Items.Clear();
                    foreach (string port in portNames)
                    {
                        comboBox1.Items.Add(port);
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!serialPort.IsOpen)
                serialPort.BaudRate = Convert.ToInt32(comboBox2.SelectedItem);
        }
    }
}
