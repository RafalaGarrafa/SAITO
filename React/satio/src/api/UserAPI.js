import {axiosBase} from './AxiosConfig';

export const GetAll = async () => {
    try 
    {
        const response =await axiosBase.get("/RegisteredUser/GetAll");
        console.log("Getall", response);
    }catch(error){
        console.error(error);
        return error;
    }
}
 
  