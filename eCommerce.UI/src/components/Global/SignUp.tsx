import {
  Button,
  Container,
  FormControl,
  FormLabel,
  Heading,
  Input,
} from "@chakra-ui/react";
import { useForm } from "react-hook-form";
import { Form, useNavigate } from "react-router-dom";
import UserService from "../../services/UserService";

const SignUpContainer = () => {
  const { register: signUpResigter, handleSubmit: handleSignUpSubmit } =
    useForm();
  const { SignUp } = new UserService();
  const navigate = useNavigate();
  return (
    <Container>
      <Form
        onSubmit={handleSignUpSubmit((data) =>
          SignUp(data.email, data.password, navigate)
        )}
      >
        <FormControl marginBottom={"1.3em"}>
          <Input
            {...signUpResigter("firstName")}
            placeholder="First Name"
          ></Input>
        </FormControl>
        <FormControl marginBottom={"1.3em"}>
          <Input
            {...signUpResigter("lastName")}
            placeholder="Last Name"
          ></Input>
        </FormControl>
        <FormControl marginBottom={"1.3em"}>
          <Input {...signUpResigter("email")} placeholder="Email"></Input>
        </FormControl>
        <FormControl marginBottom={"1.3em"}>
          <FormLabel>
            <Input
              {...signUpResigter("password")}
              placeholder="Password"
            ></Input>
          </FormLabel>
        </FormControl>
        <FormControl>
          <Button type="submit">Sign Up</Button>
        </FormControl>
      </Form>
    </Container>
  );
};

export default SignUpContainer;
