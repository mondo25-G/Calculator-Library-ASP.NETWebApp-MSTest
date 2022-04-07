<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculatorPage.aspx.cs" Inherits="Calculator.Web.CalculatorPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Integer Values Calculator App</title>
    <script runat="server">
        void Page_Load(Object sender, EventArgs e)
        {
            // Manually register the event-handling method for the Command  
            // event of the Button controls.
            txtFirstNumber.Text = "0";
            txtSecondNumber.Text = "0";
            btnAdd.Command += new CommandEventHandler(this.Btn_Click);
            btnSubtract.Command += new CommandEventHandler(this.Btn_Click);
            btnMultiply.Command += new CommandEventHandler(this.Btn_Click);
            btnDivide.Command += new CommandEventHandler(this.Btn_Click);
        }
    </script>
</head>
<body style="font-family:Arial">
    <form id="form1" runat="server">
        <div>
            <table border="1">
                <tr>
                    <td>First Integer</td>
                    <td>
                         <asp:TextBox ID="txtFirstNumber" TabIndex="-1" onkeypress="return isNumberValid(this,event)" onmouseleave="overunderFlowNull(this)" runat="server" Width="50px"/>
                    </td>
                </tr>
                <tr>
                    <td>Second Integer</td>
                    <td>                        
                        <asp:TextBox ID="txtSecondNumber" TabIndex="-1" onkeypress="return isNumberValid(this,event)" onmouseleave="overunderFlowNull(this)" runat="server" Width="50px"/>
                    </td>
                </tr>
                <tr>
                    <td>Result</td>
                    <td>
                        <asp:Label ID="lblResult" runat="server" />
                    </td>
                </tr> 
            </table>
        </div>
        <div>
            <table border="1">
                <tr>
                    <asp:Button ID="btnAdd" Text="Add" CommandName="Add" runat="server" Width="50px"/><asp:Button ID="btnSubtract" Text="Subtract" CommandName="Subtract" runat="server" Width="70px"/>
                    <asp:Button ID="btnMultiply" Text="Multiply" CommandName="Multiply" runat="server" Width="70px"/><asp:Button ID="btnDivide" Text="Divide" CommandName="Divide" runat="server" Width="50px"/>
                </tr>
                <tr>
                    <td>Error Message:</td>
                    <td>
                        <asp:Label ID="lblErrorMessage" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
    <script type="text/javascript">
        //Int32 MaxValue, MinValue. Catch these clientside.
        const IntOverflowLimit = 2147483647;
        const IntUnderflowLimit = -2147483648;
        function isNumberValid(el, evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            // Allow non-printable keys
            if (!charCode || charCode == 8 /* Backspace */) {
                return;
            }
            var typedChar = String.fromCharCode(charCode);
            // Allow numeric characters
            if (/\d/.test(typedChar)) {
                return;
            }
            // Allow the minus sign (-) if the user enters it first
            if (typedChar == "-" && el.value == "") {
                return;
            }
            // In all other cases, suppress the event
            return false;
        }
        function overunderFlowNull(el) {
            if (el.value > IntOverflowLimit) {
                alert("Value above Int32.MaxValue");
                el.value = 0;
            }
            if (el.value < IntUnderflowLimit) {
                alert("Value below Int32.MaxValue");
                el.value = 0;
            }
            if (el.value=="") {
                el.value = 0;
            }
        }
    </script>
</html>
