<template>
  <div class="KeepView container-fluid">
    <div class="row">
      <div class="card mx-auto">
        <div class="card shadow-lg">
          <img :src="keep.img" class="card-img-top img-fluid" />
          <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
            <hr />
            <p>Views: {{keep.views + 1}} - Keeps: {{keep.keeps}}</p>
          </div>
        </div>
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
.card {
  background-color: #bfeaa3;
}
</style>