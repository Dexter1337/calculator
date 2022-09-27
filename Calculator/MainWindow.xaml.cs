using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Calculator.Calculation;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        bool operationFinished = false;
        double firstnum;
        double secondnum;
        string op;
        Calculation calculation;
        public MainWindow()
        {            
            InitializeComponent();
            txtRes.Text = "0";
            calculation = new Calculation();           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (operationFinished == true)
            {
                txtRes.Clear();
                operationFinished = false;
            }
            Button btn = (Button)sender;
            if (txtRes.Text == "0")
            {
                txtRes.Text = btn.Content.ToString();
            }
           else               
                txtRes.Text += btn.Content.ToString();
                secondnum = double.Parse(txtRes.Text);           
        }

        private void divideBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtRes.Text, out firstnum))
            {
                op = "/";
                txtRes.Clear();
            }
        }
        private void equalsBtn_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
            if (op == "/" && secondnum == 0)
            {
                MessageBox.Show("Division by 0 is not supported!");
                txtRes.Clear();
                txtRes.Text = "0";
                return;
            }
            if (double.TryParse(txtRes.Text, out secondnum))
            {
                secondnum = double.Parse(txtRes.Text);
            }                        
            result = calculation.operations[op].Call(firstnum, secondnum);
            
          
            txtRes.Text = result.ToString();
            operationFinished = true;
        }
        private void commaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtRes.Text == "")
            {
                txtRes.Text = "0,";
                return;
            }
            if (txtRes.Text.Contains(","))
            {
                return;
            }
            else
                txtRes.Text += ",";
            
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            txtRes.Text = "";
        }

        private void addminusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtRes.Text.Contains("-"))
            {
                txtRes.Text = txtRes.Text.Replace("-", "");
            }
            else
                txtRes.Text = "-" + txtRes.Text;
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtRes.Text, out firstnum))
            {
                op = "+";
                txtRes.Clear();
            }
        }
        private void multiplyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtRes.Text, out firstnum))
            {
                op = "*";
                txtRes.Clear();
            }
        }

        private void subBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtRes.Text, out firstnum))
            {
                op = "-";
                txtRes.Clear();
            }
        }
        private void percentBtn_Click(object sender, RoutedEventArgs e)
        {           
            txtRes.Text = calculation.operations["percent"].Call(Double.Parse(txtRes.Text)).ToString();
        }
        private void sinBtn_Click(object sender, RoutedEventArgs e)
        {
            double result;
            result = calculation.operations["sinus"].Call(Double.Parse(txtRes.Text));
            txtRes.Text = result.ToString();
        }
    }
}
