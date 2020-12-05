import React from 'react';
import { Link } from "react-router-dom";
import { FiCheckCircle } from "react-icons/fi"
import "./css/CreateNotification.css"


function CreateNotification(props) {
    

    return (
        <section className="notification-page container">
            <div className="notification-message">
                <h1 className="notification-header text-success">Success! <FiCheckCircle /></h1>
                <p id="notification-paragraph" className="lead"><strong>Thank You for joining us!</strong></p>
                <p id="notification-paragraph" className="lead">Your Account has been Successfully Created.</p>
                <button className="btn btn-info">
                    <Link className="white-text" to="/">
                        Login to Continue
                    </Link>
                </button> 
                <section id="notification-steppers" className="steppers stepper stepper-horizontal">
                    <div>
                        <span className="circle bg-success">1</span>
                        <span className="label d-none d-sm-block">Client Info</span>
                    </div>
                    <div className="horizontal-line-one">
                        <hr />
                    </div>
                    <div>
                        <span className="circle bg-success">2</span>
                        <span className="label d-none d-sm-block">Account</span>
                    </div>
                    <div className="horizontal-line-one">
                        <hr />
                    </div>
                    <div>
                        <span className="circle bg-success">3</span>
                        <span className="label d-none d-sm-block">Success!</span>
                    </div>
                </section>           

            </div>
        </section>


    );

}
export { CreateNotification };