<template>
  <div class="CreateVault">
    <div id="CreateVaultModal" class="modal" tabindex="-1" role="dialog">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Vault Creator</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <!-- FORM -->
            <form @submit.prevent="createVault()">
              <div class="form-group">
                <label for="name">Vault Name</label>
                <input
                  type="text"
                  class="form-control"
                  id="name"
                  placeholder="Name"
                  required
                  v-model="newVault.name"
                />
              </div>
              <div class="form-group">
                <label for="description">Vault Description</label>
                <input
                  type="text"
                  class="form-control"
                  id="description"
                  placeholder="Description"
                  required
                  v-model="newVault.description"
                />
              </div>
              <button type="submit" class="btn btn-primary">Create Vault</button>
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
  name: "CreateVault",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {},
  methods: {
    createVault() {
      this.$store.dispatch("createVault", this.newVault);
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