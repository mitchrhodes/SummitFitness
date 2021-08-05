<template>
  <div class="home">
    <h1>Home</h1>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Event</th>
          <th scope="col">Description</th>
          <th scope="col">Type</th>
          <th scope="col">Duration</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
      <tr v-for="event in events" v-bind:key="event.name">
          <td>{{event.name }}</td>
          <td>{{ event.description }}</td>
          <td>{{ event.type }}</td>
          <td>{{ event.duration }}</td>
         <!-- <td>
            <a
              class="btn btn-success"
              v-on:click="signUp(event)"
              v-show="user.role === 'user'"
            >
              Make Administrator
            </a> 
          </td>-->
        </tr>
      </tbody> 
    </table>
  </div>
</template>

<script>
import homeService from "../services/HomeService";
export default {
  name: "home",
  data() {
    return {
      isEventsShown: false,
      events: [],
      event: {
        name: "",
        description: "",
        type: "",
        duration: "",
      },
    };
  },
  created() {
    homeService.getEvents().then((response) => {
      this.events = response.data;
    });
  },
};
</script>
