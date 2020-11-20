import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from '../components/Layout';


function ArchiveNotification(props) {
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
    const [isSubmit, setIsSubmit] = useState(false);





    function handleSubmit(event) {
        event.preventDefault();
        setWaiting(true);
        setIsSubmit(true);

        axios(
            {
                method: 'post',
                url: 'BankAPI/Login',
                params: {
                    email: email,
                    password: password,
                }
            }
        ).then((res) => {
            setWaiting(false);
            setResponse(res.data);
            history.push("/landing-page");
        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });


    }

    return (
        <div>
            <Layout />
            <h1> Account Archived </h1>
            <p> Your Account has been Archived. Your data is safe, and has not been deleted.</p>
            <p>{isSubmit ? <p>{waiting ? "Waiting..." : `${response}`}</p> : ""}</p>
            <br />
            <form onSubmit={handleSubmit}>
                <input type="submit" className="btn btn-primary" value="Log Out to Finalize Changes" />
            </form>
        </div>


    );

}
export { ArchiveNotification };