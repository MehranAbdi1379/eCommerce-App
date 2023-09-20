import React, { CSSProperties, useEffect, useState } from "react";
import CategoryService, { Category } from "../../../services/CategoryService";
import AdminCategorySelectTree from "./AdminCategorySelectTree";
import { Box, Button } from "@chakra-ui/react";

interface Props {
  setParentCategory: any;
  setShowCategories: any;
  parentCategory: Category | undefined;
}

const modalStyles: CSSProperties = {
  backgroundColor: "white",
  padding: 20,
  borderRadius: 8,
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  boxShadow: "0 2px 4px rgba(0, 0, 0, 0.2)",
  maxHeight: "90vh", // Adjust the value as needed
  width: "50%",
  overflowY: "auto",
};

const AdminCategorySelectOverlay = ({
  setParentCategory,
  setShowCategories,
  parentCategory,
}: Props) => {
  const { getAll } = new CategoryService();
  const [categories, setCategories] = useState<Category[]>();
  useEffect(() => {
    getAll(setCategories);
  }, []);
  return (
    <div style={modalStyles}>
      <Box textAlign={"center"}>
        <Button onClick={() => setShowCategories(false)} colorScheme="red">
          Close
        </Button>
      </Box>

      {categories
        ?.filter((cat) => cat.parentCategoryId == null)
        .map((category) => (
          <AdminCategorySelectTree
            key={category.id}
            parentCategory={parentCategory}
            setShowCategories={setShowCategories}
            setParentCategory={setParentCategory}
            categories={categories}
            category={category}
          />
        ))}
    </div>
  );
};

export default AdminCategorySelectOverlay;
