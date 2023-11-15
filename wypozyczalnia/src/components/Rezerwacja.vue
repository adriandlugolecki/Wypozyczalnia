<script setup>
    import {axioss} from "../main"
    import { ref } from "vue";
    const data = ref();
    const dataZakonczenia = ref();
    const zapytanie = ref([]);
    
    const submit = async () => {
    var res = await axioss.get(`/samochod/wolnesamochody/${data.value}/${dataZakonczenia.value}`
    );
       
       console.log(res.data)
       zapytanie.value = res.data
       
    }
</script>

<template>
    <v-card width="100vw" height="100vh" class="d-flex justify-center align-center">
        <v-form @submit.prevent="submit">
        
            <div>
                <v-card elevation="5" >
                    <input type="date" v-model="data"/>
                    <input type="date" v-model="dataZakonczenia"/>
                    <v-btn class="mt-5 mb-5" type="submit">
                            szukaj
                    </v-btn>
                </v-card>
            </div>
        </v-form>  
                <div>      
                <TransitionGroup name="list">
                    <v-list-item v-for="samochod in zapytanie" :key="samochod.id" width="90%">
                        
                           
                            <div text-color="primary">
                                {{samochod}}
                                <RouterLink :to="'/rezerwacja/'+ samochod.id +'/ubezpieczenia'" custom v-slot="{ navigate }">
                                <v-tab @click="navigate">zarezerwuj</v-tab>
                                </RouterLink>
                            </div>
                           
                                
                           
                        
                    </v-list-item>
                </TransitionGroup>
                </div>
                
            
            
            
        
        
    </v-card>
</template>