import React from 'react';
import { Link } from "react-router-dom";
import "./css/CreateNotification.css"


function CreateTransaction(props) {
    

    return (
        <section className="notification-page">
            <section className="notification-message">
                <h1 className="notification-header" className="display-3"> Transaction Created! </h1>
                <p id="notification-paragraph" className="lead"><strong>Thank You for banking with us!</strong></p>
                <p id="notification-paragraph" className="lead">Your Transaction has been successfully added to the database.</p>
                <button className="btn btn-info">
                    <Link className="white-text" to="/landing-page">
                        Return To Landing Page
                </Link>
                </button>
            </section>
        </section>


    );

}
export { CreateTransaction };