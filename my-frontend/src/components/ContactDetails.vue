<template>

  <div class="contacts container">
 
    <h1 class="page-header">Contact details</h1>
    <br />

    <span class="pull-right">
            <router-link class="btn btn-primary" v-bind:to="'/edit/'+contacts.id">Edit</router-link>
            <button class="btn btn-danger" v-on:click="deleteContact(id)">Delete</button>
    </span>

    <table class="table table-striped">
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Phone number</th>
            <th>Phone type</th>
          </tr>          
        </thead>

        <tbody>
          <tr >
            <td>{{contacts.name1}}</td>
            <td>{{contacts.surname1}}</td>

            <tr v-for="item in contacts.phoneNumbers" :key="item.PhoneNumberID">
              <td>{{item.phoneNumber}}</td>
              <td>{{item.type}}</td>      
         </tr>
      </tbody>
     

    </table>
  </div>

</template>

<script>
  import Alert from './Alert';
  import axios from 'axios';
  export default {
    name: 'contacts',
    data () {
    return {
      id: 0,
      contacts: []
    }
  },
  
  created(id) {
    axios.get('https://localhost:44366/api/Contact/id/' + this.$route.params.id)
    .then((response) => {
      this.contacts = response.data
    })
    .catch((e) => {
      console.error(e)
    })
  },       
  
methods: {
  deleteContact: function(id) {
  axios.delete('https://localhost:44366/api/Contact/Delete/id/' + this.$route.params.id)
    .then((response) => {
      this.fetchContactList();
    })
    .catch((error) => {
      console.log(error);
    });
  }
}


    
   
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
