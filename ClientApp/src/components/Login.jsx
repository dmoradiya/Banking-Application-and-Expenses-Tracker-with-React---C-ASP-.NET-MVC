import React, { useState } from 'react';
import axios from 'axios';
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";
import { FaEye } from "react-icons/fa";
import "./css/Login.css";


function Login(props) { 
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [response, setResponse] = useState([]);
    const [waiting, setWaiting] = useState(false);
    const[passwordShow, setPasswordShow] = useState(false); /*default is false. Change to true to display text instead of password mask - see line 58*/
    const history = useHistory();

    function handleFieldChange(event) { /*Updates fields with target values*/
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

    function handleSubmit(event) { /*Creates a POST request to the API using email and password as parameters*/
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
        ).then((res) => {   /*If No errors, give success message AND then push to landing page*/
            setWaiting(false);
            setResponse("Login Successfully");
            history.push("/landing-page");
        }
        ).catch((err) => { /*Else, give error message*/
            setWaiting(false);
            setResponse(err.response.data);
        });


    }

    function togglePassword(event) {    /*Allows user to hide or display password field with a mask -> Defaults to False therefore does not show text*/
        event.preventDefault();
        setPasswordShow(passwordShow ? false : true); /*Reverse the 'false' and 'true' statements to show text by default, see line 14*/
    };

    return (
        <section className="login-page">
            <p><img id="banner-small" className="d-block d-sm-none" src={require("./img/banner320px.png") } alt="vv bank text for small size" /></p>
            <p><img id="banner-medium" className="d-none d-sm-block d-md-none" src={require("./img/banner576px.png") } alt="vv bank text for medium size" /></p>
            <p><img id="banner-large" className="d-none d-md-block d-lg-none" src={require("./img/banner768px.png") } alt="vv bank text for large size" /></p>
            <p><img id="banner-exlarge" className="d-none d-lg-block d-xl-block" src={require("./img/banner992px.png") } alt="vv bank text for extra large size" /></p>
            <p>{waiting ? "Logging In..." : `${response}`}</p>
            <form className="login-form" onSubmit={handleSubmit}>
                <section className="input-group-prepend login-prepend">
                    <label className="input-group-text login-placeholder" htmlFor="email" >Email: </label>
                    <input className="form-control" id="email" type="text" onChange={handleFieldChange} placeholder="Email Address"/>
                </section>
                <section className="input-group-prepend login-prepend">
                    <label className="input-group-text login-placeholder" htmlFor="password">Password: </label>
                    <input className="form-control" id="password" type={passwordShow ? "text" : "password"} onChange={handleFieldChange} placeholder="Password" /> 
                    <span id="eye-icon" onClick={togglePassword}><FaEye /></span>
                </section>
                <section className="login-submit">
                    <input type="submit" className="btn btn-primary" value="Login" />
                </section>
            </form>
            <section className="login-submit">
                <button className="btn btn-info">
                    <Link to="/create-client" className="white-text">Become A Client!</Link>
                </button>
            </section>
        </section>
    );
}
export { Login };
