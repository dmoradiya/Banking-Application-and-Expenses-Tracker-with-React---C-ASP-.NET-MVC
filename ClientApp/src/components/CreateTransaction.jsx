import React from 'react';
import { Link } from "react-router-dom";
import "./css/CreateNotification.css"


function CreateTransaction(props) {
    const randomString = require('random-string');    // https://www.npmjs.com/package/random-string
    const x = randomString(); // x contains now a random String with the length of 8

    return (
        <section className="notification-page">
            <section className="notification-message">
                <h1 className="notification-header" className="display-3"> Transaction Created! </h1>
                <p id="notification-paragraph" className="lead"><strong>Thank You for banking with us!</strong></p>
                <p id="notification-paragraph" className="lead">Your Transaction has been successfully added to the database. Your unique TransactionID is: <strong>{x}</strong>.</p>
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