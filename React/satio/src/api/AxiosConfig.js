import axios from 'axios';

export const axiosBase = axios.create({
    baseUrl: "https://localhost:5001/api"
});
 
  