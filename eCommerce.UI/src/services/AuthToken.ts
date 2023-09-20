function GetAuthToken() {
  const token = localStorage.getItem("token");
  if (token) return token;
  return "";
}

export default GetAuthToken;
