import React, {useEffect, useState} from "react";
import {Link, useLocation} from "react-router-dom";
import "./Header.css";

const Header = () => {
    const [activeTab, setActiveTab] = useState("Assignments");

    const location = useLocation();
    useEffect(() => {
        setActiveTab(location.pathname)
    }, [location])

    return (
        <div className='header'>
            <p className='logo'>Journal</p>
            <div className="header-right">
                <Link to="/">
                    <p 
                    className={`${activeTab === "Assignments" ? "active" : ""}`} 
                    onClick={() => setActiveTab("Assignments")}
                    > 
                        Home 
                    </p>
                </Link>
                <Link to="/add">
                    <p 
                    className={`${activeTab === "AddAssignment" ? "active" : ""}`} 
                    onClick={() => setActiveTab("AddAssignment")}
                    > 
                        Add Assignment 
                    </p>
                </Link>
            </div>
         </div>
    );
}

export default Header;