<template>
  <div id="contact">
    <md-dialog-alert
      :md-active.sync="edited"
      md-content="Your contact has been updated!"
      md-confirm-text="Ok"
    />

    <md-dialog-alert
      :md-active.sync="deleted"
      md-content="Your contact has been deleted!"
      md-confirm-text="Ok"
    />

    <h1 class="page-header">Contact details</h1>
    <md-list class="md-double-line">
      <md-card-media>
        <img v-if="contacts.photo" src="contacts.photo" alt="profilePic" />
        <img
          v-else
          src="https://sm.pcmag.com/pcmag_in/feature/g/get-organi/get-organized-update-your-profile-picture_9acz.jpg"
          alt="People"
        />
        <md-field
          :disabled="!isEditingContact"
          :class="{view: !isEditingContact}"
          v-if="isEditingContact"
        >
          <label>Profile picture</label>
          <md-file
            v-model="contacts.photo"
            accept="image/*"
            :disabled="!isEditingContact"
            :class="{view: !isEditingContact}"
          />
        </md-field>
      </md-card-media>

      <md-subheader>Personal details</md-subheader>
      <md-list-item>
        <div class="md-list-item-text">
          <span>Name:</span>
          <input
            type="text"
            v-model="contacts.name1"
            :disabled="!isEditingContact"
            :class="{view: !isEditingContact}"
          />
          <span>Second Name:</span>
          <input
            type="text"
            v-model="contacts.name2"
            :disabled="!isEditingContact"
            :class="{view: !isEditingContact}"
          />
          <span>Surname:</span>
          <input
            type="text"
            v-model="contacts.surname1"
            :disabled="!isEditingContact"
            :class="{view: !isEditingContact}"
          />
          <span>Second surname:</span>
          <input
            type="text"
            v-model="contacts.surname2"
            :disabled="!isEditingContact"
            :class="{view: !isEditingContact}"
          />
          <span>Birthday:</span>
          <input
            type="text"
            format="yyyy-MM-dd"
            v-model="contacts.birthday"
            :disabled="!isEditingContact"
            :class="{view: !isEditingContact}"
          />
        </div>
      </md-list-item>

      <md-divider></md-divider>

      <md-subheader>Email</md-subheader>
      <md-list-item>
        <div class="md-list-item-text" v-for="item in contacts.emails" :key="item.emailID">
          <span>Email address:</span>
          <input
            type="text"
            v-model="item.emailAddress"
            :disabled="!isEditingEmail"
            :class="{view: !isEditingEmail}"
          />
          <span>Email type:</span>
          <input
            type="text"
            v-model="item.type"
            :disabled="!isEditingEmail"
            :class="{view: !isEditingEmail}"
          />
        </div>
      </md-list-item>

      <md-card-actions>
        <md-button v-if="isEditingEmail" v-on:click="saveEmail">Save</md-button>
        <md-button v-on:click="deleteEmail">Delete</md-button>
        <md-button v-on:click="isEditingEmail = !isEditingEmail" v-if="!isEditingEmail">Edit</md-button>
        <md-button v-on:click="isEditingEmail = !isEditingEmail" v-if="isEditingEmail">Cancel</md-button>
      </md-card-actions>

      <md-divider></md-divider>

      <md-subheader>Phone</md-subheader>
      <md-list-item>
        <div
          class="md-list-item-text"
          v-for="item in contacts.phoneNumbers"
          :key="item.PhoneNumberID"
        >
          <span>Phone number:</span>
          <input
            type="text"
            v-model="item.phoneNumber"
            :disabled="!isEditingPhone"
            :class="{view: !isEditingPhone}"
          />
          <span>Type:</span>
          <input
            type="text"
            v-model="item.type"
            :disabled="!isEditingPhone"
            :class="{view: !isEditingPhone}"
          />
        </div>
      </md-list-item>

      <md-card-actions>
        <md-button v-if="isEditingPhone" v-on:click="savePhone">Save</md-button>
        <md-button class="btn btn-danger" v-on:click="deletePhone">Delete</md-button>
        <md-button v-on:click="isEditingPhone = !isEditingPhone" v-if="!isEditingPhone">Edit</md-button>
      </md-card-actions>

      <md-divider></md-divider>

      <md-subheader>Address</md-subheader>
      <md-list-item>
        <div class="md-list-item-text" v-for="item in contacts.addresses" :key="item.AddressID">
          <span>City:</span>
          <input
            type="text"
            v-model="item.city"
            :disabled="!isEditingAddress"
            :class="{view: !isEditingAddress}"
          />
          <span>Street:</span>
          <input
            type="text"
            v-model="item.street"
            :disabled="!isEditingAddress"
            :class="{view: !isEditingAddress}"
          />
          <span>House number:</span>
          <input
            type="text"
            v-model="item.houseNumber"
            :disabled="!isEditingAddress"
            :class="{view: !isEditingAddress}"
          />
          <span>Postal code:</span>
          <input
            type="text"
            v-model="item.postalCode"
            :disabled="!isEditingAddress"
            :class="{view: !isEditingAddress}"
          />
        </div>
      </md-list-item>

      <md-card-actions>
        <md-button v-if="isEditingAddress" v-on:click="saveAddress">Save</md-button>
        <md-button class="btn btn-danger" v-on:click="deleteAddress">Delete</md-button>
        <md-button v-on:click="isEditingAddress = !isEditingAddress" v-if="!isEditingAddress">Edit</md-button>
        <md-button v-on:click="isEditingAddress = !isEditingAddress" v-if="isEditingAddress">Cancel</md-button>
      </md-card-actions>

      <md-divider></md-divider>

      <md-subheader>Additional information</md-subheader>
      <md-list-item>
        <div class="md-list-item-text">
          <span>Notes:</span>
          <input
            type="text"
            v-model="contacts.notes"
            :disabled="!isEditingContact"
            :class="{view: !isEditingContact}"
          />
          <span>Company:</span>
          <input
            type="text"
            v-model="contacts.company"
            :disabled="!isEditingContact"
            :class="{view: !isEditingContact}"
          />
        </div>
      </md-list-item>

      <md-card-actions>
        <md-button>
          <router-link class="btn btn-primary" v-bind:to="'/'">Go back</router-link>
        </md-button>
        <md-button class="btn btn-danger" v-on:click="deleteContact">Delete</md-button>
        <md-button v-on:click="isEditingContact = !isEditingContact" v-if="!isEditingContact">Edit</md-button>
        <md-button v-if="isEditingContact" v-on:click="save">Save</md-button>
        <md-button v-if="isEditingContact" v-on:click="isEditingContact = !isEditingContact">Cancel</md-button>
      </md-card-actions>
    </md-list>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "contact",
  data() {
    return {
      isEditingContact: false,
      isEditingEmail: false,
      isEditingPhone: false,
      isEditingAddress: false,

      edited: false,
      deleted: false,
      filterInput: "",
      contacts: [
        {
          id: 0,
          name1: "",
          name2: "",
          surname1: "",
          surname2: "",
          photo: "",
          birthday: "",
          notes: "",
          company: "",
          addresses: [
            {
              addressID: 0,
              city: "",
              street: "",
              houseNumber: "",
              postalCode: "",
              contactId: 0
            }
          ],
          phoneNumbers: [
            {
              phoneNumberID: 0,
              phoneNumber: "",
              type: "",
              contactId: 0
            }
          ],
          emails: [
            {
              emailID: 0,
              contactId: 0,
              emailAddress: "",
              type: ""
            }
          ]
        }
      ]
    };
  },
  created(id) {
    axios
      .get("https://localhost:44366/api/Contact/id/" + this.$route.params.id)
      .then(response => {
        this.contacts = response.data;
      })
      .catch(e => {
        console.error(e);
      });
  },
  methods: {
    save(e) {
      e.preventDefault();
      let currentObj = this;
      axios
        .put(
          "https://localhost:44366/api/Contact/update/id/" +
            this.$route.params.id,
          {
            id: this.contacts.id,
            name1: this.contacts.name1,
            name2: this.contacts.name2,
            surname1: this.contacts.surname1,
            surname2: this.contacts.surname2,
            birthday: this.contacts.birthday,
            photo: this.contacts.photo,
            notes: this.contacts.notes,
            company: this.contacts.company
          }
        )
        .then(function(response) {
          currentObj.output = response.data;
          console.log(response.message);
        });

      this.edited = true;
    },
    saveEmail(e) {
      e.preventDefault();
      let currentObj = this;
      axios
        .put(
          "https://localhost:44366/api/Contact/update/email/" +
            this.contacts.emails[0].emailID,
          {
            emailID: this.contacts.emails[0].emailID,
            contactId: this.contacts.emails[0].contactId,
            emailAddress: this.contacts.emails[0].emailAddress,
            type: this.contacts.emails[0].type
          }
        )
        .then(function(response) {
          currentObj.output = response.data;
          console.log(response.message);
        });

      this.edited = true;
    },
    savePhone(e) {
      e.preventDefault();
      let currentObj = this;
      axios
        .put(
          "https://localhost:44366/api/Contact/update/phone/" +
            this.contacts.phoneNumbers[0].phoneNumberID,
          {
            phoneNumberID: this.contacts.phoneNumbers[0].phoneNumberID,
            phoneNumber: this.contacts.phoneNumbers[0].phoneNumber,
            contactId: this.contacts.phoneNumbers[0].contactId,
            type: this.contacts.phoneNumbers[0].type
          }
        )
        .then(function(response) {
          currentObj.output = response.data;
          console.log(response.message);
        });

      this.edited = true;
    },
    saveAddress(e) {
      e.preventDefault();
      let currentObj = this;
      axios
        .put(
          "https://localhost:44366/api/Contact/update/address/" +
            this.contacts.addresses[0].addressID,
          {
            addressID: this.contacts.addresses[0].addressID,
            city: this.contacts.addresses[0].city,
            street: this.contacts.addresses[0].street,
            houseNumber: this.contacts.addresses[0].houseNumber,
            postalCode: this.contacts.addresses[0].postalCode,
            contactId: this.contacts.addresses[0].contactId
          }
        )
        .then(function(response) {
          currentObj.output = response.data;
          console.log(response.message);
        });

      this.edited = true;
    },

    deleteContact(e) {
      e.preventDefault();
      axios
        .delete(
          "https://localhost:44366/api/Contact/Delete/id/" +
            this.$route.params.id
        )
        .catch(error => {
          console.log(error);
          this.deleted = true;
          setTimeout(() => this.$router.push("/"), 2000);
        });
    },
    deleteEmail(e) {
      e.preventDefault();
      axios
        .delete(
          "https://localhost:44366/api/Contact/Delete/emailID/" +
            this.contacts.emails[0].emailID
        )
        .catch(error => {
          console.log(error);
          this.deleted = true;
        });
    },
    deletePhone(e) {
      e.preventDefault();
      axios
        .delete(
          "https://localhost:44366/api/Contact/Delete/phoneID/" +
            this.contacts.phoneNumbers[0].phoneNumberID
        )
        .catch(error => {
          console.log(error);
          this.deleted = true;
        });
    },
    deleteAddress(e) {
      e.preventDefault();
      axios
        .delete(
          "https://localhost:44366/api/Contact/Delete/addressID/" +
            this.contacts.addresses[0].addressID
        )
        .catch(error => {
          console.log(error);
          this.deleted = true;
        });
    }
  }
};
</script>

<style lang="scss" scoped>
.md-list {
  width: 320px;
  max-width: 100%;
  display: inline-block;
  vertical-align: top;
  border: 1px solid rgba(#000, 0.12);
}
.view {
  border-color: transparent;
  background-color: initial;
  color: initial;
}
</style>
