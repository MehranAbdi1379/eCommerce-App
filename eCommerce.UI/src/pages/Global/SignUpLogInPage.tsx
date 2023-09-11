import {
  Container,
  Tab,
  TabList,
  TabPanel,
  TabPanels,
  Tabs,
} from "@chakra-ui/react";
import SignInContainer from "../../components/Global/SignIn";
import SignUpContainer from "../../components/Global/SignUp";

const SignUpLogInPage = () => {
  return (
    <Container border={"2px solid gray"} borderRadius={"10px"} padding={"20px"}>
      <Tabs variant={"enclosed"}>
        <TabList>
          <Tab>Log In</Tab>
          <Tab>Sign Up</Tab>
        </TabList>
        <TabPanels>
          <TabPanel marginTop={5}>
            <SignInContainer></SignInContainer>
          </TabPanel>
          <TabPanel marginTop={5}>
            <SignUpContainer></SignUpContainer>
          </TabPanel>
        </TabPanels>
      </Tabs>
    </Container>
  );
};

export default SignUpLogInPage;
