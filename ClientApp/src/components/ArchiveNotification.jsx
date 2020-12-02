import React from 'react';
import { Link } from "react-router-dom";
import { FiCheckCircle } from "react-icons/fi"
import "./css/CreateNotification.css"

function ArchiveNotification(props) {
    return (
        <section className="notification-page container">
            <div className="notification-message">
                <h1 className="notification-header text-success">Success! <FiCheckCircle /></h1>
                <p id="notification-paragraph lead"> Your Account has been Archived. Your data is safe, and has not been deleted.</p>
                <button className="btn btn-info">
                    <Link className="white-text" to="/">
                        Logout
                    </Link>
                </button> 
            </div>
        </section>
    );
}
export { ArchiveNotification };