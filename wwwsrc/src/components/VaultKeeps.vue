<template>
  <div class="VaultKeeps col-6 mt-2">
    <div class="card shadow-lg">
      <img :src="keepProp.img" class="card-img-top img-fluid" />
      <div class="card-body">
        <h5 class="card-title">{{keepProp.name}}</h5>
        <p class="card-text">{{keepProp.description}}</p>
        <hr />
        <p>Views:{{keepProp.views}} - Keeps:{{keepProp.keeps}}</p>
        <button class="btn btn-dark mr-2" @click="viewKeep()">
          <i class="far fa-eye"></i>
        </button>
        <button class="btn btn-danger" @click="removeKeep()">
          <i class="fas fa-minus"></i>
        </button>
      </div>
    </div>
  </div>
</template>


<script>
import NotificationService from "../NotificationService";
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
    async removeKeep() {
      if (await NotificationService.remove()) {
        this.$store.dispatch("removeFromVault", {
          keepId: this.keepProp.id,
          vaultId: this.vault.id
        });
        this.$store.dispatch("updateKeepsTotal", {
          id: this.keepProp.id,
          views: this.keepProp.views,
          name: this.keepProp.name,
          img: this.keepProp.img,
          keeps: (this.keepProp.keeps -= 1)
        });
      }
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
.card {
  background-color: #bfeaa3;
}
</style>