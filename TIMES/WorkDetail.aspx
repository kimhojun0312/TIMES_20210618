<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkDetail.aspx.cs" Inherits="TIMES.WorkDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <h2><asp:Label ID="lblTitle" runat="server" Text="勤務時間変更申請"></asp:Label></h2>
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

                <asp:TextBox ID="txtInHour" runat="server"></asp:TextBox>
                <asp:Label ID="lblInHour" runat="server" Text="時"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtInMinute" runat="server"></asp:TextBox>
                <asp:Label ID="lblInMinute" runat="server" Text="分"></asp:Label>
                <br />
                <asp:RequiredFieldValidator ID="rfvInHour" runat="server" ControlToValidate="txtInHour" Display="None" ErrorMessage="出勤時間（時）を入力してください。"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfvInMinutes" runat="server" ControlToValidate="txtInMinute" Display="None" ErrorMessage="出勤時間（分）を入力してください。"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfvOutH" runat="server" ControlToValidate="txtOutHour" Display="None" ErrorMessage="退勤時間（時）を入力してください。"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfvOutM" runat="server" ControlToValidate="txtOutMinute" Display="None" ErrorMessage="退勤時間（分）を入力してください。"></asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="revInHourType" runat="server" BorderStyle="None" ControlToValidate="txtInHour" Display="None" ErrorMessage="出勤時間（時）は数字を入力してください" ValidateRequestMode="Disabled" ValidationExpression="^[0-23]+$"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="revInMType" runat="server" BorderStyle="None" ControlToValidate="txtInHour" Display="None" ErrorMessage="出勤時間（分）は数字を入力してください。" ValidateRequestMode="Disabled" ValidationExpression="^[0-59]+$"></asp:RegularExpressionValidator>

                <br />
                <br />
                <br />

                退勤時間  :
                <asp:Label ID="lblOuttime" runat="server"></asp:Label>
                &nbsp;<br />

                <br />

                <asp:TextBox ID="txtOutHour" runat="server"></asp:TextBox>
                <asp:Label ID="lblOutHour" runat="server" Text="時"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtOutMinute" runat="server"></asp:TextBox>
                <asp:Label ID="lblOutMinute" runat="server" Text="分"></asp:Label>


            <asp:RegularExpressionValidator ID="revOutHourType" runat="server" BorderStyle="None" ControlToValidate="txtOutHour" Display="None" ErrorMessage="退勤時間（時）は数字を入力してください" ValidateRequestMode="Disabled" ValidationExpression="^[0-23]+$"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="revOutMType" runat="server" BorderStyle="None" ControlToValidate="txtOutMinute" Display="None" ErrorMessage="退勤時間（分）は数字を入力してください。" ValidateRequestMode="Disabled" ValidationExpression="^[0-59]+$"></asp:RegularExpressionValidator>


                <br />


                <br />


                <br />

                変更理由 :
                <asp:TextBox ID="txtTitle" runat="server" Width="552px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvComment" runat="server" ControlToValidate="txtComment" Display="None" ErrorMessage="タイトルを入力してください。"></asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" Display="None" ErrorMessage="理由書を入力してください。"></asp:RequiredFieldValidator>
                <br />
                <br />


                理由書 (２００文字以内)<br />
                <br />
                <asp:TextBox ID="txtComment" runat="server" Height="161px" Width="698px"></asp:TextBox>

                <br />
                <asp:Label ID="lblWarning" runat="server" ForeColor="#FF0066"></asp:Label>

                <br />


                <asp:ValidationSummary ID="vsSearch" runat="server" DisplayMode="List" ForeColor="Red" />

                <br />

                <asp:Button ID="btnOk" runat="server" class="btn btn-outline-dark" Text="申込む" OnClick="btnOk_Click" />
                &nbsp;
                <asp:Button ID="btnReturn" runat="server" class="btn btn-outline-danger" OnClick="btnReturn_Click" Text="戻る" CausesValidation="False" />

    &nbsp;

    </form>
</body>
</html>
