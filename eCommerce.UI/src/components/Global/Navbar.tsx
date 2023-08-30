import { Button, Flex, Heading } from "@chakra-ui/react";
import React from "react";
import { useNavigate } from "react-router-dom";

const Navbar = () => {
  const navigate = useNavigate();
  return (
    <Flex
      padding={"2vh 10vw"}
      marginBottom={5}
      justifyContent={"space-between"}
      bg={"red.300"}
    >
      <Heading cursor={"pointer"} onClick={() => navigate("/")}>
        E-Commerce
      </Heading>
      <Flex gap={3}>
        <Button onClick={() => navigate("/sign-in")}>Log In</Button>
        <Button onClick={() => navigate("/sign-up")}>Sign Up</Button>
      </Flex>
    </Flex>
  );
};

export default Navbar;
