import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';


function CreateAccountForExistingClient(props) {

    const [accountInfo, setAccountInfo] = useState([]);
    const [loading, setLoading] = useState(true);

    async function populateClientData() {
        const response = await axios.get('BankAPI/LandingPage');
        setAccountInfo(response.data);
        setLoading(false);
    }

    useEffect(() => {
        populateClientData();
    }, [loading]);

    function handleFieldChange(event) {

    }

    function handleSubmit(event) {

    }

    return (
        <div>
            <Layout />
            <h1>Open New Account</h1>
            <br />
            <form onSubmit={handleSubmit}>

                <label htmlFor="accountID">Account Type</label>
                <select id="accountID" onChange={handleFieldChange}>
                    <option value="" >Choose Account here</option>
                    {accountInfo.map(client => (
                        <option key={client.accountID} value={`${client.accountID}`}>
                            {`${client.accountType} Account`}
                        </option>
                    ))}
                </select>
                <br />
                <input type="submit" className="btn btn-primary" value="Submit" />
            </form>
        </div>


    );

}
export { CreateAccountForExistingClient };