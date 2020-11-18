import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';


function ViewTransactions(props) {
    const displayName = ViewTransactions.name;

    const [transactions, setTransactions] = useState([]);
    const [loading, setLoading] = useState(true);

    function renderClientInfoTable(transactions) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Source</th>
                        <th>Category</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
                    {transactions.map(transaction =>
                        <tr key={transaction.transactionID}>
                            <td>{transaction.transactionDate}</td>
                            <td>{transaction.transactionSource}</td>
                            <td>{transaction.transactionCategory}</td>
                            <td>{transaction.transactionValue}</td>
                        </tr>
                    )}
                </tbody>

            </table>

        );
    }

    async function populateTransactionsData() {
        const response = await axios.get('BankAPI/ViewTransactions');
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
        <div>
            <Layout />
            <h1 id="tabelLabel" >View Transactions</h1>
            {contents}
        </div>
    );

   
}

export { ViewTransactions };
