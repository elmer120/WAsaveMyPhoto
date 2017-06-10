<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WAsaveMyphoto.Index" %>

<!DOCTYPE html>
<link href="bootstrap3.3.7/css/bootstrap.min.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
   

    <div class="container">
    <div class="row">
        <div class="col-md-offset-5 col-md-3">
            
            <div class="form-login text-center">
                <h3>Accedi</h3>

            <form id="login" runat="server">
                <asp:Textbox id="txtUsername" runat="server" CssClass="form-control input-sm chat-input" placeholder="nome utente"></asp:Textbox>
                <br/>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control input-sm chat-input" placeholder="password"></asp:TextBox>
                <br/>
                <asp:Label ID="lblError" runat="server" CssClass="alert-danger"></asp:Label>
                <br/><br/>
                    <div class="wrapper">
                        <span class="group-btn">     
                            <asp:Button ID="btnAccedi" runat="server" CssClass="btn btn-primary btn-md" Text="Accedi" Onclick="btnAccedi_click"></asp:Button>
                        </span>
                    </div>
              </form>
            </div>
        </div>
    </div>
</div>


 <%--   <form id="login" runat="server">
    <div>

        Login

        <br/><br/>

        <asp:Label id="lblUsername" runat="server" Text="Nome Utente"></asp:Label>
        &#160 &#160 &#160
        <asp:Textbox id="txtUsername" runat="server"></asp:Textbox>

        <br/><br/>
        
        <asp:Label id="lblPassword" runat="server" Text="Password"></asp:Label>
        &#160 &#160 &#160 &#160 &#160
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>

        <br /><br />

        <asp:Button ID="btnAccedi" runat="server" Text="Accedi" Onclick="btnAccedi_click"/>

        <br/> <br/> 

        <asp:Label ID="lblError" runat="server" ></asp:Label>

    </div>
    </form>--%>
    <script src="bootstrap3.3.7/jquery3.0.0/jquery-3.0.0.min.js"></script>
    <script src="bootstrap3.3.7/js/bootstrap.min.js"></script>
</body>
</html>
