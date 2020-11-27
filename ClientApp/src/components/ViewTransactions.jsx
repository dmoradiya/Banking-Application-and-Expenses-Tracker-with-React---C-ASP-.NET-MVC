import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import "./css/root.css"
import "./css/ViewTransactions.css"


function ViewTransactions(props) {

    const [transactions, setTransactions] = useState([]);
    const [loading, setLoading] = useState(true);

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
                        {transactions.map(transaction =>
                            <tr key={transaction.transactionID}>
                                <td>{transaction.transactionDate.slice(0, 10)}</td>
                                <td className="d-none d-sm-block">{transaction.transactionSource}</td>
                                <td>{transaction.transactionCategory}</td>
                                {transaction.transactionCategory === "Deposit" ? <td>${transaction.transactionValue}</td> : <td>{`($${transaction.transactionValue})`}</td>}                                
                            </tr>
                        )}
                    </tbody>

                </table>
            </section>       
        );
    }
    // Receiving parameter from Landing page Link
    const { id } = props.location.state;
    async function populateTransactionsData() {
        const response = await axios.get(`BankAPI/ViewTransactions?id=${id}`);

        setTransactions(response.data);
        setLoading(false);
    }

    useEffect(() => {
        populateTransactionsData();
    }, [loading]);

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
