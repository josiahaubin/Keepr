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
        <button class="btn btn-dark mx-2" v-if="keepProp.isPrivate == true" @click="makePublic()">
          <i class="fas fa-unlock"></i>
        </button>
        <button class="btn btn-dark mr-2" @click="viewKeep()">
          <i class="fas fa-eye"></i>
        </button>
        <button class="btn btn-danger" @click="deleteKeep()">
          <i class="fas fa-trash"></i>
        </button>
      </div>
    </div>
  </div>
</template>


<script>
import NotificationService from "../NotificationService";
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
    async deleteKeep() {
      if (await NotificationService.delete()) {
        if (this.user.id == this.keepProp.userId) {
          this.$store.dispatch("deleteKeep", this.keepProp.id);
        }
      }
    },
    async makePublic() {
      if (await NotificationService.makePublic()) {
        this.$store.dispatch("updateViews", {
          id: this.keepProp.id,
          views: this.keepProp.views,
          name: this.keepProp.name,
          keeps: this.keepProp.keeps,
          img: this.keepProp.img,
          isPrivate: this.keepProp.isPrivate == false
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
        img: this.keepProp.img,
        isPrivate: this.keepProp.isPrivate
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