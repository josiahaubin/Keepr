<template>
  <div id="app" class="container-fluid">
    <div class="row">
      <div class="col-12">
        <nav class="navbar navbar-light bg-light">
          <a class="navbar-brand">
            <img
              src="http://assets.stickpng.com/thumbs/580b57fcd9996e24bc43c2f2.png"
              width="50"
              height="50"
              class="d-inline-block align-top"
            />
            Keepr
          </a>
          <button v-if="user.id" @click="viewDashboard()" class="btn btn-dark ml-5">Dashboard</button>
          <button v-if="user.id" @click="logout" class="btn btn-danger">Logout</button>
          <router-link v-else :to="{name: 'login'}">Login</router-link>
        </nav>
        <!-- END OF NAVBAR -->
      </div>
    </div>
    <router-view />
  </div>
</template>

<script>
export default {
  name: "App",
  mounted() {},
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    viewDashboard() {}
  },
  components: {}
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}

.navbar-brand {
  font-size: 33px;
}
</style>