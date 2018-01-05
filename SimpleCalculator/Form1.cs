/*
SimpleCalculator
VERSION: 1.0

Description: It is a simple calculator.

Developer: Nicolas CHEN
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        Double resultCalculator = 0;
        bool isOperatorPerformed = false;
        String operatorPerformed = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] about = new string[]
            {
                "SimpleCalculator"
                , ""
                , "This is a simple calculator."                
            };

            MessageBoxMultiLines(about);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] about = new string[]
            {
                "SimpleCalculator"
                , ""
                , "VERSION: 1.0"
                , ""
                , "Developed by Nicolas Chen"
            };

            MessageBoxMultiLines(about);
        }


        public void MessageBoxMultiLines(IEnumerable<string> lines)
        {
            var instructionLine = new StringBuilder();
            bool firstLine = false;
            foreach (string line in lines)
            {
                if (firstLine)
                    instructionLine.Append(Environment.NewLine);

                instructionLine.Append(line);
                firstLine = true;
            }
            MessageBox.Show(instructionLine.ToString(), "Information");
        }


        private void OperatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultCalculator != 0)
            {
                ResultButton.PerformClick();
                operatorPerformed = button.Text;
                labelCurrentOp.Text = resultCalculator + " " + operatorPerformed;
                isOperatorPerformed = true;
            }
            else
            {

                operatorPerformed = button.Text;
                resultCalculator = double.Parse(textBoxResult.Text);
                labelCurrentOp.Text = resultCalculator + " " + operatorPerformed;
                isOperatorPerformed = true;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            resultCalculator = 0;
            labelCurrentOp.Text = String.Empty;
        }

        private void ClearRecentEntryButton_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
        }   

        private void figureClick(object sender, EventArgs e)
        {
            if ((textBoxResult.Text == "0") || (isOperatorPerformed))
                textBoxResult.Clear();

            isOperatorPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBoxResult.Text.Contains("."))
                    textBoxResult.Text = textBoxResult.Text + button.Text;

            }
            else
                textBoxResult.Text = textBoxResult.Text + button.Text;
        }

        private void resultClick(object sender, EventArgs e)
        {
            switch (operatorPerformed)
            {
                case "+":
                    textBoxResult.Text = (resultCalculator + double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "-":
                    textBoxResult.Text = (resultCalculator - double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "*":
                    textBoxResult.Text = (resultCalculator * double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "/":
                    textBoxResult.Text = (resultCalculator / double.Parse(textBoxResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultCalculator = double.Parse(textBoxResult.Text);
            labelCurrentOp.Text = "";
        }

        private void PiButton_Click(object sender, EventArgs e)
        {            
            isOperatorPerformed = false;            
            double pi = Math.PI;
            textBoxResult.Text = pi.ToString();
        }

        private void InverseButton_Click(object sender, EventArgs e)
        {
            isOperatorPerformed = false;
            
            if (textBoxResult.Text == "0")
            {
                MessageBox.Show("Error: Division by zero!", "Error", MessageBoxButtons.OK,    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                textBoxResult.Clear();
            }
            else
            {
                textBoxResult.Text = (1 / double.Parse(textBoxResult.Text)).ToString();
            }
        }

        private void SquareRoot_Click(object sender, EventArgs e)
        {
            isOperatorPerformed = false;            
            textBoxResult.Text = Math.Sqrt(double.Parse(textBoxResult.Text)).ToString();
        }

        private void PlusMinus_Click(object sender, EventArgs e)
        {
            isOperatorPerformed = false;
            textBoxResult.Text = (double.Parse(textBoxResult.Text) * -1).ToString();
        }
    }
}
