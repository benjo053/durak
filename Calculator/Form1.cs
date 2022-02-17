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

        private void Multiply_onClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "123*";
        }

        private void Divide_onClick(object sender, MouseEventArgs e)
        {
            textBox1.Text += "/";
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