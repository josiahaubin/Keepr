<template>
  <div class="VaultKeeps col-6 mt-2">
    <div class="card">
      <img :src="keepProp.img" class="card-img-top img-fluid" />
      <div class="card-body">
        <h5 class="card-title">{{keepProp.name}}</h5>
        <p class="card-text">{{keepProp.description}}</p>
        <hr />
        <p>Views:{{keepProp.views}} - Keeps:{{keepProp.keeps}}</p>
        <button class="btn btn-primary mr-2" @click="viewKeep()">View</button>
        <button class="btn btn-danger" @click="removeKeep()">Remove from Vault</button>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "VaultKeeps",
  props: ["keepProp"],
  mounted() {},
  data() {
    return {};
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    }
  },
  methods: {
    removeKeep() {
      this.$store.dispatch("removeFromVault", {
        keepId: this.keepProp.id,
        vaultId: this.vault.id
      });
    },
    viewKeep() {
      this.$store.dispatch("getKeepById", this.keepProp.id);
      this.$store.dispatch("updateViews", {
        id: this.keepProp.id,
        views: (this.keepProp.views += 1),
        keeps: this.keepProp.keeps,
        name: this.keepProp.name,
        img: this.keepProp.img
      });
    }
  },
  components: {}
};
</script>


<style scoped>
</style>