import axios from 'axios';

const path = "/events";

export default {

    getEvents() {
        return axios.get(path)
    },
    signUp(signUpInfo) {
        return axios.post(path, signUpInfo)
    }
}