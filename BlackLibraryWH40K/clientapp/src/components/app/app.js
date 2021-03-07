import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

import Header from "../header";
import Home from "../main";
import ItemList from "../itemList";
import WorldService from "../services/worldService";

export default class App extends Component{
    render() {
        const worldService = new WorldService();
        const worlds = worldService.getWorlds();
        
        return(
            <Router>
                <div>
                    <Header/>
                    <Switch>
                        <Route path="/">
                            <Home/>
                        </Route>
                    </Switch>
                </div>
            </Router>
        )
    }
}