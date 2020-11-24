import React, { useState } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import { useHistory } from "react-router-dom";


function AddAccount(props) {

    const [accountType, setAccountType] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
    const history = useHistory();


    function handleFieldChange(event) {
        switch (event.target.id) {
           
            case "accountType":
                setAccountType(event.target.value);
                break;
        }
    }
    
    function handleSubmit(event) {
        event.preventDefault();
        setWaiting(true);

        axios(
            {
                method: 'post',
                url: 'BankAPI/AddAccount',
                params: {
                    accountType: accountType
                }
            }
        ).then((res) => {
            setWaiting(false);
            setResponse("New Account Added Successfully");
            history.push("/create-notification");

        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
           
        });
    }


    return (

        <div>
            <Layout />
            <h1>Select Your Account</h1>

            <p>{waiting ? "Submiting..." : `${response}`}</p>
            <form onSubmit={handleSubmit}>

                <label htmlFor="accountType">Account Type</label>
                <select id="accountType" onChange={handleFieldChange}>
                    <option value="" >Choose here</option>
                    <option value="Chequing">Chequing Account</option>
                    <option value="Savings">Saving Account</option>
                </select>
               
                <input type="submit" className="btn btn-primary" value="Submit" />
            </form>
        </div>


    );
}
export { AddAccount };