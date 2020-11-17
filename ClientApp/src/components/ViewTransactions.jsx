import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';


function ViewTransaction(props) {
    

    return (
        <div>
            <Layout />
            <h1 id="tabelLabel" >View Transaction</h1>
        </div>
    );
}

export { ViewTransaction };
