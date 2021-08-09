import axios from 'axios';

const path = "/history";

export default{
   
  
    getHistory(){
        return axios.get(path)
    },
   
    
}