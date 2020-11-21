import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Layout } from './Layout';
import { Link } from "react-router-dom";


function CreateNotification(props) {
    

    return (
        <div>
            <h1> Account Created </h1>
            <p>Thank You for your wait</p>
            <p> Your Account has been Successfully Created.</p>
            <button className="btn btn-info">
                <Link to="/">
                    Login to Continue...
                </Link>
            </button> 
        </div>


    );

}
export { CreateNotification };