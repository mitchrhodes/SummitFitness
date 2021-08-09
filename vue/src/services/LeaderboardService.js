import axios from 'axios';

const path = "/leaderboard";

export default{
   
    
    getLeaders(eventId){
        return axios.get(path + "/"+ eventId)
    },
    getUserProgress(){
        return axios.get(path)
    },
   
}