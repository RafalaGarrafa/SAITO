import { Typography, Card, CardContent, Box, TextField, makeStyles,
Button, Grid, Paper, Avatar, FormControlLabel, Checkbox} from '@material-ui/core';
import React, {useEffect, useState, Fragment} from 'react';
import LockOutlineIcon from '@material-ui/icons/LockOutlined'

import {useAlert} from "react-alert";

const useSatioStyle = makeStyles( satioTheme => ({
    marginForm: {
        marginTop: satioTheme.spacing(3),
    },
    

}));

const LogIn = () => {
    const paperStyle = {padding: 20, height: 700, width: 400, margin: "20px auto "};
    const avatarStyle = {color: '#f4f5ef', backgroundColor: '#ff914c'};
    const btnStyle = { borderRadius: '27px'};

    const classes = useSatioStyle();
    const alert = useAlert();
    const [user, setUser] = useState ({
        name: "",
        lastName: "",
        email: "",
        profilePicture:""
    });
    
    const handleInputChange = (e) => {
        const {name, value} = e.target;
        setUser({
            ...user,
            [name]: value
        })
        
    };

    return(
        <Grid>
            <Paper elevation = {10} style = {paperStyle}> 
            
            <Grid align = 'center'>
                <Avatar style = {avatarStyle}> <LockOutlineIcon/></Avatar>
                <h3>SIGN IN</h3>
            </Grid>
            <TextField name ="name"  label="Name" className = {classes.marginForm} 
            fullWidth required inputProps = {{ maxLength: 30 }} value = {user.name} onChange = {handleInputChange}/>  

            <TextField name ="lastName" type = "password" label="Password" className = {classes.marginForm} 
            fullWidth required inputProps = {{ maxLength: 30 }} value = {user.lastName} onChange = {handleInputChange}/>  
            
            <a href = "/recipes" decoration = "none" ><Button type= "submit" color = "secondary" style = {btnStyle} variant = "contained" className = {classes.marginForm} fullWidth > Sign up </Button> </a>

            </Paper>
        </Grid>
    )
}
export default LogIn;