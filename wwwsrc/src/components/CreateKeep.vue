<template>
  <div class="CreateKeep">
    <div id="CreateKeepModal" class="modal" tabindex="-1" role="dialog">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Keep Creator</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <!-- FORM -->
            <form @submit.prevent="createKeep()">
              <div class="form-group">
                <label for="name">Keep Name</label>
                <input
                  type="text"
                  class="form-control"
                  id="name"
                  placeholder="Name"
                  required
                  v-model="newKeep.name"
                />
              </div>
              <div class="form-group">
                <label for="description">Keep Description</label>
                <input
                  type="text"
                  class="form-control"
                  id="description"
                  placeholder="Description"
                  required
                  v-model="newKeep.description"
                />
              </div>
              <div class="form-group">
                <label for="img">Keep Image</label>
                <input
                  type="text"
                  class="form-control"
                  id="img"
                  placeholder="Image URL"
                  required
                  v-model="newKeep.img"
                />
              </div>
              <div class="form-check">
                <input
                  class="form-check-input"
                  type="checkbox"
                  id="privacy"
                  v-model="newKeep.isPrivate"
                />
                <label class="form-check-label" for="privacy">Do you want this keep set to private?</label>
              </div>
              <button id="submit" type="submit" class="btn btn-primary">Save changes</button>
            </form>
            <!-- END OF FORM -->
          </div>
          <div class="modal-footer">
            <button id="close" type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "CreateKeep",
  data() {
    return {
      newKeep: {}
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
      $("#close").click();
    }
  },
  components: {}
};
</script>


<style scoped>
.form-group {
  text-align: left;
}
</style>