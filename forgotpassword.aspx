<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgotpassword.aspx.cs" Inherits="forgotpassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8">
    <title>FORGOT PASSWORD</title>

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
        <div class="ks-logo">MAKEWAY</div>

        <div class="card panel panel-default light ks-panel ks-forgot-password">
            <div class="card-block">
                <form class="form-container" runat="server">
                    <h4 class="ks-header">
                        Forgot Password
                        <span>Don't worry, this happens sometimes.</span>
                    </h4>
                    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>

                    <div class="form-group">
                        <div class="input-icon icon-left icon-lg icon-color-primary">
                                 <asp:TextBox ID="ForgotPasswordId" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                           <span class="icon-addon">
                            <span class="la la-at"></span>
                        </span>
                        </div>
                    </div>

                    <div class="form-group">
                       <asp:Button ID="ForgotPasswordSubmit" runat="server" Text="SUBMIT" 
                            class="btn btn-primary btn-block" onclick="ForgotPasswordSubmit_Click" OnClientClick="return validate();" />
                    </div>
                    <div class="ks-text-center">
                        <span class="text-muted">Remember It?</span> <a href="login.aspx">Login</a>
                    </div>
                </form>
            </div>
        </div>
    </div>

</div>
<script type="text/javascript">
    function validate() {
        var err = document.getElementById('<%=lblErrorMessage.ClientID%>');
        if (document.getElementById('<%=ForgotPasswordId.ClientID%>').value == "") {
            err.innerHTML = "Enter your Registered Id";
            document.getElementById('<%=ForgotPasswordId.ClientID%>').focus();
            return false;
        }
        if (!(/^[m]{1}[0-9]{4}$/.test(document.getElementById('<%=ForgotPasswordId.ClientID%>').value))) {
            err.innerHTML = "Invalid  Id";
            document.getElementById('<%=ForgotPasswordId.ClientID%>').focus();
            return false;
        }
       

    }
</script>

<script src="libs/jquery/jquery.min.js"></script>
<script src="libs/tether/js/tether.min.js"></script>
<script src="libs/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
