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
import { Form, Link } from "react-router-dom";
import SignIn from "../../../components/Global/SignIn";
import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import CategoryService, { Category } from "../../../services/CategoryService";
import AdminCategories from "../../../components/Admin/AdminCategories";
import AdminCategoryTree from "../../../components/Admin/AdminCategoryTree";

const AdminCategoryCreatePage = () => {
  const { register, handleSubmit } = useForm();
  const [categories, setCategories] = useState<Category[]>();
  const { getAll, createRoot, createWithParent } = new CategoryService();
  const [showCategories, setShowCategories] = useState(false);
  var sortedCategories: Category[] = [];
  categories?.forEach((category) => {
    sortedCategories.push(category);
  });
  sortedCategories?.sort((a, b) => {
    const titleA = a.title.toLowerCase();
    const titleB = b.title.toLowerCase();

    if (titleA < titleB) return -1;
    if (titleA > titleB) return 1;
    return 0;
  });

  useEffect(() => {
    getAll(setCategories);
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
            if (data.parentId == "Root Category") {
              createRoot(data.title, null, null);
            } else {
              createWithParent(data.title, data.parentId, null, null);
            }
          })}
        >
          <FormControl marginBottom={"1.3em"}>
            <FormLabel>Title</FormLabel>
            <Input {...register("email")} placeholder="Title"></Input>
          </FormControl>
          <FormControl>
            <HStack>
              <FormLabel>Parent</FormLabel>
              <Button
                onClick={() => {
                  if (showCategories == true) setShowCategories(false);
                  if (showCategories == false) setShowCategories(true);
                }}
                fontSize={"1rem"}
                padding={2}
                marginBottom={4}
              >
                {showCategories && <text>Hide Category Tree</text>}
                {!showCategories && <text>Show Category Tree</text>}
              </Button>
            </HStack>

            <Select>
              <option {...register("parentId")}>Root Category</option>
              {sortedCategories?.map((category) => (
                <option
                  key={category.id}
                  value={category.title}
                  {...register("parentId")}
                >
                  {category.title}
                </option>
              ))}
            </Select>
            <FormHelperText>Select an option</FormHelperText>
          </FormControl>
          <FormControl>
            <Button type="submit">Create</Button>
          </FormControl>
        </Form>
      </Container>
      {showCategories &&
        categories?.map((category) => (
          <AdminCategoryTree categories={categories} category={category} />
        ))}
    </>
  );
};

export default AdminCategoryCreatePage;
