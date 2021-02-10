import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import { Link } from "react-router-dom";
import "./css/root.css"
import "./css/LandingPage.css"


function LandingPage(props) {

    const [accountInfo, setAccountInfo] = useState([]);
    const [loading, setLoading] = useState(true);

    function renderClientInfoTable(accountInfo) { /*Rendering the API data in a tabular format*/

        const totalHolding = accountInfo.reduce((total, client) => total = total + client.accountBalance, 0) + 
                           accountInfo.reduce((total, client) => total = total + client.cashback, 0); /*totalHolding is used to do the calculation for total balance (including balance + cashback) for each account*/

        const name = accountInfo.map(x => x.client.firstName + " " + x.client.lastName)[0]; /*Will only give the first account*/
       

        return (
            <section id="landing-page-summary">
                <h1>Account Summary</h1>  
                <h2>Total Holdings : $ {totalHolding.toFixed(2)}</h2>
                <h3>Full Name: { name }</h3>
                <table className='table table-borderless' aria-labelledby="tabelLabel">
                    <tbody>
                        {accountInfo.map(client =>
                            <tr key={client.accountID}>                                
                                <th className="flex-container account-type">
                                    <p className="heading">Account Type: </p>
                                    <p className="font-weight-normal">{client.accountType}</p>
                                </th>
                                <th className="flex-container">
                                    <p className="heading">Account Balance: </p>
                                    <p className="font-weight-normal">$ {(client.accountBalance).toFixed(2)}</p>
                                </th>
                                <th className="flex-container">
                                    <p className="heading">Cashback Earned: </p>
                                    <p className="font-weight-normal">$ {(client.cashback).toFixed(2)}</p>
                                </th>
                                <th className="flex-container total-balance">
                                    <p className="heading">Total Balance: </p>
                                    <p className="font-weight-normal">$ {(client.accountBalance + client.cashback).toFixed(2)}</p>
                                </th>
                                <th className="flex-container view-transactions">
                                    <p className="heading">View Transactions: </p>
                                    <p>
                                        <button className="btn btn-info">

                                            {/* Sending account Id to Transaction Page*/ }
                                            <Link className="text-white" to={{
                                                pathname: "/view-transactions",
                                                state: { id: client.accountID }
                                            }}>
                                                { client.accountType }
                                            </Link>
                                        </button>
                                    </p>
                                </th>
                            </tr>
                        )}
                    </tbody>
                </table>
            </section>
            

        );
    }
    
    async function populateClientData() { /*Populates response with API/LandingPage*/
        const response = await axios.get('BankAPI/LandingPage');
        setAccountInfo(response.data);
        setLoading(false);
    }

    useEffect(() => { /*Prevent useEffect From Running Every Render*/
        populateClientData();
    }, [loading]);

    let contents = loading
        ? <p><strong>Loading...</strong></p>
        : renderClientInfoTable(accountInfo);

    return (
        <section id="landing-page">
            <Layout />                     
            {contents}
        </section>
    );
}

export { LandingPage };
