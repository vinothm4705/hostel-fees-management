<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Hostel Fees Calculation System</title>

    
</head>

<body>
<center>
<form id="form1" runat="server">

<h2>HOSTEL FEES CALCULATION SYSTEM</h2>


<table>
<tr>
<td>STUDENT ID:</td>
<td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>STUDENT NAME:</td>
<td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>ROOM TYPE:</td>
<td>
<asp:DropDownList ID="DropDownList1" runat="server">
<asp:ListItem Text="-- Select --" Value=""></asp:ListItem>
<asp:ListItem Text="Single Room-4000" Value="4000"></asp:ListItem>
<asp:ListItem Text="Double Sharing-3000" Value="3000"></asp:ListItem>
<asp:ListItem Text="Triple Sharing-2500" Value="2500"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td>MONTHS:</td>
<td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
</tr>
</table>

<asp:Button ID="Button1" runat="server" Text="CALCULATE" 
    CssClass="calc-btn" OnClick="Button1_Click" />


<br />


<br />



<asp:Button ID="Button2" runat="server" Text="INSERT" OnClick="Button2_Click" CssClass="style1" />
<asp:Button ID="Button3" runat="server" Text="UPDATE" OnClick="Button3_Click" CssClass="style1" />
<asp:Button ID="Button4" runat="server" Text="DELETE" OnClick="Button4_Click" CssClass="style1" />
<asp:Button ID="Button5" runat="server" Text="SELECT" OnClick="Button5_Click" CssClass="style1" />
<asp:Button ID="Button6" runat="server" Text="SHOW ALL" OnClick="Button6_Click" CssClass="style1" />


<br />


<br />
<asp:Literal ID="LiteralFees" runat="server"></asp:Literal>

<br />
<br />
<asp:Label ID="LabelMessage" runat="server" 
    style="color: #009900; font-weight: 700"></asp:Label>

<br />
<br />

<div class="grid-container">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    DataKeyNames="StudentID" DataSourceID="SqlDataSource1">

    <Columns>
        <asp:BoundField DataField="StudentID" HeaderText="StudentID" ReadOnly="True" 
            SortExpression="StudentID" />
        <asp:BoundField DataField="StudentName" HeaderText="StudentName" 
            SortExpression="StudentName" />
        <asp:BoundField DataField="RoomType" HeaderText="RoomType" 
            SortExpression="RoomType" />
        <asp:BoundField DataField="MonthsStayed" HeaderText="MonthsStayed" 
            SortExpression="MonthsStayed" />
        <asp:BoundField DataField="RoomCharges" HeaderText="RoomCharges" 
            SortExpression="RoomCharges" />
        <asp:BoundField DataField="MessCharges" HeaderText="MessCharges" 
            SortExpression="MessCharges" />
        <asp:BoundField DataField="ElectricityCharges" HeaderText="ElectricityCharges" 
            SortExpression="ElectricityCharges" />
        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" 
            SortExpression="Subtotal" />
        <asp:BoundField DataField="ServiceCharge" HeaderText="ServiceCharge" 
            SortExpression="ServiceCharge" />
        <asp:BoundField DataField="TotalFee" HeaderText="TotalFee" 
            SortExpression="TotalFee" />
    </Columns>

</asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server"
    ConnectionString="<%$ ConnectionStrings:Database1 %>"
    SelectCommand="SELECT * FROM [HostelFees]">
</asp:SqlDataSource>
</div>

</form>
</center>
</body>
</html>