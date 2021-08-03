<template>
  <div>
    <table class="table table-bordered table-hover">
      <thead>
        <tr>
          <th scope="col">Username</th>
          <th scope="col">Email Address</th>
          <th scope="col">Role</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in users" v-bind:key="user.username">
          <td>{{ user.username }}</td>
          <td>{{ user.email }}</td>
          <td>{{ user.role }}</td>
          <td>
            <a class="btn btn-success" v-on:click="addAdmin(user)" v-show="user.role === 'user'"> Make Administrator </a>
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
      users: [],
      user: {
        email: "",
        username: "",
        role: "",
        userId: "",
      },
    };
  },
  created() {
    userService.getUsers().then((response) => {
      this.users = response.data;
    });
  },
  methods: {
    addAdmin(user){
      userService.updateAdmin(user)
       .then((response) => {
            console.log(response.status);
          })
          .catch((error) => {
            console.log(error.response);
          });
          this.$router.go();
    }
  }
    
  
};
</script>

<style>
</style>