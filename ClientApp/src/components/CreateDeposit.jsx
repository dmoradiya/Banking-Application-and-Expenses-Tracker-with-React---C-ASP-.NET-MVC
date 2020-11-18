import React, { useState } from 'react';
import axios from 'axios';
import { useHistory } from "react-router-dom";

function CreateDeposit(props) {
    const [transactionSource, setTransactionSource] = useState("");
    const [transactionCategory, setTransactionCategory] = useState("");
    const [transactionValue, setTransactionValue] = useState("");
    const transactionDate = new Date().getDate();

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
            <input id="transactionSource" type="text" onChange={handleFieldChange} />
                <br />

            <label htmlFor="transactionCategory">Categorize this Deposit</label>
            <input id="transactionCategory" type="text" onChange={handleFieldChange} />
                <br />

            <label htmlFor="transactionValue">Value of this transaction</label>
            <input id="transactionValue" type="text" onChange={handleFieldChange} />

                <input type="submit" className="btn btn-primary" value="Submit" />
            </form>
        </div>

        
        );

}
export { CreateDeposit };