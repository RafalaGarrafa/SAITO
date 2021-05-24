import React, { Fragment } from 'react';
import {BrowserRouter as Router, Route} from "react-router-dom"

import {AppBar, Toolbar, Typography, IconButton, Container, Box,
createMuiTheme, MuiThemeProvider} from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';

import Index from './components/Index';
import UsersIndex from './components/users/Index'
import UserRegister from './components/users/Register'
import Login from './components/users/LogIn'



const satioTheme = createMuiTheme({
  palette: {
    primary: {
      main: "#f4f5ef"
    },
    secondary: {
      main: "#ff914c"
    },
    background: '#f4f5ef'
  }
})

function App() {
  return (
    <Fragment>
      <MuiThemeProvider theme={satioTheme}>
        <AppBar position="static">
          <Toolbar variant="dense">

            <IconButton 
              edge="start"  
              color="secondary" 
              aria-label="menu"
            >
              <MenuIcon />       
            </IconButton>

            <Typography variant="h6" color="secondary"> SATIO </Typography>

          </Toolbar>
        </AppBar>

        <Container maxWidth="sm">
          <Box mt = {10}>
            <Router>

            <Route exact path = '/' component = {Index}></Route>
            <Route exact path = '/Index' component = {Index}></Route>
            <Route exact path = '/users' component = {UsersIndex}></Route>
            <Route exact path = '/users/register' component = {UserRegister}></Route>
            <Route exact path = '/users/login' component = {Login}></Route>


            </Router>
          </Box>
        </Container>
      </MuiThemeProvider>
    </Fragment>

  );
}


export default App;

