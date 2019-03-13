<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8">
    <title>MAKEWAY</title>
   
    <meta http-equiv="X-UA-Compatible" content=="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="libs/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="assets/fonts/line-awesome/css/line-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="assets/fonts/open-sans/styles.css">
    <link rel="stylesheet" type="text/css" href="libs/tether/css/tether.min.css">
    <link rel="stylesheet" type="text/css" href="assets/styles/common.min.css">
<link rel="stylesheet" type="text/css" href="assets/styles/pages/auth.min.css">
    
</head>
<body>
   <div class="ks-page">
    <div class="ks-page-header">
        <a href="#" class="ks-logo"></a>
    </div>
    <div class="ks-page-content">
        <div class="ks-logo">MAKE WAY</div>

        <div class="card panel panel-default ks-light ks-panel ks-login">
            <div class="card-block">
                <form class="form-container" runat="server">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                    <h4 class="ks-header">Login</h4>
                    <div class="form-group">
                        <div class="input-icon icon-left icon-lg icon-color-primary">
                            <asp:TextBox ID="LoginIdText" class="form-control" placeholder="Employee Id" runat="server" ></asp:TextBox>
                            <span class="icon-addon">
                                <span class="la la-at"></span>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-icon icon-left icon-lg icon-color-primary">
                            <asp:TextBox ID="LoginPasswordText" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                            <span class="icon-addon">
                                <span class="la la-key"></span>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                       <asp:Button  class="btn btn-primary btn-block" ID="LoginButton" runat="server" 
                            Text="Login" OnClientClick="return validate();" onclick="LoginButton_Click" />
                    </div>
                    <div class="ks-text-center">
                        <a href="forgotpassword.aspx">Forgot your password?</a>
                    </div>
                </form>
            </div>
        </div>
    </div>
   
</div>    
<script type="text/javascript">
        function validate() {
            var err = document.getElementById('<%=lblErrorMessage.ClientID%>');
            if (document.getElementById('<%=LoginIdText.ClientID%>').value == "") {
                err.innerHTML = "Enter the Login Id";
                document.getElementById('<%=LoginIdText.ClientID%>').focus();
                return false;
            }
            if (!(/^[m]{1}[0-9]+$/.test(document.getElementById('<%=LoginIdText.ClientID%>').value))) {
                err.innerHTML = "Invalid Login Id";
                document.getElementById('<%=LoginIdText.ClientID%>').focus();
                return false;
            }
            if (document.getElementById('<%=LoginPasswordText.ClientID%>').value == "") {
                err.innerHTML = "Enter the Password";
                document.getElementById('<%=LoginPasswordText.ClientID%>').focus();
                return false;
            }

        }
</script>
<script src="libs/jquery/jquery.min.js"></script>
<script src="libs/tether/js/tether.min.js"></script>
<script src="libs/bootstrap/js/bootstrap.min.js"></script>
</body>

</html>
