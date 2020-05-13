import React, { Component } from "react";
import {
  Route,
  NavLink,
  HashRouter
} from "react-router-dom";
import Home from "./Home";
import Stuff from "./Stuff";
import Contact from "./Contact";
 
class Main extends Component {
  render() {
    return (
        <HashRouter>
            <div>
                <h1>CADConfig</h1>
                <ul className="header">
                <li><NavLink to="/">Конфигурации</NavLink></li>
                <li><NavLink to="/resources">Ресурсы</NavLink></li>
                <li><NavLink to="/procedures">Процедуры</NavLink></li>
                <li><NavLink to="/contact">Помощь</NavLink></li>
                </ul>
                <div className="content">
                <Route exact path="/" component={Home}/>
                <Route path="/resources" component={Stuff}/>
                <Route path="/procedures" component={Stuff}/>
                <Route path="/contact" component={Contact}/>
                </div>
                </div>
        </HashRouter>
    );
  }
}
 
export default Main;