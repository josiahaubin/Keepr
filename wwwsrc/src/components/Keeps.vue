<template>
  <div class="Keeps col-4">
    <div class="card">
      <img :src="keepProp.img" class="card-img-top img-fluid" />
      <div class="card-body">
        <h5 class="card-title">{{keepProp.name}}</h5>
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
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>