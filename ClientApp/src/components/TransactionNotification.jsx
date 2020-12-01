import React from 'react';
import { Link } from "react-router-dom";
import "./css/CreateNotification.css";
import { FiCheckCircle } from "react-icons/fi"


function TransactionNotification(props) {

    // confirmationNumber contains a random String of A-Z0-9 with the length of 10 Characters
    let confirmationNumber = Math.random().toString(36).toUpperCase().substr(2, 10);

    return (
        <section className="notification-page container">
            <div className="notification-message">
                <h1 className="notification-header text-success" >Success! <FiCheckCircle /> </h1>
                <p id="notification-paragraph" className="lead"><strong>Thank You for banking with us!</strong></p>
                <p id="notification-paragraph" className="lead">Your Transaction has been successfully Completed. Your Confirmation Number is: <strong>{confirmationNumber}</strong></p>
                <button className="btn btn-info">
                    <Link className="white-text" to="/landing-page">
                        Return To Home
                    </Link>
                </button>
            </div>
        </section>
    );

}
export { TransactionNotification };