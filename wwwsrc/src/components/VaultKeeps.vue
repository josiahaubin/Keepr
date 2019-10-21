<template>
  <div class="VaultKeeps col-6 mt-2">
    <div class="card">
      <img :src="keepProp.img" class="card-img-top img-fluid" />
      <div class="card-body">
        <h5 class="card-title">{{keepProp.name}}</h5>
        <p class="card-text">{{keepProp.description}}</p>
        <hr />
        <p>Views:{{keepProp.views}} - Keeps:{{keepProp.keeps}}</p>
        <button class="btn btn-danger" @click="deleteKeep()">Delete</button>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "VaultKeeps",
  props: ["keepProp"],
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