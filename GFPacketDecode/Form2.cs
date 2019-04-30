using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFPacketDecode
{
    public delegate void FormSendDataHandler(Object obj);
    public partial class Form2 : Form
    {
        
        public event FormSendDataHandler form2SendEvent;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = packetdecode.Getsigns(richTextBox1.Text);
            if (temp != string.Empty)
            {
                //Form1.sign = temp;
                form2SendEvent(temp);
                //Form1.refresh();
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to get signtoken","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
