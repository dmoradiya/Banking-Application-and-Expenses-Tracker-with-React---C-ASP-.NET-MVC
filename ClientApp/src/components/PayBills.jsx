import React, { useState, useEffect } from 'react';
import axios from 'axios';

import { Layout } from '../components/Layout';

function PayBills(props) {
    const [accountID, setAccountID] = useState("");

    const [transactionCategory, setTransactionCategory] = useState("");
    const [transactionValue, setTransactionValue] = useState("");
    const [transactionDate, setTransactionDate] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
    const [postResponse, setPostResponse] = useState(false);

    const [accountInfo, setAccountInfo] = useState([]);
    const [loading, setLoading] = useState(true);

    const [patchResponse, setPatchResponse] = useState([]);
    const [patchWaiting, setPatchWaiting] = useState(false);



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
        }
    }

    function handleSubmit(event) {
        event.preventDefault();
        setWaiting(true);
        setPatchWaiting(true);

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
            setResponse(res.data);
            setPostResponse(true);
        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });

        if (setPostResponse) {
            // Patch Request
            axios(
                {
                    method: 'patch',
                    url: 'BankAPI/WithdrawBalance',
                    params: {
                        accountID: accountID,
                        transactionValue: transactionValue,
                    }
                }
            ).then((res) => {
                setPatchWaiting(false);
                setPatchResponse(res.data);


            }
            ).catch((err) => {
                setPatchWaiting(false);
                setPatchResponse(err.response.data);
            });
        }
        

    }

    return (
        <div>
            <Layout />
            <h1> Pay Bills </h1>
            <p>{waiting ? "Waiting..." : `${response}`}</p>
            <p>{postResponse ? <p>{patchWaiting ? "Waiting..." : `${patchResponse}`}</p> : ""}</p>

            <br />
            <form onSubmit={handleSubmit}>

                <label htmlFor="accountID">Account Type</label>
                <select id="accountID" onChange={handleFieldChange}>
                    <option value="" >Choose here</option>

                    {accountInfo.map(client => (
                        <option key={client.accountID} value={`${client.accountID}`}>
                            {console.log(client.accountID)}
                            {`${client.accountType} Account      Total Balance: $${client.accountBalance + client.accountInterest}`}
                        </option>
                    ))}
                </select>

                <br />
                <label htmlFor="transactionCategory">Transaction Category</label>
                <select id="transactionCategory" onChange={handleFieldChange}>
                    <option value="" >Choose here</option>
                    <option value="Food">Food</option>
                    <option value="Rent/Mortgage">Rent/Mortgage</option>
                    <option value="Utilities">Utilities</option>
                    <option value="Entertainment">Entertainment</option>
                    <option value="Phone">Phone</option>
                    <option value="Internet">Internet</option>
                    <option value="Health">Health</option>
                    <option value="Memberships">Memberships</option>
                    <option value="Subscriptions">Subscriptions</option>
                    <option value="Other">Other</option>
                </select>
                <br />

                <label htmlFor="transactionValue">Value of this transaction</label>

                <br />
                <input id="transactionValue" type="text" onChange={handleFieldChange} />
                <br />
                <label htmlFor="transactionDate">Transaction Date</label>
                <br />
                <input id="transactionDate" type="date" onChange={handleFieldChange} />
                <br />
                <input type="submit" className="btn btn-primary" value="Submit" />
            </form>
        </div>
    );
}
export { PayBills };