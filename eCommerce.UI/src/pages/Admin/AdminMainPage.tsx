import React from "react";
import { Link, useNavigate } from "react-router-dom";

const AdminMainPage = () => {
  const navigate = useNavigate();
  return (
    <div>
      <Link to={"/admin/category"}>Categories</Link>
    </div>
  );
};

export default AdminMainPage;
