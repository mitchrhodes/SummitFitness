<template>
  <div>
    <div
      class="p-5 text-center bg-image"
      style="
        background-image: url('https://images.unsplash.com/photo-1512588571475-d3791d9ffecc?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1489&q=80');
        height: 300px;
        max-width: 100%;
        margin-top: 58px;
      "
    >
      <div class="d-flex justify-content-center align-items-center h-100">
        <div class="text-black">
          <h1 class="mb-3">Events</h1>
        </div>
      </div>
    </div>
    <!-- added alert for event sign up -->
      <div id="eventSignedUp" class="alert alert-dismissible fade show" role="alert" v-show="isEventSignedUp">You are signed up for this event!!
      <button
        type="button"
        class="close btn bg-transparent text-right"
        data-dismiss="alert"
        aria-label="Close"
        v-on:click="refreshPage"
      >
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
     <div id="progressUpdated" class="alert alert-dismissible fade show" role="alert" v-show="isProgressUpdated">Progress has been updated!!

      <button
        type="button"
        class="close btn bg-transparent text-right"
        data-dismiss="alert"
        aria-label="Close"
        v-on:click="(isProgressUpdated = false), refreshPage()"
      >
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <br />
    <form
      v-show="isAddProgress"
      @submit.prevent="logEventProgress(), (isAddProgress = false)"
    >
      <label for="progress">Progress Towards Event Completion: </label>
      <input
        type="number"
        id="progress"
        v-model="updateEventProgress.distanceProgress"
      />
      <button class="btn " type="submit">
        Update Progress
      </button>
    </form>
    <br />

    <h1>Your Registered Events</h1>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Event ID</th>
          <th scope="col">Event</th>
          <th scope="col">Description</th>
          <th scope="col">Type</th>
          <th scope="col">Event Length</th>
          <th scope="col">Progress</th>
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
          <td>{{ userEvent.duration }} days</td>
          <td>{{ userEvent.distanceProgress }} miles</td>
          <td>
            <a
              class="btn"
              v-on:click="
                (isAddProgress = true),
                  (updateEventProgress.eventId = userEvent.eventId)
              "
              >Add Progress</a
            >
          </td>
          <td>
            <router-link class='btn' v-bind:to='{ name: "leaderboard", params:{eventId: userEvent.eventId }}'>View Leaderboard</router-link>
          </td>
          <td></td>
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
          <th scope="col">Event Length</th>
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
          <td>{{ event.duration }} days</td>
          <td>
            <a class="btn" v-on:click="SignUp(event.eventId)"
              >Sign Up For Event</a
            >
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import eventService from "../services/EventService";
export default {
  name: "events",
  data() {
    return {
      isAddProgress: false,
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
        distanceProgress: "",
      },
      signUpInfo: {
        eventId: "",
        userId: "",
      },
      userId: {
        userId: 0,
      },
      updateEventProgress: {
        eventId: 0,
        distanceProgress: "",
      },
      isEventSignedUp: false,
      isProgressUpdated: false,
    };
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
    logEventProgress() {
      eventService
        .logEvent(this.updateEventProgress)
        .then((response) => {
          console.log(response.status);
        })
        .catch((error) => {
          console.log(error.response);
        });
      this.updateEventProgress = {};
      this.isAddProgress = false;
      this.isProgressUpdated = true;
    },
    refreshPage() {
      this.$router.go();
    },
  },
};
</script>

<style>
#eventSignedUp{
  background-color: #489CA5;
  color: white;
}
#progressUpdated{
  background-color: #489CA5;
  color: white;
}
.btn {
  background-color: #4A9081 !important;
  outline-color: #2D474D !important;
  color: white;
}
</style>