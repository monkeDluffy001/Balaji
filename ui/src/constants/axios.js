import axios from 'axios';

export const configureAxios = () => {
  const TIMEOUT = 1 * 60 * 1000;
  axios.defaults.timeout = TIMEOUT;
  axios.defaults.baseURL = import.meta.env.VITE_API_ENDPOINT;
  axios.defaults.headers['Content-Type'] = 'application/json';
};
