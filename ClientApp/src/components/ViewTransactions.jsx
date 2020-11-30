import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import "./css/root.css"
import "./css/ViewTransactions.css"
import { Link } from "react-router-dom";


function ViewTransactions(props) {

    const [transactions, setTransactions] = useState([]);
    const [loading, setLoading] = useState(true);
    const [lastMonth, setLastMonth] = useState("");
    const [checked, setChecked] = useState("");

    function renderClientInfoTable(transactions) {

        return (
            <section id="view-transactions-section">
                
                <table className='table' aria-labelledby="tabelLabel">
                    <thead>
                        <tr className="col-sm-4">
                            <th>Date</th>
                            <th className="d-none d-sm-block">Source</th>
                            <th>Category</th>
                            <th>Amount</th>
                        </tr>
                    </thead>
                    <tbody>
                        {transactions.filter((val) => {
                            if (lastMonth === "lastMonth" && checked === true) {
                                return val = val.transactionDate > "2020-11-29";
                            }
                            else {
                                return val;
                            }
                        }
                        ).map(transaction =>
                            <tr key={transaction.transactionID}>
                                <td>{transaction.transactionDate.slice(0, 10)}</td>
                                <td className="d-none d-sm-block">{transaction.transactionSource}</td>
                                <td>{transaction.transactionCategory}</td>
                                {transaction.transactionCategory === "Deposit" ? <td>${transaction.transactionValue}</td> : <td>{`($${transaction.transactionValue})`}</td>}                                
                            </tr>
                        )}
                    </tbody>
                </table>
                <p className="text-center">
                    <button className="btn btn-info">
                        {/* Sending transactions array to view Expenses Page*/}
                        <Link className="text-white" to={{
                            pathname: "/view-expenses",
                            state: { allTransaction : transactions }
                        }}>
                            View Expenses
                        </Link>
                    </button>
                </p>
            </section>       
        );
    }

    function handleFieldChange(event) {
            switch (event.target.id) {
                case "lastMonth":
                    setLastMonth(event.target.value);
                    break;
                    
            }
        setChecked(event.target.checked);
    }
    console.log(checked);
    console.log(lastMonth);
   
    const today = new Date().toLocaleDateString().substr(0, 10);
   
    // Receiving parameter from Landing page Link
    const { id } = props.location.state;
    async function populateTransactionsData() {
        const response = await axios.get(`BankAPI/ViewTransactions?id=${id}`);
        
        setTransactions(response.data);
        setLoading(false);
    }

    useEffect(() => {
        populateTransactionsData();
    },[loading]);

    let contents = loading
        ? <p><em>Loading...</em></p>
        : renderClientInfoTable(transactions);

    return (
        <section id="view-transactions">
            <Layout />   
            <h1>View Transactions</h1>
            <div>
                <label htmlFor="lastMonth">Last month</label>
                <input
                     id="lastMonth" type="checkbox" value="lastMonth" onChange={handleFieldChange} />
            </div>
            {contents}
        </section>
    );
}

export { ViewTransactions };
