<template>
  <div class="KeepView container-fluid">
    <div class="row">
      <div class="col-12">
        <img :src="keep.img" class="img-fluid" />
        <h1>{{keep.name}}</h1>
        <h5>{{keep.description}}</h5>
        <hr />
        <h6>Views: {{keep.views + 1}} -- Keeps: {{keep.keeps}}</h6>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "KeepView",
  data() {
    return {};
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
.KeepView {
  min-height: 100vh;
}
</style>