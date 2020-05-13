import React, { Component } from "react";
import API from './Api';
import "./Home.css";
import "bootstrap/dist/css/bootstrap.min.css";
import "shards-ui/dist/css/shards.min.css"
import { Route, Link, HashRouter } from "react-router-dom";
import { Bar } from 'react-chartjs-2';
 
class ConfigurationInfo extends Component { 
  constructor(props) {
    super(props);
    // this.handleChange = this.handleChange.bind(this);
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

  render() {
    return (
      <div>
        <h4>{this.state.config.configuration.name}</h4>
        <Bar
          data={{
            labels: ['Среднее значение', 'Максимальное', 'Минимальное'],
            datasets: [{
            label:'Время выполнения проектирования',
            data:[this.state.config.duration, this.state.config.durationWorst, this.state.config.durationBest],
            backgroundColor: [
              'rgba(255, 99, 132, 0.2)',
              'rgba(54, 162, 235, 0.2)',
              'rgba(255, 206, 86, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(153, 102, 255, 0.2)',
              'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
              'rgba(255, 99, 132, 1)',
              'rgba(54, 162, 235, 1)',
              'rgba(255, 206, 86, 1)',
              'rgba(75, 192, 192, 1)',
              'rgba(153, 102, 255, 1)',
              'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 2
          }]
          }}
          options={{
            title:{
              display:true,
              text:'Время выполнения проектирования',
              fontSize:40
            },
            legend:{
              display: false
            },
            tooltips: {
              titleFontSize: 30,
              bodyFontSize: 30
            },
            scales: {
            yAxes: [{
                ticks: {
                  beginAtZero: true,
                  fontSize: 30
                }
            }],
            xAxes: [{
              ticks: {
                fontSize: 30
              }
          }]
        }}}
        />
      </div>
    );
  }
}
 
export default ConfigurationInfo;