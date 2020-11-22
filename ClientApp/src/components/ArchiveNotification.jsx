import React from 'react';
import { Link } from "react-router-dom";

function ArchiveNotification(props) {
    
    
    return (
        <div>
            <h1> Account Archived </h1>
            <p> Your Account has been Archived. Your data is safe, and has not been deleted.</p>
            <button className="btn btn-info">
                <Link to="/">
                    Logout
                </Link>
            </button> 
        </div>
    );

}
export { ArchiveNotification };