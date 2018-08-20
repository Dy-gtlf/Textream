<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EzCommenterWeb.aspx.cs" Inherits="EzCommenterWeb.EzCommenterWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="Comment" runat="server"></asp:TextBox>
            <asp:Button ID="TransmionButton" runat="server" Text="送信" OnClick="TransmissionButton_Click" />
        </div>
    </form>
</body>
</html>
