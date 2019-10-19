<template>
  <div class="home container-fluid">
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <div class="row">
      <Keeps v-for="keep in keeps" :key="keep.id" :keepProp="keep" class="mt-4" />
    </div>
  </div>
</template>

<script>
import Keeps from "../components/Keeps";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: { Keeps }
};
</script>