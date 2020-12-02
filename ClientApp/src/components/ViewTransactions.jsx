import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import "./css/root.css"
import "./css/ViewTransactions.css"
import { Link } from "react-router-dom";


function ViewTransactions(props) {

    const [transactions, setTransactions] = useState([]);
    const [loading, setLoading] = useState(true);
    const [thisMonthchecked, setThisMonthChecked] = useState("");
    const [threeMonthchecked, setThreeMonthChecked] = useState("");
    const [sixMonthchecked, setSixMonthChecked] = useState("");

    let filteredTransactions = [];

    function renderClientInfoTable(transactions) {


        return (
            <section id="view-transactions-section">
                <section id="checkbox-section">
                    <div className="checkbox-label-container">
                        <label htmlFor="thisMonth">This Month</label>
                        <input id="thisMonth" type="checkbox" className="checkboxes" onChange={handleFieldChange} />
                    </div>                        
                    <div className="checkbox-label-container">
                        <label htmlFor="threeMonth">Last Three Months</label>
                        <input id="threeMonth" type="checkbox" className="checkboxes" onChange={handleFieldChange} />
                    </div>
                    <div className="checkbox-label-container">
                        <label htmlFor="sixMonth">Last Six Months</label>
                        <input id="sixMonth" type="checkbox" className="checkboxes" onChange={handleFieldChange} />
                    </div>
                </section>
                <table className='table' aria-labelledby="tabelLabel">
                    <thead>
                        <tr className="col-sm-4">
                            <th>Date</th>
                            <th className="d-none d-sm-block">Source</th> {/*Will display on all but mobile phone layouts (not enough space)*/ }
                            <th>Category</th>
                            <th>Amount</th>
                        </tr>
                    </thead>
                    <tbody>
                        {filteredTransactions.map(transaction =>
                            <tr key={transaction.transactionID}>
                                <td>{transaction.transactionDate.slice(0, 10)}</td>
                                <td className="d-none d-sm-block">{transaction.transactionSource}</td>
                                <td>{transaction.transactionCategory}</td>
                                {transaction.transactionCategory === "Deposit" ? <td>${transaction.transactionValue}</td> : <td>{`($${transaction.transactionValue})`}</td>} {/*Displays transactions which reduce Account Balance in Brackets!*/ }                                
                            </tr>
                        )}
                    </tbody>
                </table>
                <p className="text-center">
                    <button className="btn btn-info">
                        {/* Sending transactions array to view Expenses Page*/}
                        <Link className="text-white" to={{
                            pathname: "/view-expenses",
                            state: { allTransaction : filteredTransactions }
                        }}>
                            View Expenses
                        </Link>
                    </button>
                </p>
            </section>       
        );
    }

    function handleFieldChange(event) { /*Updates the constant values with whatever is located in the input fields*/
            switch (event.target.id) {
                case "thisMonth":
                    setThisMonthChecked(event.target.checked);
                    break;
                case "threeMonth":
                    setThreeMonthChecked(event.target.checked);
                    
                    break;
                case "sixMonth":
                    setSixMonthChecked(event.target.checked);
                    break;               
        }
        // Disable other checkbox when you Click on one
        const allCheckbox = document.getElementsByClassName("checkboxes");
        if (event.target.checked) {
            for (const checkbox of allCheckbox) {
                if (!(checkbox === event.target)) {
                    checkbox.disabled = true;
                }
            }
        } else {
            for (const checkbox of allCheckbox) {
                checkbox.disabled = false;
            }
        }
        
    }
   
  
   // New filtered output Array
    const newArray = (transactions) => {
        let currentDate = new Date();
        let currentMonth = currentDate.getMonth();
        return [...transactions].filter(val => {
            if (thisMonthchecked) { /*Index 5 + 2 characters = month*/
                return val = val.transactionDate.substr(5, 2) > currentMonth;
            }
            else if (threeMonthchecked) {
                return val = val.transactionDate.substr(5, 2) > (currentMonth - 3);     // TODO -> Causes errors for January, Feb, Early Months etc.
            }
            else if (sixMonthchecked) {
                return val = val.transactionDate.substr(5, 2) > (currentMonth - 6);
            }           
            else {
                return val;
            }
        }, []);
    }
    filteredTransactions = newArray(transactions);
   
    // Receiving parameter from Landing page Link
    const { id } = props.location.state;
    async function populateTransactionsData() {
        const response = await axios.get(`BankAPI/ViewTransactions?id=${id}`);
        
        setTransactions(response.data);
        setLoading(false);
    }

    useEffect(() => { /*Prevent useEffect From Running Every Render*/
        populateTransactionsData();
    },[loading]);

    let contents = loading
        ? <p><em>Loading...</em></p>
        : renderClientInfoTable(transactions);

    return (
        <section id="view-transactions">
            <Layout />   
            <h1>View Transactions</h1>
            
            {contents}
        </section>
    );
}

export { ViewTransactions };
