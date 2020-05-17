import React, { Component } from "react";
import API from '../Helpers/Api';
import "./Styles/Home.css";
import "bootstrap/dist/css/bootstrap.min.css";
import "shards-ui/dist/css/shards.min.css"
import { FormCheckbox, Container, Row, Col  } from "shards-react";
import { Route, Link, HashRouter } from "react-router-dom";
import MidMaxMinBar from '../Bars/MidMaxMinBar';
import SortedBar from '../Bars/SortedBar';
 
class BestConfigs extends Component { 
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
          },
          configurations:[],
          allConfigurations: [],
          allIds:[],
          method: 0
        }
      }

      componentDidMount() {
        const { ids } = this.props.match.params;
        var allIds = ids.split('&').map( (value) => {
          return parseInt(value, 10);
        });
        var method = allIds.pop();

        this.getBestConfigsFromApi({Ids:allIds}).then(configurations=> {
            this.getConfigFromApi(configurations[0].id).then(config => {
              this.getConfigsFromApi().then (allConfigurations => {

              this.setState({configurations, config, allConfigurations, allIds, method})
              })
        })
      })
    }

      getList(){
        return this.state.allConfigurations.map((value) => {
          if (this.state.allIds.includes(value.id)){
          var link = '/config-description/' + value.id;
          return <div><Link to={link}>{value.name}</Link></div>
          }
        })
      }

      getBestConfigsList(){
        return this.state.configurations.map((value) => {
          var link = '/config-description/' + value.id;
          return <div><Link to={link}>{value.name}</Link></div>
        })
      }
    
    
      getBestConfigsFromApi(request) {
        return API.post('configurations/best',request).then(value => value.data);
      }
    
      getConfigFromApi (id) {
        return API.get('configurations/'+ id).then(value => value.data)
      }

      getConfigsFromApi () {
        return API.get('configurations/').then(value => value.data.map((value) => {
          return {id: value.id, name: value.name, isChecked: false}
        }))
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

      getBestConfigsRow()
      {
        if (this.state.configurations.length>1) {
        return <Row>
        <Col>Все оптимальные конфигурации:</Col>
        <Col>{this.getBestConfigsList()}</Col>
        </Row>
        }
      }

      getMethodName(){
        if (this.state.method===0)
        return 'Метод целевого программирования'
        else 
        return 'Метод последовательных уступок'
        
      }
    
    
      render() {
        return (
          <Container>
            <Row>
              <Col>
                <h5>Все рассмотренные конфигурации:</h5>
              </Col>
              <Col>{this.getList()}</Col>
              </Row>
              <Row>
                <Col>
                <h5>Метод:</h5>
                </Col>
                <Col><h5>{this.getMethodName()} </h5></Col>
              </Row>
            <Row>
            <Col>
            <h5>Оптимальная конфигурация:</h5>
            </Col>
            <Col>
            <h5>{this.state.config.configuration.name}</h5>
            </Col>
            </Row>
            <Row>
              <Col>
            <Container>
            <Row>
              <Col>{'Среднее время выполнения проектирования'}</Col>
              <Col>{this.state.config.duration} </Col>
            </Row>
            <Row>
            <Col>{'Среднее неэффективно использованное время'}</Col>
              <Col>{this.state.config.inefficiencyTime} </Col>
            </Row>
            <Row>
            <Col>{'Стоимость'}</Col>
              <Col>{this.state.config.cost} </Col>
            </Row>
            </Container>
            </Col>
            <Col>
            <Container>
            {this.getBestConfigsRow()}
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
 
export default BestConfigs;