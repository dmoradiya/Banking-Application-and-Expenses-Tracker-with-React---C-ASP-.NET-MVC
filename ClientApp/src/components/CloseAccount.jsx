import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import { useHistory } from "react-router-dom";


function CloseAccount(props) {
    const [accountID, setAccountID] = useState("");    
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);

    // Populate DropDown Select Option with Account(S)
    const [accountInfo, setAccountInfo] = useState([]);
    const [loading, setLoading] = useState(true);
    const history = useHistory();

   
    async function populateClientData() {
        const response = await axios.get('BankAPI/LandingPage');
        setAccountInfo(response.data);
        setLoading(false);
    }

    useEffect(() => {
        populateClientData();
    }, [loading]);



    function handleFieldChange(event) {
        switch (event.target.id) {
            case "accountID":
                setAccountID(event.target.value);
                break;          
        }
    }

    function handleSubmit(event) {
        event.preventDefault();
        setWaiting(true);
              
        // Patch Request
        axios(
            {
                method: 'patch',
                url: 'BankAPI/CloseAccount',
                params: {
                    accountID: accountID,
                }
            }
        ).then((res) => {
            setWaiting(false);
            setResponse(res.data);
            history.push("/archive-notification");


        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });
       
    }

    return (
        <div>
            <Layout />
            <h1> Close Your Account </h1>
            <p>{waiting ? "Waiting..." : `${response}`}</p>

            <br />
            <form onSubmit={handleSubmit}>

                <label htmlFor="accountID">Account Type</label>
                <select id="accountID" onChange={handleFieldChange}>
                    <option value="" >Choose Account here</option>
                    {accountInfo.map(client => (
                        <option key={client.accountID} value={`${client.accountID}`}>
                            {console.log(client.accountID)}
                            {`${client.accountType} Account      Total Balance: $${client.accountBalance + client.accountInterest}`}
                        </option>
                    ))}
                </select>               
                <br />
                <input type="submit" className="btn btn-primary" value="Close Account" />
            </form>
        </div>


    );

}
export { CloseAccount };