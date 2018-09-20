<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
        }

        #login_frame {
            width: 400px;
            height: 260px;
            padding: 13px;
            position: absolute;
            left: 50%;
            top: 50%;
            margin-left: -200px;
            margin-top: -200px;
            background-color: rgba(240, 255, 255, 0.5);
            border-radius: 10px;
            text-align: center;
        }

        form p > * {
            display: inline-block;
            vertical-align: middle;
        }

        .label_input {
            font-size: 14px;
            font: Tahoma;
            width: 65px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            color: white;
            background-color: #3CD8FF;
            border-top-left-radius: 5px;
            border-bottom-left-radius: 5px;
        }

        .text_field {
            width: 278px;
            height: 28px;
            border-top-right-radius: 5px;
            border-bottom-right-radius: 5px;
            border: 0;
        }



        #allow {
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
            float: left;
        }

        #login_control {
            padding: 0 28px;
        }

        .abov {
            font-size: 14px;
            font: Tahoma;
            width: 160px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            color: white;
            background-color: #3BD9FF;
            border-radius: 6px;
            border: 0;
        }
    </style>
    <script type="text/javascript">

</script>
</head>
<body style="background-color: #e5eecc; text-align: center; font-family: Arial, Helvetica, sans-serif; font-size: small">
    <div id="login_frame">
        <form id="form1" runat="server">
            <h4 style="font-size: medium">Log In</h4>
            <hr />
            <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
                <p>
                    <asp:Literal runat="server" ID="StatusText" />
                </p>
            </asp:PlaceHolder>
            <p>
                <asp:Label runat="server" AssociatedControlID="UserName">UserName</asp:Label><asp:TextBox ID="UserName" runat="server" class="text_field" />
            </p>

            <p>
                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label><asp:TextBox ID="Password" runat="server" TextMode="Password" class="text_field" />
            </p>
            <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">
                <div style="margin-bottom: 10px">
                    <div>
                        <asp:Button class="abov" runat="server" OnClick="SignIn" Text="Log in" />
                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="LogoutButton" Visible="false">
                <div style="margin-bottom: 10px">
                    <div>
                        <asp:Button class="abov" runat="server" OnClick="btn_Select" Text="Only view information" />
                    </div>
                </div>
            </asp:PlaceHolder>
        </form>
       
    </div>
</body>
</html>
