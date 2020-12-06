import React from 'react';
import { Link } from "react-router-dom";
import "./css/FAQ.css"

function FAQ(props) {
       
    return (
        <section>
            <section className="faq-page">
                <div className="banner"></div>
                <section className="faq-message">
                    <h1 className="faq-header display-3"> Frequently Asked Questions </h1>
                    <p className="form-control" id="faq-paragraph lead"><strong> Q: What is the purpose of this application?</strong></p>
                    <p>A: This application allows you to enter transaction data, and displays a visual representation of your expenses.</p>
                    <p className="form-control" id="faq-paragraph lead"><strong> Q: How do I know my funds are safe here?</strong></p>
                    <p>A: We use state of the art technology to ensure your data is safe and secure at all times. Just trust us :)</p>
                    <p className="form-control" id="faq-paragraph lead"><strong> Q: What do good expenses look like?</strong></p>
                    <p>A: According to creditcanada.com, 35% Housing, 15% Food, 15% Transportation, 10% Utilities, 10% Debt Payments, 5% Savings, 2.5% Clothing, 2.5% Medical, 5% Other is a good benchmark!</p>
                    <p className="form-control" id="faq-paragraph lead"><strong> Q: What can I do to save more money?</strong></p>
                    <p>A: Create a budget. Our planners would be happy to assist you. See our contact page for more details!</p>
                    <p className="form-control" id="faq-paragraph lead"><strong> Q: What's all this about Cash Back?</strong></p>
                    <p>A: When you pay your bills, we'll deposit 5% of the amount you spend into a cashback account. When that account reaches $100, we'll automatically redeem it back into your account!</p>
                            <button className="btn btn-info">
                                <Link className="white-text" to="/">Return To Login Page</Link>
                            </button>
                </section>
            </section>
            </section>



    );

}
export { FAQ };