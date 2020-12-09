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
    const [passwordShow, setPasswordShow] = useState(false); /*default is false. Change to true to display text instead of password mask - see line 58*/
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

    const errorMsg = () => { /* If there is an error then returns className='alert alert-danger'*/

        return `${ !waiting && (response.length > 0) ? 'alert alert-danger' : '' }`;
    };

    return (
        <section className="login-page">
            <div className="banner"></div>            
            <p id="error-msg" className={errorMsg()}>{waiting ? "Logging In..." : `${response}`}</p>
            <form className="login-form" onSubmit={handleSubmit}>
                <section className="input-group-prepend login-prepend">
                    <label className="input-group-text login-placeholder" htmlFor="email" >Email: </label>
                    <input className="form-control" id="email" type="text" onChange={handleFieldChange} placeholder="Email Address"/>
                </section>
                <section className="input-group-prepend login-prepend">
                    <label className="input-group-text login-placeholder" htmlFor="password">Password: </label>
                    {/*<input className="form-control" id="password" type="text" onChange={handleFieldChange} /> -- Uncomment this and comment the line below to disable password masking*/} 
                    <input className="form-control" id="password" type={passwordShow ? "text" : "password"} onChange={handleFieldChange} placeholder="Password" /> 
                    <span id="eye-icon" onClick={togglePassword}><FaEye /></span>
                </section>
                <section className="login-submit">
                    <input type="submit" className="btn btn-primary" value="Login" />
                </section>
            </form>
            <section  className="login-submit">
                <button id="become-client" className="btn btn-info">
                    <Link  to="/create-client" className="white-text">Become A Client!</Link>
                </button>
            </section>
        </section>
    );
}
export { Login };
