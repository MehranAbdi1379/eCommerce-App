import {
  Button,
  Container,
  FormControl,
  FormLabel,
  Input,
} from "@chakra-ui/react";
import React from "react";
import { useForm } from "react-hook-form";
import { Form } from "react-router-dom";
import UserService from "../services/UserService";

const MainPage = () => {
  const { handleSubmit, register } = useForm();
  const { SignUp, SignIn } = new UserService();
  return (
    <>
      <Container>
        <Form
          onSubmit={handleSubmit((data) =>
            SignUp(data.signUpEmail, data.signUpPassword)
          )}
        >
          <FormControl>
            <FormLabel>Email:</FormLabel>
            <Input {...register("signUpEmail")}></Input>
          </FormControl>
          <FormControl>
            <FormLabel>
              <FormLabel>Password:</FormLabel>
              <Input {...register("signUpPassword")}></Input>
            </FormLabel>
          </FormControl>
          <FormControl>
            <Button type="submit">Sign Up</Button>
          </FormControl>
        </Form>
      </Container>
      <Container>
        <Form
          onSubmit={handleSubmit((data) =>
            SignIn(data.signInEmail, data.signInPassword)
          )}
        >
          <FormControl>
            <FormLabel>Email:</FormLabel>
            <Input {...register("signInEmail")}></Input>
          </FormControl>
          <FormControl>
            <FormLabel>
              <FormLabel>Password:</FormLabel>
              <Input {...register("signInPassword")}></Input>
            </FormLabel>
          </FormControl>
          <FormControl>
            <Button type="submit">Sign In</Button>
          </FormControl>
        </Form>
      </Container>
    </>
  );
};

export default MainPage;
