using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Calculator.Library;

namespace Calculator.Web
{
    //TODO: Maybe add some css to page.
    public partial class CalculatorPage : System.Web.UI.Page
    {
        protected void OnMouseLeave(EventArgs e)
        {
            int x = 0;
            int y = 0;            
            string error = String.Empty;
            try
            {
                checked
                {
                    x = Convert.ToInt32(txtFirstNumber.Text);
                    y = Convert.ToInt32(txtSecondNumber.Text);
                }
            }
            catch (Exception ex) when (ex is OverflowException || ex is FormatException)
            {
                lblErrorMessage.Text = ex.Message;
                txtFirstNumber.Text = "0";
                txtSecondNumber.Text = "0";
            }
        }
        protected void Btn_Click(object sender, CommandEventArgs e)
        {
            int x = Convert.ToInt32(txtFirstNumber.Text);
            int y = Convert.ToInt32(txtSecondNumber.Text);
            int result = 0;
            string error = String.Empty;
            switch (e.CommandName)
            {
                case "Add":
                    result = Library.Calculator.Addition(x, y, out error);
                    break;
                case "Subtract":
                    result = Library.Calculator.Subtraction(x, y, out error);
                    break;
                case "Multiply":
                    result = Library.Calculator.Multiplication(x, y, out error);
                    break;
                case "Divide":
                    result = Library.Calculator.Division(x, y, out error);
                    break;
            }
            lblResult.Text = result.ToString();
            lblErrorMessage.Text = error;
        }
    }
}