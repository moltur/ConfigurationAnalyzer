import React, { Component } from "react";
import API from '../Helpers/Api';
import { FormCheckbox, Button, Container, Row, Col  } from "shards-react";
import "bootstrap/dist/css/bootstrap.min.css";
import "shards-ui/dist/css/shards.min.css"
import "./Styles/Home.css";
import { Route, Link, HashRouter } from "react-router-dom";
 
class Home extends Component {
  constructor(props) {
    super(props);
    this.handleChange = this.handleChange.bind(this);
    this.state = {
      configurations: [],
      isComparisonAllowed: false,
      isSearchAllowed: false
    };
  }

  handleChange(e, id) {
    for (var i in this.state.configurations){
      if (this.state.configurations[i].id === id){
        this.state.configurations[i].isChecked = !this.state.configurations[i].isChecked;
        break;
      }
    }

    var enabledCount = 0;
    for(var i in this.state.configurations){
    if(this.state.configurations[i].isChecked === true)
      enabledCount++;
    }

    if (enabledCount > 1){
      this.state.isSearchAllowed = true;
     if(enabledCount < 3){
      this.state.isComparisonAllowed = true;
    } else{
      this.state.isComparisonAllowed = false;
    }
  } else {
    this.state.isComparisonAllowed = false;
    this.state.isSearchAllowed = false;
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
      <Link to={link}>{value.name}</Link>
    </FormCheckbox>
    })
  }

  getConfigsFromApi () {
    return API.get('configurations/').then(value => value.data.map((value) => {
      return {id: value.id, name: value.name, isChecked: false}
    }))
  }

  getComparisonButton(){
      if (this.state.isComparisonAllowed)
      {
        return <Button outline squared active>
       <Link to={'/configs-comparison/'+ this.state.configurations.map((value) => {
         if (value.isChecked) return value.id;
       }).filter(function (el) {
        return el != null;
      }).join('&')}>
         Сравнить
         </Link>
      </Button>
      }
      else{
        return <Button outline squared disabled>
          Сравнить
       </Button>
      } 
  }

  getSearchButton(){
      if (this.state.isSearchAllowed)
      {
        return <Button outline squared active>
       <Link to={'/best/' + this.state.configurations.map((value) => {
         if (value.isChecked) return value.id;
       }).filter(function (el) {
        return el != null;
      }).join('&')}>
         Выбрать оптимальную
       </Link>
      </Button>
      }
      else{
        return <Button outline squared disabled>
          Выбрать оптимальную
       </Button>
      } 
  }


  render() {
    return (
      <Container>
        <Row>
          <Col>
        <h4>Доступные конфигурации САПР:</h4>
        </Col>
        <Col></Col>
        <Col></Col>
        </Row>
        <Row>
        <Col>
        {this.getList()}
        </Col>
        <Col></Col>
        <Col></Col>
        </Row>
        <Row>
        <Col></Col>
        <Col></Col>
        <Col>
        {this.getComparisonButton()}
        {this.getSearchButton()}
        </Col>
        </Row>
      </Container>
    );
  }
}
 
export default Home;