import React, { useState, useEffect } from 'react';
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

            <p className="deposit-error alert alert-light">{waiting ? "Waiting..." : `${response}`}</p>
            <form className="deposit-form" onSubmit={handleSubmit}>              

                <section className="input-group-prepend deposit-prepend">
                <label className="input-group-text deposit-placeholder" htmlFor="accountID">Account</label>
                <select className="form-control" id="accountID"  onChange={handleFieldChange}>
                    <option value=""  >Select Account</option>
                        {accountInfo.map(client => (<option key={client.accountID} value={`${client.accountID}`}>
                        {`${client.accountType}- Total Balance: $${client.accountBalance + client.cashback}`}
                    </option>
                ))}
                    </select>
                    </section>
                <section className="input-group-prepend deposit-prepend">
                    <label className="input-group-text deposit-placeholder" htmlFor="accountID">Location</label>
                    <select className="form-control" id="transactionSource" onChange={handleFieldChange}>
                    <option value="" >Deposit Source</option>
                    <option value="Bank">Bank</option>
                    <option value="ATM">ATM</option>
                    </select>
                    </section>
                <section className="input-group-prepend deposit-prepend">
                    <label className="input-group-text deposit-placeholder" htmlFor="address">Value</label>
                        <input
                        className="form-control" id="transactionValue" placeholder="Transaction Value" type="text" onChange={handleFieldChange} />
                    </section>
                <section className="deposit-submit">
                    <input type="submit" className="btn btn-primary dropdown-toggle" value="Submit" />
                    </section>
                </form>
        </section>

        
        );

}
export { CreateDeposit };