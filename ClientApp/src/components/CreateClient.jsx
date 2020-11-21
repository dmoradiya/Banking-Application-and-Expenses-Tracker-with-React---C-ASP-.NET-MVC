import React, { useState } from 'react';
import axios from 'axios';
import { useHistory } from "react-router-dom";

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
        }
    }

    function handleSubmit(event) {
        event.preventDefault();
        setWaiting(true);
        setIsSubmit(true);

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
            setResponse(res.data);
            history.push("/create-account");
            
        }
        ).catch((err) => {
            setWaiting(false);
            setResponse(err.response.data);
        });
        event.target.reset();
    }


    return (

        <div>
            <h1>Client Information</h1>

            <p>{isSubmit ? <p>{waiting ? "Processing..." : `${JSON.stringify(response)}`}</p> : ""}</p>

            <form onSubmit={handleSubmit}>
                
                <label htmlFor="email">Email</label>
                <input id="email" type="text" onChange={handleFieldChange} />
                <label htmlFor="password">Password</label>
                <input id="password" type="text" onChange={handleFieldChange} />
                <label htmlFor="phone">Phone Number</label>
                <input id="phone" type="text" onChange={handleFieldChange} />
                <label htmlFor="fname">First Name</label>
                <input id="fname" type="text" onChange={handleFieldChange} />
                <label htmlFor="lname">Last Name</label>
                <input id="lname" type="text" onChange={handleFieldChange} />
                <label htmlFor="dateOfBirth">Date Of Birth</label>
                <input id="dateOfBirth" type="date" onChange={handleFieldChange} />
                <label htmlFor="address">Address</label>
                <input id="address" type="text" onChange={handleFieldChange} />
                <label htmlFor="city">City</label>
                <input id="city" type="text" onChange={handleFieldChange} />
                <label htmlFor="province">Province</label>
                <select id="province" onChange={handleFieldChange}>
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
                <label htmlFor="postalCode">Postal Code</label>
                <input id="postalCode" type="text" onChange={handleFieldChange} />

                <input type="submit" className="btn btn-primary" value="Next" />
            </form>
        </div>


    );
}
export { CreateClient };
