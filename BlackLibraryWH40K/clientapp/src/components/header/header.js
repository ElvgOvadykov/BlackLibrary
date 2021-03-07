import React from 'react';
import { Link } from 'react-router-dom';
import './header.css';
import WorldService from "../services/worldService";

const Header = () => {
    return(
        <div className="header d-flex">
            <h3>
                <Link to="/">
                    Black Library
                </Link>
            </h3>
            <ul className="d-flex">
                <li>
                    <Link to="/states">Стороны</Link>
                </li>
                <li>
                    <Link to="/vehicle">Техника</Link>
                </li>
                <li>
                    <Link to="/spaceship">Корабли</Link>
                </li>
                <li>
                    <Link to="/worlds">Миры</Link>
                </li>
                <li>
                    <button className='btn-primary' onClick={() => {
                        const worldService = new WorldService();
                            worldService.getWorlds().then((body) => {
                                console.log(body);
                        });
                    }}>Test</button>
                </li>
            </ul>
        </div>
    )
}

export default Header;