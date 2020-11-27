import React, { useState } from 'react';
import axios from 'axios';
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";
import "./css/Login.css"


function Login(props) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
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
            setResponse("Login Successfully");
            history.push("/landing-page");
        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });


    }


    return (

        <section className="login-page">
            <h1 className="login-header">Log In</h1>

            <p className="login-error alert alert-light">{waiting ? "Logging In..." : `${response}`}</p>

            <form className="login-form" onSubmit={handleSubmit}>
                <section className="input-group-prepend login-prepend">
                    <label className="input-group-text login-placeholder" htmlFor="email" >Email: </label>
                    <input className="form-control" id="email" type="text" onChange={handleFieldChange} placeholder="Email Address"/>
                </section>

                <section className="input-group-prepend login-prepend">
                    <label className="input-group-text login-placeholder" htmlFor="password">Password: </label>
                    <input className="form-control" id="password" type="text" onChange={handleFieldChange} placeholder="Password" />
                </section>
                <section className="login-submit">
                    <input type="submit" className="btn btn-primary" value="Login" />
                </section>
                <section className="login-submit">
                    <button className="btn btn-info">
                        <Link to="/create-client">Become A Client!</Link>
                    </button>
                </section>
            </form>

        </section>


    );
}
export { Login };
