import React, { useEffect, useState } from "react";
import CategoryService, { Category } from "../../../services/CategoryService";
import { Box, Container } from "@chakra-ui/react";
import AdminCategoryTree from "./AdminCategoryTree";

const AdminCategories = () => {
  const { getAll } = new CategoryService();
  const [categories, setCategories] = useState<Category[]>();
  useEffect(() => {
    getAll(setCategories);
  }, []);

  if (categories)
    return (
      <Container maxWidth={700}>
        {categories
          .filter((cat) => cat.parentCategoryId == null)
          .map((category) => (
            <AdminCategoryTree
              categories={categories}
              category={category}
              key={1}
            ></AdminCategoryTree>
          ))}
      </Container>
    );
};

export default AdminCategories;
