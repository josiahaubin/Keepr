<template>
  <div class="Vaults col-6">
    <div class="card">
      <div class="card-body">
        <h5 class="card-title">{{vaultProp.name}}</h5>
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
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>