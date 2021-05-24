import { Typography, Card, CardContent, Box, TextField, makeStyles,
    Button} from '@material-ui/core';
    import React, {useEffect, useState, Fragment} from 'react';
    import {Register} from '../../api/UserAPI';
    import {useAlert} from "react-alert";
    
    const useSatioStyle = makeStyles( satioTheme => ({
        marginForm: {
            marginTop: satioTheme.spacing(3),
        },
    
    }));
    
    
    
    const RecipeRegister = (props) => {
    
        const classes = useSatioStyle();
        const alert = useAlert();
        const [recipe, setRecipes] = useState ({
            name: "",
            ingredients: "",
            description: "",
           
        });
    
        const recipeSubmit = async (e) => {
            e.preventDefault();
            const response = await Register(recipe);
            console.log("No se que onda" + response);
            if(response){
                alert.success("Yummi yummi <3");
                
                //redirigirla a su menú
                props.history.push("/users");
            }else{
                alert.error("ugh, C'mon! Let's try again... sorry :c \n\n That was so delicious btw");
                //redirigirla a su menú
                props.history.push("/users/register");
            }
        };
    
        const handleInputChange = (e) => {
            const {name, value} = e.target;
            setRecipe({
                ...recipe,
                [name]: value
            })
            
        };
    
        return ( 
    
            <Fragment>
        
                <Box mt={2}>
                    <Card>
                        <CardContent>
                        <h3 align='center'> SIGN UP</h3>
                        
    
                            <form onSubmit = {userSubmit}>
    
                                <TextField name ="name / e"  label="Name" className = {classes.marginForm} 
                                fullWidth required inputProps = {{ maxLength: 30 }} value = {recipe.name} onChange = {handleInputChange}/>  
    
                                <TextField name ="ingredients"  label="Ingredients" className = {classes.marginForm} 
                                fullWidth required inputProps = {{ maxLength: 30 }} value = {recipe.ingredients} onChange = {handleInputChange}/>  
    
                                <TextField name ="description"  label="Description" className = {classes.marginForm} 
                                fullWidth required  value = {recipe.description} onChange = {handleInputChange}/>   
    
                                <Button type= "submit" color = "secondary" variant = "contained" className = {classes.marginForm}> Sign up </Button>
                            
                            </form>
                        </CardContent>
                    </Card>
                </Box>
    
            </Fragment>
        );
    }
    
    export default RecipeRegister;