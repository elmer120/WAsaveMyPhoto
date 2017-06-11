<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFfoto.aspx.cs" Inherits="WAsaveMyphoto.WFfoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <link href="bootstrap3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/baguettebox.js/1.8.1/baguetteBox.min.css">
    <link rel="stylesheet" href="plugin/freebie/gallery-grid.css">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="foto.css" rel="stylesheet" />
    <title></title>
</head>
<body>

 <nav class="navbar navbar-default">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand gli" href="#">SaveMyPhoto</a>
    </div>
    <ul id="navMenu" runat="server" class="nav navbar-nav">
     
    </ul>
  </div>
</nav>
  

<div class="container-fluid gallery-container">
    
    <div id="galleria" runat="server" class="tz-gallery">

        
        </div>

    </div>

</div>

<script src="https://cdnjs.cloudflare.com/ajax/libs/baguettebox.js/1.8.1/baguetteBox.min.js"></script>
<script>
    baguetteBox.run('.tz-gallery');
</script>

      <form id="form" runat="server">
    <div id="divMedia" runat="server">
    
    <!--
        <asp:Table ID="tUtenti" runat="server" BorderColor="Blue" BorderWidth="1px" GridLines="Both"></asp:Table>
     -->
    </div>
    </form>

      <script src="bootstrap3.3.7/jquery3.0.0/jquery-3.0.0.min.js"></script>
    <script src="bootstrap3.3.7/js/bootstrap.min.js"></script>
</body>
</html>
