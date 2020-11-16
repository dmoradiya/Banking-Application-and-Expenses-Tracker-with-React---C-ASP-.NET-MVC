import React, { useState } from 'react';
import axios from 'axios';
import { useHistory } from "react-router-dom";


function Login(props) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
    const [isSubmit, setIsSubmit] = useState(false);
    const history = useHistory();

    function handleFieldChange(event) {
        switch (event.target.id) {
            case "email":
                setEmail(event.target.value);
                break;
            case "password":
                setPassword(event.target.value);
                break;
        }
    }

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
            <h1>Log In</h1>

            <p>{isSubmit ? <p>{waiting ? "Loging In..." : `${response}`}</p> : ""}</p>

            <form onSubmit={handleSubmit}>
                <label htmlFor="email">Email : </label>
                <input id="email" type="text" onChange={handleFieldChange} />
                <label htmlFor="password">Password</label>
                <input id="password" type="text" onChange={handleFieldChange} />
                <input type="submit" className="btn btn-primary" value="Login" />
            </form>
        </div>


    );
}
export { Login };
