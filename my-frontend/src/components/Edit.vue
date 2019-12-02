<template>
  <div class="edit container">
    <h1 class="page-header">Edit Contact</h1>
    <form v-on:submit="updateCustomer">


        <div class="well">
            <h4>Contact Info</h4>
            <div class="form-group">
                <label>First Name</label>
                <input type="text" class="form-control" placeholder="name1" v-model="contacts.name1">
            </div>
            <div class="form-group">
                <label>Last Name</label>
                <input type="text" class="form-control" placeholder="surname1" v-model="contacts.surname1">
            </div>
        </div>



        <button type="submit" class="btn btn-primary">Submit</button>

    </form>
  </div>
</template>

<script>

    export default {
          mounted() {
              console.log('Component mounted.')
          },
         data () {
            return {
            id: 0,
            contacts: []
          }
       },
             

         fetchCustomer(id) {
                axios.get('https://localhost:44366/api/Contact/id/' + this.$route.params.id)
                .then((response) => {
                this.contacts = response.data
                })
                .catch((e) => {
                console.error(e)
                    })
         }, 

 methods: { 
        updateContact(e){
                let updContact = {
                    name1: this.contacts.name1,
                    surname1: this.contacts.surname1,
                }
                   
                axios.put('https://localhost:44366/api/Contact/update/id/'  + this.$route.params.id, updContact)
                    .then(function(response){
                         console.log('saved successfully');
                    });

                e.preventDefault();
        
        }
    },
    created: function(){
        this.fetchCustomer(this.$route.params.id);
    },
    
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
