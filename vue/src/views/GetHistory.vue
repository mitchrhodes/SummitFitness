<template>
<div>
<h1>Your Registered Events</h1>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Name</th>
          <th scope="col">Date</th>
          <th scope="col">Distance Progress</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="userEvent in userEvents" v-bind:key="userEvent.name">
          <td>{{ userEvent.name }}</td>
          <td>{{ userEvent.description }}</td>
          <td>{{ userEvent.type }}</td>
          <td>{{ userEvent.type }}</td>

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
        history:[],
        activity:{

            eventName: "",
            date: "",
            distanceProgress: "",
            goalName: "",
        
        }
    } 
},
created() {
    historyService.getHistory().then((response) => {
      this.history = response.data;
    });
  },
}
</script>

<style>

</style>