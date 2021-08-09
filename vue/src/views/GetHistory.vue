<template>
  <div>
    <br>
    <br>
    <br>
    <h1>Event History</h1>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Name</th>
          <th scope="col">Date</th>
          <th scope="col">Distance Progress</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="eventActivity in eventHistory" v-bind:key="eventActivity.name">
          <td>{{ eventActivity.name }}</td>
          <td>{{ eventActivity.date }}</td>
          <td>{{ eventActivity.distanceProgress }}</td>
        </tr>
      </tbody>
    </table>
    <h1>Goal History</h1>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Name</th>
          <th scope="col">Date</th>
          <th scope="col">Distance Progress</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="goalActivity in goalHistory" v-bind:key="goalActivity.name">
          <td>{{ goalActivity.name }}</td>
          <td>{{ goalActivity.date }}</td>
          <td>{{ goalActivity.distanceProgress }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import historyService from "../services/HistoryService";
export default {
name:"history",
data() {
    return {
        eventHistory:[],
        eventactivity:{

            eventName: "",
            date: "",
            distanceProgress: "",
        
        }, 
        goalHistory:[],
        goalActivity:{
            date: "",
            distanceProgress: "",
            goalName: "",
        
        }
    } 
},

created() {
    historyService.getEventHistory().then((response) => {
      this.eventHistory = response.data;
    });
    historyService.getGoalHistory().then((response) => {
      this.goalHistory = response.data;
    });
  },
}
</script>

<style>
</style>