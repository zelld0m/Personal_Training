<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ResponsiveWebSite_Tutorial.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!------  CAROUSEL-->
    <div>
        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <img src="Images/ASUS-ZENBOOK-UX305FA-BLANC-08.jpg" alt="ASUS-ZENBOOK-UX305FA-BLANC-08">
                    <div class="carousel-caption">
                        <h3>ASUS ZENBOOK</h3>
                        <p>ASUS</p>
                        <p><a class="btn btn-lg btn-primary" href="SignUp.aspx" role="button">Join Us Today</a></p>
                        ...
                    </div>
                </div>
                <div class="item">
                    <img src="Images/17R_Frei_Dell_new_01.jpg" alt="17R_Frei_Dell_new_01">
                    <div class="carousel-caption">
                        <h3>17R_Frei_Dell</h3>
                        <p>DeLL</p>
                        ...
                    </div>
                </div>
                <div class="item">
                    <img src="Images/4zu3_Dell_Latitude_3570_Teaser.jpg" alt="4zu3_Dell_Latitude_3570_Teaser">
                    <div class="carousel-caption">
                        <h3>Dell_Latitude_3570</h3>
                        <p>Dell</p>
                        ...
                    </div>
                </div>
                <div class="item">
                    <img src="Images/4zu3_xps15.jpg" alt="4zu3_xps15">
                    <div class="carousel-caption">
                        <h3>ASUS XPS 15</h3>
                        <p>Asus</p>
                        ...
                    </div>
                </div>
                <div class="item">
                    <img src="Images/AsusTransformerBookFlipTP200SA__1_.jpg" alt="...">
                    <div class="carousel-caption">
                        <h3>Asus BookFlip</h3>
                        <p>Asus</p>
                        ...
                    </div>
                </div>
                <div class="item">
                    <img src="Images/AsusGL552VW__2_.jpg" alt="...">
                    <div class="carousel-caption">
                        <h3>AsusGL552VW 2</h3>
                        <p>Asus</p>
                        ...
                    </div>
                </div>
                <div class="item">
                    <img src="Images/ASUS GOLD.jpg" alt="...">
                    <div class="carousel-caption">
                        <h3>Asus gold</h3>
                        <p>Asus</p>
                        ...
                    </div>
                </div>
                <div class="item">
                    <img src="Images/inspiron-desktop-product-overview.jpg" alt="...">
                    <div class="carousel-caption">
                        <h3>Asus gold</h3>
                        <p>Asus</p>
                        ...
                    </div>
                </div>
                <div class="item">
                    <img src="Images/Dell-XPS-13-vs-HP-Spectre-x360-Tech2-720.jpg" alt="...">
                    <div class="carousel-caption">
                        <h3>DELL XPS 13</h3>
                        <p>Asus</p>
                        ...
                    </div>
                </div>
                <div class="item">
                    <img src="Images/Dell-XPS.jpg" alt="Dell-XPS">
                    <div class="carousel-caption">
                        <h3>DELL XPS</h3>
                        <p>Asus</p>
                        ...
                    </div>
                </div>
                ...
            </div>

            <!-- Controls -->
            <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>


        <!------  CAROUSEL  END-->
    </div>
    <br />


    <!--- Middle Contents -->

    <div class=" container center">
        <div class=" row">
            <div class="col-lg-4">
                <img class="img-circle" src="Images/AsusGL552VW__2_.jpg" alt="..." width="140" height="140" />
                <h2>LAPTOP</h2>
                <p>NEW ASUS 2015 top of the line </p>
                <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
            </div>
            <div class="col-lg-4">
                <img class="img-circle" src="Images/ASUS-ZENBOOK-UX305FA-BLANC-08.jpg" alt="..." width="140" height="140" />
                <h2>LAPTOP</h2>
                <p>NEW ASUS ZENBOOK 2015  </p>
                <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
            </div>
            <div class="col-lg-4">
                <img class="img-circle" src="Images/Dell-XPS-13-vs-HP-Spectre-x360-Tech2-720.jpg" alt="..." width="140" height="140" />
                <h2>LAPTOP</h2>
                <p>DELL 2015  </p>
                <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
            </div>
        </div>
    </div>
    <!--- Middle Contents END -->

</asp:Content>




<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ResponsiveWebSite_Tutorial.Default" %>

<!DOCTYPE html>

<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>PCM HOME</title>

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
<body style="height: 50px">
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
                            <li class="active"><a href="Home.aspx">Home</a></li>
                            <li><a href="About.aspx">About</a></li>
                            <li><a href="#">Contact</a></li>
                            <li><a href="http://DMNLANUNAG/Ship1/ShipR.Project/">ShipRTooL</a></li>


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
                            <li><a href="SignUp.aspx">Signup</a></li>
                            <li><a href="SignIn.aspx">Sign In</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-----------------NAVBAR END -->

            <!------  CAROUSEL-->
            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src="Images/ASUS-ZENBOOK-UX305FA-BLANC-08.jpg" alt="ASUS-ZENBOOK-UX305FA-BLANC-08">
                        <div class="carousel-caption">
                            <h3>ASUS ZENBOOK</h3>
                            <p>ASUS</p>
                            <p><a class="btn btn-lg btn-primary" href="SignUp.aspx" role="button">Join Us Today</a></p>
                            ...
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/17R_Frei_Dell_new_01.jpg" alt="17R_Frei_Dell_new_01">
                        <div class="carousel-caption">
                            <h3>17R_Frei_Dell</h3>
                            <p>DeLL</p>
                            ...
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/4zu3_Dell_Latitude_3570_Teaser.jpg" alt="4zu3_Dell_Latitude_3570_Teaser">
                        <div class="carousel-caption">
                            <h3>Dell_Latitude_3570</h3>
                            <p>Dell</p>
                            ...
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/4zu3_xps15.jpg" alt="4zu3_xps15">
                        <div class="carousel-caption">
                            <h3>ASUS XPS 15</h3>
                            <p>Asus</p>
                            ...
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/AsusTransformerBookFlipTP200SA__1_.jpg" alt="...">
                        <div class="carousel-caption">
                            <h3>Asus BookFlip</h3>
                            <p>Asus</p>
                            ...
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/AsusGL552VW__2_.jpg" alt="...">
                        <div class="carousel-caption">
                            <h3>AsusGL552VW 2</h3>
                            <p>Asus</p>
                            ...
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/ASUS GOLD.jpg" alt="...">
                        <div class="carousel-caption">
                            <h3>Asus gold</h3>
                            <p>Asus</p>
                            ...
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/inspiron-desktop-product-overview.jpg" alt="...">
                        <div class="carousel-caption">
                            <h3>Asus gold</h3>
                            <p>Asus</p>
                            ...
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/Dell-XPS-13-vs-HP-Spectre-x360-Tech2-720.jpg" alt="...">
                        <div class="carousel-caption">
                            <h3>DELL XPS 13</h3>
                            <p>Asus</p>
                            ...
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/Dell-XPS.jpg" alt="Dell-XPS">
                        <div class="carousel-caption">
                            <h3>DELL XPS</h3>
                            <p>Asus</p>
                            ...
                        </div>
                    </div>
                    ...
                </div>

                <!-- Controls -->
                <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>


            <!------  CAROUSEL  END-->
        </div>
        <br />


        <!--- Middle Contents -->

        <div class=" container center">
            <div class=" row">
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/AsusGL552VW__2_.jpg" alt="..." width="140" height="140" />
                    <h2>LAPTOP</h2>
                    <p>NEW ASUS 2015 top of the line </p>
                    <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/ASUS-ZENBOOK-UX305FA-BLANC-08.jpg" alt="..." width="140" height="140" />
                    <h2>LAPTOP</h2>
                    <p>NEW ASUS ZENBOOK 2015  </p>
                    <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/Dell-XPS-13-vs-HP-Spectre-x360-Tech2-720.jpg" alt="..." width="140" height="140" />
                    <h2>LAPTOP</h2>
                    <p>DELL 2015  </p>
                    <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                </div>
            </div>
        </div>
        <!--- Middle Contents END -->

        <!---- FOOTER -->
        <footer>
            <div class="container">
                <p class="pull-right"><a href="#">Back to top</a></p>
                <p>&copy; 2015 PCM.com &middot;<a href="Home.aspx">Home</a>&middot;<a href="About.aspx">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a>&middot;</p>

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
