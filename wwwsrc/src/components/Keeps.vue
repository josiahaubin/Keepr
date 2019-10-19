<template>
  <div class="Keeps col-4" v-if="keepProp.isPrivate == false">
    <div class="card">
      <img :src="keepProp.img" class="card-img-top img-fluid" />
      <div class="card-body">
        <h5 class="card-title" @click="viewKeep">{{keepProp.name}}</h5>
        <p class="card-text">{{keepProp.description}}</p>
        <hr />
        <p>Views:{{keepProp.views}} - Keeps:{{keepProp.keeps}}</p>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "Keeps",
  data() {
    return {};
  },
  props: ["keepProp"],
  computed: {},
  methods: {
    viewKeep() {
      this.$store.dispatch("getKeepById", this.keepProp.id);
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