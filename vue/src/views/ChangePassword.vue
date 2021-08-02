<template>
  <div>
    <form @submit.prevent="sendEmail">
      <label>Email Address</label>
      <input type="text" name="email_address" v-model="user.emailAddress" />'
      <label>Username</label>
      <input type="text" name="username" v-model="user.username" />'
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
        emailAddress: "",
        username: "",
        newPassword: "",
        confirmNewPassword: "",
      },
    };
  },
  methods: {
    sendEmail() {
      if (this.user.newPassword === this.user.confirmNewPassword) {
        passwordService
          .changePassword(this.user)
          .then((response) => {
            console.log(response.status);
          })
          .catch((error) => {
            console.log(error.response);
          });
      } else {
        this.$router.push("/");
      }
    },
  },
};
</script>

<style>
</style>