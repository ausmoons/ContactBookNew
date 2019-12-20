<template>

  <div>
    <h1 class="page-header">Contact details</h1>
    <md-list class="md-double-line">

        <md-card-media>
          <img src="https://sm.pcmag.com/pcmag_in/feature/g/get-organi/get-organized-update-your-profile-picture_9acz.jpg" alt="People">
        </md-card-media>

      <md-subheader>Personal details</md-subheader>
      <md-list-item>
        <div class="md-list-item-text">
          <span>Name: {{contacts.name1}}</span>
              <input type="text" v-model="contacts.name1" :disabled="!isEditing"
           :class="{view: !isEditing}">
          <span>Second Name: {{contacts.name2}}</span>
          <span>Surname: {{contacts.surname1}}</span>
          <span>Second surname: {{contacts.surname2}}</span>
          <span>Birthday: {{contacts.birthday}}</span>
        </div>
      </md-list-item>

      <md-divider></md-divider>



      <md-subheader>Email</md-subheader>
      <md-list-item>
        <div class="md-list-item-text" v-for="item in contacts.emails" :key="item.emailID">
          <span>{{item.emailAddress}}</span>
          <span>{{item.type}}</span>
        </div>
      </md-list-item>

      <md-divider></md-divider>

      <md-subheader>Phone</md-subheader>
      <md-list-item>
        <div class="md-list-item-text" v-for="item in contacts.phoneNumbers" :key="item.PhoneNumberID">
          <span>{{item.phoneNumber}}</span>
          <span>{{item.type}}</span>
        </div>
      </md-list-item>

      <md-divider></md-divider>

      <md-subheader>Address</md-subheader>
      <md-list-item>
        <div class="md-list-item-text" v-for="item in contacts.addresses" :key="item.AddressID">
          <span>City: {{item.city}}</span>
          <span>Street: {{item.street}}</span>
          <span>House number: {{item.houseNumber}}</span>
          <span>Postal code: {{item.postalCode}}</span>
        </div>
      </md-list-item>

 <md-divider></md-divider>

      <md-subheader>Additional information</md-subheader>
      <md-list-item>
        <div class="md-list-item-text">
         <span>Notes: {{contacts.notes}}</span>
         <span>Company: {{contacts.company}}</span>
        </div>
      </md-list-item>

     
<md-card-actions>
        <md-button><router-link class="btn btn-primary" v-bind:to="'/edit/id/'+contacts.id">Edit</router-link></md-button>
        <md-button class="btn btn-danger" v-on:click="deleteContact(id)">Delete</md-button>
      </md-card-actions>

    </md-list>
    

</div>
</template>

<script>
  import axios from 'axios';
  export default {
    name: 'contacts',
    data () {      
    return {
      isEditing: false,
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

<style lang="scss" scoped>
  .md-list {
    width: 320px;
    max-width: 100%;
    display: inline-block;
    vertical-align: top;
    border: 1px solid rgba(#000, .12);
  }
</style>
