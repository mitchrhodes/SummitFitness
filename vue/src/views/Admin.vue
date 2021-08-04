<template>
  <div>
    <div class="text-center">
      <a class="btn btn-primary" v-on:click="isAddNewForm = true, isEventCreated = false"
        >Create Virtual Event</a
      >
    </div>
    <div class="alert alert-success" role="alert" v-show="isEventCreated">
      Event Created!
    </div>

    <form  v-show="isAddNewForm" @submit.prevent="addEvent">
      <div class="row">
        <div class="col">
          <label for="name">Name</label>
          <input
            type="text"
            id="name"
            class="form-control"
            v-model="event.name"
          />
        </div>
        <div class="col">
          <label for="description">Description</label>
          <input
            type="text"
            id="description"
            class="form-control"
            v-model="event.description"
          />
        </div>
      </div>
      <div class="row">
        <div class="col">
          <label for="type">Activity Type</label>
          <select v-model="event.type" class="form-control">
            <option>Running</option>
            <option>Walking</option>
            <option>Biking</option>
            <option>Swimming</option>
          </select>
        </div>
        <div class="col">
          <label for="duration">Activity Duration in Days</label>
          <input
            type="text"
            id="duration"
            class="form-control"
            v-model="event.duration"
          />
        </div>
      </div>
      <div class="text-center">
        <button class="btn btn-primary btn-block" type="submit">
          Create Event
        </button>
      </div>
    </form>
    <table class="table table-bordered table-hover mx-4">
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
      isEventCreated: false,
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
      this.isAddNewForm = false;
      this.isEventCreated = true;
      this.event = {};
    },
  },
};
</script>

<style>
</style>