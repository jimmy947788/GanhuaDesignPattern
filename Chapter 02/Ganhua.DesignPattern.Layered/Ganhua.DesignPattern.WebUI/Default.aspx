<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ganhua.DesignPattern.WebUI._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          Savings
        <asp:DropDownList ID="ddlDiscountType" runat="server" AutoPostBack="True" >
           <asp:ListItem Value="0">一般人</asp:ListItem>
            <asp:ListItem Value="1">老司機</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
             DataKeyNames="No"  
            EmptyDataText="There are no data records to display." >
            <Columns>           
                <asp:BoundField DataField="No" HeaderText="番號" ItemStyle-Width="100" 
                                ReadOnly="True" SortExpression="ProductId" />     
                 <asp:TemplateField HeaderText="片名" SortExpression="Name">
                    <ItemTemplate>
                        <img src="Images/<%# Eval("Cover") %>" width="150" />
                        <br />
                        <a style="font-size:small;word-break: break-all;" href="<%# Eval("URL") %>" target="_blank"><%# Eval("Name") %></a>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:BoundField DataField="RRP" HeaderText="建議售價" SortExpression="RRP" ItemStyle-Width="80" DataFormatString="{0:C}" />
                <asp:BoundField DataField="SellingPrice" HeaderText="賣價" SortExpression="SellingPrice" ItemStyle-Width="80" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Discount" HeaderText="折扣" SortExpression="Discount" ItemStyle-Width="80" DataFormatString="{0}%" />
                <asp:BoundField DataField="Savings" HeaderText="立刻省下" SortExpression="Savings" ItemStyle-Width="80" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
