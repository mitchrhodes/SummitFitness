import axios from 'axios';

const path = "/history";

export default{
   
  
    getEventHistory(){
        return axios.get(path)
    },
    getGoalHistory(){
        return axios.get(path + "/goal" )
    }
   
    
}