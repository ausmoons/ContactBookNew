<template>

  <div class="contacts container">
    <Alert v-if="alert" v-bind:message="alert" />
    <h1 class="page-header">Contacts</h1>

    <span>Search: </span>
    <input class="form-control" placeholder="Enter name" v-model="filterInput">
    <br />

  <div  v-for="contact in filterBy(contacts, filterInput)" :key="contact.id">  
    <md-card  md-with-hover>
      <md-card-header>
        <md-card-header-text>
          <div class="md-title">{{contact.name1}} {{contact.surname1}} </div>
           <div class="md-subhead">{{contact.emails}}</div>
           <div class="md-subhead">{{contact.phoneNumbers}}</div>

        </md-card-header-text>


        <md-card-media>
          <img src="https://sm.pcmag.com/pcmag_in/feature/g/get-organi/get-organized-update-your-profile-picture_9acz.jpg" alt="People">
        </md-card-media>
      </md-card-header>

      <md-card-actions>
        <md-button><router-link class="btn btn-default" v-bind:to="'/contactDetails/id/'+contact.id">View</router-link></md-button>
      </md-card-actions>
    </md-card>
</div>

      <div class="container">
        <div id="navbar" class="collapse navbar-collapse">
          <ul class="nav navbar-nav navbar-right">
            <md-button><router-link class="btn btn-default" to="/add">Add Contact</router-link></md-button>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
 
  </div>
</template>

<script>
  import Alert from './Alert';
  import axios from 'axios';
  export default {
    name: 'contacts',
    data: () => ({
      contacts: [],
      alert:'',
        filterInput:''
    }),
    methods: {
      fetchContacts(){
       this.axios.get('https://localhost:44366/api/Contact/All')
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
    },
    filterBy(list, value){
        value = value.charAt(0).toUpperCase() + value.slice(1);
        return list.filter(function(contacts){
          return contacts.name1.indexOf(value) > -1;
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

<style lang="scss" scoped>
  .md-card {
    width: 320px;
    margin: 4px;
    display: inline-block;
    vertical-align: top;
  }
</style>

