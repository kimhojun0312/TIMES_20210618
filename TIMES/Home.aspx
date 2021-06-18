<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TIMES.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <h2>TIMESホーム</h2>
            <br />
            <asp:Label ID="lblName" runat="server"></asp:Label>
            <br />
            <h2><asp:Label ID="lblTime" runat="server"></asp:Label><span class="badge hours"></span></a>時 <a><span class="badge min"></span></a>分 <a><span class="badge sec"></span></a>秒 </h2>
            <br />
            <asp:Button ID="btnInTime" runat="server" OnClick="btnInTime_Click" Text="出勤" Width="85px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnOutTime" runat="server" OnClick="btnOutTime_Click" Text="退勤" Width="85px" />
            &nbsp; 　 
            <asp:Button ID="btnEarly" runat="server" Text="早退" OnClick="btnEarly_Click" Width="85px" />
            <br />
            <br />
            <asp:Button ID="btnList" runat="server" OnClick="btnList_Click" Text="勤務履歴" Width="325px" />
            <br />
            <br />
            <asp:Button ID="btnChangeResult" runat="server" OnClick="btnChangeResult_Click" Text="勤務時間変更履歴" Width="325px" />
            <br />
            <br />
            <asp:Button ID="btnPaid" runat="server" OnClick="btnPaid_Click" Text="有給申請・履歴" Width="325px" />
            <br />
            <br />
            <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="ログアウト" Width="325px" />
        </div>
    </form>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.4.1/jquery.easing.min.js"></script>
    <script>
        $(document).ready(function () {
            setInterval(function () {
                var hours = new Date().getHours();
                $(".hours").html((hours < 10 ? "0" : "") + hours);
            }, 1000);
            setInterval(function () {
                var minutes = new Date().getMinutes();
                $(".min").html((minutes < 10 ? "0" : "") + minutes);
            }, 1000);
            setInterval(function () {
                var seconds = new Date().getSeconds();
                $(".sec").html((seconds < 10 ? "0" : "") + seconds);
            }, 1000);
        });
    </script>
</body>
</html>