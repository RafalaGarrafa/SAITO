import {axiosBase} from './AxiosConfig';

export const GetAll = async () => {
    try 
    {
        const response =await axiosBase.get("/RegisteredRecipe/GetAll");
        
        return response.data;

    }catch(error){
        console.error(error);
        return error;
    }
};

export const Register = async (user) => {
    try 
    {
        const response = await axiosBase.post("/RegisteredRecipe/Create", user);

        return true;

    }catch(error){

        return false;
    }
} 
  