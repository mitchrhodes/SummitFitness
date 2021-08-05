import axios from 'axios';

const path = "/goals";

export default{
   
    addEvent(event) {
        return axios.post(path, event)
    }
}