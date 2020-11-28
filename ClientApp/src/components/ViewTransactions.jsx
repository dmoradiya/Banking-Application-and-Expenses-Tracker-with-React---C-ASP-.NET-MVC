import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import "./css/root.css"
import "./css/ViewTransactions.css"
import { PieChart } from 'react-minimal-pie-chart';


function ViewTransactions(props) {

    const [transactions, setTransactions] = useState([]);
    const [loading, setLoading] = useState(true);

    function renderClientInfoTable(transactions) {

        let data = [];
        let newData = [];
       
       
        // Link: https://medium.com/@tgknapp11/render-a-chart-with-react-minimal-pie-chart-e30420c9276c
        transactions.map((transaction) => {
            var randomColor = "#000000".replace(/0/g, function () {
                return (~~(Math.random() * 16)).toString(16);
            });
            if (transaction.transactionSource === 'Bill Payment') {

                let insert = {
                    color: randomColor,
                    title: transaction.transactionCategory,
                    value: transaction.transactionValue,
                };
                data.push(insert);
            }
            const newArray = (data) => {
                return [...data].reduce((acc, val, i, arr) => {
                    const { color, title, value } = val;
                    const ind = acc.findIndex(el => el.title === title);
                    if (ind !== -1) {
                        acc[ind].value += value;
                    } else {
                        acc.push({
                            color : color,
                            title : title,
                            value : value,
                        });
                    }
                    return acc;
                }, []);
            }
            newData = newArray(data);
        });
        
        
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
                <p class="p-3 mb-2 bg-info text-white text-center">Pie Chart for Tracking Expenses</p>
                <section id="pie-chart">
                    <PieChart

                        data={newData}
                        animate
                        animationDuration={500}
                        animationEasing="ease-out"
                        startAngle={0}
                        labelPosition={65}
                        labelStyle={{
                            fontSize: "6px",
                            fontWeight: "400",
                        }}
                        label={({ dataEntry }) => `${dataEntry.title}  ${Math.round(dataEntry.percentage)} %`}
                    />;
                </section>             
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
