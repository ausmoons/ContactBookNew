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
        <md-table-cell md-label="Address">{{ item.addresses }}</md-table-cell> 
        <md-table-cell md-label="Phone">{{ item.phoneNumbers }}</md-table-cell>        
      </md-table-row>
    </md-table>     
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
      }
    },
    created: function() {
        this.$http.get('https://localhost:44366/api/Data/All')
        .then(function(response){
            this.people = response.data
        })
    }
  }
</script>

<style lang="scss" scoped>
  .md-table + .md-table {
    margin-top: 16px
  }
</style>



