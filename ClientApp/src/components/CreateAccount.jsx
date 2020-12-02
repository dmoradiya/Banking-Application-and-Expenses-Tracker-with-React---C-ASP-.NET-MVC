import React, { useState } from 'react';
import axios from 'axios';
import { useHistory } from "react-router-dom";
import "./css/CreateClient.css"


function CreateAccount(props) {
   
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
                url: 'BankAPI/CreateAccount',
                params: {

                    accountType: accountType
                }
            }
        ).then((res) => {
            setWaiting(false);
            setResponse("Account Created Successfully");
            history.push("/create-notification");

        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });
    }


    return (

        <section className="create-client">
            <h1 className="account-header">Select An Account</h1>
            <p>{waiting ? "Submiting..." : `${response}`}</p>
            <form className="account-form create-account-section" onSubmit={handleSubmit}>
                <div className="input-group-prepend">
                    <label className="input-group-text create-account-placeholder-text" htmlFor="accountType">Account Type</label>
                    <select className="form-control" id="accountType" onChange={handleFieldChange}>
                        <option value="" >Select Account</option>
                        <option value="Chequing">Chequing Account</option>
                        <option value="Savings">Saving Account</option>
                    </select>
                </div>
                <div className="input-group-prepend">
                    <input className="btn btn btn-info submit-button" type="submit" value="Submit" />
                </div>
            </form>
        </section>


    );
}
export { CreateAccount };
