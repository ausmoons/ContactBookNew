import Vue from 'vue'
import VueRouter from 'vue-router'
import AllContactsTable from '../components/AllContactsTable.vue'
import addNewContacts from '../components/AddNewContacts.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: AllContactsTable
  },
  { path: '/add',
    name: 'newContacts', 
    component: addNewContacts}
]

const router = new VueRouter({
  routes,
  mode: 'history'
})

export default router
