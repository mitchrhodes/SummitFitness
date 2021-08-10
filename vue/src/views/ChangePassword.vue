<template>
  <div>
    <br>
    <br>
    <br>
    <br>
    <h4 class="text-center">Change Password</h4>
    <div class="alert alert-success" role="alert" v-show="isPasswordChanged">Password Changed!</div>
    <form @submit.prevent="sendEmail" class="mx-4">
      <div class="row">
        <div class="col">
          <label>Email Address</label>
          <input
            class="form-control"
            type="text"
            name="email_address"
            v-model="user.emailAddress"
          />
        </div>
        <div class="col">
          <label>Username</label>
          <input
            type="text"
            name="username"
            class="form-control"
            v-model="user.username"
          />
        </div>
      </div>
      <div class="row">
        <div class="col">
          <label>New Password</label>
          <input
            type="password"
            class="form-control"
            name="new_password"
            v-model="user.newPassword"
          />
        </div>
        <div class="col">
          <label>Confirm New Password</label>
          <input
            class="form-control"
            type="password"
            name="confirm_new_password"
            v-model="user.confirmNewPassword"
          />
        </div>
      </div>
      <input class="btn btn-success my-3" type="submit" value="Send" />
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
      isPasswordChanged: false,
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
      this.isPasswordChanged = true;
      this.user = {};
    },
  },
};
</script>

<style>

.btn {
  background-color: #489CA5 !important;
  outline-color: #2D474D !important;
}
</style>