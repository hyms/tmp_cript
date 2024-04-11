using System;
using System.Windows.Forms;

namespace BouncyCastle_BGAUI
{
    public partial class Form1 : Form
    {
        private Logic _logic;

        public Form1()
        {
            InitializeComponent();
            _logic = new Logic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = _logic.GeneratePublic();
            textBox4.Text = path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var path = _logic.GeneratePrivate();
            textBox1.Text = path;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                MessageBox.Show(@"path de llave publica no puede ser vacio");
                textBox4.Focus();
            }
            else if (textBox2.Text == string.Empty)
            {
                MessageBox.Show(@"texto originar no puede ser vacio");
                textBox2.Focus();
            }
            else
            {
                textBox3.Text=_logic.Encrypt(textBox2.Text,textBox4.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show(@"path de llave privada no puede ser vacio");
                textBox3.Focus();
            }
            else if (textBox3.Text == string.Empty)
            {
                MessageBox.Show(@"texto encriptado no puede ser vacio");
                textBox3.Focus();
            }
            else
            {
                textBox2.Text=_logic.Decrypt(textBox3.Text,textBox1.Text);
            }
        }
    }
}