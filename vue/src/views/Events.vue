<template>
  <div>
    <h1>EVENTS</h1>
    <!-- added alert for event sign up -->
     <div class="alert alert-success mx-4" role="alert" v-show="isEventSignedUp">
      You are signed up for this event!
      <button
        type="button"
        class="close btn bg-transparent text-right"
        data-dismiss="alert"
        aria-label="Close"       
      >
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Event ID</th>
          <th scope="col">Event</th>
          <th scope="col">Description</th>
          <th scope="col">Type</th>
          <th scope="col">Duration</th>
          <th scope="col"></th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="userEvent in userEvents" v-bind:key="userEvent.name">
          <td>{{ userEvent.eventId }}</td>
          <td>{{ userEvent.name }}</td>
          <td>{{ userEvent.description }}</td>
          <td>{{ userEvent.type }}</td>
          <td>{{ userEvent.duration }}</td>  
          <td>
            <a class="btn btn-success" 
              >Add Progress</a
            >
          </td>      
        
        </tr>
      </tbody>
    </table>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Event ID</th>
          <th scope="col">Event</th>
          <th scope="col">Description</th>
          <th scope="col">Type</th>
          <th scope="col">Duration</th>
          <th scope="col"></th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="event in events" v-bind:key="event.name">
          <td>{{ event.eventId }}</td>
          <td>{{ event.name }}</td>
          <td>{{ event.description }}</td>
          <td>{{ event.type }}</td>
          <td>{{ event.duration }}</td>         
          <td>
            <a class="btn btn-success" v-on:click="SignUp(event.eventId)"
              >Sign Up For Event</a
            >
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import eventService from "../services/EventService"
export default {
  name: "events",
  data() {
    return {
      events: [],
      event: {
        eventId: "",
        name: "",
        description: "",
        type: "",
        duration: "",
      },
      userEvents: [],
      userEvent: {
        eventId: "",
        name: "",
        description: "",
        type: "",
        duration: "",
      },
      signUpInfo: {
        eventId: "",
        userId: "",
      },
      userId: {
        userId: 0,
      },
      isEventSignedUp: false,
      
  }
  },
  created() {
    this.userId.userId = this.$store.state.user.userId;
    eventService.getUserEvents(this.userId.userId).then((response) => {
      this.userEvents = response.data;
    });
    eventService.getEvents().then((response) => {
      this.events = response.data;
    });
  },
  methods: {
    SignUp(eventId) {
      this.signUpInfo.eventId = eventId;
      this.signUpInfo.userId = this.$store.state.user.userId;
      eventService
        .signUp(this.signUpInfo)
        .then((response) => {
          console.log(response.status + "We got here");
        })
        .catch((error) => {
          console.log(error.response);
        });
        this.isEventSignedUp = true;
        
    },       
  },
};
</script>

<style>
</style>