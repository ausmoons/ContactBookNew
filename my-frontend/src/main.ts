import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import AllContactsTable from '../components/AllContactsTable.vue'
import vueResource from 'vue-resource'
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
Vue.use(VueMaterial)
Vue.use(vueResource)

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
