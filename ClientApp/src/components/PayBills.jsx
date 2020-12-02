import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import { useHistory } from "react-router-dom";

import "./css/PayBills.css"

function PayBills(props) {
    const [accountID, setAccountID] = useState("");
    const [transactionCategory, setTransactionCategory] = useState("");
    const [transactionValue, setTransactionValue] = useState("");
    const [transactionDate, setTransactionDate] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
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
            case "transactionCategory":
                setTransactionCategory(event.target.value);
                break;
            case "transactionValue":
                setTransactionValue(event.target.value);
                break;
            case "transactionDate":
                setTransactionDate(event.target.value);
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
                    transactionCategory: transactionCategory,
                    transactionValue: transactionValue,
                    transactionDate: transactionDate,
                }
            }
        ).then((res) => {
            setWaiting(false);
            setResponse("Thank you for the Transaction");
            history.push("/transaction-notification");
        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });

    }

    return (
        <section className="bills-page">
            <Layout />
            <h1 className="bills-header"> Pay Bills </h1>
            <p className="bills-error alert alert-light">{waiting ? "Waiting..." : `${response}`}</p>

            <form className="bills-form" onSubmit={handleSubmit}>
                <section className="input-group-prepend bills-prepend">
                    <label className="input-group-text bills-placeholder" htmlFor="accountID">Account</label>
                    <select className="form-control" id="accountID" onChange={handleFieldChange}>
                            <option value="" >Select Account</option>
                            {accountInfo.map(client => (
                            <option key={client.accountID} value={`${client.accountID}`}>
                                    {`${client.accountType}- Total Balance: $${(client.accountBalance + client.cashback).toFixed(2)}`}
                            </option>
                            ))}
                        </select>
                </section>
                <section className="input-group-prepend bills-prepend">
                    <label className="input-group-text bills-placeholder" htmlFor="transactionCategory">Category</label>
                    <select className="form-control" id="transactionCategory" onChange={handleFieldChange}>
                            <option value="" >Select Category</option>
                            <option value="Food">Food</option>
                            <option value="Rent">Rent/Mortgage</option>
                            <option value="Utilities">Utilities</option>
                            <option value="Entertainment">Entertainment</option>
                            <option value="Phone">Phone</option>
                            <option value="Internet">Internet</option>
                            <option value="Health">Health</option>
                            <option value="Memberships">Memberships</option>
                            <option value="Subscriptions">Subscriptions</option>
                            <option value="Other">Other</option>
                        </select>
                </section>
                <section className="input-group-prepend bills-prepend">
                    <label className="input-group-text bills-placeholder" htmlFor="transactionValue">Value</label>
                    <input className="form-control" id="transactionValue" placeholder="Transaction Value" type="text" onChange={handleFieldChange} />
                </section>
                <section className="input-group-prepend bills-prepend">
                    <label className="input-group-text bills-placeholder" htmlFor="transactionDate">Date</label>
                    <input className="form-control" id="transactionDate" type="date" onChange={handleFieldChange} />
                </section>
                <section className="bills-submit">
                    <input className="form-control" type="submit" className="btn btn-info" value="Submit" />
                </section>
            </form>
        </section>
    );
}
export { PayBills };