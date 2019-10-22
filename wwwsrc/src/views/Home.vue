<template>
  <div class="home mt-2">
    <div class="row">
      <div class="col-12">
        <h1>{{user.username}} Welcome To Creepr Keepr</h1>
        <h5>The place for all things Minecraft and gaming</h5>
      </div>
    </div>
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
    this.$store.dispatch("getUserVaults");
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
    },
    viewDashboard() {}
  },
  components: { Keeps }
};
</script>

<style scoped>
</style>