<template>
  <div class="Login">
    <div id="LoginModal" class="modal" tabindex="-1" role="dialog">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Sign-In or Register</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form v-if="loginForm" @submit="loginUser">
              <input type="email" v-model="creds.email" placeholder="email" />
              <input type="password" v-model="creds.password" placeholder="password" />
              <button type="submit" class="ml-1 btn btn-success">Login</button>
            </form>
            <form v-else @submit.prevent="register">
              <input type="text" v-model="newUser.username" placeholder="name" class="mt-2" />
              <br />
              <input type="email" v-model="newUser.email" placeholder="email" class="mt-2" />
              <br />
              <input type="password" v-model="newUser.password" placeholder="password" class="mt-2" />
              <br />
              <button class="mt-2 btn btn-primary" type="submit">Create Account</button>
            </form>
            <div @click="loginForm = !loginForm" class="mt-2">
              <p v-if="loginForm">No account Click to Register</p>
              <p v-else>Already have an account click to Login</p>
            </div>
          </div>
          <div class="modal-footer">
            <button
              id="closeModal"
              type="button"
              class="btn btn-secondary"
              data-dismiss="modal"
            >Close</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "Login",
  data() {
    return {
      loginForm: true,
      creds: {
        email: "",
        password: ""
      },
      newUser: {
        email: "",
        password: "",
        username: ""
      }
    };
  },
  beforeCreate() {
    if (this.$store.state.user.id) {
      this.$router.push({ name: "home" });
    }
  },
  methods: {
    register() {
      this.$store.dispatch("register", this.newUser);
      $("#closeModal").click();
    },
    loginUser() {
      this.$store.dispatch("login", this.creds);
      $("#closeModal").click();
    }
  }
};
</script>


<style scoped>
p:hover {
  cursor: pointer;
  text-decoration: underline;
  color: blue;
}
</style>