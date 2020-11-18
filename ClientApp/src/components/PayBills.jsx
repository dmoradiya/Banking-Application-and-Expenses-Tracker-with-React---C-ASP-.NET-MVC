import React, { useState } from 'react';
import axios from 'axios';
import { useHistory } from "react-router-dom";

function PayBills(props) {
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
                url: 'BankAPI/PayBills',
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
            history.push("/pay-bills");

        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });
        event.target.reset();
    }

    return (
        <div>
            <h1> Pay a Bill </h1>
            <p>{isSubmit ? <p>{waiting ? "Waiting..." : `${response}`}</p> : ""}</p>

            <br />
            <form onSubmit={handleSubmit}>
                <label htmlFor="transactionSource">Pay To</label>
                <br />
                <input id="transactionSource" type="text" onChange={handleFieldChange} />
                <br />
                <label htmlFor="transactionCategory">Categorize this Payment</label>
                <br />
                <input id="transactionCategory" type="text" onChange={handleFieldChange} />
                <br />
                <label htmlFor="transactionValue">Value of this Payment</label>
                <br />
                <input id="transactionValue" type="text" onChange={handleFieldChange} />
                <br />
                <input type="submit" className="btn btn-primary" value="Submit" />
            </form>
        </div>


    );

}
export { PayBills };