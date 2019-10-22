<template>
  <div class="Keeps col-4" v-if="keepProp.isPrivate == false">
    <div class="card shadow-lg">
      <img :src="keepProp.img" class="card-img-top img-fluid" />
      <div class="card-body">
        <h5 class="card-title" @click="viewKeep">{{keepProp.name}}</h5>
        <p class="card-text">{{keepProp.description}}</p>
        <hr />
        <p>Views: {{keepProp.views}} - Keeps: {{keepProp.keeps}}</p>
        <button class="btn btn-dark" @click="viewKeep">
          <i class="fas fa-eye"></i>
        </button>
        <button v-if="user.id" class="btn btn-success ml-2" @click="showInput = !showInput">
          <i class="far fa-save"></i>
        </button>
        <div v-if="showInput" class="mt-2">
          <select v-model="selectedVault">
            <option disabled>Select a Vault</option>
            <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
          </select>
          <button class="btn btn-success ml-1" @click="addToVault()">Submit</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "Keeps",
  data() {
    return {
      showInput: false,
      selectedVault: ""
    };
  },
  props: ["keepProp"],
  computed: {
    vaults() {
      return this.$store.state.userVaults;
    },
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    viewKeep() {
      this.$store.dispatch("getKeepById", this.keepProp.id);
      this.$store.dispatch("updateViews", {
        id: this.keepProp.id,
        views: (this.keepProp.views += 1),
        name: this.keepProp.name,
        keeps: this.keepProp.keeps,
        img: this.keepProp.img
      });
    },
    addToVault() {
      this.$store.dispatch("addToVault", {
        vaultId: this.selectedVault,
        keepId: this.keepProp.id
      });
      this.$store.dispatch("updateKeepsTotal", {
        id: this.keepProp.id,
        views: this.keepProp.views,
        name: this.keepProp.name,
        img: this.keepProp.img,
        keeps: (this.keepProp.keeps += 1)
      });
      this.showInput = !this.showInput;
    }
  },
  components: {}
};
</script>


<style scoped>
.card {
  background-color: rgba(255, 255, 255, 0.9);
}
</style>