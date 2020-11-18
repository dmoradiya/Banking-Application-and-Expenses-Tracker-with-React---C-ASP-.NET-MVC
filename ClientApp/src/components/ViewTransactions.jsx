import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';


function ViewTransactions(props) {
    

    return (
        <div>
            <Layout />
            <h1 id="tabelLabel" >View Transactions</h1>
        </div>
    );
}

export { ViewTransactions };
