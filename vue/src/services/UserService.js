import axios from 'axios';

const path = "/admin";

export default{
    getUsers(){
        return axios.get(path)
    },
    updateAdmin(user){
        return axios.put(path, user)
    },
    addEvent(event) {
        return axios.post(path, event)
    }
}