import React from 'react';
import { Link } from "react-router-dom";

function FAQ(props) {
        

    return (
        <section>
            <section className="notification-page">
                <div className="notification-message">

                    <h1 className="notification-header display-3"> Frequently Asked Questions </h1>
                    <p className="form-control" id="notification-paragraph lead"><strong> Q: What is the purpose of this application?</strong></p>
                    <p>A: This application allows you to enter transaction data, and displays a visual representation of your expenses.</p>
                    <button className="btn btn-info">
                        <Link className="white-text" to="/">
                            Return To Login Page
                </Link>
                    </button>
                </div>
            </section>
            </section>



    );

}
export { FAQ };