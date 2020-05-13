import React, { Component } from "react";
import { FormCheckbox } from "shards-react";
import "bootstrap/dist/css/bootstrap.min.css";
import "shards-ui/dist/css/shards.min.css"
 
class Stuff extends Component {
    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
    this.state = {
      orange: false,
      lemon: false,
      kiwi: false
    };
      }
    
      handleChange(e, fruit) {
        const newState = {};
        newState[fruit] = !this.state[fruit];
        this.setState({ ...this.state, ...newState });
      }
    
  render() {
    return (
      <div>
        <h2>STUFF</h2>
        <p>Mauris sem velit, vehicula eget sodales vitae,
        rhoncus eget sapien:</p>
        <ol>
          <li>Nulla pulvinar diam</li>
          <li>Facilisis bibendum</li>
          <li>Vestibulum vulputate</li>
          <li>Eget erat</li>
          <li>Id porttitor</li>
        </ol>
        <div>
        <p>Select your favorite fruits:</p>
        <FormCheckbox
          checked={this.state.orange}
          onChange={e => this.handleChange(e, "orange")}
        >
          Orange
        </FormCheckbox>
        <FormCheckbox
          checked={this.state.lemon}
          onChange={e => this.handleChange(e, "lemon")}
        >
          Lemon
        </FormCheckbox>
        <FormCheckbox
          checked={this.state.kiwi}
          onChange={e => this.handleChange(e, "kiwi")}
        >
          Kiwi
        </FormCheckbox>
        <span className="d-block mt-3">
          <strong>Selected fruits:</strong>{" "}
          <pre>{JSON.stringify(this.state)}</pre>
        </span>
      </div>
      </div>
    );
  }
}
 
export default Stuff;