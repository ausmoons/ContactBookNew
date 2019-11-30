<template>

  <div class="contacts container">
    <Alert v-if="alert" v-bind:message="alert" />
    <h1 class="page-header">Manage Contacts</h1>
    <input class="form-control" placeholder="Enter Last Name" v-model="filterInput">
    <br />
    <table class="table table-striped">
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Address</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="contact in contacts" :key="contact.id">
            <td>{{contact.name1}}</td>
            <td>{{contact.surname1}}</td>
            <td>{{contact.emails}}</td>
            <td>{{contact.phoneNumbers}}</td>
            <td>{{contact.addresses}}</td>
            
            <td><router-link class="btn btn-default" v-bind:to="'contact'+contact.id">View</router-link></td>
          </tr>
        </tbody> 
    </table>

      <div class="container">
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav navbar-right">
            <li><router-link to="/add">Add Contact</router-link></li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
 
  </div>

</template>

<script>
  import Alert from './Alert';
  export default {
    name: 'contacts',
    data: () => ({
      contacts: [],
      alert:'',
        filterInput:''
    }),
    methods: {
      fetchContacts(){

        
        this.$http.get('https://localhost:44366/api/Contact/All')
          .then(({data}) => {
          this.contacts = data.map(contact => {

            contact.emails = contact.emails.map((email) => { return email.emailAddress });
            contact.emails = contact.emails.join(", ");
            
            contact.phoneNumbers = contact.phoneNumbers.map((phoneNumber) => {return phoneNumber.phoneNumber });
            contact.phoneNumbers = contact.phoneNumbers.join(", ");
            
            contact.addresses = contact.addresses.map((address) =>
             {return address.city + "," + address.street + "," + address.houseNumber });
             contact.addresses = contact.addresses.join(", ");

            return contact;
          });
        });
      }
    },
    created: function(){
      if(this.$route.query.alert){
        this.alert = this.$route.query.alert;
      }
      this.fetchContacts();
    },
    updated: function(){
      this.fetchContacts();
    },
    components: {
      Alert
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
