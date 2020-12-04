import React from 'react';
import { Link } from "react-router-dom";
import {
    FiFacebook,
    FiInstagram,
    FiTwitter,
    FiYoutube,
   
} from "react-icons/fi";
import "./css/Footer.css"
import "./css/root.css"


function Footer(props) {
   
    return (

        <footer className="fixed-bottom">
            <div className="d-flex justify-content-around">
                <Link className="text-white general-page" to='/contact-us'>Contact</Link>
                <Link className="text-white general-page" to='/careers'>Careers</Link>
                <Link className="text-white general-page" to='/faq'>FAQs</Link>                
                <a className="d-none d-sm-block text-white social-icons" href="https://www.facebook.com" target="_blank" rel="noopener noreferrer"><FiFacebook /></a>
                <a className="d-none d-sm-block text-white social-icons" href="https://www.instagram.com" target="_blank" rel="noopener noreferrer"><FiInstagram /></a>
                <a className="d-none d-sm-block text-white social-icons" href="https://www.twitter.com" target="_blank" rel="noopener noreferrer"><FiTwitter /></a>
                <a className="d-none d-sm-block text-white social-icons" href="https://www.youtube.com" target="_blank" rel="noopener noreferrer"><FiYoutube /></a>      
            </div>   
        </footer>
    );

}
export { Footer };