<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WAsaveMyphoto.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="login" runat="server">
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
    </form>
</body>
</html>
