import React, { useState } from 'react';
import axios from 'axios';
import { useHistory } from "react-router-dom";
import "./css/CreateClient.css"



function CreateClient(props) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [phone, setPhone] = useState("");
    const [fname, setFName] = useState("");
    const [lname, setLName] = useState("");
    const [dateOfBirth, setDateOfBirth] = useState("");
    const [address, setAddress] = useState("");
    const [city, setCity] = useState("");
    const [province, setProvince] = useState("");
    const [postalCode, setPostalCode] = useState("");
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
            case "phone":
                setPhone(event.target.value);
                break;
            case "fname":
                setFName(event.target.value);
                break;
            case "lname":
                setLName(event.target.value);
                break;
            case "dateOfBirth":
                setDateOfBirth(event.target.value);
                break;
            case "address":
                setAddress(event.target.value);
                break;
            case "city":
                setCity(event.target.value);
                break;
            case "province":
                setProvince(event.target.value);
                break;
            case "postalCode":
                setPostalCode(event.target.value);
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
                url: 'BankAPI/CreateClient',
                params: {
                    email: email,
                    password: password,
                    phone: phone,
                    fname: fname,
                    lname: lname,
                    dateOfBirth: dateOfBirth,
                    address: address,
                    city: city,
                    province: province,
                    postalCode: postalCode

                }
            }
        ).then((res) => {
            setWaiting(false);
            setResponse("Client Info Added Successfully");
            history.push("/create-account");

        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });
    }


    return (
        <section className="create-client">

            <h1 className="client-header">Client Information</h1>

            <p className="client-error alert alert-light">{waiting ? "Processing..." : `${response}`}</p>

            <form className="deposit-form" onSubmit={handleSubmit}>

                <div className="input-group-prepend create-client-fields">
                    <label className="input-group-text create-client-placeholder-text" htmlFor="email">Email Address</label>
                    <input className="form-control create-client-form-field" id="email" type="text" placeholder="youremail@email.com" onChange={handleFieldChange} />
                </div>
                <div className="input-group-prepend create-client-fields">
                    <label className="input-group-text create-client-placeholder-text" htmlFor="password">Password</label>
                    <input className="form-control create-client-form-field" id="password" type="text" placeholder="Please enter your Password" onChange={handleFieldChange} />
                </div>
                <div className="input-group-prepend create-client-fields">
                    <label className="input-group-text create-client-placeholder-text" htmlFor="phone">Phone Number</label>
                    <input className="form-control create-client-form-field" id="phone" type="text" placeholder="(XXX) XXX-XXXX" onChange={handleFieldChange} />
                </div>
                <div className="input-group-prepend create-client-fields">
                    <label className="input-group-text create-client-placeholder-text" htmlFor="fname">First Name</label>
                    <input className="form-control create-client-form-field" id="fname" type="text" placeholder="" onChange={handleFieldChange} />
                </div>
                <div className="input-group-prepend create-client-fields">
                    <label className="input-group-text create-client-placeholder-text" htmlFor="lname">Last Name</label>
                    <input className="form-control create-client-form-field" id="lname" type="text" placeholder="" onChange={handleFieldChange} />
                </div>
                <div className="input-group-prepend create-client-fields">
                    <label className="input-group-text create-client-placeholder-text" htmlFor="dateOfBirth">Date Of Birth</label>
                    <input className="form-control create-client-form-field" id="dateOfBirth" type="date" onChange={handleFieldChange} />
                </div>
                <div className="input-group-prepend create-client-fields">
                    <label className="input-group-text create-client-placeholder-text" htmlFor="address">Address</label>
                    <input className="form-control create-client-form-field" id="address" type="text" onChange={handleFieldChange} />
                </div>
                <div className="input-group-prepend create-client-fields">
                    <label className="input-group-text create-client-placeholder-text" htmlFor="city">City</label>
                    <input className="form-control create-client-form-field" id="city" type="text" onChange={handleFieldChange} />
                </div>
                <div className="input-group-prepend create-client-fields">
                    <label className="input-group-text create-client-placeholder-text" htmlFor="province">Province</label>
                    <select className="create-client-form-field form-control" id="province" onChange={handleFieldChange}>
                        <option value="" >Choose here</option>
                        <option value="AB">Alberta</option>
                        <option value="BC">British Columbia</option>
                        <option value="MB">Manitoba</option>
                        <option value="NB">New Brunswick</option>
                        <option value="NF">Newfoundland</option>
                        <option value="NT">Northwest Territories</option>
                        <option value="NS">Nova Scotia</option>
                        <option value="NU">Nunavut</option>
                        <option value="ON">Ontario</option>
                        <option value="PE">Prince Edward Island</option>
                        <option value="QC">Quebec</option>
                        <option value="SK">Saskatchewan</option>
                        <option value="YT">Yukon Territory</option>
                    </select>
                </div>
                <div className="input-group-prepend create-client-fields">
                    <label className="input-group-text create-client-placeholder-text" htmlFor="postalCode">Postal Code</label>
                    <input className="form-control create-client-form-field" id="postalCode" type="text" onChange={handleFieldChange} />
                </div>
                <div className="input-group-prepend create-client-fields">

                    <input type="submit" className="btn btn-primary submit-button" value="Submit!" />
                </div>








            </form>
        </section>

    );
}
export { CreateClient };
