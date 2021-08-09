<template>
  <div class="home">
    <h1>Home</h1>
    <div class="text-center">
      <router-link class="btn btn-success" v-bind:to="{ name: 'goals' }">Goals</router-link>
   <router-link class="btn btn-success" v-bind:to="{ name: 'events' }">Events</router-link>
   <router-link class="btn btn-success" v-bind:to="{name: 'history'}">History</router-link> 
  </div>
  </div>
</template>

<script>

</script>
