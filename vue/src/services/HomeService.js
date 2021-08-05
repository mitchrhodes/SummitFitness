import axios from 'axios';

const path =  '/';

export default {

  getEvents() {
    return axios.get(path)
  },
  signUp(signUpInfo) {
    return axios.post(path, signUpInfo)
  }

}