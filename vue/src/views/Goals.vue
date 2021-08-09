<template>
  <div>
    <div
      class="p-5 text-center bg-image img-fluid img-responsive"
      style="
        background-image: url('https://images.unsplash.com/photo-1551632811-561732d1e306?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8dHJla2tpbmd8ZW58MHx8MHx8&ixlib=rb-1.2.1&w=1000&q=80');
        background-size: cover;
        object-fit: contain;
        height: 300px;
        max-width: 100%;
        margin-top: 58px;
      "
    >
      <div class="d-flex justify-content-center align-items-center h-100">
        <div class="text-black">
          <h1 class="mb-3">Goals</h1>
        </div>
      </div>
    </div>

    <!-- Added alert to progress updated, this refreshes the page when closed out so progress updates on screen-->
    <div
      class="alert alert-success mx-4"
      role="alert"
      v-show="isProgressUpdated"
    >
      Progress has been updated!
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
    <br>
    <form
      v-show="isAddProgress"
      @submit.prevent="logGoal(), (isAddProgress = false)"
    >
      <label for="progress">Progress Towards Goal Completion: </label>
      <input
        type="number"
        id="progress"
        v-model="updateProgress.distanceProgress"
      />
      <button class="btn btn-primary btn-block" type="submit">
        Update Progress
      </button>
    </form>
    <br>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Goal ID</th>
          <th scope="col">Name</th>
          <th scope="col">Description</th>
          <th scope="col">Type</th>
          <th scope="col">Duration</th>
          <th scope="col">Distance</th>
          <th scope="col">Progress</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="goal in goals" v-bind:key="goal.name">
          <td>{{ goal.goalId }}</td>
          <td>{{ goal.name }}</td>
          <td>{{ goal.description }}</td>
          <td>{{ goal.type }}</td>
          <td>{{ goal.duration }}</td>
          <td>{{ goal.distance }}</td>
          <td>{{ goal.distanceProgress }}</td>
          <td>
            <a
              class="btn btn-success"
              v-on:click="
                (isAddProgress = true), (updateProgress.goalId = goal.goalId)
              "
              >Add Progress</a
            >
          </td>
        </tr>
      </tbody>
    </table>
    <div class="text-center">
      <a
        class="btn btn-primary my-3"
        v-on:click="(isAddNewForm = true), (isGoalCreated = false)"
        >Add Goal</a
      >
    </div>
    <div class="alert alert-success mx-4" role="alert" v-show="isGoalCreated">
      Event Created!
      <button
        type="button"
        class="close btn bg-transparent text-right"
        data-dismiss="alert"
        aria-label="Close"
        v-on:click="isGoalCreated = false"
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
            v-model="goal.duration"
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
import goalService from "../services/GoalService";
export default {
  name: "goals",
  data() {
    return {
      isAddProgress: false,
      isGoalCreated: false,
      isAddNewForm: false,
      isProgressUpdated: false,
      goals: [],
      goal: {
        goalId: 0,
        userId: "",
        name: "",
        description: "",
        type: "",
        duration: "",
        distance: "",
        distanceProgress: "",
        time: "",
        timeProgress: "",
      },
      updateProgress: {
        goalId: 0,
        distanceProgress: "",
      },
      //udate history log JSON data type
      updateHistoryLog: {
        goalId: 0,
        userId: "",
        distanceProgress: 0,
      },
    };
  },
  created() {
    this.goal.userId = this.$store.state.user.userId;
    goalService.getGoals(this.goal.userId).then((response) => {
      this.goals = response.data;
    });
  },
  methods: {
    addGoal() {
      this.goal.userId = this.$store.state.user.userId;
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

    logGoal() {
      goalService
        .logGoal(this.updateProgress)
        .then((response) => {
          console.log(response.status);
        })
        .catch((error) => {
          console.log(error.response);
        });
      this.updateProgress = {};
      this.isAddProgress = false;
      this.isProgressUpdated = true;
      //this.$router.go();  took this out as it seems to be the issue with update progress only workign some of the time
    },
    //created refresh page method to be used when needed
    refreshPage() {
      this.$router.go();
    },
    //added update to history method
    // addUpdateToHistoryLog(id) {
    //   this.updateHistoryLog.goalId = id;
    //   this.updateHistoryLog.userId = this.$store.state.user.userId;
    //   this.updateHistoryLog.distanceProgress = this.updateProgress.distanceProgress;
    //   goalService
    //     .updateHistoryLog(this.updateHistoryLog, id)
    //     .then((response) => {
    //       console.log(response.status);
    //     })
    //     .catch((error) => {
    //       console.log(error.response);
    //     });
    // },
  },
};
</script>

<style>
</style>