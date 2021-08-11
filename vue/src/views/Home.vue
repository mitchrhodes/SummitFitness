<template>
  <div>
    <br />
    <br />
    <br />
    <br />
    <img
      id="banner"
      src="https://i.postimg.cc/RhkNfKWW/summit8-1.png"
      alt="banner"
    />
    <br />
    <h3 class="text-center">Welcome to Summit Fitness</h3>
    <br />
    <h6 class="text-center mx-5">
      We all have our mountains to climb. But no matter the size of the obstacle
      you're looking to overcome, the only way to get there is one step at a
      time. At Summit Fitness, we're here for you every step you take on your
      fitness journey. Whether you are looking to see how you stack up against
      the competition in our virtual events or have a distance goal you are
      trying to reach for the first time ever, let us help you reach your peak.
      Track your progress, see results.
    </h6>
    <br />
    <div id="firstRowPhotos" class="d-flex justify-content-around mx-3">
      <div class="photoCard">
        <img
          class="typePhoto"
          src="https://images.unsplash.com/photo-1592727995117-4cdc7ee6fcb4?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80"
          alt="walkin"
        />
        <h6 class="text-center pt-1">Walking</h6>
      </div>
      <div class="photoCard">
        <img
          class="typePhoto"
          src="https://images.unsplash.com/photo-1530138948699-6a75eebc9d9b?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1349&q=80"
          alt="swimmin"
        />
        <h6 class="text-center pt-1">Swimming</h6>
      </div>
      <div class="photoCard">
        <img
          class="typePhoto"
          src="https://images.unsplash.com/photo-1552674605-db6ffd4facb5?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80"
          alt="runnin"
        />
        <h6 class="text-center pt-1">Running</h6>
      </div>
    </div>
<br>
    <div id="secondRowPhotos" class="d-flex justify-content-around mx-3">
      <div class="photoCard">
        <img
          class="typePhoto"
          src="https://images.unsplash.com/photo-1541625810516-44f1ce894bcd?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80"
          alt="bikin"
        />
        <h6 class="text-center pt-1">Cycling</h6>
      </div>
      <div>
<img
      id="logo"
      src="https://i.ibb.co/93LNtrf/summit-Final.png"
    />
      </div>
      <div class="photoCard">
        <img
          class="typePhoto"
          src="https://images.unsplash.com/photo-1440186347098-386b7459ad6b?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80"
          alt="hikin"
        />
        <h6 class="text-center pt-1">Hiking</h6>
      </div>
      </div>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    
    <div class="text-center">
      <router-link :to="{ name: 'register' }" class="btn mx-3"
        >Create Account</router-link
      >
      <router-link :to="{ name: 'login' }" class="btn mx-3">Log In</router-link>
      <br />
      <br />
    </div>
  </div>
</template>

<script>
</script>

<style>
#banner {
  height: 300px;
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 90%;
}
.btn {
  background-color: #489ca5 !important;
  outline-color: #2d474d !important;
}
#logo {
  height: 175px;
  
}
.typePhoto {
  height: 175px;
  
  border-top-left-radius: 5px;
  border-top-right-radius: 5px;
}
.photoCard {
  background-color: #b3cfc7;
  border-radius: 5px;
}
#banner {
  border-radius: 5px;
}
</style>
