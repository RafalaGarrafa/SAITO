import { Typography, Card, CardContent, Box, TextField, makeStyles,
Button, Grid, Paper} from '@material-ui/core';
import React, {useEffect, useState, Fragment} from 'react';
import {Register} from '../../api/UserAPI';
import {useAlert} from "react-alert";
import { Height } from '@material-ui/icons';

const LogIn = () => {
    const paperStyle = {padding: 20, height: 700, width: 400, margin: "20px auto "};
    
    return(
        <Grid>
            <Paper elevation = {10} style = {paperStyle}> SIGN IN</Paper>
        </Grid>
    )
}
export default LogIn;