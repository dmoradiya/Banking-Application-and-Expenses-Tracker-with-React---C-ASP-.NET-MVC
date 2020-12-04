import React, { useState } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import { useHistory } from "react-router-dom";
import "./css/CreateAccount.css"


function AddAccount(props) {

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

        axios( /*Sends a POST request to the API using all parameters defined below. Needed as inputs for creating a new Account.*/
            {
                method: 'post',
                url: 'BankAPI/AddAccount',
                params: {
                    accountType: accountType
                }
            }
        ).then((res) => { /*If POST is successful, give success message and push to Create-Notification page*/
            setWaiting(false);
            setResponse("New Account Added Successfully");
            history.push("/create-notification");

        }
        ).catch((err) => { /*Else, give an error message*/
            setWaiting(false);
            setResponse(err.response.data);
           
        });
    }

    const errorMsg = () => { /* If there is an error then returns className='alert alert-danger'*/

        return `${!waiting && (response.length > 0) ? 'alert alert-danger' : ''}`;
    };



    return (

        <section>
            <Layout />
            <h1 className="account-header">Select An Account</h1>
            <p id="error-msg" className={errorMsg()}>{waiting ? "Submiting..." : `${response}`}</p>
            <form className="account-form" onSubmit={handleSubmit}>
                <div className="input-group-prepend account-prepend">
                    <label className="input-group-text account-placeholder" htmlFor="accountType">Account Type</label>
                    <select className="form-control" id="accountType" onChange={handleFieldChange}>
                        <option value="" >Select Account</option>
                        <option value="Chequing">Chequing Account</option>
                        <option value="Savings">Saving Account</option>
                    </select>
                </div>
                <div className="account-submit">
                    <input className="btn btn-info" type="submit" value="Submit" />
                </div>
            </form>
            <section className="steppers stepper stepper-horizontal">
                <div>
                    <span className="circle bg-success">1</span>
                    <span className="label d-none d-sm-block">Client Info</span>
                </div>
                <div className="horizontal-line-one">
                    <hr />
                </div>
                <div>
                    <span className="circle bg-success">2</span>
                    <span className="label d-none d-sm-block">Account</span>
                </div>
                <div className="horizontal-line">
                    <hr />
                </div>
                <div>
                    <span className="circle">3</span>
                    <span className="label d-none d-sm-block">Success!</span>
                </div>
            </section>
        </section>


    );
}
export { AddAccount };