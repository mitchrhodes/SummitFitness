<template>
  <div id="app">
    <div id="nav" class="text-center">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token != ''"
        >Logout</router-link
      >
      |
      <router-link v-bind:to="{ name: 'changePassword' }"
        >Change Password</router-link
      >
      |
      <router-link
        v-show="isAdmin(this.$store.state.user)"
        v-bind:to="{ name: 'admin' }"
        >Administrator</router-link
      >
    </div>

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
