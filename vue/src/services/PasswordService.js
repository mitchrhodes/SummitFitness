import axios from 'axios';

const path = '/changePassword';

export default {
    changePassword(user)  {
        return axios.put(path, user)
    }
}