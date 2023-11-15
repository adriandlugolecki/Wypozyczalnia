<script setup>
    import { ref } from "vue";
    import {zasadyHaslo, zasadyLogin} from "../zasady";
    import {axioss} from "../main";

    const email = ref();
    const haslo = ref();

    const submit = async () => {
        var zapytanie = await axioss.post("/autoryzacja/logowanie", {
            email : email.value,
            password : haslo.value,
        });
        localStorage.setItem("token", zapytanie.data.token);
        localStorage.SetItem("uprawnienia", "klient")
        
    }
</script>
<template>
    <v-card width="100vw" height="100vh" class="d-flex justify-center align-center">
        <v-container class="d-flex justify-center align-center">
                <v-card elevation="10"
                        width="400px"
                        height="400px"
                        class="px-6 "
                        radius="200">
                    <v-form ref="formularzLogowania" @submit.prevent="submit" >
                        <v-row class="justify-center my-6">
                            <v-card-title>
                                Zaloguj się
                            </v-card-title>
                        </v-row>
                        
                        <v-text-field label="login"  v-model="email" :rules= "zasadyLogin"/>
                        <v-text-field label="hasło" v-model="haslo" :rules= "zasadyHaslo"/>
                        
                        <v-row class="justify-center mt-5">
                            <v-btn type="submit">
                                zaloguj
                            </v-btn>
                        </v-row>
                        <v-row class="justify-center">
                            <v-btn size="x-small" variant="plain">
                                zapomnałem hasła
                            </v-btn>
                        </v-row>  
                    </v-form>
                    
                    
                </v-card>

            </v-container>
    </v-card>
    
    
</template>
<style>

</style>