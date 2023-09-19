import React, { useEffect, useState } from "react";
import { Category } from "../../services/CategoryService";
import { List, ListItem, Text } from "@chakra-ui/react";

interface Props {
  category: Category;
  categories: Category[];
}
const AdminCategoryTree = ({ categories, category }: Props) => {
  const childrenCategories = categories.filter(
    (cat) =>
      cat.index === category.index + 1 && cat.parentCategoryId == category.id
  );

  if (childrenCategories.length === 0 && category.index != 0) {
    return null; // No categories to render at this level
  }

  if (category.index == 0)
    return (
      <List>
        {category.index == 0 && (
          <ListItem padding={2} margin={2} border={"1px gray solid"}>
            {category.title}
            {childrenCategories.map((category) => (
              <ListItem
                key={category.id}
                padding={2}
                margin={2}
                border={"1px gray solid"}
                paddingLeft={`${category.index + 1}rem`}
              >
                <Text>{category.title}</Text>

                <AdminCategoryTree
                  category={category}
                  categories={categories}
                />
              </ListItem>
            ))}
          </ListItem>
        )}
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
          paddingLeft={`${category.index + 1}rem`}
        >
          <Text>{category.title}</Text>

          <AdminCategoryTree category={category} categories={categories} />
        </ListItem>
      ))}
    </List>
  );
};

export default AdminCategoryTree;
