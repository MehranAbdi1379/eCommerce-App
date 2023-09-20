import {
  Button,
  Container,
  FormControl,
  FormHelperText,
  FormLabel,
  HStack,
  Input,
  Select,
  Text,
} from "@chakra-ui/react";
import { Form, Link, useLocation, useNavigate } from "react-router-dom";
import SignIn from "../../../components/Global/SignIn";
import { useForm } from "react-hook-form";
import { CSSProperties, useEffect, useState } from "react";
import CategoryService, { Category } from "../../../services/CategoryService";
import AdminCategories from "../../../components/Admin/Category/AdminCategories";
import AdminCategoryTree from "../../../components/Admin/Category/AdminCategoryTree";
import AdminCategorySelectOverlay from "../../../components/Admin/Category/AdminCategorySelectOverlay";

const overlayStyles: CSSProperties = {
  position: "fixed",
  top: 0,
  left: 0,
  right: 0,
  bottom: 0,
  backgroundColor: "rgba(0, 0, 0, 0.7)",
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
  zIndex: 1000,
};

const AdminCategoryEditPage = () => {
  const { register, handleSubmit } = useForm();
  const { update, updateParentId, getById, deleteCategory, removeParentId } =
    new CategoryService();
  const [showCategories, setShowCategories] = useState(false);
  const [parentCategory, setParentCategory] = useState<Category>();
  const navigate = useNavigate();
  const [error, setError] = useState();
  const category: Category = useLocation().state.category;

  useEffect(() => {
    getById(category.parentCategoryId, setParentCategory);
  }, []);

  return (
    <>
      <Container
        border={"2px solid gray"}
        borderRadius={"10px"}
        padding={"20px"}
      >
        <Form
          onSubmit={handleSubmit((data) => {
            if (parentCategory != undefined) {
              updateParentId(category.id, parentCategory.id, setError);
            } else {
              removeParentId(category.id, setError);
            }
            update(category.id, data.title, navigate, setError);
          })}
        >
          <FormControl marginBottom={"1.3em"}>
            <FormLabel>Title</FormLabel>
            <Input
              {...register("title")}
              defaultValue={category.title}
              placeholder="Title"
            ></Input>
          </FormControl>
          <FormControl>
            <FormLabel>
              Parent Category: {parentCategory?.title}{" "}
              {parentCategory == undefined ? "Root Category" : ""}
            </FormLabel>
            <Button
              onClick={() => {
                setShowCategories(!showCategories);
              }}
              fontSize={"1rem"}
              padding={2}
              marginBottom={4}
              marginRight={4}
            >
              Select Parent Category
            </Button>
            <Button
              onClick={() => {
                setParentCategory(undefined);
              }}
              fontSize={"1rem"}
              padding={2}
              marginBottom={4}
            >
              Delete Parent Category
            </Button>
          </FormControl>

          <FormControl>
            <Button marginRight={5} type="submit">
              Edit
            </Button>
            <Button
              onClick={() => deleteCategory(category.id, navigate, setError)}
              colorScheme="red"
            >
              Delete
            </Button>
            <FormHelperText>
              To delete a category, it should have no sub categories.
            </FormHelperText>
          </FormControl>
        </Form>
      </Container>
      {showCategories && (
        <div style={overlayStyles}>
          <AdminCategorySelectOverlay
            parentCategory={parentCategory}
            setShowCategories={setShowCategories}
            setParentCategory={setParentCategory}
          />
        </div>
      )}
    </>
  );
};

export default AdminCategoryEditPage;
