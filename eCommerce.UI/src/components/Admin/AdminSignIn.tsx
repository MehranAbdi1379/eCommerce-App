import React from "react";
import AdminService from "../../services/AdminService";
import { Form, Link, useNavigate } from "react-router-dom";
import {
  Container,
  FormControl,
  Input,
  FormLabel,
  Button,
  Text,
} from "@chakra-ui/react";
import { useForm } from "react-hook-form";

const AdminSignIn = () => {
  const { handleSubmit: handleSignInSubmit, register: signInRegister } =
    useForm();
  const { SignIn } = new AdminService();
  const navigate = useNavigate();

  return (
    <Container>
      <Form
        onSubmit={handleSignInSubmit((data) =>
          SignIn(data.email, data.password, navigate)
        )}
      >
        <FormControl marginBottom={"1.3em"}>
          <Input {...signInRegister("email")} placeholder="Email"></Input>
        </FormControl>
        <FormControl marginBottom={"1.3em"}>
          <FormLabel>
            <Input
              {...signInRegister("password")}
              placeholder="Password"
            ></Input>
          </FormLabel>
        </FormControl>
        <FormControl>
          <Button type="submit">Log In</Button>
        </FormControl>
      </Form>
    </Container>
  );
};

export default AdminSignIn;
