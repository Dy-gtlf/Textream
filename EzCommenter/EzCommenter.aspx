<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EzCommenter.aspx.cs" Inherits="EzCommenter.EzCommenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EzCommenter</title>
</head>
<body>
    <h1>EzCommenter</h1>
    <form id="form1" runat="server" defaultbutton="TransmissionButton">
        <div>
            <asp:TextBox ID="Comment" runat="server"></asp:TextBox>
            <asp:Button ID="TransmissionButton" runat="server" Text="送信" OnClick="TransmissionButton_Click"/>
        </div>
    </form>
</body>
</html>
