import {axiosBase} from './AxiosConfig';

export const GetAll = async () => {
    try 
    {
        const response =await axiosBase.get("/Recipe/GetAll");
        
        console.log(response.data);
        return response.data;


    }catch(error){
        console.error(error);
        return error;
    }
};

export const Register = async (user) => {
    try 
    {
        const response = await axiosBase.post("/Recipe/Create", user);

        return true;

    }catch(error){

        return false;
    }
} 
  