import React, { useEffect, useState } from "react";
import CategoryService, { Category } from "../../services/CategoryService";
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
      <Container>
        {categories.map((category) => (
          <Box>
            {category.index == 0 && (
              <AdminCategoryTree
                categories={categories}
                category={category}
                key={1}
              ></AdminCategoryTree>
            )}
          </Box>
        ))}
      </Container>
    );
};

export default AdminCategories;
