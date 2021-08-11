<template>
  <div>
    <br />
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
        <tr v-for="progress in userProgress" v-bind:key="progress.name">
          <td>{{ progress.eventName }}</td>
          <td>{{ progress.userName }}</td>
          <td>{{ progress.distanceProgress }} miles</td>        
         
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
        <tr v-for="leader in leaderboard" v-bind:key="leader.name">
          <td>{{ leader.eventName}}</td>
          <td>{{ leader.userName }}</td>
          <td>{{ leader.distanceProgress }} miles</td>      
         
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
            eventName: "",
            username: "",
            distanceProgress: ""
        },
        leaderboard: [],
        leader: {
            eventName: "",
            username: "",
            distanceProgress: ""
        }

    }
    },
    created() {
      const eventId = this.$route.params.eventId;
       leaderboardService.getLeaders(eventId).then((response) => {
      this.leaderboard = response.data;
    });
    leaderboardService.getUserProgress(eventId).then((response) => {
      this.userProgress = response.data;
    });
   
  },
};
</script>

<style>
</style>