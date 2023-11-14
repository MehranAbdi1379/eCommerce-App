import { Button, List, ListItem, Text } from "@chakra-ui/react";
import React from "react";
import { Category } from "../../../services/CategoryService";
import AdminCategoryTree from "./AdminCategoryTree";

interface Props {
  category: Category;
  categories: Category[];
  setParentCategory: any;
  setShowCategories: any;
  parentCategory: Category | undefined;
}

const AdminCategorySelectTree = ({
  categories,
  category,
  setParentCategory,
  setShowCategories,
  parentCategory,
}: Props) => {
  const childrenCategories = categories.filter(
    (cat) => cat.parentCategoryId == category.id
  );
  const setParentCategoryAndClose = (category: Category) => {
    setParentCategory(category);
    setShowCategories(false);
  };

  if (childrenCategories.length === 0 && category.parentCategoryId != null) {
    return null; // No categories to render at this level
  }

  if (category.parentCategoryId == null)
    return (
      <List>
        <ListItem
          key={category.id}
          padding={2}
          margin={2}
          border={"1px gray solid"}
          borderRadius={"10px"}
        >
          <Button
            colorScheme={parentCategory?.id == category.id ? "green" : "gray"}
            onClick={() => setParentCategoryAndClose(category)}
          >
            {category.title}
          </Button>

          {childrenCategories.map((cat) => (
            <ListItem
              key={cat.id}
              padding={2}
              margin={2}
              border={"1px gray solid"}
              paddingLeft={`20px`}
              borderRadius={"10px"}
            >
              <Button
                colorScheme={parentCategory?.id == cat.id ? "green" : "gray"}
                onClick={() => setParentCategoryAndClose(cat)}
              >
                {cat.title}
              </Button>

              <AdminCategorySelectTree
                parentCategory={parentCategory}
                setShowCategories={setShowCategories}
                category={cat}
                categories={categories}
                setParentCategory={setParentCategory}
              />
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
          <Button
            colorScheme={parentCategory?.id == category.id ? "green" : "gray"}
            onClick={() => setParentCategoryAndClose(category)}
          >
            {category.title}
          </Button>

          <AdminCategorySelectTree
            key={category.id}
            parentCategory={parentCategory}
            setShowCategories={setShowCategories}
            setParentCategory={setParentCategory}
            category={category}
            categories={categories}
          />
        </ListItem>
      ))}
    </List>
  );
};

export default AdminCategorySelectTree;
