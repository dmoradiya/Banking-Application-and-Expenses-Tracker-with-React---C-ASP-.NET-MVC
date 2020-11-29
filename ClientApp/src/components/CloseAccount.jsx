import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import { useHistory } from "react-router-dom";
import "./css/CloseAccount.css"


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
            default:
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
            setResponse("Account Archived Successfully");
            history.push("/archive-notification");


        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });
       
    }

    return (
        <section className="close-account-page">
            <Layout />
            <h1 className="close-account-header"> Close Account </h1>
            <p className="close-account-error alert alert-light">{waiting ? "Waiting..." : `${response}`}</p>
            <form className="close-account-form" onSubmit={handleSubmit}>
                <section className="input-group-prepend close-account-prepend">

                <label className="input-group-text close-account-placeholder" htmlFor="accountID">Account</label>
                <select className="form-control" id="accountID" onChange={handleFieldChange}>
                    <option value="" >Select Account</option>
                    {accountInfo.map(client => (
                        <option key={client.accountID} value={`${client.accountID}`}>
                            {console.log(client.accountID)}
                            {`${client.accountType}- Total Balance: $${client.accountBalance + client.cashback}`}
                        </option>
                    ))}
                    </select>               
                </section>
                <section className="close-account-submit">
                <input type="submit" className="btn btn-primary" value="Close Account" />
                </section>
            </form>
        </section>


    );

}
export { CloseAccount };