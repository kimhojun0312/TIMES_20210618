<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="w2Entry.aspx.cs" Inherits="TIMES.w2Entry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            会員登録<br />
            <br />
            G-mail&nbsp;<asp:TextBox ID="txtUserId" runat="server"　placeholder="ID" class="form-control"></asp:TextBox>
            &nbsp;<asp:Button ID="btnCheck" runat="server" CausesValidation="False" OnClick="btnCheck_Click" Text="重複チェック" />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="認証メールを送る" Visible="False" />
            &nbsp;<asp:Label ID="lblIdCheck" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="lblIdOk" runat="server" ForeColor="Black"></asp:Label>
            
            <br />
            <br />
        </div>
    </form>
</by>
