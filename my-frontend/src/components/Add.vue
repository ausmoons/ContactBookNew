<template>
  <div class="add container">
    <h1 class="page-header">Add Contact</h1>
    <form @submit="formSubmit">
        <div class="well">
            <h4>Contact Info</h4>
            <div class="form-group">
                <label>First Name</label>
                <input type="text" class="form-control" placeholder="name1" v-model="name1">
            </div>
            <div class="form-group">
                <label>Last Name</label>
                <input type="text" class="form-control" placeholder="surname1" v-model="surname1">
            </div>
        </div>


        <div class="well">
            <h4>Contact info</h4>
            <div class="form-group">
                <label>Email</label>
                <input type="text" class="form-control" placeholder="emailAddress" v-model="emails.emailAddress">
            </div>
            <div class="form-group">
                <label>Email type</label>
                <input type="text" class="form-control" placeholder="emailType" v-model="emails.type">
            </div>
            <div class="form-group">
                <label>Phone</label>
                <input type="text" class="form-control" placeholder="phoneNumbers" v-model="phoneNumbers.phoneNumber">
            </div>
            <div class="form-group">
                <label>Phonenumber type</label>
                <input type="text" class="form-control" placeholder="phoneNumbersType" v-model="phoneNumbers.type">
            </div>
        </div>

        <div class="well">
            <h4>Address</h4>
            <div class="form-group">
                <label>City</label>
                <input type="text" class="form-control" placeholder="city" v-model="addresses.city">
            </div>
            <div class="form-group">
                <label>Street</label>
                <input type="text" class="form-control" placeholder="street" v-model="addresses.street">
            </div>
            <div class="form-group">
                <label>House number</label>
                <input type="text" class="form-control" placeholder="houseNumber" v-model="addresses.houseNumber">
            </div>
            <div class="form-group">
                <label>Postal code</label>
                <input type="text" class="form-control" placeholder="postalCode" v-model="addresses.postalCode">
            </div>
        </div>  



        <button type="submit" class="btn btn-primary">Submit</button>
    </form>
  </div>
</template>

<script>

    import axios from 'axios';

    export default {
          mounted() {
              console.log('Component mounted.')
          },
          data() {
              return {
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
                emailAddress:'',
                type: '',
                }],
              };
          },
    
      methods: {
              formSubmit(e) {
                  e.preventDefault();
                  let currentObj = this;
                  axios.post('https://localhost:44366/api/Contact', {
                      name1: this.name1,
                      surname1: this.surname1,
                      addresses: [{
                        city : this.addresses.city,
                        street: this.addresses.street,
                        houseNumber: this.addresses.houseNumber,
                        postalCode: this.addresses.postalCode,
                      }], 
                    phoneNumbers: [{
                        phoneNumber: this.phoneNumbers.phoneNumber,
                        type: this.phoneNumbers.type,
                      }], 
                     emails: [{
                        emailAddress: this.emails.emailAddress,
                        type: this.emails.type,
                      }], 

                  })
                  .then(function (response) {
                      currentObj.output = response.data;
                      console.log(response.message);
                  });
                  
              }
          }
      }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
