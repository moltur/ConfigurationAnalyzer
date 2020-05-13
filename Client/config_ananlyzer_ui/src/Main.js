import React, { Component } from "react";
import {
  Route,
  NavLink,
  HashRouter
} from "react-router-dom";
import Home from "./Home";
import Stuff from "./Stuff";
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
                <li><NavLink to="/resources">Ресурсы</NavLink></li>
                <li><NavLink to="/procedures">Процедуры</NavLink></li>
                <li><NavLink to="/contact">Помощь</NavLink></li>
                </ul>
                <div className="content">
                <Route exact path="/" component={Home}/>
                <Route path="/resources" component={Stuff}/>
                <Route path="/procedures" component={Stuff}/>
                <Route path="/contact" component={Contact}/>
                <Route path="/config-description"  render ={(props) => <ConfigurationInfo {...props} text={'true'} />}/>
                <Route path="/configs-comparison"  render ={(props) => <ConfigsComparison {...props} text={'true'} />}/>
                <Route path="/configs-search"  render ={(props) => <BestConfigs {...props} text={'true'} />}/>
                {/* <Route component={Error} /> */}
                </div>
                </div>
        </HashRouter>
    );
  }
}
 
export default Main;