import axios from 'axios';

const path = "/leaderboard";

export default{
   
    
    getLeaders(eventId){
        return axios.get(path + "/"+ eventId)
    },
    getUserProgress(eventId){
        return axios.get(path + "/user" + eventId)
    },
   
}