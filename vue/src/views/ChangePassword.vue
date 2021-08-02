<template>
  <div>
    <form @submit.prevent="sendEmail">
      <label>Email Address</label>
      <input type="email" name="email_address" v-model="user.email" />
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
export default {
  name: "changePassword",
  data() {
    return {
      user: {
        email: "",
        newPassword: "",
        confirmNewPassword: "",
      },
    };
  },
  methods: {
  sendEmail: 


};
</script>

<style>
</style>