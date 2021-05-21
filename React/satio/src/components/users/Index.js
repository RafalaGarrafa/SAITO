import React, {useEffect} from 'react';
import {GetAll} from '../../api/UserAPI'

const UsersIndex = (props) => {

    useEffect(() =>{
        async function fetchData() {
            await GetAll();
        }
        fetchData();
    }, []);


    return  <div> Usuarios </div> ;
}
export default UsersIndex;