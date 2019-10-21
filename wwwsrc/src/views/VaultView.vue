<template>
  <div class="VaultView mt-2">
    <h1>{{vault.name}}</h1>
    <h6>{{vault.description}}</h6>
  </div>
</template>


<script>
export default {
  name: "VaultView",
  mounted() {
    this.$store.dispatch("getVaultKeeps", this.vault.id);
  },
  data() {
    return {};
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    },
    vaultKeep() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>