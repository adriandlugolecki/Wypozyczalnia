<script setup>
import { ref, onBeforeMount } from 'vue'
import { zasadyHaslo, zasadyLogin } from '../zasady'
import { axioss, uzytkownik, alert } from '../main'
import { useRoute } from 'vue-router'
import router from '../router'
const widocznoscHasla = ref(false)
const email = ref()
const haslo = ref()
const route = useRoute()

const submit = async () => {
  try {
    var zapytanie = await axioss.post('/autoryzacja/logowanie', {
      email: email.value,
      password: haslo.value
    })

    localStorage.setItem('token', zapytanie.data.token)
    localStorage.setItem('uprawnienia', zapytanie.data.role)
    uzytkownik.uprawnienia = zapytanie.data.role
    if (localStorage.getItem('uprawnienia') == 'pracownik') {
      router.push('/pracownik')
    } else {
      router.push('/')
    }
  } catch (error) {}
}
</script>
<template>
  <v-card width="100vw" height="100vh" class="d-flex justify-center align-center">
    <v-container class="d-flex justify-center align-center">
      <v-card elevation="10" width="400px" height="400px" class="px-6" radius="200">
        <v-form ref="formularzLogowania" @submit.prevent="submit">
          <v-row class="justify-center my-6">
            <v-card-title> Zaloguj się </v-card-title>
          </v-row>

          <v-text-field label="login" v-model="email" :rules="zasadyLogin" />
          <v-text-field
            label="hasło"
            v-model="haslo"
            :rules="zasadyHaslo"
            :type="widocznoscHasla ? 'text' : 'password'"
            :append-inner-icon="widocznoscHasla ? 'mdi-eye-off' : 'mdi-eye'"
            @click:append-inner="() => (widocznoscHasla = !widocznoscHasla)"
          />

          <v-row class="justify-center mt-5">
            <v-btn type="submit"> zaloguj </v-btn>
          </v-row>
          <v-row class="justify-center">
            <v-btn size="x-small" variant="plain"> zapomnałem hasła </v-btn>
          </v-row>
        </v-form>
      </v-card>
    </v-container>
  </v-card>
</template>
<style></style>
