<template>
  <div class="DashboardKeeps col-4 mb-2">
    <div class="card shadow-lg">
      <img :src="keepProp.img" class="card-img-top img-fluid" />
      <div class="card-body">
        <h5 class="card-title">
          {{keepProp.name}}
          <i v-if="keepProp.isPrivate == true" class="fas fa-lock"></i>
        </h5>
        <p class="card-text">{{keepProp.description}}</p>
        <hr />
        <p>Views:{{keepProp.views}} - Keeps:{{keepProp.keeps}}</p>
        <button class="btn btn-danger" @click="deleteKeep()">
          <i class="fas fa-trash"></i>
        </button>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "DashboardKeeps",
  data() {
    return {};
  },
  props: ["keepProp"],
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    deleteKeep() {
      if (this.user.id == this.keepProp.userId) {
        this.$store.dispatch("deleteKeep", this.keepProp.id);
      }
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