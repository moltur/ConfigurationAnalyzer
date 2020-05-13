import axios from 'axios';

export default axios.create({
  baseURL: `https://localhost:44329/api/v1/`,
  responseType: "json"
});