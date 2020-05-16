import React, { Component } from "react";
import {
  Route,
  NavLink,
  HashRouter
} from "react-router-dom";
import Home from "./Home";
import Contact from "./Contact";
import ConfigurationInfo from "./ConfigurationInfo";
import ConfigsComparison from "./ConfigsComparison";
import BestConfigs from "./BestConfigs";
 
class Main extends Component {
  render() {
    return (
        <HashRouter>
            <div>
                <h1>CADConfig</h1>
                <ul className="header">
                <li><NavLink to="/">Конфигурации</NavLink></li>
                <li><NavLink to="/contact">Помощь</NavLink></li>
                </ul>
                <div className="content">
                <Route exact path="/" component={Home}/>
                <Route path="/contact" component={Contact}/>
                <Route path="/config-description/:id"  component={ConfigurationInfo}/>
                <Route path="/configs-comparison/:ids"  component={ConfigsComparison}/>
                <Route path="/configs-search"  component={BestConfigs}/>
                {/* <Route component={Error} /> */}
                </div>
                </div>
        </HashRouter>
    );
  }
}
 
export default Main;