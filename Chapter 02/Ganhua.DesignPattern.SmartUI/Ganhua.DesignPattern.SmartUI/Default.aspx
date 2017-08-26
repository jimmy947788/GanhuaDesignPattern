<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ganhua.DesignPattern.SmartUI._Default" %>

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
        <asp:DropDownList ID="ddlDiscountType" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlDiscountType_SelectedIndexChanged">
            <asp:ListItem Value="0">一般人</asp:ListItem>
            <asp:ListItem Value="1">老司機</asp:ListItem>
        </asp:DropDownList>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
             DataSourceID="SqlDataSource1"
             DataKeyNames="No"  
            EmptyDataText="There are no data records to display." 
            OnRowDataBound="GridView1_RowDataBound">
            <Columns>           
                <asp:BoundField DataField="No" HeaderText="番號" ItemStyle-Width="100" 
                                ReadOnly="True" SortExpression="ProductId" />     
                 <asp:TemplateField HeaderText="片名" SortExpression="Name">
                    <ItemTemplate>
                        <img src="Images/<%# Eval("Cover") %>" width="150" />
                        <br />
                        <a style="font-size:small;word-break: break-all;" href="<%# Eval("URL") %>" target="_blank" ><%# Eval("Name") %></a>
                    </ItemTemplate>                    
                </asp:TemplateField>

                <asp:BoundField DataField="RRP" HeaderText="建議售價" SortExpression="RRP" ItemStyle-Width="80"
                    DataFormatString="{0:C}" />               
                <asp:TemplateField HeaderText="賣價" ItemStyle-Width="80">
                    <ItemTemplate>
                        <asp:Label ID="lblSellingPrice" runat="server" Text='<%# Bind("SellingPrice") %>'></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="折扣" ItemStyle-Width="80">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDiscount"></asp:Label>
                    </ItemTemplate> 
                </asp:TemplateField>
                <asp:TemplateField HeaderText="立刻省下" ItemStyle-Width="80">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblSavings"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ShopConnectionString %>" 
            SelectCommand="SELECT * FROM [Products]">
        </asp:SqlDataSource>
    </form>
</body>
</html>
