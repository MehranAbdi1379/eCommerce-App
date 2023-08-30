import {
  Container,
  FormControl,
  FormLabel,
  Input,
  Button,
  Heading,
} from "@chakra-ui/react";
import React from "react";
import { useForm } from "react-hook-form";
import { Form } from "react-router-dom";
import UserService from "../../services/UserService";

const SignUpPage = () => {
  const { handleSubmit, register } = useForm();
  const { SignUp } = new UserService();
  return (
    <Container border={"2px solid gray"} borderRadius={"10px"} padding={"35px"}>
      <Heading fontSize={"2rem"} marginBottom={"0.8em"}>
        Sing Up
      </Heading>
      <Form
        onSubmit={handleSubmit((data) => SignUp(data.email, data.password))}
      >
        <FormControl marginBottom={"1.3em"}>
          <Input {...register("email")} placeholder="Email"></Input>
        </FormControl>
        <FormControl marginBottom={"1.3em"}>
          <FormLabel>
            <Input {...register("password")} placeholder="Password"></Input>
          </FormLabel>
        </FormControl>
        <FormControl>
          <Button type="submit">Sign Up</Button>
        </FormControl>
      </Form>
    </Container>
  );
};

export default SignUpPage;
