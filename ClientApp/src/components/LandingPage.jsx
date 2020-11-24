import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import { Link } from "react-router-dom";
import "./css/root.css"


function LandingPage(props) {

    const [accountInfo, setAccountInfo] = useState([]);
    const [loading, setLoading] = useState(true);

    function renderClientInfoTable(accountInfo) {


        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
               
                <tbody>
                    {accountInfo.map(client =>
                        <tr key={client.accountID}>
                            <th>Full Name</th>
                            <td>{client.client.firstName + " " + client.client.lastName}</td>
                            <th>Account Type</th>  
                            <td>{client.accountType}</td>
                            <th>Account Balance</th>  
                            <td>{client.accountBalance}</td>
                            <th>Interest Earned</th>  
                            <td>{client.accountInterest}</td>
                            <th>Total Balance</th>
                            <td>{client.accountBalance + client.accountInterest}</td>
                            <th>View Transactions</th> 
                            <td>                                
                                <button className="btn btn-info">
                                    <Link to={`/view-transactions?id=${ client.accountID }`}>
                                        {client.accountType}                                        
                                    </Link>
                                </button> 
                            </td>
                        </tr>
                    )}
                </tbody>
               
            </table>

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
        <div>
            <Layout />
            <h1 id="tabelLabel" >Account Summary</h1>
            {contents}
        </div>
    );
}

export { LandingPage };
