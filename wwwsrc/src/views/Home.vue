<template>
  <div class="home mt-2">
    <div class="row my-4">
      <div class="col-12">
        <h1>Welcome To Keepr</h1>
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