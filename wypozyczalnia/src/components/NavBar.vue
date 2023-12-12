<script setup>
import { uzytkownik } from '../main'
import router from '../router'
const wyloguj = () => {
  localStorage.clear()
  uzytkownik.uprawnienia = null
  router.push('/')
}
</script>

<template>
  <v-app-bar :elevaton="5" color="#C0C0C0" height="50">
    <v-tabs :mandatory="false" v-if="uzytkownik.uprawnienia === 'klient'">
      <RouterLink to="/" custom v-slot="{ navigate }">
        <v-tab @click="navigate">rezerwacje</v-tab>
      </RouterLink>
      <RouterLink to="/mojeRezerwacje" custom v-slot="{ navigate }">
        <v-tab @click="navigate">moje rezerwacje</v-tab>
      </RouterLink>
    </v-tabs>
    <v-tabs :mandatory="false" v-if="uzytkownik.uprawnienia === 'pracownik'">
      <RouterLink to="/pracownik" custom v-slot="{ navigate }">
        <v-tab @click="navigate">rezerwacje</v-tab>
      </RouterLink>
    </v-tabs>
    <v-tabs :mandatory="false" v-if="uzytkownik.uprawnienia === 'admin'">
      <RouterLink to="/pracownik" custom v-slot="{ navigate }">
        <v-tab @click="navigate">rezerwacje</v-tab>
      </RouterLink>
      <RouterLink to="/listaPracownikow" custom v-slot="{ navigate }">
        <v-tab @click="navigate">Pracownicy</v-tab>
      </RouterLink>
      <RouterLink to="/listaSamochodow" custom v-slot="{ navigate }">
        <v-tab @click="navigate">Samochody</v-tab>
      </RouterLink>
      <RouterLink to="/listaUbezpieczen" custom v-slot="{ navigate }">
        <v-tab @click="navigate">Ubezpieczenia</v-tab>
      </RouterLink>
    </v-tabs>
    <template v-slot:append v-if="uzytkownik.uprawnienia">
      <v-btn icon="mdi-dots-vertical"></v-btn>
      <v-btn icon="mdi-logout" link @click="wyloguj" />
    </template>
    <template v-slot:append v-if="!uzytkownik.uprawnienia">
      <RouterLink to="/logowanie" custom v-slot="{ navigate }">
        <v-tab @click="navigate">Zaloguj się</v-tab>
      </RouterLink>
    </template>
  </v-app-bar>
</template>
