import React from 'react';
import { Link } from "react-router-dom";
import "./css/ContactUs.css"

function ContactUs(props) {

    return (
        <section>
            <section className="contact-page">
                <div className="banner"></div>
                <section className="contact-message">
                    <h1 className="contact-header display-3"> Contact Us </h1>
                    <p>Have any Questions? We'd love to hear from you!</p>  

                    <div className="card-deck">
                        <div className="card">
                            <div className="card-header bg-primary text-center">
                                <p className="card-text"><strong>Press</strong></p>
                            </div>
                            <div className="card-body text-center">
                                <p>Suggestions? Contact our press team to get in touch with us regarding general inquiries!</p>
                                <button className="btn btn-primary">
                                    <a className="white-text" href="mailto:press@vvbank.com" target="_blank" rel="noopener noreferrer">Email Our Press Team</a>
                                </button>
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-header bg-success text-center">
                                <p className="card-text"><strong> Support</strong></p>
                            </div>
                            <div className="card-body text-center">
                                <p>Having Trouble? Our support team is available 24/7 to give you answers fast.</p>
                                <p> If you prefer a human contact, call us at 1-800-555-5555!</p>
                                <button className="btn btn-success">
                                    <a className="white-text" href="mailto:support@vvbank.com" target="_blank" rel="noopener noreferrer">Email Our Support Staff!</a>
                                </button>
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-header bg-warning text-center">
                                <p className="card-text"><strong> Consulting</strong></p>
                            </div>
                            <div className="card-body text-center">
                                <p>Get in touch with our team of top professionals to see how we can work together!</p>
                                <p> Call us at 1-800-555-5555!</p>
                                <button className="btn btn-warning">
                                    <a className="white-text" href="mailto:sales@vvbank.com" target="_blank" rel="noopener noreferrer">Email Our Sales Team!</a>
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
export { ContactUs };