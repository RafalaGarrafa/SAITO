import { Typography, Card, CardContent, Box, TextField, makeStyles,
Button} from '@material-ui/core';
import React, {useEffect, useState, Fragment} from 'react';
import {Register} from '../../api/UserAPI';

const useSatioStyle = makeStyles( satioTheme => ({
    marginForm: {
        marginTop: satioTheme.spacing(3),
    },

  }));



const UserRegister = (props) => {

    const classes = useSatioStyle();

    const [user, setUser] = useState ({
        name: "",
        lastName: "",
        email: "",
        profilePicture:"",
        idContactInfo: ""
    });

    const userSubmit = async (e) => {
        e.preventDefault();
        await Register(user);
    };

    const handleInputChange = (e) => {
        const {name, value} = e.target;
        setUser({
            ...user,
            [name]: value
        })
        
    };

    return ( 

        <Fragment>
            <Typography variant="h5"> SIGN UP </Typography>

            <Box mt={2}>
                <Card>
                    <CardContent>
                        <form onSubmit = {userSubmit}>

                            <TextField name ="name" variant = "outlined" label="Name" className = {classes.marginForm} 
                            fullWidth required inputProps = {{ maxLength: 30 }} value = {user.name} onChange = {handleInputChange}/>  

                            <TextField name ="lastName" variant = "outlined" label="Last name" className = {classes.marginForm} 
                            fullWidth required inputProps = {{ maxLength: 30 }} value = {user.lastName} onChange = {handleInputChange}/>  

                            <TextField name ="email" variant = "outlined" label="Email" className = {classes.marginForm} 
                            fullWidth required inputProps = {{ maxLength: 50 }} value = {user.email} onChange = {handleInputChange}/>   

                            <Button type= "submit" color = "secondary" variant = "contained" className = {classes.marginForm}> Sign up </Button>
                        
                        </form>
                    </CardContent>
                </Card>
            </Box>

        </Fragment>
    );
}

export default UserRegister;