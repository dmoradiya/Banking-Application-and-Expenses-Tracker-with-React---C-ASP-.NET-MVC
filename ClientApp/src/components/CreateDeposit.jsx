import React, { useState } from 'react';
import axios from 'axios';
import { useHistory } from "react-router-dom";

function CreateDeposit(props) {
    const [transactionSource, setTransactionSource] = useState("");
    const [transactionCategory, setTransactionCategory] = useState("");
    const [transactionValue, setTransactionValue] = useState("");
    const [transactionDate, setTransactionDate] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
    const [isSubmit, setIsSubmit] = useState(false);
    const history = useHistory();


    function handleFieldChange(event) {
        switch (event.target.id) {
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
        setIsSubmit(true);

        axios(
            {
                method: 'post',
                url: 'BankAPI/CreateDeposit',
                params: {
                    accountID: 1,
                    transactionSource: transactionSource,
                    transactionCategory: transactionCategory,
                    transactionValue: transactionValue,
                    transactionDate: transactionDate
                }
            }
        ).then((res) => {
            setWaiting(false);
            setResponse(res.data);
            history.push("/create-deposit");

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