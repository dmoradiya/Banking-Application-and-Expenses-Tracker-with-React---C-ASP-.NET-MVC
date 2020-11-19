import React, { useState, useEffect } from 'react';
import axios from 'axios';

function CreateDeposit(props) {
    const [transactionSource, setTransactionSource] = useState("");
    const [transactionCategory, setTransactionCategory] = useState("");
    const [transactionValue, setTransactionValue] = useState("");
    const transactionDate = new Date().getDate();

    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
    const [isSubmit, setIsSubmit] = useState(false);

    const [accountInfo, setAccountInfo] = useState([]);

       
    async function populateClientData() {
        const response = await axios.get('BankAPI/LandingPage');
        setAccountInfo(response.data);
    }

    useEffect(() => {
        populateClientData();
    });

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
            case "transactionAmount":
                setTransactionValue(event.target.value);
                break;
        }
    }

    function handleSubmit(event) {
        event.preventDefault();
        setWaiting(true);
        setIsSubmit(true);

        axios(
            {
                method: 'post',
                url: 'BankAPI/CreateDeposit',
                params: {
                    // TODO: Add reference to parent Account ID
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
        event.target.reset();
    }

    return (
        <div>
            <h1> Make a Deposit </h1>
            <p>{isSubmit ? <p>{waiting ? "Waiting..." : `${response}`}</p> : ""}</p>

            <br/>
            <form onSubmit={handleSubmit}>

                <label htmlFor="accountID">Account Type</label>
                <select id="accountID" onChange={handleFieldChange}>
                {accountInfo.map(client => (
                    <option key={client.accountID} value={client.accountID}>
                        {client.accountType}
                    </option>
                ))}
                </select>
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
                <input type="submit" className="btn btn-primary" value="Submit" />
            </form>
        </div>

        
        );

}
export { CreateDeposit };