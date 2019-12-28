using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mortgage_Calculator
{
    public partial class Form1 : Form
    {
        Double homePrice;
        Double downPayment;
        Double loanAmount;
        Double intRatePerMonth;
        Double loanPeriod;
        Double mortgagePayment;
        Double propertyTaxRate;
        Double pmiRate;
        Double hoa;
        Double fin;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //1. Loan Amount
            homePrice = Convert.ToDouble(textBox1.Text);
            downPayment = Convert.ToDouble(textBox2.Text);
            loanAmount = homePrice - downPayment;
            
            //3. Loan Period (Years)
            loanPeriod = Convert.ToDouble(textBox4.Text);

            //2. Interest Rate
            //Check if interest rate is not entered
            //If yes proceed
            //If no, assign var the national average mortgage rates
            //30 year fixed = 3.99%
            //15 year fixed = 3.52%
            //else 3.76%
            if (textBox3.Text == "")
                if (loanPeriod == 30)
                {
                    intRatePerMonth = 3.99 / 100 / 12;
                    textBox2.Text = "3.99 - National Average";
                }

                else if (loanPeriod == 15)
                {
                    intRatePerMonth = 3.52 / 100 / 12;
                    textBox2.Text = "3.52 - National Average";
                }
                else
                {
                    intRatePerMonth = 3.76 / 100 / 12;
                    textBox2.Text = "3.76 - National Average";
                }
            else
                intRatePerMonth = Convert.ToDouble(textBox3.Text) / 100 / 12;

            loanPeriod *= 12;

            mortgagePayment = (loanAmount) * ((intRatePerMonth) * (Math.Pow((1 + intRatePerMonth), loanPeriod)) / ((Math.Pow((1 + intRatePerMonth), loanPeriod)) - 1));
            //mortgagePayment = Math.Round(mortgagePayment);
            
            if(textBox5.Text == "")
            {
                propertyTaxRate = 1.2 / 100;
                textBox5.Text = "1.2 - Average";
            }
            else
                propertyTaxRate = Convert.ToDouble(textBox5.Text)/100;

            if (textBox6.Text == "")
            {
                if(downPayment/homePrice < .2)
                {
                    textBox6.Text = "0.75 - Average";
                    pmiRate = .75 / 100;
                }
                else
                {
                    textBox6.Text = "0 - >20% Equity";
                    pmiRate = 0;
                }
            }
            else
                pmiRate = Convert.ToDouble(textBox6.Text)/100;

            if (textBox7.Text == "")
            {
                hoa = 0;
                textBox7.Text = "0";
            }
            else
                hoa = Convert.ToDouble(textBox7.Text);

            fin = Math.Round(mortgagePayment + (propertyTaxRate * homePrice / 12) + (pmiRate * loanAmount / 12) + hoa);
            textBox8.Text = "$" + fin.ToString() + " /month";
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            //textBox1.Clear();
            //textBox2.Clear();
            //textBox5.Clear();
            //textBox4.Clear();
        }
        //private void button4_Click_1(object sender, EventArgs e)
        //{
            
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            //Go to next panel and show costs such as Property Tax, PMI, Home Insurance and HOA
            panel1.Visible = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //label4.Visible = false;
            //textBox4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            panel1.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
