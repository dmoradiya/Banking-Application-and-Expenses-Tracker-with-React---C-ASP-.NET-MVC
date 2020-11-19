import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';

function CreateDeposit(props) {
    const [accountID, setAccountID] = useState("");
    const [transactionSource, setTransactionSource] = useState("");
    const [accountID, setAccountID] = useState("");
    const [transactionCategory, setTransactionCategory] = useState("");
    const [transactionValue, setTransactionValue] = useState("");
    const [transactionDate, setTransactionDate] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
    const [isSubmit, setIsSubmit] = useState(false);

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
            case "transactionSource":
                setTransactionSource(event.target.value);
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
        setIsSubmit(true);

        // Post Request
        axios(
            {
                method: 'post',
                url: 'BankAPI/CreateDeposit',
                params: {
                    accountID: accountID,
                    transactionSource: transactionSource,
                    transactionCategory: transactionCategory,
                    transactionValue: transactionValue,
                    transactionDate: transactionDate
                }
            }
        ).then((res) => {
            setWaiting(false);
            setResponse(res.data);
            

        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });

        // Patch Request
        axios(
            {
                method: 'patch',
                url: 'BankAPI/UpdateBalance',
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



        event.target.reset();
    }

    return (
        <div>
            <Layout />
            <h1> Make a Deposit </h1>
            <p>{isSubmit ? <p>{waiting ? "Waiting..." : `${response}`}</p> : ""}</p>
            <p>{isSubmit ? <p>{patchWaiting ? "Waiting..." : `${patchResponse}`}</p> : ""}</p>

            <br/>
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
                <label htmlFor="transactionSource">Source of Deposit</label>
                <br />
                <input id="transactionSource" type="text" onChange={handleFieldChange} />
                <br />
                <label htmlFor="transactionCategory">Categorize this Transaction</label>
                <br />
                <input id="transactionCategory" type="text" onChange={handleFieldChange} />
                <br />
                <label htmlFor="transactionValue">Value of this transaction</label>
                <br />
                <input id="transactionValue" type="text" onChange={handleFieldChange} />
                <br />
                <input id="transactionDate" type="date" onChange={handleFieldChange} />
                <br />
                <input type="submit" className="btn btn-primary" value="Submit" />
            </form>
        </div>

        
        );

}
export { CreateDeposit };