<template>
  <div>
    <form novalidate class="md-layout" @submit.prevent="validateUser">
      <md-card class="md-layout-item md-size-50 md-small-size-100">
        <md-card-header>
          <div class="md-title">Add contact</div>
        </md-card-header>

        <md-card-content>
          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-100">
              <md-field >
                <label for="name1">First Name</label>
                <md-input name="name1" id="name1" autocomplete="given-name" v-model="form.name1" :disabled="sending" />
                <span class="md-error" v-if="!$v.form.name1.required">The first name is required</span>
                <span class="md-error" v-else-if="!$v.form.name1.minlength">Invalid first name</span>
              </md-field>
            </div>
            </div>

            <div class="md-layout-item md-small-size-100">
              <md-field >
                <label for="surname1">Last Name</label>
                <md-input name="surname1" id="surname1" autocomplete="family-name" v-model="form.surname1" :disabled="sending" />
                <span class="md-error" v-if="!$v.form.surname1.required">The last name is required</span>
                <span class="md-error" v-else-if="!$v.form.surname1.minlength">Invalid last name</span>
              </md-field>
            </div>
 

            <div class="birthday">
              <h3>Birthday</h3>
             <md-datepicker v-model="date" />
            </div>   

          <md-field >
            <label for="email">Email</label>
            <md-input type="email" name="email" id="email" autocomplete="email" v-model="form.email" :disabled="sending" />
          </md-field>

          <md-field>
            <label>Email type</label>
            <md-input v-model="type"></md-input>
           </md-field>


            <md-field>
              <label>Notes</label>
              <md-textarea v-model="textarea"></md-textarea>
            </md-field>

            <md-field>
            <label>Company</label>
            <md-input v-model="type"></md-input>
           </md-field>

           <md-field>
            <label>Phone number</label>
            <md-input v-model="type"></md-input>
           </md-field>

           <md-field>
            <label>Phone number type</label>
            <md-input v-model="type"></md-input>
           </md-field>
           
          <md-field>
            <label>City</label>
            <md-input v-model="type"></md-input>
           </md-field>

           <md-field>
            <label>Street</label>
            <md-input v-model="type"></md-input>
           </md-field>

           <md-field>
            <label>House number</label>
            <md-input v-model="type"></md-input>
           </md-field>

           <md-field>
            <label>Postal code</label>
            <md-input v-model="type"></md-input>
           </md-field>

           <md-field>
           <label>Profile picture</label>
            <md-file v-model="single" accept="image/*" />
            </md-field>

        </md-card-content>


        <md-progress-bar md-mode="indeterminate" v-if="sending" /> 

        <md-card-actions>
          <md-button v-on:click.prevent="save">Save</md-button>
        </md-card-actions>
      </md-card>

      <md-snackbar :md-active.sync="userSaved">The user {{ lastUser }} was saved with success!</md-snackbar>
    </form>
  </div>
</template>

<script>
  import { validationMixin } from 'vuelidate'
  import {
    required,
     email,
    minLength,
    maxLength
  } from 'vuelidate/lib/validators'

  export default {
    name: 'AddData',
      data: () => {
      return {
        people: {         
        name1:"",
        name2:"",       
        surname1:"", 
        surname2:"",     
        notes:"", 
        birthday:"", 
        company:"", 
        photo:"", 
        emails: {
          type:"", 
          emailAddress:""
        },
        addresses: {        
          city:"",  
          street:"",  
          houseNumber:"",  
          postalCode:"" 
        },
        phoneNumbers: {
          type:"", 
          phoneNumber:"" 
        },
        }
      }
    },

    methods: {
      save () {
         this.$http.post('https://localhost:44366/api/Data', {
        name1: this.people.name1,
        name2: this.people.name2,
        surname1: this.people.surname1,
        surname2: this.people.surname2,   
        notes: this.people.notes,
        birthday: this.people.birthday,
        company: this.people.company,
        photo: this.people.photo,
        emails: {
          type: this.people.emails.type,
          emailAddress: this.people.emails.emailAddress
        },
        addresses: {        
          city: this.people.addresses.city,
          street: this.people.addresses.street,
          houseNumber: this.people.addresses.houseNumber,
          postalCode: this.people.addresses.postalCode
        },
        phoneNumbers: {
          type: this.people.phoneNumbers.type,
          phoneNumber: this.people.phoneNumbers.phoneNumber
        },
        submitted: false
      }).then(function(data) {
        console.log(data);
        this.submitted = true;
      })
      }
    },
    name: 'FormValidation',
    mixins: [validationMixin],
    data: () => ({
      form: {
        name1: null,
        surname1: null,
        email: null,
      },
      userSaved: false,
      sending: false,
      lastUser: null
    }),
    validations: {
      form: {
        name1: {
          required,
          minLength: minLength(3)
        },
        surname1: {
          required,
          minLength: minLength(3)
        },
        email: {
          email
        }
      }
    },
    methods: {
      clearForm () {
        this.$v.$reset()
        this.form.name1 = null
        this.form.surname1 = null
        this.form.email = null
      },
      saveUser () {
        this.sending = true
        // Instead of this timeout, here you can call your API
        window.setTimeout(() => {
          this.lastUser = `${this.form.name1} ${this.form.surname1}`
          this.userSaved = true
          this.sending = false
          this.clearForm()
        }, 1500)
      },
      validateUser () {
        this.$v.$touch()

        if (!this.$v.$invalid) {
          this.saveUser()
        }
      }
    },
  }
</script>

<style lang="scss" scoped>
  .md-progress-bar {
    position: absolute;
    top: 0;
    right: 0;
    left: 0;
  }
</style>

