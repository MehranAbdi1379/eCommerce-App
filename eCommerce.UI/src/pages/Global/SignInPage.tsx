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

const SignInPage = () => {
  const { handleSubmit, register } = useForm();
  const { SignIn } = new UserService();
  return (
    <Container border={"2px solid gray"} borderRadius={"10px"} padding={"35px"}>
      <Heading fontSize={"2rem"} marginBottom={"0.8em"}>
        Log In
      </Heading>
      <Form
        onSubmit={handleSubmit((data) => SignIn(data.email, data.password))}
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
          <Button type="submit">Log In</Button>
        </FormControl>
      </Form>
    </Container>
  );
};

export default SignInPage;
