import { Button, FormControl, FormLabel, Input } from "@chakra-ui/react";
import React from "react";
import { useForm } from "react-hook-form";
import { Form } from "react-router-dom";
import UserService from "../services/UserService";

const MainPage = () => {
  const { handleSubmit, register } = useForm();
  const { SignUp } = new UserService();
  return (
    <Form onSubmit={handleSubmit((data) => SignUp(data.email, data.password))}>
      <FormControl>
        <FormLabel>Email:</FormLabel>
        <Input {...register("email")}></Input>
      </FormControl>
      <FormControl>
        <FormLabel>
          <FormLabel>Password:</FormLabel>
          <Input {...register("password")}></Input>
        </FormLabel>
      </FormControl>
      <FormControl>
        <Button type="submit">Sign Up</Button>
      </FormControl>
    </Form>
  );
};

export default MainPage;
