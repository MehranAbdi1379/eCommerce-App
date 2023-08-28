function GetAuthToken() {
  const token = localStorage.getItem("Token");
  if (token) return token;
  return "";
}

export default GetAuthToken;
