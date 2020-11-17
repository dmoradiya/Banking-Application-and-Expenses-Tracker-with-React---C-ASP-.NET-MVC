import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';


function LandingPage(props) {
    const displayName = LandingPage.name;

    const [accountInfo, setAccountInfo] = useState([]);
    const [loading, setLoading] = useState(true);

    function renderClientInfoTable(accountInfo) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Full Name</th>
                        <th>Account Type</th>                        
                        <th>Account Balance</th>                        
                        <th>Interest Earned</th>                        
                        <th>Total Balance</th>                        
                    </tr>
                </thead>
                <tbody>
                    {accountInfo.map(client =>
                        <tr key={client.clientID}>
                            <td>{client.client.firstName + " " + client.client.lastName}</td>
                            <td>{client.accountType}</td>
                            <td>{client.accountBalance}</td>
                            <td>{client.accountInterest}</td>
                            <td>{client.accountBalance + client.accountInterest}</td>
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
