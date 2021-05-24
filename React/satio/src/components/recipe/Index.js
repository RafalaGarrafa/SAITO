import React, {useEffect, useState, Fragment} from 'react';
import {GetAll} from '../../api/UserAPI'

import {Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper,
Typography, Box, Fab, Grid} from '@material-ui/core';

import AddIcon from '@material-ui/icons/Add';


const RecipeIndex = (props) => {

    const[ recipe, setRecipe] = useState([]);

    useEffect(() =>{
        async function fetchData() {
            const recipeResult = await GetAll();
            setRecipe(recipeResult);
        }

        fetchData();
    }, []);
    


    return  (

        <Fragment>  
            <Box mt = {2}>
                <TableContainer component = { Paper }>
                    <Table>
                        <TableHead>
                            <TableRow>

                                <TableCell> Name </TableCell>
                                <TableCell> Ingredients </TableCell>
                                <TableCell> Description </TableCell>

                            </TableRow>
                        </TableHead>

                        <TableBody>

                            {/*  TRAER DATOS DEL VISUAL

                            {recipes.map((item, index) => (

                                <TableRow key = {index}>

                                <TableCell> {item.name} </TableCell>
                                <TableCell> {item.ingredients} </TableCell>
                                <TableCell> {item.description} </TableCell>

                                </TableRow>
                            ))}*/} 

                        </TableBody>
                    </Table>
                </TableContainer>
            </Box>

            <Grid container>

                <Grid item xs={10}>
                    <Typography varient = "h3"></Typography>
                </Grid>

                <Grid item container xs={2} justify = "flex-end" alignItems = "center">
                    <Box mt = {2} >
                        <Fab size = "small" color="primary" aria-label="add" href = "/recipes/register"> <AddIcon /> </Fab>
                    </Box>
                </Grid>

            </Grid>  

        </Fragment>
    )
}
export default RecipeIndex;