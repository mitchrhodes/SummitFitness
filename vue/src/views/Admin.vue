<template>
  <div>
    <a class="btn btn-primary" v-on:click="isAddNewForm = true"
      >Creat Virtual Event</a
    >
    <form v-show="isAddNewForm" @submit.prevent="addEvent">
      <label for="name">Name</label>
      <input type="text" id="name" v-model="event.name" />
      <label for="description">Description</label>
      <input type="text" id="description" v-model="event.description" />
      <label for="type">Activity Type</label>
      <select v-model="event.type">
        <option>Running</option>
        <option>Walking</option>
        <option>Biking</option>
        <option>Swimming</option>
      </select>
      <label for="duration">Activity Duration in Days</label>
      <input type="text" id="duration" v-model="event.duration" />
      <button class="btn btn-lg btn-primary btn-block" type="submit">
        Create Event
      </button>
    </form>
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
            <a
              class="btn btn-success"
              v-on:click="addAdmin(user)"
              v-show="user.role === 'user'"
            >
              Make Administrator
            </a>
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
      isAddNewForm: false,
      event: {
        name: "",
        description: "",
        type: "",
        duration: "",
      },
    };
  },
  created() {
    userService.getUsers().then((response) => {
      this.users = response.data;
    });
  },
  methods: {
    addAdmin(user) {
      userService
        .updateAdmin(user)
        .then((response) => {
          console.log(response.status);
        })
        .catch((error) => {
          console.log(error.response);
        });
      this.$router.go();
    },

    addEvent() {
      userService
        .addEvent(this.event)
        .then((response) => {
          console.log(response.status);
        })
        .catch((error) => {
          console.log(error.response);
        });
    },
  },
};
</script>

<style>
</style>