import React, { Component } from "react";
import "../Pages/Styles/Home.css";
import "bootstrap/dist/css/bootstrap.min.css";
import "shards-ui/dist/css/shards.min.css"
import { Bar } from 'react-chartjs-2';

class SortedBar extends Component { 
    constructor(props) {
      super(props);
    }
    render() {
        return (
        <Bar
          data={{
            labels: this.props.labels,
            datasets: [{
            label:this.props.title,
            data: this.props.data,
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
              text:this.props.title,
              fontSize:15
            },
            legend:{
              display: false
            },
            tooltips: {
              titleFontSize: 15,
              bodyFontSize: 15
            },
            scales: {
            yAxes: [{
                ticks: {
                  beginAtZero: true,
                  fontSize: 15
                }
            }],
            xAxes: [{
              ticks: {
                fontSize: 15
              }
          }]
        }}}
        />
        )
    }
}

export default SortedBar;