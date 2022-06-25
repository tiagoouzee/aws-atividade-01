using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace aws_atividade_01_win_forms
{    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Incluirlinha()
        {
            textBox1.Text += Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var objServicoWeb = new ServiceReference1.SOAPDemoSoapClient();
                                                
            //Executa o m�todo AddInteger 
            textBox1.AppendText("Executando met�do AddInteger (1 + 2)");
            textBox1.Text += Environment.NewLine + "****Resultado: " + objServicoWeb.AddIntegerAsync(1, 2).Result.ToString();

            Incluirlinha();

            textBox1.AppendText(Environment.NewLine + "Executando met�do DivideInteger (20 + 10)");
            textBox1.Text += Environment.NewLine + "****Resultado: " + objServicoWeb.DivideIntegerAsync(20,10).Result.ToString();

            Incluirlinha();

            textBox1.AppendText(Environment.NewLine + "Executando met�do FindPerson (ID Person 1)");

            var objPerson = objServicoWeb.FindPersonAsync("1").Result;
            if (objPerson != null)
                textBox1.Text += Environment.NewLine + "****Resultado: " + JsonConvert.SerializeObject(objPerson);
            else
                textBox1.Text += Environment.NewLine + "****Resultado: Person ID 1 N�o Localizado";

            Incluirlinha();

            textBox1.AppendText(Environment.NewLine + "Executando met�do GetByName (Name Newton)");

            var objListaPerson = objServicoWeb.GetByNameAsync("Newton").Result;

            if (objListaPerson != null)
                textBox1.Text += Environment.NewLine + "****Resultado: " + JsonConvert.SerializeObject(objListaPerson);
            else
                textBox1.Text += Environment.NewLine + "****Resultado: Person Name 'Newton' N�o Localizado";

            Incluirlinha();

        }
      
    }
}