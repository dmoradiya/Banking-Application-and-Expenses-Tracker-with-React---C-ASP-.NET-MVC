import React, { useState } from 'react';
import axios from 'axios';
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";
import "./css/root.css"


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
            default:
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

        <div>
            <h1>Log In</h1>

            <p>{waiting ? "Logging In..." : `${response}`}</p>

            <form onSubmit={handleSubmit}>
                <div classname="form-group">
                    <label htmlFor="email" >Please enter your Email Address: </label>
                    <br/>
                    <input id="email" type="text" onChange={handleFieldChange} placeholder="Email Address"/>
                </div>

                <div classname="form-group">
                    <label htmlFor="password">Please enter your Password: </label>
                    <br />
                    <input id="password" type="text" onChange={handleFieldChange} placeholder="Password" />
                </div>
                <div classname="form-group">
                    <input type="submit" className="btn btn-primary" value="Login" />
                    <button className="btn btn-info">
                        <Link to="/create-client">Become A Client!</Link>
                    </button>
                </div>
            </form>

        </div>


    );
}
export { Login };
