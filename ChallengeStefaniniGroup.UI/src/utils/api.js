import axios from 'axios';

const app = axios.create({
    baseURL: "https://localhost:44380/api"
});

export default app