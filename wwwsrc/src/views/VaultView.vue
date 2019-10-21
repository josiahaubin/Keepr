<template>
  <div class="VaultView mt-2">
    <div class="row">
      <div class="col-12">
        <h1>{{vault.name}}</h1>
        <h6>{{vault.description}}</h6>
      </div>
    </div>
    <div class="row">
      <VaultKeeps v-for="keep in vaultKeep" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import VaultKeeps from "../components/VaultKeeps";
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
  components: { VaultKeeps }
};
</script>


<style scoped>
</style>