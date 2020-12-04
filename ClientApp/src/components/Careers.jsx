import React from 'react';
import { Link } from "react-router-dom";
import "./css/Careers.css"

function Careers(props) {

    return (
        <section>
            <section className="careers-page">
                <p><img id="banner-small" className="d-block d-sm-none" src={require("./img/banner320px.png")} alt="vv bank text for small size" /></p>
                <p><img id="banner-medium" className="d-none d-sm-block d-md-none" src={require("./img/banner576px.png")} alt="vv bank text for medium size" /></p>
                <p><img id="banner-large" className="d-none d-md-block d-lg-none" src={require("./img/banner768px.png")} alt="vv bank text for large size" /></p>
                <p><img id="banner-exlarge" className="d-none d-lg-block d-xl-block" src={require("./img/banner992px.png")} alt="vv bank text for extra large size" /></p>
                <section className="careers-message">
                    <h1 className="careers-header display-3"> Careers </h1>
                    <p>Do you have experience in the banking industry and/or know how to code? We'd love to hear from you!</p>

                    <div className="card-deck">
                        <div className="card">
                            <div className="card-header bg-danger text-center">
                                <p className="card-text"><strong>Current Opportunities</strong></p>
                            </div>
                            <div className="card-body text-center">
                                <p>Unfortunately, we are not actively hiring at this time! Please come back and check this page again in the future!</p>
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-header bg-info text-center">
                                <p className="card-text"><strong>Open Inquiries</strong></p>
                            </div>
                            <div className="card-body text-center">
                                <p>We're always willing to review applications from interested professionals. Don't hesitate to contact us!</p>
                                <button className="btn btn-info">
                                    <a className="white-text" href="mailto:careers@vvbank.com" target="_blank" rel="noopener noreferrer">Email Our HR Staff!</a>
                                </button>
                            </div>
                        </div>
                      
                    </div>
                    <button className="btn btn-info">
                        <Link className="white-text" to="/">Return To Login Page</Link>
                    </button>
                </section>
            </section>
        </section>



    );

}
export { Careers };