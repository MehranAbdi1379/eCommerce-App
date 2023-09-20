import React, { useEffect, useState } from "react";
import { List, ListItem, Text } from "@chakra-ui/react";
import { Category } from "../../../services/CategoryService";
import { color } from "framer-motion";
import { useNavigate } from "react-router-dom";

interface Props {
  category: Category;
  categories: Category[];
}
const AdminCategoryTree = ({ categories, category }: Props) => {
  const navigate = useNavigate();
  const childrenCategories = categories.filter(
    (cat) => cat.parentCategoryId == category.id
  );

  if (childrenCategories.length === 0 && category.parentCategoryId != null) {
    return null; // No categories to render at this level
  }

  if (category.parentCategoryId == null)
    return (
      <List>
        <ListItem
          padding={2}
          margin={2}
          border={"1px gray solid"}
          borderRadius={"10px"}
        >
          <Text
            cursor={"pointer"}
            onClick={() => navigate("edit", { state: { category } })}
          >
            {category.title}
          </Text>

          {childrenCategories.map((category) => (
            <ListItem
              key={category.id}
              padding={2}
              margin={2}
              border={"1px gray solid"}
              paddingLeft={`2rem`}
              borderRadius={"10px"}
            >
              <Text
                cursor={"pointer"}
                onClick={() => navigate("edit", { state: { category } })}
              >
                {category.title}
              </Text>

              <AdminCategoryTree category={category} categories={categories} />
            </ListItem>
          ))}
        </ListItem>
      </List>
    );

  return (
    <List>
      {childrenCategories.map((category) => (
        <ListItem
          key={category.id}
          padding={2}
          margin={2}
          border={"1px gray solid"}
          paddingLeft={`2rem`}
          borderRadius={"10px"}
        >
          <Text
            cursor={"pointer"}
            onClick={() => navigate("edit", { state: { category } })}
          >
            {category.title}
          </Text>

          <AdminCategoryTree category={category} categories={categories} />
        </ListItem>
      ))}
    </List>
  );
};

export default AdminCategoryTree;
