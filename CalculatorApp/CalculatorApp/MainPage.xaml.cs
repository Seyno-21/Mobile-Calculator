using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private decimal firstNumber;
        private string operatorName;
        private bool isOperatorClicked;

        private void Common_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if(Result.Text=="0" || isOperatorClicked)
            {
                isOperatorClicked = false;  
                Result.Text = button.Text; 
            }
            else
            {
                Result.Text += button.Text;
            }
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            Result.Text="0";
            isOperatorClicked=false;
            firstNumber=0; 
        }

        private void Backspace_Clicked(object sender, EventArgs e)
        {
            string number = Result.Text;
            if(number != "0")
            {
                number = number.Remove(number.Length - 1, 1);  
                if(string.IsNullOrEmpty(number))
                {
                    Result.Text = "0";
                }
                else
                {
                    Result.Text = number;
                }
            }
        }

        private void CommonOperation_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = Convert.ToDecimal(Result.Text);
        }

        private async void Percentage_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = Result.Text;
                if (number != "0")
                {
                    decimal percent = Convert.ToDecimal(number);
                    string result = (percent / 100).ToString("0.##");
                    Result.Text = result;
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private void Equals_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(Result.Text);
                string endResult = Calculate(firstNumber, secondNumber).ToString("0.##");
                Result.Text = endResult;
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        public decimal Calculate(decimal firstNumber, decimal secondNumber)
        {
            decimal result = 0;
            if(operatorName == "+")
            {
                result =  firstNumber + secondNumber;
            }
            else if (operatorName == "-")
            {
                result =  firstNumber - secondNumber;
            }
            else if (operatorName == "*")
            {
                result =  firstNumber * secondNumber;
            }
            else if (operatorName == "/")
            {
                result = firstNumber / secondNumber;
            }
            return result;
        }
    }
}
