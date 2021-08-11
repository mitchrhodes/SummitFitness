<template>
  <div class="admin">
    <br />
    <br />
    <br />
    <div class="text-center">
      <a
        class="btn my-3"
        v-on:click="(isAddNewForm = true), (isEventCreated = false)"
        >Create Virtual Event</a
      >
    </div>
    <div id="eventCreatedAlert" class="alert alert-dismissible fade show" role="alert" v-show="isEventCreated">
    Event Created!
    <button
        type="button"
        class="btn-close"
        data-bs-dismiss="alert"
        aria-label="Close"
        v-on:click="refreshPage"
      ></button>
      </div>

    <div id="newAdministratorAdded" class="alert alert-dismissible fade show" role="alert" v-show="isAdministratorAdded">New administrator added!

      <button
        type="button"
        class="btn-close"
        data-bs-dismiss="alert"
        aria-label="Close"
        v-on:click="refreshPage"
      ></button>
    </div>
    <form class="mx-4" v-show="isAddNewForm" @submit.prevent="addEvent">
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
            <option>Hiking</option>
            <option>Swimming</option>
          </select>
        </div>
        <div class="col">
          <label for="duration">Activity Duration in Days</label>
          <input
            type="number"
            step="1"
            id="duration"
            class="form-control"
            v-model="event.duration"
          />
        </div>
      </div>
      <div class="text-center my-3">
        <button class="btn btn-block" type="submit">
          Create Event
        </button>
      </div>
    </form>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Username</th>
          <th scope="col">Email Address</th>
          <th scope="col">Role</th>
          <th scope="col">Change Role</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in users" v-bind:key="user.username">
          <td>{{ user.username }}</td>
          <td>{{ user.email }}</td>
          <td>{{ user.role }}</td>
          <td>
            <a
              class="btn"
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
    },
    refreshPage(){
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
#eventCreatedAlert{
  background-color: #489CA5;
  color: white;
}
.btn {
  background-color: #489CA5 !important;
  outline-color: #2D474D !important;
  color: white;
}
</style>