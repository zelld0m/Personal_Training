<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="ResponsiveWebSite_Tutorial.AdminHome" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <!---- Sign up -->
        <div class="center-page">

            <label class=" col-xs-11">UserName</label>
            <div class=" col-xs-11">
                <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Username"></asp:TextBox>
            </div>

            <label class=" col-xs-11">Password</label>
            <div class=" col-xs-11">
                <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
            </div>


            <label class=" col-xs-11">Conform Password</label>
            <div class=" col-xs-11">
                <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="Confirm Password"></asp:TextBox>
            </div>

            <label class=" col-xs-11">Name</label>
            <div class=" col-xs-11">
                <asp:TextBox ID="TextBox4" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
            </div>


            <label class=" col-xs-11">Email</label>
            <div class=" col-xs-11">
                <asp:TextBox ID="TextBox5" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
            </div>

            <div class="col-xs-11 space-vert">
                <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Sign Up" />
            </div>

        </div>

        <!---- Sign up -->

</asp:Content>




<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ResponsiveWebSite_Tutorial.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Sign Up</title>

    <!-- Bootstrap -->

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Custom-Cs.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-----------------NAVBAR-->
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class=" navbar-header" style="height: 2px">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle Navigation </span>
                            <span class="icon-bar">- </span>

                        </button>


                        <a class="navbar-brand" href="Home.aspx"><span>
                            <img alt="Logo" src="Images/pcm_logo.jpg" height="35" /></span></a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="Home.aspx">Home</a></li>
                            <li><a href="#">About</a></li>
                            <li><a href="#">Contact</a></li>
                            <li class=" dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li role="separator" class="divider"></li>
                                    <li class=" dropdown-header">LAPTOP</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="#">PriceList</a></li>
                                    <li><a href="#">Pants</a></li>
                                    <li><a href="#">Denims</a></li>
                                    <li role="separator" class="divider"></li>
                                    <li class=" dropdown-header">PersonalComputer</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="#">Top</a></li>
                                    <li><a href="#">Leggings</a></li>
                                    <li><a href="#">Denims</a></li>
                                </ul>
                            </li>
                            <li class="active" ><a href="SignUp.aspx">Signup</a></li>
                            <li ><a href="SignIn.aspx">Sign In</a></li>
                        </ul>
                    </div>
                </div>
            </div>

            <!-----------------NAVBAR END -->
        </div>
        <!---- Sign up -->
        <div class="center-page">

            <label class=" col-xs-11">UserName</label>
            <div class=" col-xs-11">
                <asp:TextBox ID="tb_UserName" runat="server" class="form-control" placeholder="Username"></asp:TextBox>
            </div>

            <label class=" col-xs-11">Password</label>
            <div class=" col-xs-11">
                <asp:TextBox ID="tb_Password" runat="server" class="form-control" placeholder="Password"></asp:TextBox>
            </div>


            <label class=" col-xs-11">Conform Password</label>
            <div class=" col-xs-11">
                <asp:TextBox ID="Tb_CPassword" runat="server" class="form-control" placeholder="Confirm Password"></asp:TextBox>
            </div>

            <label class=" col-xs-11">Name</label>
            <div class=" col-xs-11">
                <asp:TextBox ID="tb_Name" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
            </div>


            <label class=" col-xs-11">Email</label>
            <div class=" col-xs-11">
                <asp:TextBox ID="tb_Emaol" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
            </div>

            <div class="col-xs-11 space-vert">
                <asp:Button ID="bt_Signup" runat="server" class="btn btn-success" Text="Sign Up" />
            </div>

        </div>

        <!---- Sign up -->

        <!---- FOOTER -->

        <footer class="footer-pos">
            <div class="container">
                <p class="pull-right"><a href="#">Back top</a></p>
                <p>&copy; 2015 PCM.com &middot;<a href="Home.aspx">Home</a>&middot;<a href="#">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a>&middot;</p>


            </div>
        </footer>
        <!---- FOOTER END-->
    </form>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>--%>
