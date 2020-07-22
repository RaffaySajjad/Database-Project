<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Database_Project.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	
	<!-- Start Banner -->
	<div class="ulockd-home-slider">
		<div class="container-fluid">
			<div class="row">
				<div class="pogoSlider" id="js-main-slider">
					<div class="pogoSlider-slide" data-transition="fade" data-duration="750" style="background-image:url(images/slider-01.jpg);">
						<div class="lbox-caption pogoSlider-slide-element">
							<div class="lbox-details">
								<h1>Welcome to Pharma Health Services (PHS)</h1>
								<p>Revolutionizing the way you think about medicine </p>
								<a href="#contact" class="btn">Contact Us</a>
							</div>
						</div>
					</div>
					<div class="pogoSlider-slide" data-transition="fade" data-duration="750" style="background-image:url(images/slider-02.jpg);">
						<div class="lbox-caption pogoSlider-slide-element">
							<div class="lbox-details">
								<h1>We are Expert in The Field of Health</h1>
								<p>Your requests are fulfilled by expert personnel</p>
								<a href="#services" class="btn">Services</a>
							</div>
						</div>
					</div>
					<div class="pogoSlider-slide" data-transition="fade" data-duration="750" style="background-image:url(images/slider-03.jpg);">
						<div class="lbox-caption pogoSlider-slide-element">
							<div class="lbox-details">
								<h1>One of its kind, in Pakistan</h1>
								<p>Order a service, from comfort of your home </p>
								<a href="#blog" class="btn">Reviews</a>
							</div>
						</div>
						
					</div>
				</div>
			</div>
		</div>
	</div>
	<!-- End Banner -->
	
	<!-- Start About us -->
	<div id="about" class="about-box">
		<div class="about-a1">
			<div class="container">
				<div class="row">
					<div class="col-lg-12">
						<div class="title-box">
							<h2>About Us</h2>
							<p>What is PHS? How we differentiate? </p>
						</div>
					</div>
				</div>
				<div class="row">
					<div class="col-lg-12 col-md-12 col-sm-12">
						<div class="row align-items-center about-main-info">
							<div class="col-lg-6 col-md-6 col-sm-12">
								<h2> Welcome to Pharma Health Services </h2>
								<p>Pharma Health Services (PHS) is a venture that strives to provide range of healthcare services under one platform for ultimate customers’ ease and to maximize value for their money. Unlike traditional medicine industry, PHS bring the core components under one platform, creating a Win Win position for customers as well as the service providers. </p>
								<p>We are not only providing the services blindly. At PHS, we know health is the most important aspect of an individual. Thus we partnered with Pakistan Medical Commission (PMC) to let only the verified doctors provide their services. So quality is one less thing to worry about! </p>
								<a href="#" class="new-btn-d br-2">Home</a>
							</div>
							<div class="col-lg-6 col-md-6 col-sm-12">
								<div class="about-m">
									<ul id="banner">
										<li>
											<img src="images/about-img-01.jpg" alt="">
										</li>
										<li>
											<img src="images/about-img-02.jpg" alt="">
										</li>
										<li>
											<img src="images/about-img-03.jpg" alt="">
										</li>
									</ul>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<!-- End About us -->

		<!-- Start Services -->
	<div id="services" runat="server" class="services-box">
		<div class="container">
			<div class="row">
				<div class="col-lg-12">
					<div class="title-box">
						<h2>Services</h2>
						<p>We got all bases covered! What would you like to opt? </p>
					</div>
				</div>
			</div>
			
			<div class="row">
				<div class="col-lg-12">
					<div class="owl-carousel owl-theme">
						<div class="item">
							<div class="serviceBox">
								<div class="service-icon"><i class="fa fa-h-square" aria-hidden="true"></i></div>
								<h3 class="title">Order a Medicine</h3>
								<p class="description">
									All the medicines are tested to ensure they are authentic for your ultimate peace of mind.
								</p>
								<a runat="server" id="medicineTag" onserverclick="medicineTag_ServerClick" class="new-btn-d br-2">Proceed</a>
							</div>
						</div>
						<div class="item">
							<div class="serviceBox">
								<div class="service-icon"><i class="fa fa-heart" aria-hidden="true"></i></div>
								<h3 class="title">Schedule Lab Test</h3>
								<p class="description">
									Get yourself tested from the comfort of your home. Each test comes with free recommendation.
								</p>
								<a runat="server" id="labTag" onserverclick="labTag_ServerClick" class="new-btn-d br-2">Proceed</a>
							</div>
						</div>
						<div class="item">
							<div class="serviceBox">
								<div class="service-icon"><i class="fa fa-hospital-o" aria-hidden="true"></i></div>
								<h3 class="title">Schedule Radiology</h3>
								<p class="description">
									Get attractive discounts on X-Rays, MRIs and Ultrasounds when you order from select labs.
								</p>
								<a id="radiologyTab" runat="server" onserverclick="radiologyTab_ServerClick" class="new-btn-d br-2">Proceed</a>
							</div>
						</div>
						<div class="item">
							<div class="serviceBox">
								<div class="service-icon"><i class="fa fa-ambulance" aria-hidden="true"></i></div>
								<h3 class="title">Need a Doctor</h3>
								<p class="description">
									Doesn't feel like going to a doctor? Get yourself inspected from top specialists right at your home.
								</p>
								<a id="serviceTab" runat="server" onserverclick="serviceTab_ServerClick" class="new-btn-d br-2">Proceed</a>
							</div>
						</div>
					</div>
				</div>
			</div>			
		</div>
	</div>
	<!-- End Services -->
	
	<!-- Start Gallery -->
	<div id="gallery" class="gallery-box">
		<div class="container-fluid">
			<div class="row">
				<div class="col-lg-12">
					<div class="title-box">
						<h2>Gallery</h2>
						<p>PHS strives to offer best possible services to its clientele </p>
					</div>
				</div>
			</div>
			
			<div class="popup-gallery row clearfix">
				<div class="col-md-3 col-sm-6">
					<div class="box-gallery">
						<img src="images/gallery-01.jpg" alt="">
						<div class="box-content">	
							<h3 class="title">PMC Certified Doctors</h3>
						</div>
					</div>
				</div>
				<div class="col-md-3 col-sm-6">
					<div class="box-gallery">
						<img src="images/gallery-02.jpg" alt="">
						<div class="box-content">
							<h3 class="title">Inspection from Home</h3>
						</div>
					</div>
				</div>
				<div class="col-md-3 col-sm-6">					
					<div class="box-gallery">
						<img src="images/gallery-03.jpg" alt="">
						<div class="box-content">	
							<h3 class="title">Affordable HealthCare</h3>
						</div>
					</div>
				</div>
				<div class="col-md-3 col-sm-6">
					<div class="box-gallery">
						<img src="images/gallery-04.jpg" alt="">
						<div class="box-content">	
							<h3 class="title">Reliable Lab Tests</h3>
						</div>
					</div>
				</div>
				<div class="col-md-3 col-sm-6">
					<div class="box-gallery">
						<img src="images/gallery-05.jpg" alt="">
						<div class="box-content">							
							<h3 class="title">Body X-Rays From Home</h3>
						</div>
					</div>
				</div>
				<div class="col-md-3 col-sm-6">					
					<div class="box-gallery">
						<img src="images/gallery-06.jpg" alt="">
						<div class="box-content">
							<h3 class="title">Doctors at your disposal</h3>
						</div>
					</div>
				</div>
				<div class="col-md-3 col-sm-6">
					<div class="box-gallery">
						<img src="images/gallery-07.jpg" alt="">
						<div class="box-content">
							<h3 class="title">Renowned Labs</h3>
						</div>
					</div>
				</div>
				<div class="col-md-3 col-sm-6">
					<div class="box-gallery">
						<img src="images/gallery-08.jpg" alt="">
						<div class="box-content">		
							<h3 class="title">Field Experts</h3>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<!-- End Gallery -->
	
	<!-- Start Customer Reviews -->
	<div id="blog" class="blog-box">
		<div class="container">
			<div class="row">
				<div class="col-lg-12">
					<div class="title-box">
						<h2>Reviews</h2>
						<p>See what our customers have to say after using PHS. These reviews are not edited or modified in any way.</p>
					</div>
				</div>
			</div>
			<div class="row">
				<div class="col-lg-4 col-md-6 col-sm-12">
					<div class="blog-inner">
						<div class="blog-img">
							<img class="img-fluid" src="images/review-img-01.jpg" alt="" />
						</div>
						<div class="item-meta">
							<a><i class="fa fa-user-o"></i> Bilal Ahmed</a>
							<span class="dti">25 May 2020</span>
						</div>
						<h2>An Exceptional Experience.</h2>
						<p>I was looking for a medicine in the local market. But couldn't find it. PHS got it delivered at my doorstep within a few hours and it was 100% authentic!!! </p><br>
						
					</div>
				</div>
				<div class="col-lg-4 col-md-6 col-sm-12">
					<div class="blog-inner">
						<div class="blog-img">
							<img class="img-fluid" src="images/review-img-02.jpg" alt="" />
						</div>
						<div class="item-meta">
							<a><i class="fa fa-user-o"></i> Noman Amjad</a>
							<span class="dti">12 March 2020</span>
						</div>
						<h2>Wonderful Experience. </h2>
						<p>I need to have me Electromyography performed. I decided to try PHS as they were offering special discount on this test. Guess what, I am totally satisfied with their service.</p>
					</div>
				</div>
				<div class="col-lg-4 col-md-6 col-sm-12">
					<div class="blog-inner">
						<div class="blog-img">
							<img class="img-fluid" src="images/review-img-03.jpg" alt="" />
						</div>
						<div class="item-meta">
							<a><i class="fa fa-user-o"></i> Arshad Khan</a>
							<span class="dti">26 November 2019</span>
						</div>
						<h2>PHS deserves more than 5 stars! </h2>
						<p> My doctor recommended that I get Creatine Kinase performed. I wasn't able to leave my home but the team at PHS managed it all. Very satisfied with their services. Will surely return back in future.</p>
					</div>
				</div>
			</div>
		</div>
	</div>
	<!-- End Blog -->
	
	<!-- Start Contact -->
	<div id="contact" class="contact-box">
		<div class="container">
			<div class="row">
				<div class="col-lg-12">
					<div class="title-box">
						<h2>Contact Us</h2>
						<p>Have any queries? Get them resolved through an exceptional Customer Support</p>
					</div>
				</div>
			</div>
			<div class="row">
				
				<div class="col-lg-12 col-xs-12">
				  <div class="contact-block">
					  <div class="row">
						<div class="col-md-6">
							<div class="form-group">
								<asp:TextBox ID="name" placeholder="Your Name" class="form-control" runat="server"></asp:TextBox>
							</div>                                 
						</div>
						<div class="col-md-6">
							<div class="form-group">
								<asp:TextBox ID="email" placeholder="Your Email" class="form-control" runat="server"></asp:TextBox>
							</div> 
						</div>
						<div class="col-md-12">
							<div class="form-group">
								<asp:TextBox ID="number" placeholder="Your Contact Number" class="form-control" runat="server"></asp:TextBox>
							</div>
						</div>
						<div class="col-md-12">
							<div class="form-group">
								<asp:TextBox ID="message" placeholder="Message" class="form-control" runat="server"></asp:TextBox>
							</div>
							<div class="submit-button text-center">

								<div class="form-group">
									<asp:Button class="btn btn-common h3" Width="15%" ID="submitButton" runat="server" Text="Send Message" OnClick="submitButton_Click" />
								</div>

							</div>
						</div>
					  </div>            
					
				  </div>
				</div>
				
				
				<div class="col-lg-12 col-xs-12">
					<div class="left-contact">
						<h2>Address</h2>
						<div class="media cont-line">
							<div class="media-left icon-b">
								<i class="fa fa-location-arrow" aria-hidden="true"></i>
							</div>
							<div class="media-body dit-right">
								<h4>Address</h4>
								<p>80/A, Main Blvd, Block E1, Gulberg III, Lahore, Punjab 54810</p>
							</div>
						</div>
						<div class="media cont-line">
							<div class="media-left icon-b">
								<i class="fa fa-envelope" aria-hidden="true"></i>
							</div>
							<div class="media-body dit-right">
								<h4>Email</h4>
								<a href="#">inquire@phs.com</a><br>
								<a href="#">care@phs.com</a>
							</div>
						</div>
						<div class="media cont-line">
							<div class="media-left icon-b">
								<i class="fa fa-volume-control-phone" aria-hidden="true"></i>
							</div>
							<div class="media-body dit-right">
								<h4>Phone Number</h4>
								<a href="#">0423 5482159</a><br>
								<a href="#">0321 4258967</a>
							</div>
						</div>
					</div>
				</div>
				
				
			</div>
		</div>
	</div>
	<!-- End Contact -->
	



	





	

</asp:Content>
