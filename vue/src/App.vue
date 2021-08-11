<template>
  <div id="app" v-bind:style="{ backgroundColor: a4bdc5}">
    <nav id="navbar-design" class="navbar navbar-expand-lg fixed-top">
      <div class="container-fluid">
        <img class="navbar-brand" src="https://i.ibb.co/mqm8QS9/summit-Logo-Cropped.png" alt="..." height="55">
        <button
          class="navbar-toggler"
          type="button"
          data-mdb-toggle="collapse"
          data-mdb-target="#navbarExample01"
          aria-controls="navbarExample01"
          aria-expanded="false"
          aria-label="Toggle navigation"
        > 
          <i class="fas fa-bars"></i>
        </button> 
        <div class="collapse navbar-collapse" id="navbarExample01">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item active">
              <router-link class="nav-link" v-bind:to="{ name: 'home' }"
                >Home</router-link
              >
            </li>
            <li class="nav-item active">
              <router-link
                class="nav-link"
                v-bind:to="{ name: 'login' }"
                v-show="!isUser(this.$store.state.user) && !isAdmin(this.$store.state.user)"
                >Log In</router-link
              >
            </li>
            <li class="nav-item active">
              <router-link
              
                class="nav-link"
                v-bind:to="{ name: 'register' }"
               v-show="!isUser(this.$store.state.user) && !isAdmin(this.$store.state.user)"
                >Create Account</router-link
              >
            </li>
            <li class="nav-item">
              <router-link
                class="nav-link"
                v-show="
                  isAdmin(this.$store.state.user) ||
                  isUser(this.$store.state.user)
                "
                v-bind:to="{ name: 'logout' }"
                v-if="$store.state.token != ''"
                >Logout</router-link
              >
            </li>
            <li class="nav-item">
              <router-link
                v-show="
                  isAdmin(this.$store.state.user) ||
                  isUser(this.$store.state.user)
                "
                v-bind:to="{ name: 'changePassword' }"
                class="nav-link"
                >Change Password</router-link
              >
            </li>
            <li class="nav-item">
              <router-link
                v-show="
                  isAdmin(this.$store.state.user) ||
                  isUser(this.$store.state.user)
                "
                v-bind:to="{ name: 'goals' }"
                class="nav-link"
                >Goals</router-link
              >
            </li>
            <li class="nav-item">
              <router-link
                v-show="
                  isAdmin(this.$store.state.user) ||
                  isUser(this.$store.state.user)
                "
                v-bind:to="{ name: 'events' }"
                class="nav-link"
                >Events</router-link
              >
            </li>

            <li class="nav-item">
              <router-link
                v-show="
                  isAdmin(this.$store.state.user) ||
                  isUser(this.$store.state.user)
                "
                v-bind:to="{ name: 'history' }"
                class="nav-link"
                >History</router-link
              >
            </li>
            <li class="nav-item">
              <router-link
                v-show="isAdmin(this.$store.state.user)"
                v-bind:to="{ name: 'admin' }"
                class="nav-link"
                >Administrator</router-link
              >
            </li>
          </ul>
        </div>
      </div>
    </nav>

    <router-view />
  </div>
</template>
<script>
export default {
  data() {
    return {
      isLoggedIn: false,
    };
  },
  methods: {
    isAdmin(user) {
      if (user.role === "admin") {
        return true;
      }
      return false;
    },
    isUser(user) {
      if (user.role === "user") {
        return true;
      }
      return false;
    },
  },
};
</script>

<style >
#app {
  background-color: #a4bdc5;
}

#navbar-design {
  background-color: #b3cfc7;
  color: #ffffff;
}
nav .navbar-nav li a {
  color: #2D474D;
  
}
nav .navbar-nav li a:hover {
  color: #A4BDC5;
  
}
router-link {
color: white

}






</style>
