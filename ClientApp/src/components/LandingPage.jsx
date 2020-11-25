import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import { Link } from "react-router-dom";
import "./css/root.css"
import "./css/LandingPage.css"


function LandingPage(props) {

    const [accountInfo, setAccountInfo] = useState([]);
    const [loading, setLoading] = useState(true);

    function renderClientInfoTable(accountInfo) {


        return (
            <section id="landing-page-summary">
                <table className='table table-striped table-borderless' aria-labelledby="tabelLabel">
                    <tbody>
                        {accountInfo.map(client =>
                            <tr key={client.accountID}>
                                <div className="flex-container">
                                    <th>Full Name: </th>
                                    <td>{client.client.firstName + " " + client.client.lastName}</td>
                                </div>
                                <div className="flex-container account-type">
                                    <th>Account Type: </th>
                                    <td>{client.accountType}</td>
                                </div>
                                <div className="flex-container">
                                    <th>Account Balance: </th>
                                    <td>{client.accountBalance}</td>
                                </div>
                                <div className="flex-container">
                                    <th>Interest Earned: </th>
                                    <td>{client.accountInterest}</td>
                                </div>
                                <div className="flex-container">
                                    <th>Total Balance: </th>
                                    <td>{client.accountBalance + client.accountInterest}</td>
                                </div>
                                <div className="flex-container">
                                    <th>View Transactions: </th>
                                    <td>
                                        <button className="btn btn-info">
                                            <Link to={`/view-transactions?id=${client.accountID}`}>
                                                {client.accountType}
                                            </Link>
                                        </button>
                                    </td>
                                </div>
                            </tr>
                        )}
                    </tbody>
                </table>
            </section>
            

        );
    }

    async function populateClientData() {
        const response = await axios.get('BankAPI/LandingPage');
        setAccountInfo(response.data);
        setLoading(false);
    }

    useEffect(() => {
        populateClientData();
    }, [loading]);

    let contents = loading
        ? <p><em>Loading...</em></p>
        : renderClientInfoTable(accountInfo);

    return (
        <section id="landing-page">
            <Layout />
            <h1 id="tabelLabel" >Account Summary</h1>
            {contents}
        </section>
    );
}

export { LandingPage };
