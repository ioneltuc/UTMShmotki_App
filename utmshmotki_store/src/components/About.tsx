import placeholder from "../assets/images/product_placeholder.png"
import LocationOnIcon from '@mui/icons-material/LocationOn';
import LocalPhoneIcon from '@mui/icons-material/LocalPhone';
import EmailIcon from '@mui/icons-material/Email';
import InstagramIcon from '@mui/icons-material/Instagram';
import FacebookIcon from '@mui/icons-material/Facebook';
import LinkedInIcon from '@mui/icons-material/LinkedIn';
import GitHubIcon from '@mui/icons-material/GitHub';

function About(){

    return(
        <div className="about-section">
            <img className="about-section-image" src={placeholder} />
            <h1>UTMShmotki</h1>
            <div className="contact-info">
                <div>
                    <LocationOnIcon sx={{ fontSize: 40 }}/>
                    <a href="https://www.google.com/maps/place/ZIPHOUSE/@47.0629816,28.8668051,17z/data=!3m1!4b1!4m5!3m4!1s0x40c97d1e3f4d2e6b:0x52a8851f8dedc44b!8m2!3d47.062978!4d28.8689938">9/19 Studenților Street,<br/>Chișinău,<br/>Republic of Moldova</a>
                </div>
                <div>
                    <LocalPhoneIcon sx={{ fontSize: 40 }}/>
                    <a href="tel:068129830">+373 0 68 129 830</a>
                </div>
                <div>
                    <EmailIcon sx={{ fontSize: 40 }}/>
                    <a href="mailto:iontuc21@gmail.com">iontuc21@gmail.com</a>
                </div> 
            </div>
            <div className="social-info">
                <a href="https://www.facebook.com/iontuc"><FacebookIcon sx={{ fontSize: 50 }}/></a>
                <a href="https://www.instagram.com/ioneltuc/"><InstagramIcon sx={{ fontSize: 50 }}/></a>
                <a href="https://www.linkedin.com/in/ion-tentiuc-1140b0244/"><LinkedInIcon sx={{ fontSize: 50 }}/></a>
                <a href="https://github.com/ioneltuc"><GitHubIcon sx={{ fontSize: 50 }}/></a>
            </div>
            <div>
                <p className="copyright">©2022 ioneltuc. Toate drepturile rezervate.</p>
            </div>
        </div>
    )
}

export default About