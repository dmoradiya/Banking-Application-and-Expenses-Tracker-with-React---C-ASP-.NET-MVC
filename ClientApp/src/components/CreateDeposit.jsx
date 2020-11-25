﻿import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import "./css/CreateDeposit.css"


function CreateDeposit(props) {
    const [accountID, setAccountID] = useState("");
    const [transactionSource, setTransactionSource] = useState("");
    const [transactionValue, setTransactionValue] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
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
        switch (event.target.id) {
            case "accountID":
                setAccountID(event.target.value);
                break;
            case "transactionSource":
                setTransactionSource(event.target.value);
                break;           
            case "transactionValue":
                setTransactionValue(event.target.value);
                break;           
        }
    }

    function handleSubmit(event) {
        event.preventDefault();
        setWaiting(true);       

        // Post Request
        axios(
            {
                method: 'post',
                url: 'BankAPI/CreateDeposit',
                params: {
                    accountID: accountID,
                    transactionSource: transactionSource,
                    transactionValue: transactionValue,
                }
            }
        ).then((res) => {
            setWaiting(false);
            setResponse("Transaction Completed Successfully");
        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });

    }

    return (
        <section className="deposit-page">
            <Layout />

            <h1 className="deposit-header"> Make a Deposit </h1>

            <p className="deposit-error">{waiting ? "Waiting..." : `${response}`}</p>
            <form className="deposit-form" onSubmit={handleSubmit}>              

                <section className="input-group-prepend">
                <label className="input-group-text" htmlFor="accountID">Account</label>
                <select className="deposit-selector" id="accountID"  onChange={handleFieldChange}>
                    <option className="center" value=""  >Select Account</option>
                        {accountInfo.map(client => (<option key={client.accountID} value={`${client.accountID}`}>
                        {`${client.accountType} Account -- Total Balance: $${client.accountBalance + client.accountInterest}`}
                    </option>
                ))}
                    </select>
                    </section>
                <br />  
                <section className="input-group-prepend">
                    <label className="input-group-text" htmlFor="accountID">Location</label>
                <select className="deposit-selector" id="transactionSource" onChange={handleFieldChange}>
                    <option value="" >Deposit Source</option>
                    <option value="Bank">Bank</option>
                    <option value="ATM">ATM</option>
                    </select>
                    </section>
                <br />
                <section className="input-group-prepend">
                    <label className="input-group-text" htmlFor="address">Address</label>
                        <input
                            className="deposit-selector"
                            id="transactionValue"
                            placeholder="Transaction Value"
                            type="text"
                        onChange={handleFieldChange} />
                    </section>
                <br />
                <input type="submit" className="btn btn-primary deposit-submit" value="Submit" />
                </form>
        </section>

        
        );

}
export { CreateDeposit };