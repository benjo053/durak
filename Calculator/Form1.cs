namespace Calculator
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    
    public partial class Form1 : Form
    {
        Taschenrechner tr = new Taschenrechner();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Number_onClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text = (textBox1.Text == "0") ? button.Text : textBox1.Text + button.Text;
        }

        private void Symbol_onClick(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            int i = textBox1.Text.Length - 1;
            if (textBox1.Text[i] == '+' || textBox1.Text[i] == '-' || textBox1.Text[i] == '*' || textBox1.Text[i] == '/' || textBox1.Text[i] == ',')
            {
                textBox1.Text = textBox1.Text[0..i] + b.Tag;
            } else
            {
                textBox1.Text += b.Tag;
            }
        }

        private void Evaluate_onClick(object sender, MouseEventArgs e)
        {
            tr.SetEingabe(textBox1.Text);
            textBox1.Text = tr.GetErgebnis().ToString();
        }

        private void ClearAll_onClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "0";
        }
    }

    class RoundButton : Button
    {
        protected override void OnResize(EventArgs e)
        {
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(2, 2, this.Width - 5, this.Height - 5));
                this.Region = new Region(path);
            }
            base.OnResize(e);
        }
    }
}