<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Automobiles.aspx.cs" Inherits="Assignment_1.Automobiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="dropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropdown_SelectedIndexChanged">
                <asp:ListItem Text="Select Available Mobiles"/>
                <asp:ListItem Text="Oppo A83" Value="1"  />
                <asp:ListItem Text="Iphone 13" Value="2"  />
                <asp:ListItem Text="Samsung" Value="3"  />
            </asp:DropDownList>
            <br />
            <br />

            <asp:Image ID="image"  runat="server" ImageUrl="~/images/normal.png" Width="300" Height="300" />

            <br />
            <br />

            <asp:Button ID="btnShowCost" runat="server" Text="Show Cost" OnClick="btnShowCost_Click" />

            <br />
            <br />

            <asp:Label ID="lableCost" runat="server" />
        </div>
    </form>
</body>
</html>
