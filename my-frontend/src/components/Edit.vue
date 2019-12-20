<template>
  <div class="add container">
    <h1 class="page-header">Edit Contact</h1>
    <form @submit="updateContact">
        <div class="well">
            <div class="form-group">                
                <label>First Name</label>
                <input type="text" class="form-control" >

            </div>
            <div class="form-group">
                <label>Last Name</label>
                <input type="text" class="form-control"  v-model="contacts.surname1">
            </div>
        </div>


        <button type="save" class="btn btn-primary">Save</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios';
  export default {
    name: 'contacts',
    data () {
    return {
      id: 0,
      contacts: []
    }
  },
  methods: {
    fetchCustomer(id) {
        axios.get('https://localhost:44366/api/Contact/id/' + this.$route.params.id)
        .then((response) => {
          this.contacts = response.data
        })
        .catch((e) => {
          Console.error(e)
        })
      }, 
  updateContact(e){
            if(!this.contacts.name1 || !this.contacts.surname1){
                this.alert = 'Please fill in all required fields';
            } else {
                let updCustomer = {
                    name1: this.contacts.name1,
                    surname1: this.contacts.surname1,
                }

                this.$http.put('https://localhost:44366/api/Contact/update/id/'+this.$route.params.id, updCustomer)
                    .then(function(response){
                        this.$router.push({path: '/', query: {alert: 'Customer Updated'}});
                    });

                e.preventDefault();
            }
            e.preventDefault();
      },
    created: function(){
    this.fetchCustomer(this.$route.params.id);
    }
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
