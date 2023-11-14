import { PhoneIcon, SearchIcon } from "@chakra-ui/icons";
import {
  Button,
  Flex,
  Heading,
  Input,
  InputGroup,
  InputLeftElement,
  InputRightElement,
  Menu,
  MenuButton,
  MenuItem,
  MenuList,
} from "@chakra-ui/react";
import React from "react";
import { useNavigate } from "react-router-dom";

const Navbar = () => {
  const navigate = useNavigate();
  const token = localStorage.getItem("token");
  const role = localStorage.getItem("role");
  return (
    <Flex
      padding={"2vh 10vw"}
      marginBottom={5}
      justifyContent={"space-between"}
      bg={"red.300"}
    >
      <Flex alignItems={"center"}>
        <Heading
          minWidth={225}
          cursor={"pointer"}
          onClick={() => navigate("/")}
        >
          E-Commerce
        </Heading>
        <InputGroup marginLeft={4}>
          <InputLeftElement>
            <SearchIcon />
          </InputLeftElement>
          <Input minWidth={"20vw"} bg={"gray.200"} placeholder="Search"></Input>
        </InputGroup>
      </Flex>

      <Flex gap={3}>
        {token && (
          <Menu>
            <MenuButton as={Button}>Logged In</MenuButton>
            <MenuList>
              <MenuItem>Your Name</MenuItem>
              <MenuItem
                onClick={() => {
                  navigate("/");
                  localStorage.removeItem("userId");
                  localStorage.removeItem("token");
                }}
              >
                Log Out
              </MenuItem>
            </MenuList>
          </Menu>
        )}
        {!token && (
          <Button onClick={() => navigate("/sign")}>Log In | Sign Up</Button>
        )}
      </Flex>
    </Flex>
  );
};

export default Navbar;
