<template>
  <div class="home">
    <h1>Home</h1>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Event ID</th>
          <th scope="col">Event</th>
          <th scope="col">Description</th>
          <th scope="col">Type</th>
          <th scope="col">Duration</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
      <tr v-for="event in events" v-bind:key="event.name">
        <td>{{event.eventId}}</td>
          <td>{{event.name }}</td>
          <td>{{ event.description }}</td>
          <td>{{ event.type }}</td>
          <td>{{ event.duration }}</td>
          <td>
            <a class="btn btn-success" v-on:click="SignUp(event.eventId)">Sign Up For Event</a>
          </td>
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
        eventId: "",
        name: "",
        description: "",
        type: "",
        duration: "",
      },
      signUpInfo: {
        eventId: "",
        currentUserId: this.$store.state.user.userId,
      },
    };
  },
  created() {
    homeService.getEvents().then((response) => {
      this.events = response.data;
    });
  },
  methods: {
    SignUp(eventId) {
      this.signUpInfo.eventId = eventId;
         homeService
        .signUp(this.signUpInfo)
        .then((response) => {
          console.log(response.status);
        })
        .catch((error) => {
          console.log(error.response);
        });
    


    }
  },
};
</script>
