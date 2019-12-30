import Vue from 'vue'
import App from './App.vue'
import router from './router'


import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'
import axios from 'axios'
import VueAxios from 'vue-axios'
import VModal from 'vue-js-modal'
    
Vue.use(VueAxios, axios)
Vue.use(VueMaterial);
Vue.use(VModal, { dialog: true })


Vue.config.productionTip = false



new Vue({
  router,
  render: h => h(App)
}).$mount('#app')