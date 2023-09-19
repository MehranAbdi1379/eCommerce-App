import React from "react";
import AdminNavbar from "../../components/Admin/AdminNavbar";
import { Outlet } from "react-router-dom";

const AdminRootLayout = () => {
  return (
    <>
      <AdminNavbar></AdminNavbar>
      <Outlet></Outlet>
    </>
  );
};

export default AdminRootLayout;
