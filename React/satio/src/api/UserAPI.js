import {axiosBase as axios} from './AxiosConfig';

export const GetAll = async () => {
    try 
    {
        const response =await axios.get("/RegisteredUser/GetAll");
        console.log("Getall", response);
    }catch(error){
        console.error(error);
        return error;
    }
}
 
  