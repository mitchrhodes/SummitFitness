<template>
  <div>
    <br />
    <br />
    <br />
    <img id="banner" src="https://i.postimg.cc/RhkNfKWW/summit8-1.png" alt="banner">
    <br />
    <h3 class="text-center">Welcome to Summit Fitness</h3>
    <br />
    <h6 class="text-center mx-5" >We all have our mountains to climb.  But no matter the size of the obstacle you're looking to overcome, the only way to get there is one step at a time. 
       At Summit Fitness, we're here for you every step you take on your fitness journey.  Whether you are looking to see how you stack up against the competition in our virtual events or
       have a distance goal you are trying to reach for the first time ever, let us help you reach your peak.  Track your progress, see results. 
</h6>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <div class="text-center">
      <router-link :to="{ name: 'register' }" class="btn btn-primary mx-3"
        >Create Account</router-link
      >
      <router-link :to="{ name: 'login' }" class="btn btn-primary mx-3"
        >Log In</router-link
      >
      <br>
      <br>
    </div>
  </div>
</template>

<script>
</script>

<style>
#banner{
  height: 300px;
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 90%;

}

</style>
