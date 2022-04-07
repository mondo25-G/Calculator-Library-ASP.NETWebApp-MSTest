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
        protected void Btn_Click(object sender, CommandEventArgs e)
        {
            //catch button click with no input at all.
            if (txtFirstNumber.Text=="")
            {
                txtFirstNumber.Text = "0";
            }
            if (txtSecondNumber.Text == "")
            {
                txtSecondNumber.Text = "0";
            }
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