<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkChangeAdmin.aspx.cs" Inherits="TIMES.WorkChangeAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <h2><asp:Label ID="lblTitle" runat="server" Text="勤務時間変更"></asp:Label></h2>
                <br />
                <br />
                社員名 :
                <asp:Label ID="lblName" runat="server"></asp:Label>
                <br />
                <br />
                出勤時間 :
                <asp:Label ID="lblIntime" runat="server"></asp:Label>
                　<br />
                <br />

                <asp:TextBox ID="txtInHour" runat="server" ></asp:TextBox>
                <asp:Label ID="lblInHour" runat="server" Text="時"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtInMinute" runat="server" ></asp:TextBox>
                <asp:Label ID="lblInMinute" runat="server" Text="分"></asp:Label>
                <asp:RequiredFieldValidator ID="rfvInHour" runat="server" ControlToValidate="txtInHour" Display="None" ErrorMessage="空白があります。"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfvInMinutes" runat="server" ControlToValidate="txtInMinute" Display="None" ErrorMessage="空白があります。"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfvOutH" runat="server" ControlToValidate="txtOutHour" Display="None" ErrorMessage="空白があります。"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfvOutM" runat="server" ControlToValidate="txtOutMinute" Display="None" ErrorMessage="空白があります。"></asp:RequiredFieldValidator>

                <br />
                <br />
                <br />

                退勤時間  :
                <asp:Label ID="lblOuttime" runat="server"></asp:Label>
                &nbsp;<br />

                <br />

                <asp:TextBox ID="txtOutHour" runat="server" ></asp:TextBox>
                <asp:Label ID="lblOutHour" runat="server" Text="時"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtOutMinute" runat="server" ></asp:TextBox>
                <asp:Label ID="lblOutMinute" runat="server" Text="分"></asp:Label>


                <br />
                <br />
                勤務状態 :
                <asp:Label ID="lblStatus" runat="server"></asp:Label>


                <br />


                <br />


                <asp:ValidationSummary ID="vsSearch" runat="server" DisplayMode="List" ForeColor="Red" />

                <br />
                <br />

                <asp:Button ID="btnOk" runat="server" class="btn btn-outline-dark" Text="変更" OnClick="btnOk_Click" />
                &nbsp;
                <asp:Button ID="btnReturn" runat="server" class="btn btn-outline-danger" OnClick="btnReturn_Click" Text="戻る" />

        <div>
        </div>
    </form>
</body>
</html>
