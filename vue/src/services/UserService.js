import axios from 'axios';

const path = "/admin";

export default{
    getUsers(){
        return axios.get(path)
    }
}