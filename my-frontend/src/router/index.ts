import Vue from 'vue'
import VueRouter from 'vue-router'
import Contact from '../components/Contacts.vue'
import Add from '../components/Add.vue'
import ContactDetails from '../components/ContactDetails.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'contact',
    component: Contact
  },
  { path: '/add',
    name: 'newContacts', 
    component: Add
  },
   { path: '/contactDetails/id/:id',
    name: 'contactDetails',
    component: ContactDetails
  }, 

]


const router = new VueRouter({
  routes,
  mode: 'history'
})

export default router
