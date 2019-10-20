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
      <h1>My Vaults</h1>
    </div>
    <div class="row mt-3">
      <h1>My Keeps</h1>
    </div>
  </div>
</template>


<script>
import CreateKeep from "../components/CreateKeep";
import CreateVault from "../components/CreateVault";
export default {
  name: "Dashboard",
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {},
  components: { CreateKeep, CreateVault }
};
</script>


<style scoped>
</style>