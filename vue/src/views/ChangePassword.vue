<template>
  <div>
    <form @submit.prevent="sendEmail">
      <label>New Password</label>
      <input type="text" name="new_password" v-model="user.newPassword" />
      <label>Confirm New Password</label>
      <input
        type="text"
        name="confirm_new_password"
        v-model="user.confirmNewPassword"
      />
      <input type="submit" value="Send" />
    </form>
  </div>
</template>

<script>
// import emailjs from 'emailjs-com'
import passwordService from "../services/PasswordService";
export default {
  name: "changePassword",
  data() {
    return {
      user: {
        newPassword: "",
        confirmNewPassword: "",
      },
      changedUser: {
          user: this.$store.state.user,
          password: this.user.newPassword

      }
    };
  },
  methods: {
    sendEmail() {
      if (this.user.newPassword === this.user.confirmNewPassword) {
          
        passwordService.changePassword(
            this.changedUser
          //this.$store.state.user,
          //this.user.newPassword
        )
        .then (response => {
            console.log(response.status)
        })
        .catch(error => {
            console.log(error.response)
        })

      } else {
          this.$router.push('/');
      }
    },
  },
};
</script>

<style>
</style>