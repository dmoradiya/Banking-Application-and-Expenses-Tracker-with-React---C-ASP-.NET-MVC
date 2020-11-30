import React, { useState } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import { useHistory } from "react-router-dom";
import "./css/AddAccount.css"


function AddAccount(props) {

    const [accountType, setAccountType] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
    const history = useHistory();


    function handleFieldChange(event) {
        switch (event.target.id) {           
            default:
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

        <section className="add-account-page">
            <Layout />
            <h1 className="add-account-header">Add Account</h1>

            <p className="add-account-error alert alert-light">{waiting ? "Submiting..." : `${response}`}</p>
            <form className="add-account-form" onSubmit={handleSubmit}>
                <section className="input-group-prepend add-account-prepend">
                    <label className="input-group-text add-account-placeholder" htmlFor="accountType">Type</label>
                    <select className="form-control" id="accountType" onChange={handleFieldChange}>
                        <option value="" >Select Account</option>
                        <option value="Chequing">Chequing Account</option>
                        <option value="Savings">Savings Account</option>
                    </select>
                </section>
                <section className="add-account-submit">
                    <input type="submit" className="btn btn-primary" value="Submit" />
                </section>
            </form>
        </section>


    );
}
export { AddAccount };