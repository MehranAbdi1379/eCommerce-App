import { SearchIcon } from "@chakra-ui/icons";
import {
  Flex,
  Heading,
  InputGroup,
  InputLeftElement,
  Input,
  Menu,
  MenuButton,
  Button,
  MenuList,
  MenuItem,
  Text,
} from "@chakra-ui/react";
import React from "react";
import { useNavigate } from "react-router-dom";

const AdminNavbar = () => {
  const navigate = useNavigate();
  const token = localStorage.getItem("token");
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
        <Text border={"gray 1px solid"} padding={"0.25em"} fontSize={"1rem"}>
          Admin
        </Text>{" "}
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
                  navigate("/admin");
                  localStorage.removeItem("userId");
                  localStorage.removeItem("token");
                }}
              >
                Log Out
              </MenuItem>
            </MenuList>
          </Menu>
        )}
      </Flex>
    </Flex>
  );
};

export default AdminNavbar;
