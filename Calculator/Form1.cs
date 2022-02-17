namespace Calculator
{
    public partial class Form1 : Form
    {
        Taschenrechner tr = new Taschenrechner();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tr.SetEingabe(textBox1.Text);
            textBox1.Text = tr.GetErgebnis().ToString();
        }
    }
}