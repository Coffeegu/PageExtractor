<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }

        .abov {
            font-size: 14px;
            font: Tahoma;
            width: 120px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            color: white;
            background-color: #3BD9FF;
            border-radius: 6px;
            border: 0;
        }
    </style>
</head>
<body style="background-color: #e5eecc; text-align: center; font-family: Arial, Helvetica, sans-serif; font-size: small">
    <form id="form1" runat="server">
        <div>
            <h4 style="font-size: medium">Register a new user</h4>
            <hr />
            <p>
                <asp:Literal runat="server" ID="StatusMessage" />
            </p>
            <div style="margin-bottom: 10px">
                <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                <asp:TextBox runat="server" ID="UserName" />
            </div>
            <div style="margin-bottom: 10px">
                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
            </div>
            <div style="margin-bottom: 10px">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
            </div>
            <div style="margin-bottom: 10px">
                <asp:Panel runat="server">
                    Team:
                <asp:DropDownList ID="ddlTeam" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTeam_SelectedIndexChanged"></asp:DropDownList>
                    &nbsp; 
                    Grade:
                <asp:DropDownList ID="ddlGrade" runat="server" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" Width="50px">
                    
                  <asp:ListItem Selected="True" Value="1"> 1 </asp:ListItem>
                  <asp:ListItem Value="2"> 2 </asp:ListItem>
                  <asp:ListItem Value="3"> 3 </asp:ListItem>

                </asp:DropDownList>

                </asp:Panel>
            </div>
            <div>
                <div style="margin-bottom: 10px">
                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" class="abov" />
                </div>
                <div>
                    <asp:Button runat="server" OnClick="btn_return_Click" Text="Login Interface" class="abov" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
