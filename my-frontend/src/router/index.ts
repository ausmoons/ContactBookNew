import Vue from 'vue'
import VueRouter from 'vue-router'
import AllContactsTable from '../components/AllContactsTable.vue'


Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: AllContactsTable
  }
]

const router = new VueRouter({
  routes
})

export default router
