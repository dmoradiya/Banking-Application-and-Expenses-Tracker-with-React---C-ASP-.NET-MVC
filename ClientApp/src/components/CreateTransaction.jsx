import React from 'react';
import { Link } from "react-router-dom";
import "./css/CreateNotification.css"


function CreateTransaction(props) {
    

    return (
        <section className="notification-page">
            <div className="notification-message">
                <h1 className="notification-header" className="display-3"> Account Created! </h1>
                <p id="notification-paragraph" className="lead"><strong>Thank You for joining us!</strong></p>
                <p id="notification-paragraph" className="lead">Your Account has been Successfully Created.</p>
                <button className="btn btn-info">
                    <Link className="white-text" to="/">
                        Login to Continue
                </Link>
                </button>
            </div>
        </section>


    );

}
export { CreateTransaction };