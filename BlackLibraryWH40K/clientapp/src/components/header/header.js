import React from 'react';
import { Link } from 'react-router-dom';
import './header.css';

const Header = () => {
    return(
        <div className="header d-flex">
            <h3>
                <Link to="/">
                    Black Library
                </Link>
            </h3>
        </div>
    )
}

export default Header;