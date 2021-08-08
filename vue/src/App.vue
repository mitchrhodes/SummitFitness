<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-light bg-white fixed-top">
      <div class="container-fluid">
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
            <li class="nav-item">
              <router-link
                class="nav-link"
                v-bind:to="{ name: 'logout' }"
                v-if="$store.state.token != ''"
                >Logout</router-link
              >
            </li>
            <li class="nav-item">
              <router-link
                v-bind:to="{ name: 'changePassword' }"
                class="nav-link"
                >Change Password</router-link
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
  methods: {
    isAdmin(user) {
      if (user.role === "admin") {
        return true;
      }
      return false;
    },
  },
};
</script>
