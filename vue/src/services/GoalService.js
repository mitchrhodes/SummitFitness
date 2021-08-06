import axios from 'axios';

const path = "/goals";

export default{
   
    addGoal(goal) {
        return axios.post(path, goal)
    },
    getGoals(userId){
        return axios.get(path + "/"+ userId)
    },
    logGoal(goal){
        return axios.put(path, goal)
    }
}