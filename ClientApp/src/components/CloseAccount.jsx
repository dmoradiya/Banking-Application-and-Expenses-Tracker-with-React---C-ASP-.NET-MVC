import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';
import { useHistory } from "react-router-dom";
import "./css/CloseAccount.css"


function CloseAccount(props) {
    const [accountID, setAccountID] = useState("");    
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);

    // Populate DropDown Select Option with Account(S)
    const [accountInfo, setAccountInfo] = useState([]);
    const [loading, setLoading] = useState(true);
    const history = useHistory();

   
    async function populateClientData() { /*Populates response with API/LandingPage*/
        const response = await axios.get('BankAPI/LandingPage');
        setAccountInfo(response.data);
        setLoading(false);
    }

    useEffect(() => { /*For rendering populateClientData*/
        populateClientData();
    }, [loading]);



    function handleFieldChange(event) { /*Define updates to constant variables based on what is located in form fields.*/
        switch (event.target.id) {
            default:
                setAccountID(event.target.value);
                break;          
        }
    }

    function handleSubmit(event) {
        event.preventDefault();
        setWaiting(true);
              
        // Patch Request
        axios( /*UPDATES the Account with isActive = 0, disabling the account*/
            {
                method: 'patch',
                url: 'BankAPI/CloseAccount',
                params: {
                    accountID: accountID,
                }
            }
        ).then((res) => { /*If UPDATE is successful, send a success message, and push to archive-notification page*/
            setWaiting(false);
            setResponse("Account Archived Successfully");
            history.push("/archive-notification");


        }
        ).catch((err) => { /*Else send an error*/
            setWaiting(false);
            setResponse(err.response.data);
        });
       
    }

    const errorMsg = () => { /* If there is an error then returns className='alert alert-danger'*/

        return `${!waiting && (response.length > 0) ? 'alert alert-danger' : ''}`;
    };

    return (
        <section className="close-account-page">
            <Layout />
            <h1 className="close-account-header"> Close Account </h1>
            <p id="error-msg" className={errorMsg()}>{waiting ? "Waiting..." : `${response}`}</p>
            <form className="close-account-form" onSubmit={handleSubmit}>
                <section className="input-group-prepend close-account-prepend">

                <label className="input-group-text close-account-placeholder" htmlFor="accountID">Account</label>
                <select className="form-control" id="accountID" onChange={handleFieldChange}>
                    <option value="" >Select Account</option>
                    {accountInfo.map(client => ( /*Maps options based on AccountID to display All Active Accounts on this ClientID*/
                        <option key={client.accountID} value={`${client.accountID}`}>
                            {`${client.accountType}- Total Balance: $${(client.accountBalance).toFixed(2)}`}
                        </option>
                    ))}
                    </select>               
                </section>
                <section className="close-account-submit">
                <input type="submit" className="btn btn-info" value="Close Account" />
                </section>
            </form>
        </section>


    );

}
export { CloseAccount };