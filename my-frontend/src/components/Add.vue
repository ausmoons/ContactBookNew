<template>
  <div class="add container">
    <h1 class="page-header">Add Contact</h1>

    <div class="well">
      <h4>Contact Info</h4>
      <div class="form-group">
        <label>First Name</label>
        <input type="text" class="form-control" placeholder="Name" v-model="name1" />
      </div>
      <div class="form-group">
        <label>Last Name</label>
        <input type="text" class="form-control" placeholder="Surname" v-model="surname1" />
      </div>
    </div>

    <div class="well">
      <h4>Contact info</h4>
      <div class="form-group">
        <label>Email</label>
        <input
          type="text"
          class="form-control"
          placeholder="Email address"
          v-model="emails.emailAddress"
        />
      </div>
      <div class="form-group">
        <label>Email type</label>
        <input type="text" class="form-control" placeholder="Email type" v-model="emails.type" />
      </div>
      <div class="form-group">
        <label>Phone</label>
        <input
          type="text"
          class="form-control"
          placeholder="Phone number"
          v-model="phoneNumbers.phoneNumber"
        />
      </div>
      <div class="form-group">
        <label>Phonenumber type</label>
        <input
          type="text"
          class="form-control"
          placeholder="Phone type"
          v-model="phoneNumbers.type"
        />
      </div>
    </div>

    <div class="well">
      <h4>Address</h4>
      <div class="form-group">
        <label>City</label>
        <input type="text" class="form-control" placeholder="City" v-model="addresses.city" />
      </div>
      <div class="form-group">
        <label>Street</label>
        <input type="text" class="form-control" placeholder="Street" v-model="addresses.street" />
      </div>
      <div class="form-group">
        <label>House number</label>
        <input
          type="text"
          class="form-control"
          placeholder="House number"
          v-model="addresses.houseNumber"
        />
      </div>
      <div class="form-group">
        <label>Postal code</label>
        <input
          type="text"
          class="form-control"
          placeholder="Postal code"
          v-model="addresses.postalCode"
        />
      </div>
    </div>

<div class="well">
  <h4>Additional information</h4>
          <div class="form-group">
        <label>Notes</label>
        <input type="text" class="form-control" placeholder="Notes" v-model="notes" />
      </div>
      <div class="form-group">
        <label>Company</label>
        <input type="text" class="form-control" placeholder="Company" v-model="company" />
      </div>
</div>
    <md-dialog-alert
      :md-active.sync="saved"
      md-content="Your contact has been saved!"
      md-confirm-text="Ok"
    />

    <md-dialog-alert
      :md-active.sync="cancel"
      md-content="Your contact has not been saved!"
      md-confirm-text="Ok"
    />

    <md-dialog-alert
      :md-active.sync="notSaved"
      md-content="Your contact has not been saved!"
      md-confirm-text="Ok"
    />

    <md-card-actions>
      <md-button v-on:click="goBack">Cancel</md-button>
      <md-button v-on:click="add" class="btn btn-primary">Add</md-button>
    </md-card-actions>
  </div>
</template>

<script>
import axios from "axios";
import router from "../router";

export default {
  data() {
    return {
      saved: false,
      cancel: false,
      notSaved: false,
      name1: "",
      surname1: "",
      notes: "",
      company: "",
      addresses: [
        {
          city: "",
          street: "",
          houseNumber: "",
          postalCode: ""
        }
      ],
      phoneNumbers: [
        {
          phoneNumber: "",
          type: ""
        }
      ],
      emails: [
        {
          emailAddress: "",
          type: ""
        }
      ]
    };
  },
  methods: {
    add(e) {
      e.preventDefault();
      let currentObj = this;
      axios
        .post("https://localhost:44366/api/Contact", {
          name1: this.name1,
          surname1: this.surname1,
          notes: this.contacts.notes,
          company: this.contacts.company,
          addresses: [
            {
              city: this.addresses.city,
              street: this.addresses.street,
              houseNumber: this.addresses.houseNumber,
              postalCode: this.addresses.postalCode
            }
          ],
          phoneNumbers: [
            {
              phoneNumber: this.phoneNumbers.phoneNumber,
              type: this.phoneNumbers.type
            }
          ],
          emails: [
            {
              emailAddress: this.emails.emailAddress,
              type: this.emails.type
            }
          ]
        })
        .then(function(response) {
          currentObj.output = response.data;
          console.log(response.message);
        })
        .catch(error => {
          console.warn("The contact was not saved");
          this.notSaved = true;
        });
      this.saved = true;
      setTimeout(() => this.$router.push("/"), 2000);
    },
    goBack(e) {
      e.preventDefault();
      this.cancel = true;
      setTimeout(() => this.$router.push("/"), 2000);
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
