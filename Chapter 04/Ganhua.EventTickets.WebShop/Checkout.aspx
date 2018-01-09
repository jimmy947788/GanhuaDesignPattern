<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Ganhua.EventTickets.WebShop.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>結帳</h2>  
        
       在您的購物籃裡面有:
        <p>
        <asp:Label ID="lblBasketContents" runat="server" Text=""></asp:Label>
        </p>
                            
        <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" 
            onclick="btnPlaceOrder_Click"  />
        <br />
        <small>click &#39;Place Order&#39; button again and the Ticket Id will 
        always return the same due to the use of the Idempotent Pattern.</small><br />
        <br />
        <asp:Label ID="lblThankYou" runat="server" Text=""></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
