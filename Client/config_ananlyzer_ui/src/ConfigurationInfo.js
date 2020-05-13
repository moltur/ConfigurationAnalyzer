import React, { Component } from "react";
import API from './Api';
import "./Home.css";
import "bootstrap/dist/css/bootstrap.min.css";
import "shards-ui/dist/css/shards.min.css"
import { Container, Row, Col } from "shards-react";
import MidMaxMinBar from './Bars/MidMaxMinBar';
import SortedBar from './Bars/SortedBar';
 
class ConfigurationInfo extends Component { 
  constructor(props) {
    super(props);
    this.state = {
      config: {
        id: 0,
        configuration: {
          id: 0,
          name:"",
        },
        duration:0,
        durationBest:0,
        durationWorst:0,
        inefficiencyTime:0,
        inefficiencyTimeBest:0,
        inefficiencyTimeWorst:0,
        cost:0,
        procedures: [],
        resources: []
      }
    }
  }


  componentDidMount() {
    this.getConfigFromApi(2).then(config=> {
      this.setState({config});
    })
  }

  getConfigFromApi (id) {
    return API.get('configurations/2').then(value => value.data)
  }

  compareResourcesByInUseTime(a, b) {
    if (a.inUseTime > b.inUseTime) return -1;
    if (b.inUseTime > a.inUseTime) return 1;
  
    return 0;
  }

  compareByInefficiencyTime(a, b) {
    if (a.inefficiencyTime > b.inefficiencyTime) return -1;
    if (b.inefficiencyTime > a.inefficiencyTime) return 1;
  
    return 0;
  }

  compareResourcesByCost(a, b) {
    if (a.resource.cost > b.resource.cost) return -1;
    if (b.resource.cost > a.resource.cost) return 1;
  
    return 0;
  }

  compareProceduresByDuration(a, b) {
    if (a.duration > b.duration) return -1;
    if (b.duration > a.duration) return 1;
  
    return 0;
  }


  render() {
    return (
      <Container>
        <Row>
        <Col>
        <h4>Конфигурация: {this.state.config.configuration.name}</h4>
        </Col>
        <Col></Col>
        </Row>
        <Row>
          <Col>
        <Container>
        <Row>
          <Col>{'Среднее время выполнения проектирования'}</Col>
          <Col>{this.state.config.duration} </Col>
          <Col></Col>
        </Row>
        <Row>
        <Col>{'Среднее неэффективно использованное время'}</Col>
          <Col>{this.state.config.inefficiencyTime} </Col>
          <Col></Col>
        </Row>
        <Row>
        <Col>{'Стоимость'}</Col>
          <Col>{this.state.config.cost} </Col>
          <Col></Col>
        </Row>
        </Container>
        </Col>
        </Row>
        <Row>
          <Col>
        <MidMaxMinBar 
            data = {[ this.state.config.durationWorst, this.state.config.duration, this.state.config.durationBest]}
            title = 'Время выполнения проектирования'
        />
        </Col>
        <Col>
        <MidMaxMinBar 
            data = {[this.state.config.inefficiencyTimeWorst, this.state.config.inefficiencyTime, this.state.config.inefficiencyTimeBest]}
            title = 'Неэффективно использованное время'
        />
        </Col>
        </Row>
        <Row>
          <Col><h4>Ресурсы</h4></Col>
          <Col></Col>
          <Col></Col>
        </Row>
        <Row>
          <Col>
        <SortedBar 
            data = {this.state.config.resources.sort(this.compareResourcesByInUseTime).map(value => {
              return value.inUseTime;
            })}
            labels = {this.state.config.resources.sort(this.compareResourcesByInUseTime).map(value => {
              return value.resource.name.split(" ");
            })}
            title = 'Ресурсы по времени использования'
        />
        </Col>
        <Col>
        <SortedBar 
            data = {this.state.config.resources.sort(this.compareByInefficiencyTime).map(value => {
              return value.inefficiencyTime;
            })}
            labels = {this.state.config.resources.sort(this.compareByInefficiencyTime).map(value => {
              return value.resource.name.split(" ");
            })}
            title = 'Ресурсы по времени простоя'
        />
        </Col>
        </Row>
        <Row>
          <Col>
        <SortedBar 
            data = {this.state.config.resources.sort(this.compareResourcesByCost).map(value => {
              return value.resource.cost;
            })}
            labels = {this.state.config.resources.sort(this.compareResourcesByCost).map(value => {
              return value.resource.name.split(" ");
            })}
            title = 'Ресурсы по стоимости'
        />
        </Col>
        <Col>
        </Col>
        </Row>
        <Row>
          <Col><h4>Процедуры</h4></Col>
          <Col></Col>
          <Col></Col>
        </Row>
        <Row>
          <Col>
        <SortedBar 
            data = {this.state.config.procedures.sort(this.compareProceduresByDuration).map(value => {
              return value.duration;
            })}
            labels = {this.state.config.procedures.sort(this.compareProceduresByDuration).map(value => {
              return value.procedure.name.split(" ");
            })}
            title = 'Процедуры по времени выполнения'
        />
        </Col>
        <Col>
        <SortedBar 
            data = {this.state.config.procedures.sort(this.compareByInefficiencyTime).map(value => {
              return value.inefficiencyTime;
            })}
            labels = {this.state.config.procedures.sort(this.compareByInefficiencyTime).map(value => {
              return value.procedure.name.split(" ");
            })}
            title = 'Процедуры по времени ожидания ресурсов'
        />
        </Col>
        </Row>
      </Container>
    );
  }
}
 
export default ConfigurationInfo;