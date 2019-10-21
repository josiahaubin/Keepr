import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    activeKeep: {},
    userKeeps: [],
    userVaults: [],
    activeVault: {},
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, payload) {
      state.keeps = payload;
    },
    setActiveKeep(state, payload) {
      state.activeKeep = payload;
    },
    setUserKeeps(state, payload) {
      state.userKeeps = payload;
    },
    setUserVaults(state, payload) {
      state.userVaults = payload;
    },
    setActiveVault(state, payload) {
      state.activeVault = payload;
    },
    setVaultKeeps(state, payload) {
      state.vaultKeeps = payload;
    }
  },
  actions: {
    //#region  AUTH
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    //#endregion

    //#region  KEEPS
    async getKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps");
        commit('setKeeps', res.data);
      } catch (e) {
        console.log(e.message)
      }
    },
    async getKeepById({ commit, dispatch }, payload) {
      try {
        let res = await api.get(`keeps/${payload}`);
        commit('setActiveKeep', res.data)
        router.push({ name: "keep" })
      } catch (error) {
        console.log(error);
      }
    },
    async createKeep({ commit, dispatch }, payload) {
      try {
        let res = await api.post("keeps", payload);
        dispatch('getKeeps', res.data)
        dispatch('getUserKeeps')
      } catch (error) {
        console.log(error);
      }
    },
    async getUserKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps/user");
        commit('setUserKeeps', res.data)
      } catch (error) {
        console.log(error);
      }
    },
    async updateViews({ commit, dispatch }, payload) {
      try {
        let res = await api.put(`keeps/${payload.id}`, payload);
        dispatch('getKeeps', res.data)
      } catch (error) {
        console.log(error)
      }
    },
    async deleteKeep({ commit, dispatch }, payload) {
      try {
        let res = await api.delete(`keeps/${payload}`);
        dispatch('getUserKeeps')
      } catch (error) {
        console.log(error)
      }
    },
    async updateKeepsTotal({ commit, dispatch }, payload) {
      try {
        let res = await api.put(`keeps/${payload.id}`, payload)
        dispatch('getKeeps', res.data)
      } catch (error) {
        console.log(error)
      }
    },

    //#endregion

    //#region VAULTS
    async getUserVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults");
        commit('setUserVaults', res.data)
      } catch (error) {
        console.log(error)
      }
    },
    async createVault({ commit, dispatch }, payload) {
      try {
        let res = await api.post("vaults", payload);
        dispatch('getUserVaults');
      } catch (error) {
        console.log(error)
      }
    },
    async getVaultById({ commit, dispatch }, payload) {
      try {
        let res = await api.get(`vaults/${payload}`);
        commit('setActiveVault', res.data)
        router.push({ name: "vault" })
      } catch (error) {
        console.log(error);
      }
    },
    async deleteVault({ commit, dispatch }, payload) {
      try {
        let res = await api.delete(`vaults/${payload}`);
        dispatch('getUserVaults')
      } catch (error) {
        console.log(error)
      }
    },
    //#endregion

    //#region VAULTKEEPS
    async addToVault({ commit, dispatch }, payload) {
      try {
        let res = await api.post("vaultkeeps", payload)
      } catch (error) {
        console.log(error)
      }
    },
    async getVaultKeeps({ commit, dispatch }, payload) {
      try {
        let res = await api.get(`vaultkeeps/${payload}`)
        commit("setVaultKeeps", res.data)
      } catch (error) {
        console.log(error)
      }
    },
    async removeFromVault({ commit, dispatch }, payload) {
      try {
        let res = await api.put("vaultkeeps", payload)
        console.log(res.data)
        dispatch("getVaultKeeps", payload.vaultId)
      } catch (error) {
        console.log(error);
      }
    }
    //#endregion
  }
})
