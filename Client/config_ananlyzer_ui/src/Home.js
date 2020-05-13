import React, { Component } from "react";
import API from './Api';
import { FormCheckbox } from "shards-react";
import "bootstrap/dist/css/bootstrap.min.css";
import "shards-ui/dist/css/shards.min.css"
import "./Home.css";
import { Route, NavLink, HashRouter } from "react-router-dom";
import ConfigurationInfo from "./ConfigurationInfo";
 
class Home extends Component {
  constructor(props) {
    super(props);
    this.handleChange = this.handleChange.bind(this);
    this.state = {
      configurations: []
    };
  }

  handleChange(e, id) {
    for (var i in this.state.configurations){
      if (this.state.configurations[i].id === id){
        this.state.configurations[i].isChecked = !this.state.configurations[i].isChecked;
        break;
      }
    }
    this.setState(this.state);
  }

  componentDidMount() {
    this.getConfigsFromApi().then(configurations => {
      this.setState({configurations});
    })
  }

  getList(){
    return this.state.configurations.map((value) => {
      var link = '/config-description/' + value.id;
      return <FormCheckbox
      checked={value.isChecked}
      onChange={e => this.handleChange(e, value.id)}
    >
      <NavLink to = {link}>{value.name}</NavLink>
    </FormCheckbox>
    })
  }

  getConfigsFromApi () {
    return API.get('configurations/').then(value => value.data.map((value) => {
      return {id: value.id, name: value.name, isChecked: false}
    }))
  }

  getConfigurationInfo(){
    return <ConfigurationInfo text = {'LOLKEK'}/>;
  }

  render() {
    return (
      <HashRouter>
      <div>
        <h4>Доступные конфигурации:</h4>
        {this.getList()}
        <Route path="/config-description" component = {ConfigurationInfo}/>
      </div>
      </HashRouter>
    );
  }
}
 
export default Home;