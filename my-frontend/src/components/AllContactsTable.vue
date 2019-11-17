<template>
  <div>
    <md-table v-model="people" md-card @md-selected="onSelect">
      <md-table-row slot="md-table-row" slot-scope="{ item }" :class="getClass(item)" md-selectable="single" @md-selected="onSelect">
        <md-table-cell md-label="ID" md-numeric>{{ item.id }}</md-table-cell>
        <md-table-cell md-label="Name">{{ item.name1 }}</md-table-cell>
        <md-table-cell md-label="Second Name">{{ item.name2 }}</md-table-cell>
        <md-table-cell md-label="Surname">{{ item.surname1 }}</md-table-cell>
        <md-table-cell md-label="Second surname">{{ item.surname2 }}</md-table-cell>
        <md-table-cell md-label="Notes">{{ item.notes }}</md-table-cell>
        <md-table-cell md-label="Birthday">{{ item.birthday }}</md-table-cell>
        <md-table-cell md-label="Company">{{ item.company }}</md-table-cell>          
        <md-table-cell md-label="Email">{{ item.emails }}</md-table-cell> 
        <md-table-cell md-label="Address">{{item.addresses }}</md-table-cell>     
        <md-table-cell md-label="Phones">{{ item.phoneNumbers }}</md-table-cell>             
      </md-table-row>
    </md-table> 
     <div>
     <md-button class="md-raised">Add new contact</md-button>
      <md-button class="md-raised">Delete contact</md-button>
      
    </div>
  </div>
</template>

<script>
  export default {
    name: 'TableSingle',
    data: () => ({
      people: []
    }),
    methods: {
      getClass: ({ id }) => ({
        'md-primary': id === 2,
        'md-accent': id === 3
        }),
      onSelect (item) {
        this.selected = item
      }},
      created: function() {
        this.$http.get('https://localhost:44366/api/Data/All')
        .then(({data}) => {
          this.people = data.map(person => {

            person.emails = person.emails.map((email) => { return email.emailAddress });
            person.emails = person.emails.join(", ");
            
            person.phoneNumbers = person.phoneNumbers.map((phoneNumber) => {return phoneNumber.phoneNumber });
            person.phoneNumbers = person.phoneNumbers.join(", ");
            
            person.addresses = person.addresses.map((address) =>
             {return address.city + "," + address.street + "," + address.houseNumber });
             person.addresses = person.addresses.join(", ");

            return person;
          });
        });
    }
    }
</script>

<style lang="scss" scoped>
  .md-table + .md-table {
    margin-top: 16px
  }
</style>

