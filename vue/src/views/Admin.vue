<template>
  <div>
    <table class="table table-bordered table-hover">
      <thead>
        <tr>
          <th scope="col">Username</th>
          <th scope="col">Email Address</th>
          <th scope="col">Role</th>
          <th scope="col">Make User Admin</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(user, index) in user" v-bind:key="index">
            <td>user.username</td>
            <td>user.emailAddress</td>
            <td>user.role</td>
            <td>
            <a class="btn btn-success">
                Make Administrator
            </a>
          </td>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {};
</script>

<style>
</style>