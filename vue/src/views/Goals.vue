<template>
  <div>
    <h1>GOALS</h1>
    <div class="alert alert-success mx-4" role="alert" v-show="isEventCreated">
      Event Created!
      <button
        type="button"
        class="close btn bg-transparent text-right"
        data-dismiss="alert"
        aria-label="Close"
        v-on:click="isEventCreated = false"
      >
        <span aria-hidden="true">&times;</span>
      </button>
    </div>

    <form class="mx-4" v-show="isAddNewForm" @submit.prevent="addGoal">
      <div class="row">
        <div class="col">
          <label for="name">Name</label>
          <input
            type="text"
            id="name"
            class="form-control"
            v-model="goal.name"
          />
        </div>
        <div class="col">
          <label for="description">Description</label>
          <input
            type="text"
            id="description"
            class="form-control"
            v-model="goal.description"
          />
        </div>
      </div>
      <div class="row">
        <div class="col">
          <label for="type">Activity Type</label>
          <select v-model="goal.type" class="form-control">
            <option>Running</option>
            <option>Walking</option>
            <option>Biking</option>
            <option>Swimming</option>
          </select>
        </div>
        <div class="col">
          <label for="duration">Goal Duration in Days</label>
          <input
            type="number"
            step="1"
            id="duration"
            class="form-control"
            v-model="goal.time"
          />
        </div>
        <div class="col">
          <label for="duration">Goal Distance</label>
          <input
            type="number"
            step="1"
            id="duration"
            class="form-control"
            v-model="goal.distance"
          />
        </div>
      </div>
      <div class="text-center my-3">
        <button class="btn btn-primary btn-block" type="submit">
          Create Event
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import goalService from "../services/GoalService"
export default {
  name: "goals",
  data() {
    return {
      isGoalCreated : false,
      isAddNewForm: false,
      goals: [],
      goal: {
          name: "",
          description: "",
          type: "",
          time: "",
          distance: ""
      },
    };
  },
  methods: {

  addEvent() {
      goalService
        .addGoal(this.goal)
        .then((response) => {
          console.log(response.status);
        })
        .catch((error) => {
          console.log(error.response);
        });
      this.isAddNewForm = false;
      this.isGoalCreated = true;
      this.goal = {};
    },
  }
};
</script>

<style>
</style>