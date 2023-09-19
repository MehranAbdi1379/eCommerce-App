import React from "react";
import AdminCategories from "../../../components/Admin/AdminCategories";
import { Button, HStack } from "@chakra-ui/react";
import { useNavigate } from "react-router-dom";

const AdminCategoryPage = () => {
  const navigate = useNavigate();
  return (
    <div>
      <HStack>
        <Button onClick={() => navigate("create")}>Create</Button>
        <Button onClick={() => navigate("edit")}>Edit</Button>
        <Button onClick={() => navigate("delete")}>Delete</Button>
      </HStack>

      <AdminCategories></AdminCategories>
    </div>
  );
};

export default AdminCategoryPage;
