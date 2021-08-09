<template>
  <div>
    <br />
    <br />
    <h1>Your Event Progress</h1>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Event</th>
          <th scope="col">UserName</th>
          <th scope="col">Progress</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="userEvent in userEvents" v-bind:key="userEvent.name">
          <td>{{ userEvent.name }}</td>
          <td>{{ userEvent.userName }}</td>
          <td>{{ userEvent.distanceProgress }}</td>        
         
          <td></td>
        </tr>
      </tbody>
    </table>
    <br>
    <br>
    <h1>Event Leaderboard</h1>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Event</th>
          <th scope="col">UserName</th>
          <th scope="col">Progress</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="userEvent in userEvents" v-bind:key="userEvent.name">
          <td>{{ event.name}}</td>
          <td>{{ event.userName }}</td>
          <td>{{ event.distanceProgress }}</td>      
         
          <td></td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import leaderboardService from "../services/LeaderboardService";
export default {
    name: 'leaderboard',
    data() {
    return {
        userProgress:[],
        progress: {
            name: "",
            username: "",
            distanceProgress: ""
        },
        leaderboard: [],
        leader: {
            name: "",
            username: "",
            distanceProgress: ""
        }

    }
    },
    created() {
    leaderboardService.getUserProgress().then((response) => {
      this.userProgress = response.data;
    });
    leaderboardService.getLeaders().then((response) => {
      this.leaderboard = response.data;
    });
  },
};
</script>

<style>
</style>