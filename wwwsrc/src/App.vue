<template>
  <div id="app" class="container-fluid">
    <div class="row">
      <div class="col-12">
        <nav class="navbar navbar-light border border-dark rounded mt-1">
          <a class="navbar-brand">
            <img
              src="http://www.drodd.com/images15/letter-k26.jpg"
              width="50"
              height="50"
              class="d-inline-block align-top border border-dark"
            />
            Keepr
          </a>
          <div>
            <button class="btn btn-dark mx-2" @click="goHome()">
              <i class="fas fa-home"></i>
            </button>
            <button
              v-if="user.id"
              @click="viewDashboard()"
              class="btn btn-success mx-2"
            >{{user.username}}'s Dashboard</button>
            <button v-if="user.id" @click="logout" class="btn btn-danger mx-2">
              <i class="fas fa-power-off"></i>
            </button>
            <button
              v-else
              class="btn btn-success"
              type="button"
              data-toggle="modal"
              data-target="#LoginModal"
            >Login</button>
          </div>
          <!-- <router-link v-else :to="{name: 'login'}">Login</router-link> -->
        </nav>
        <!-- END OF NAVBAR -->
      </div>
      <Login />
    </div>
    <router-view />
  </div>
</template>

<script>
import Login from "./components/Login";
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
    viewDashboard() {
      this.$router.push({ name: "dashboard" });
    },
    goHome() {
      this.$router.push({ name: "home" });
    }
  },
  components: { Login }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: black;
  background-color: #8ed95b;
  min-height: 100vh;
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
nav {
  background-color: #bfeaa3;
}
</style>