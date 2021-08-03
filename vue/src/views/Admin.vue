<template>
  <div>
    <table class="table table-bordered table-hover">
      <thead>
        <tr>
          <th scope="col">Username</th>
          <th scope="col">Email Address</th>
          <th scope="col">Role</th>
          <th scope="col">Make User Admin</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(user, index) in users" v-bind:key="index">
          <td>{{user.username}}</td>
          <td>{{user.emailAddress}}</td>
          <td>{{user.role}}</td>
          <td>
            <a class="btn btn-success"> Make Administrator </a>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import userService from "../services/UserService";
export default {
data() {
    return {
      users:[
        {
        user:{
        emailAddress: "",
        username: "",
        role:"",
    
      }}]
    };
},

  created() 
  {
    userService.getUsers()
          .then((response) => {
            console.log(response.status);
          })
          .catch((error) => {
            console.log(error.response);
          });
  },
  
};
  
  


</script>

<style>
</style>