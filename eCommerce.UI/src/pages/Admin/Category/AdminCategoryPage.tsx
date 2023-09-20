import React from "react";
import AdminCategories from "../../../components/Admin/Category/AdminCategories";
import { Button, HStack, Text } from "@chakra-ui/react";
import { useNavigate } from "react-router-dom";

const AdminCategoryPage = () => {
  const navigate = useNavigate();
  return (
    <div>
      <HStack>
        <Button onClick={() => navigate("create")}>Create</Button>
        <HStack>
          <Text color={"red"}>Tip: </Text>
          <Text>Click on the category to edit or delete it.</Text>
        </HStack>
      </HStack>

      <AdminCategories></AdminCategories>
    </div>
  );
};

export default AdminCategoryPage;
