<template>

  <div>
    <h1 class="page-header">Contact details</h1>
    <md-list class="md-double-line">

        <md-card-media>
          <img src="https://sm.pcmag.com/pcmag_in/feature/g/get-organi/get-organized-update-your-profile-picture_9acz.jpg" alt="People">
                <md-field :disabled="!isEditing" :class="{view: !isEditing}" v-if="isEditing">
                    <label>Profile picture</label>
                    <md-file v-model="contacts.photo" accept="image/*" />
               </md-field>
        </md-card-media>

      <md-subheader>Personal details</md-subheader>
      <md-list-item>
        <div class="md-list-item-text">
          <span>Name:</span>
          <input type="text" v-model="contacts.name1" :disabled="!isEditing" :class="{view: !isEditing}">
          <span>Second Name: </span>
           <input type="text" v-model="contacts.name2" :disabled="!isEditing" :class="{view: !isEditing}">
          <span>Surname: </span>
           <input type="text" v-model="contacts.surname1" :disabled="!isEditing" :class="{view: !isEditing}">
          <span>Second surname: </span>
           <input type="text" v-model="contacts.surname2" :disabled="!isEditing" :class="{view: !isEditing}">
          <span>Birthday: </span>    
           <input type="date" v-model="contacts.birthday" :disabled="!isEditing" :class="{view: !isEditing}">
        </div>
      </md-list-item>

      <md-divider></md-divider>



      <md-subheader>Email</md-subheader>
      <md-list-item>
        <div class="md-list-item-text" v-for="item in contacts.emails" :key="item.emailID">
          <span> <input type="text" v-model="item.emailAddress" :disabled="!isEditing" :class="{view: !isEditing}"></span>
         <span> <input type="text" v-model="item.type" :disabled="!isEditing" :class="{view: !isEditing}"></span>
        </div>
      </md-list-item>

<md-card-actions> 
        <md-button v-on:click="saveEmail" v-if="isEditing">Save</md-button>      
</md-card-actions>
      


      <md-divider></md-divider>

      <md-subheader>Phone</md-subheader>
      <md-list-item>
        <div class="md-list-item-text" v-for="item in contacts.phoneNumbers" :key="item.PhoneNumberID">
          <span> <input type="text" v-model="item.phoneNumber" :disabled="!isEditing" :class="{view: !isEditing}"></span>
         <span> <input type="text" v-model="item.type" :disabled="!isEditing" :class="{view: !isEditing}"></span>
        </div>
      </md-list-item>

      <md-divider></md-divider>

      <md-subheader>Address</md-subheader>
      <md-list-item>
        <div class="md-list-item-text" v-for="item in contacts.addresses" :key="item.AddressID">
        <span>City: </span>
        <input type="text" v-model="item.city" :disabled="!isEditing" :class="{view: !isEditing}">
        <span>Street: </span>
        <input type="text" v-model="item.street" :disabled="!isEditing" :class="{view: !isEditing}">
        <span>House number: </span>
        <input type="text" v-model="item.houseNumber" :disabled="!isEditing" :class="{view: !isEditing}">
        <span>Postal code: </span>
        <input type="text" v-model="item.postalCode" :disabled="!isEditing" :class="{view: !isEditing}">
        </div>
      </md-list-item>

 <md-divider></md-divider>

      <md-subheader>Additional information</md-subheader>
      <md-list-item>
        <div class="md-list-item-text">
         <span>Notes: </span>
         <input type="text" v-model="contacts.notes" :disabled="!isEditing" :class="{view: !isEditing}">
         <span>Company: </span>
         <input type="text" v-model="contacts.company" :disabled="!isEditing" :class="{view: !isEditing}">
        </div>
      </md-list-item>

     
<md-card-actions>
        <md-button><router-link class="btn btn-primary" v-bind:to="'/'">Go back</router-link></md-button>
        <md-button class="btn btn-danger" v-on:click="deleteContact(id)">Delete</md-button>
         <md-button v-on:click="isEditing = !isEditing" v-if="!isEditing">Edit</md-button>
        <md-button v-on:click="save" v-else-if="isEditing">Save</md-button>
        <md-button v-if="isEditing" v-on:click="isEditing = !isEditing">Cancel</md-button>
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
      
      contacts: [{
        id: 0,
        name1: '',
        surname1: '',
        addresses: [{
                city : '',
                street: '',
                houseNumber: '',
                postalCode: '',
                }], 
            phoneNumbers: [{
                phoneNumber: '',
                type: '',
                 }], 
            emails: [{  
              emailID: 0,             
                emailAddress:'',
                type: '',
                }]
              
      }]
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
     save(e){
            if(!this.contacts.name1 || !this.contacts.surname1){
                this.alert = 'Please fill in all required fields';
            } else {
                let updContact = {
                    id: this.contacts.id,
                    name1: this.contacts.name1,
                    name2: this.contacts.name2,
                    surname1: this.contacts.surname1,
                    surname2: this.contacts.surname2,
                    birthday: this.contacts.birthday,
                    photo: this.contacts.photo
                }

                this.$http.put('https://localhost:44366/api/Contact/update/id/'+this.$route.params.emails[0].emailID, updContact)
                    .then(function(response){
                        this.$router.push({path: '/', query: {alert: 'Customer Updated'}});
                    });

                e.preventDefault();
            }
            e.preventDefault();
            this.isEditing = false;
      },
  saveEmail(e){
                let updEmail = {
                    emails: [{
                        emailID: this.contacts.emails.emailID,
                        emailAddress: this.contacts.emails.emailAddress,
                        type: this.contacts.emails.type,
                    }]
                }
                this.$http.put('https://localhost:44366/api/Contact/update/email/'+this.emailID, updEmail)
                    .then(function(response){
                        this.$router.push({path: '/', query: {alert: 'Customer Updated'}});
                    });

                e.preventDefault();
           
            this.isEditing = false;
      },
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
  .view {
  border-color: transparent;
  background-color: initial;
  color: initial;
  
}
</style>
