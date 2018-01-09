<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ganhua.EventTickets.WebShop._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <h2>購物籃</h2>   
        <img src="Images/18518115_1648785301817488_5497926307897632865_o.jpg" width="800px" />
        <br />
        我要買&nbsp; <asp:TextBox ID="txtNoOfTickets" runat="server" Width="43px"></asp:TextBox>
        &nbsp;張&nbsp; 
        <asp:DropDownList ID="ddlEvents" runat="server">
            <asp:ListItem Value="2de874d0-00b7-4c86-9925-c7f2c243151c">TAE 台灣成人展</asp:ListItem>            
        </asp:DropDownList> 的票
        &nbsp;
        <br />
        <br />
        <asp:Button ID="btnReserveTickets" runat="server" Text="保留 & 結帳" 
            onclick="btnReserveTickets_Click" />                           
        <br />
        <small>"保留 &amp; 結帳" Reserves the Tickets for you as part 
        of the Reservation Pattern.</small></div>
    </form>
</body>
</html>
