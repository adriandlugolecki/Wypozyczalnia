<script setup>
    import {axioss} from "../main"
    import { ref } from "vue";
    import router from "../router";
    import { onBeforeMount } from "vue";
    onBeforeMount(()=> {
        localStorage.setItem("auto", router.currentRoute.value.params["id"]);
    })
    const cos = ref(1);
    const submit = async () => {
       localStorage.setItem("ubezpieczenie",cos.value);
       router.push("/podsumowanie")
    }
</script>

<template>
    <v-card width="100vw" height="100vh" class="d-flex justify-center align-center">
        <v-form @submit.prevent="submit">
        
            <div>
                <v-card elevation="5" >
                    <input type="radio" v-model="cos" value="1" checked/>
                    <input type="radio" v-model="cos" value="2"/>
                    <input type="radio" v-model="cos" value="3"/>
                    
                    <v-btn class="mt-5 mb-5" type="submit">
                            szukaj
                    </v-btn>
                    
                    
                </v-card>
            </div>
        </v-form>  
                
                
            
            
            
        
        
    </v-card>
</template>