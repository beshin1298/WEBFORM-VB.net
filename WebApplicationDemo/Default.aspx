<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebApplicationDemo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div style="background-color:blueviolet; font-size:xx-large"; align ="center">
       DEMO WEB SITE</div>
    <br />


    <table class="w-100">
        <tr>
            <td style="width: 390px; height: 24px;">
                <asp:Label ID="Label1" runat="server" Text="PRORDUCT ID"></asp:Label>
            </td>
            <td style="width: 458px; height: 24px;">
                <asp:TextBox ID="txtProductId" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 390px">ITEM NAME</td>
            <td style="width: 458px">
                <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 390px">INSERT DATE</td>
            <td style="width: 458px">
                <asp:TextBox ID="txtInsertDate" runat="server"  TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 390px">unit</td>
            <td style="width: 458px">
                <asp:TextBox ID="txtUnit" runat="server"  TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 390px; height: 24px;">QUANLITY</td>
            <td style="width: 458px; height: 24px;">
                <asp:TextBox ID="txtQuanlity" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 390px">&nbsp;</td>
            <td style="width: 458px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 390px">
                <asp:Button ID="Reset" runat="server" Text="Reset" />
            </td>
            <td style="width: 458px">
                <asp:Button ID="Insert" runat="server" Text="Insert" />
            </td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="tableData" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="994px" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
           
            <Columns>
                <asp:BoundField DataField="Product Id" HeaderText="Product Id" />
                <asp:BoundField DataField="Name" HeaderText="Item Name" />
                <asp:BoundField DataField="Insert Date" HeaderText="Insert Date" />
                <asp:BoundField DataField="Unit" HeaderText="Unit" />
                <asp:BoundField DataField="quanlity" HeaderText="quanlity" />
                <asp:ButtonField ButtonType="Button" CommandName="EditItem" Text="Edit" />
                <asp:ButtonField CommandName="DeleteItem" Text="Delete" />
            </Columns>
           
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>

</asp:Content>
