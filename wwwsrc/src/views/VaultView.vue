<template>
  <div class="VaultView mt-2">
    <h1>{{vault.name}}</h1>
    <h6>{{vault.description}}</h6>
  </div>
</template>


<script>
export default {
  name: "VaultView",
  data() {
    return {};
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    }
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>