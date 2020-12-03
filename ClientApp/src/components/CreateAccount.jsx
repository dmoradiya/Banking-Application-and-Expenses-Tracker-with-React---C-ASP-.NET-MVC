import React, { useState } from 'react';
import axios from 'axios';
import { useHistory } from "react-router-dom";
import "./css/CreateClient.css"


function CreateAccount(props) {
   
    const [accountType, setAccountType] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
    const history = useHistory();

    function handleFieldChange(event) { /*Define updates to constant variables based on what is located in form fields.*/
        switch (event.target.id) {
            default:
                setAccountType(event.target.value);
                break;
        }
    }

    function handleSubmit(event) {
        event.preventDefault();
        setWaiting(true);

        axios( /*Sends a POST request to the API that inputs the accountType as a parameter*/
            {
                method: 'post',
                url: 'BankAPI/CreateAccount',
                params: {

                    accountType: accountType
                }
            }
        ).then((res) => { /*If post is successful, send a success message and push to create-notification page*/
            setWaiting(false);
            setResponse("Account Created Successfully");
            history.push("/create-notification");

        }
        ).catch((err) => { /*Else, send an error message*/
            setWaiting(false);
            setResponse(err.response.data);
        });
    }
    const errorMsg = () => { /* If there is an error then returns className='alert alert-danger'*/

        return `${!waiting && (response.length > 0) ? 'alert alert-danger' : ''}`;
    };

    return (
        <section className="create-client">
            <h1 className="account-header">Select An Account</h1>
            <form className="account-form create-account-section" onSubmit={handleSubmit}>
                <p id="error-msg" className={errorMsg()}>{waiting ? "Submiting..." : `${response}`}</p>
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
