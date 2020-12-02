import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import { useHistory } from "react-router-dom";

import "./css/CreateWithdraw.css"



function CreateWithdraw(props) {
    const [accountID, setAccountID] = useState("");
    const [transactionSource, setTransactionSource] = useState("");
    const [transactionValue, setTransactionValue] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
    const [accountInfo, setAccountInfo] = useState([]);
    const [loading, setLoading] = useState(true);
    const history = useHistory();



    // Get Today's Date
    const today = new Date().toLocaleDateString().substr(0, 10);


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
            default:
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
                url: 'BankAPI/CreateWithdraw',
                params: {
                    accountID: accountID,
                    transactionSource: transactionSource,
                    transactionValue: transactionValue,
                    transactionDate: today
                }
            }
        ).then((res) => {
            setWaiting(false);
            setResponse("Transaction Completed successfully");
            history.push("/transaction-notification");

        }   
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });
    }

    return (
        <section className="withdraw-page">
            <Layout />
            <h1 className="withdraw-header"> Make a Withdraw </h1>

            <p className="withdraw-error alert alert-light">{waiting ? "Waiting..." : `${response}`}</p>
            <form className="withdraw-form" onSubmit={handleSubmit}>

                <section className="input-group-prepend withdraw-prepend">
                    <label className="input-group-text withdraw-placeholder" htmlFor="accountID">Account</label>
                    <select className="form-control" id="accountID" onChange={handleFieldChange}>
                        <option value="" >Select Account</option>
                            {accountInfo.map(client => (
                        <option key={client.accountID} value={`${client.accountID}`}>
                            {`${client.accountType}- Total Balance: $${(client.accountBalance + client.cashback).toFixed(2)}`}
                        </option>
                    ))}
                    </select>
                    </section>
                <section className="input-group-prepend withdraw-prepend">
                    <label className="input-group-text withdraw-placeholder" htmlFor="transactionSource">Location</label>
                <select className="form-control" id="transactionSource" onChange={handleFieldChange}>
                    <option value="" >Deposit Source</option>
                    <option value="Bank">Bank</option>
                    <option value="ATM">ATM</option>
                    </select>
                </section>
                <section className="input-group-prepend withdraw-prepend">
                    <label className="input-group-text withdraw-placeholder" htmlFor="transactionValue">Value</label>
                    <input className="form-control" id="transactionValue" type="text" placeholder="Transaction Value" onChange={handleFieldChange} />
                </section>
                <section className="withdraw-submit">

                    <input type="submit" className="btn btn-info" value="Submit" />
                    </section>
            </form>
        </section>
    );
}
export { CreateWithdraw };