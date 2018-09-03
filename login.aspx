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



        #forget_pwd {
            font-size: 12px;
            color: black;
            text-decoration: none;
            position: relative;
            float: right;
            top: 5px;
        }



            #forget_pwd:hover {
                color: blue;
                text-decoration: underline;
            }



        #login_control {
            padding: 0 28px;
        }

        #abov {
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
    <script type="text/javascript">

    </script>
</head>
<body style="background-color: #e5eecc; text-align: center">
    <div id="login_frame">
        <form id="form1" runat="server">

            <p>
                <asp:Label runat="server">UserName</asp:Label><asp:TextBox ID="labuser" runat="server" class="text_field" />
            </p>

            <p>
                <asp:Label runat="server">Password</asp:Label><asp:TextBox ID="labpwd" runat="server" TextMode="Password" class="text_field"/>
            </p>

            <div id="login_control">
                                
                <asp:Button ID="allow" runat="server" OnClick="allow_Click" Text="Login"/>
              
                <a id="forget_pwd" href="forget_pwd.html">forget password?</a>

            </div>

            <p>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </p>
             <p>
                <asp:Button ID="abov" runat="server" Text="Register" OnClick="abov_Click" />
            </p>
        </form>
    </div>
</body>
</html>
