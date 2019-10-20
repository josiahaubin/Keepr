<template>
  <div class="Dashboard">
    <div class="row mt-3">
      <div class="col-12">
        <h1>{{user.username}}'s Dashboard</h1>
      </div>
    </div>
    <div class="row mt-3">
      <div class="col-6">
        <button
          class="btn btn-success"
          type="button"
          data-toggle="modal"
          data-target="#CreateKeepModal"
        >Create a Keep</button>
        <CreateKeep />
      </div>
      <div class="col-6">
        <button
          class="btn btn-success"
          type="button"
          data-toggle="modal"
          data-target="#CreateVaultModal"
        >Create a Vault</button>
        <CreateVault />
      </div>
    </div>
    <div class="row mt-3">
      <div class="col-12">
        <h1>My Vaults</h1>
      </div>
    </div>
    <div class="row mt-3">
      <div class="col-12">
        <h1>My Keeps</h1>
      </div>
      <DashboardKeeps v-for="keep in userKeeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import CreateKeep from "../components/CreateKeep";
import CreateVault from "../components/CreateVault";
import DashboardKeeps from "../components/DashboardKeeps";
export default {
  name: "Dashboard",
  mounted() {
    this.$store.dispatch("getUserKeeps");
  },
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    }
  },
  methods: {},
  components: { CreateKeep, CreateVault, DashboardKeeps }
};
</script>


<style scoped>
</style>