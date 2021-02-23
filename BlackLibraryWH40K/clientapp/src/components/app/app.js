import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';

import Header from "../header";

export default class App extends Component{
    render() {
        return(
            <Router>
                <div>
                    <Header/>
                </div>
            </Router>
        )
    }
}