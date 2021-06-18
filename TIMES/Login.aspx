<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TIMES.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 701px">
    <form id="form1" runat="server">
        <div>
            <h2>TIMES</h2><br />
            <br />
            <asp:Label ID="lblName" runat="server" Text="ID"></asp:Label>
            &nbsp;　&nbsp;
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
&nbsp;      <asp:CustomValidator ID="cvLogin" runat="server" Display="None" ErrorMessage="IDまたはパスワードが一致しません。" OnServerValidate="cvLogin_ServerValidate">cvLogin</asp:CustomValidator>
            <asp:RequiredFieldValidator ID="rfvId" runat="server" ControlToValidate="txtId" Display="None" ErrorMessage="IDを入力してください。"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revIdLength" runat="server" BorderStyle="None" ControlToValidate="txtId" Display="None" ErrorMessage="IDは3文字から20文字以内です。" ValidateRequestMode="Disabled" ValidationExpression="^[a-zA-Z0-9]{3,20}$"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="revIdtype" runat="server" BorderStyle="None" ControlToValidate="txtId" Display="None" ErrorMessage="IDは英語または数字のみ入力してください。" ValidateRequestMode="Disabled" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="lblPwd" runat="server" Text="PWD"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPwd" Display="None" ErrorMessage="パスワードを入力してください。"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPwdLength" runat="server" BorderStyle="None" ControlToValidate="txtPwd" Display="None" ErrorMessage="パスワードは3文字から20文字以内です。" ValidateRequestMode="Disabled" ValidationExpression="^[a-zA-Z0-9]{3,20}$"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="revPwdtype" runat="server" BorderStyle="None" ControlToValidate="txtId" Display="None" ErrorMessage="パスワードは英語または数字のみ入力してください。" ValidateRequestMode="Disabled" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:ValidationSummary ID="vsSearch" runat="server" DisplayMode="List" ForeColor="Red" />
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="ログイン" Width="166px" />
&nbsp;&nbsp;</div>
    </form>
</body>
</html>
