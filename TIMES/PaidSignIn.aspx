<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaidSignIn.aspx.cs" Inherits="TIMES.PaidSignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>有給申請</h1><br />
            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblWantDay" runat="server" Text="希望の日付："></asp:Label>
            <asp:DropDownList ID="ddlYear" runat="server">
                <asp:ListItem>2021</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblYears" runat="server" Text="年"></asp:Label>
            <asp:DropDownList ID="ddlMonth" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblMonths" runat="server" Text="月"></asp:Label>
            <asp:DropDownList ID="ddlDay" runat="server">
            </asp:DropDownList>
            <asp:Label ID="lblDays" runat="server" Text="日"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblTitle" runat="server" Text="タイトル : "></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" Width="398px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="rfvComment" runat="server" ControlToValidate="txtComment" Display="None" ErrorMessage="タイトルを入力してください。"></asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" Display="None" ErrorMessage="申請理由を入力してください。"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
            <asp:Label ID="lblComment" runat="server" Text="申請理由："></asp:Label>
            <br />
            <asp:TextBox ID="txtComment" runat="server" Height="213px" Width="524px"></asp:TextBox>
            <br />


                <asp:ValidationSummary ID="vsSearch" runat="server" DisplayMode="List" ForeColor="Red" />

            <br />
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="申請" />
&nbsp;
            <asp:Button ID="btnReturn" runat="server" Text="戻る" CausesValidation="False" OnClick="btnReturn_Click" />
            <br />
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
