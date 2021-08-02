import axios from 'axios';

const path = '/changePassword';

export default {
    changePassword(user) {//, newPassword) {
        return axios.put(path, user)
    }
}