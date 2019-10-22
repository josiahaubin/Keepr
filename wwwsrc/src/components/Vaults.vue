<template>
  <div class="Vaults col-6 mb-2">
    <div class="card shadow-lg">
      <div class="card-body">
        <h5 class="card-title" @click="viewVault()">{{vaultProp.name}}</h5>
        <p class="card-text">{{vaultProp.description}}</p>
        <button class="btn btn-danger" @click="deleteVault()">
          <i class="fas fa-trash"></i>
        </button>
      </div>
    </div>
  </div>
</template>


<script>
import NotificationService from "../NotificationService";
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
    },
    async deleteVault() {
      if (await NotificationService.delete()) {
        this.$store.dispatch("deleteVault", this.vaultProp.id);
      }
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
.card {
  background-color: #bfeaa3;
}
</style>