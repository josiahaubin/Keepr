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
            <form>
              <div class="form-group">
                <label for="name">Keep Name</label>
                <input type="text" class="form-control" id="name" placeholder="Name" required />
              </div>
              <div class="form-group">
                <label for="description">Keep Description</label>
                <input
                  type="text"
                  class="form-control"
                  id="description"
                  placeholder="Description"
                  required
                />
              </div>
              <div class="form-group">
                <label for="img">Keep Image</label>
                <input type="text" class="form-control" id="img" placeholder="Image URL" required />
              </div>
              <div class="form-check">
                <input class="form-check-input" type="checkbox" value id="privacy" />
                <label class="form-check-label" for="privacy">Do you want this keep set to private?</label>
              </div>
            </form>
            <!-- END OF FORM -->
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
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
    return {};
  },
  computed: {},
  methods: {},
  components: {}
};
</script>


<style scoped>
.form-group {
  text-align: left;
}
</style>