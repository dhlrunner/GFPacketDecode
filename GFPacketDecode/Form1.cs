using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC;
using System.Windows.Forms;

namespace GFPacketDecode
{
    public partial class Form1 : Form
    {
        public static string sign = string.Empty;
        int inittime = Int32.Parse(packetdecode.init());
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            label3.Text = "Decodemodule successfully Initialized to " + inittime.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();          
            frm.form2SendEvent += new FormSendDataHandler(receiveFormEvent);
            frm.Show();         
        }
        public void refresh()
        {
            
        }
        public void receiveFormEvent(Object objc)
        {  
            textBox1.Text = objc.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sign = textBox1.Text;
            if (textBox1.Text != string.Empty)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (sign != string.Empty)
                {
                    richTextBox2.Text = packetdecode.Decode(richTextBox1.Text, sign);
                }
                else
                    MessageBox.Show("invalled signtoken");
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                if (sign != string.Empty)
                {
                    richTextBox2.Text = packetdecode.Encode(richTextBox1.Text, sign);
                }
                else
                    MessageBox.Show("invalled signtoken");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetDataObject(richTextBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string temp1 = richTextBox1.Text;
            richTextBox1.Text = richTextBox2.Text;
            richTextBox2.Text = temp1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = "Time:  " + packetdecode.GetCurrentTimeStamp().ToString()+"  Offset:  "+( packetdecode.GetCurrentTimeStamp()-inittime ).ToString();
        }
    }
}
