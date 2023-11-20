<script setup>
import { uzytkownik } from '../main';
import router from '../router'
const wyloguj = () =>{
    localStorage.clear();
    uzytkownik.uprawnienia = null;
    router.push("/");
}
</script>

<template>
    <v-app-bar :elevaton="5" color="primary" height="50">
            <v-tabs 
            :mandatory="false" v-if="uzytkownik.uprawnienia === 'klient'">
                
                <RouterLink to="/" custom v-slot="{ navigate }">
                    <v-tab @click="navigate">rezerwacje</v-tab>
                </RouterLink>
                <RouterLink to="/mojeRezerwacje" custom v-slot="{ navigate }">
                    <v-tab @click="navigate">moje rezerwacje</v-tab>
                </RouterLink>
            </v-tabs>
            <v-tabs 
            :mandatory="false" v-if="uzytkownik.uprawnienia === 'pracownik'">
                
                <RouterLink to="/" custom v-slot="{ navigate }">
                    <v-tab @click="navigate">rezerwacje</v-tab>
                </RouterLink>
                
            </v-tabs>
            <template v-slot:append>
                witaj adam
                <v-btn icon="mdi-dots-vertical"></v-btn>
                <v-btn icon="mdi-logout" link @click="wyloguj"/>
            </template>
            
    </v-app-bar>
</template>
