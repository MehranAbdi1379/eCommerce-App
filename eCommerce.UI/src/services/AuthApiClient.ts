import axios from "axios";
import GetAuthToken from "./AuthToken";

function AuthApiClient() {
  return axios.create({
    baseURL: "https://localhost:7209/api/",
    headers: { Authorization: "bearer " + GetAuthToken() },
  });
}
