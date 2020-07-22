<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Database_Project.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<body>
    
    

    <!-- slider Area Start-->
    <div class="slider-area ">
        <!-- Mobile Menu -->
        <div class="single-slider slider-height2 d-flex align-items-center" data-background="assets/img/hero/category.jpg">
            <div class="container">
                <div class="row">
                    <div class="col-xl-12">
                        <div class="hero-cap text-center">
                            <h2>Login/ Register</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- slider Area End-->

    <!--================login_part Area =================-->

    
        <section class="login_part section_padding ">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-6 col-md-6">
                    <div class="login_part_text text-center">
                        <div class="login_part_text_iner">
                            <h2>New to PHS?</h2>

                            <div class="row">

                                <div class="column col-md-12 form-group p_star">
                                    <div class="col-md-12 form-group p_star">
                                        <asp:TextBox ID="firstname" placeholder="First Name" class="form-control" runat="server">
                                        </asp:TextBox>
                                    </div>
                                </div>

                                
                                <div class="column col-md-12 form-group p_star">
                                    <div class="col-md-12 form-group p_star">
                                        <asp:TextBox ID="lastname" placeholder="Last Name" class="form-control" runat="server">
                                        </asp:TextBox>
                                   </div>    

                                </div>

                            </div>
       
                            <div class="col-md-12 form-group p_star">
                                <asp:TextBox ID="cnic" placeholder="CNIC" class="form-control" runat="server">
                                </asp:TextBox>
                           </div>

                            <div class="col-md-12 form-group p_star">
                                <asp:TextBox ID="email" placeholder="Email" class="form-control" runat="server">
                                </asp:TextBox>
                           </div>

                            <div class="col-md-12 form-group p_star">
                                <asp:TextBox ID="pass" placeholder="Password" class="form-control" runat="server" TextMode="Password">
                                </asp:TextBox>
                           </div>

                            <div class="col-md-12 form-group" style="color:black">
                                <select name="accountTypes" id="accountTypes" runat="server" onchange="javascript:document.forms[0].submit();" onserverchange="accountType_Changed">
                                  <option value="customer">Customer</option>
                                  <option value="pharmacy">Pharmacy</option>
                                  <option value="doctor">Doctor</option>
                                </select>
                            </div>
                        
                            
                            <div class="col-md-12 form-group p_star" id="tNo" runat="server">
                                <br />
                                <asp:TextBox ID="taxNo" placeholder="Tax No" class="form-control" runat="server">
                                </asp:TextBox>
                           </div>

                            <div class="col-md-12 form-group p_star" id="pN" runat="server">
                                <asp:TextBox ID="pName" placeholder="Pharmacy Name" class="form-control" runat="server">
                                </asp:TextBox>
                           </div>

                            <div class="col-md-12 form-group p_star" id="pAd" runat="server">
                                <asp:TextBox ID="pAddress" placeholder="Pharmacy Address" class="form-control" runat="server">
                                </asp:TextBox>
                           </div>

                            <div class="col-md-12 form-group p_star" id="cAd" runat="server">
                                <br />
                                <asp:TextBox ID="cAddress" placeholder="Address" class="form-control" runat="server">
                                </asp:TextBox>
                           </div>

                            <div class="col-md-12 form-group p_star" id="dId" runat="server">
                                <br />
                                <asp:TextBox ID="docID" placeholder="Registration Number (PMC)" class="form-control" runat="server">
                                </asp:TextBox>
                           </div>

                            <div class="col-md-12 form-group p_star" id="exp" runat="server">
                                <asp:TextBox ID="experience" placeholder="Experience (Years)" class="form-control" runat="server">
                                </asp:TextBox>
                           </div>

                            <div class="col-md-12 form-group p_star" id="expert" runat="server">
                                <asp:TextBox ID="expertise" placeholder="Expertise (Specialization)" class="form-control" runat="server">
                                </asp:TextBox>
                           </div>
 
                            <div class="col-md-12 form-group p_star" id="charge" runat="server">
                                <asp:TextBox ID="chargesByDoc" placeholder="Charges (PKR)" class="form-control" runat="server">
                                </asp:TextBox>
                           </div>


                            <br />
                            <p id="messageBox" runat="server">Create an account today and avail the best deals on medics.</p>      
                            <asp:Button ID="registerButton" class="btn_3" runat="server" width="50%" Text="Create Account" OnClick="createAccount_Clicked"/>

                            
                        </div>

                    </div>
                </div>
                <div class="col-lg-6 col-md-6">
                    <div class="login_part_form">
                        <div class="login_part_form_iner">
                            <h3 id="loginTitle" runat="server">  Welcome Back ! <br>
                                Please Sign in now</h3>
                            <div class="row contact_form">
                                <div class="col-md-12 form-group p_star">
                                    <asp:TextBox ID="username" placeholder="Username (Email)" class="form-control" runat="server">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group p_star">
                                    <asp:TextBox ID="password" placeholder="Password" class="form-control" runat="server" TextMode="Password">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group">
                                    <asp:Button ID="Button1" class="btn_3" runat="server" width="50%" Text="Login" OnClick="login_Clicked"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    
    <!--================login_part end =================-->
   
	<%--<a href="#" id="scroll-to-top" class="new-btn-d br-2"><i class="fa fa-angle-up"></i></a>--%>

	<!-- ALL JS FILES -->
	<script src="js/jquery.min.js"></script>
	<script src="js/popper.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
    <!-- ALL PLUGINS -->
	<script src="js/jquery.magnific-popup.min.js"></script>
    <script src="js/jquery.pogo-slider.min.js"></script> 
	<script src="js/slider-index.js"></script>
	<%--<script src="js/smoothscroll.js"></script>--%>
	<script src="js/TweenMax.min.js"></script>
	<script src="js/main.js"></script>
	<script src="js/owl.carousel.min.js"></script>
	<script src="js/form-validator.min.js"></script>
    <script src="js/contact-form-script.js"></script>
	<script src="js/isotope.min.js"></script>	
	<script src="js/images-loded.min.js"></script>	
    <script src="js/custom.js"></script>


  <script src="js/jquery-3.3.1.min.js"></script>
  <script src="js/jquery-ui.js"></script>
  <script src="js/popper.min.js"></script>
  <script src="js/bootstrap.min.js"></script>
  <script src="js/owl.carousel.min.js"></script>
  <script src="js/jquery.magnific-popup.min.js"></script>
  <script src="js/aos.js"></script>

  <script src="js/main.js"></script>


<!-- JS here -->

    <!-- All JS Custom Plugins Link Here here -->
    <script src="./assets/js/vendor/modernizr-3.5.0.min.js"></script>
    
    <!-- Jquery, Popper, Bootstrap -->
    <script src="./assets/js/vendor/jquery-1.12.4.min.js"></script>
    <script src="./assets/js/popper.min.js"></script>
    <script src="./assets/js/bootstrap.min.js"></script>
    <!-- Jquery Mobile Menu -->
    <script src="./assets/js/jquery.slicknav.min.js"></script>

    <!-- Jquery Slick , Owl-Carousel Plugins -->
    <script src="./assets/js/owl.carousel.min.js"></script>
    <script src="./assets/js/slick.min.js"></script>

    <!-- One Page, Animated-HeadLin -->
    <script src="./assets/js/wow.min.js"></script>
    <script src="./assets/js/animated.headline.js"></script>
    
    <!-- Scrollup, nice-select, sticky -->
    <script src="./assets/js/jquery.scrollUp.min.js"></script>
    <script src="./assets/js/jquery.nice-select.min.js"></script>
    <script src="./assets/js/jquery.sticky.js"></script>
    <script src="./assets/js/jquery.magnific-popup.js"></script>

    <!-- contact js -->
    <script src="./assets/js/contact.js"></script>
    <script src="./assets/js/jquery.form.js"></script>
    <script src="./assets/js/jquery.validate.min.js"></script>
    <script src="./assets/js/mail-script.js"></script>
    <script src="./assets/js/jquery.ajaxchimp.min.js"></script>
    
    <!-- Jquery Plugins, main Jquery -->	
    <script src="./assets/js/plugins.js"></script>
    <script src="./assets/js/main.js"></script>
   

 
</body>
    

</asp:Content>
