<template>
  <div class="Vaults col-6 mb-2">
    <div class="card">
      <div class="card-body">
        <h5 class="card-title" @click="viewVault()">{{vaultProp.name}}</h5>
        <p class="card-text">{{vaultProp.description}}</p>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "Vaults",
  props: ["vaultProp"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    viewVault() {
      this.$store.dispatch("getVaultById", this.vaultProp.id);
    }
  },
  components: {}
};
</script>


<style scoped>
.card-title:hover {
  cursor: pointer;
  text-decoration: underline;
}
</style>