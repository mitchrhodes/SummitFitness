<template>
  <div>
    <form @submit.prevent="sendEmail">
      <div class="form-row">
        <div class="column">
          <label>Email Address</label>
          <input class="form-control"
            type="text"
            name="email_address"
            v-model="user.emailAddress"
          />
        </div>
        <div class="column">
          <label>Username</label>
          <input type="text" name="username" 
          class="form-control" v-model="user.username" />
        </div>
      </div>
      <div class="form-row">
        <div class="column">
          <label>New Password</label>
          <input type="text" class="form-control" name="new_password" v-model="user.newPassword" />
        </div>
        <div class="column">
          <label>Confirm New Password</label>
          <input
            class="form-control"
            type="text"
            name="confirm_new_password"
            v-model="user.confirmNewPassword"
          />
        </div>
      </div>
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