import axios from "axios";

const apiClient = axios.create({ baseURL: "https://localhost:7209/api/" });

export default apiClient;
