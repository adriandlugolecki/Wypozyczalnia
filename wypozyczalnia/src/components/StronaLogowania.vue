<script setup>
import { ref, onBeforeMount } from 'vue'
import { zasadyHaslo, zasadyLogin } from '../zasady'
import { axioss, uzytkownik, alert } from '../main'
import router from '../router'
const widocznoscHasla = ref(false)
const email = ref()
const haslo = ref()
const formularzLogowania = ref()
const submit = async (event) => {
  await event
  const dane = await formularzLogowania.value?.validate()
  if (dane && dane.valid) {
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
      } else if (localStorage.getItem('uprawnienia') == 'admin') {
        router.push('/pracownik')
      } else {
        router.push('/')
      }
    } catch (error) {
      alert.error = true
      alert.tekst = 'Email lub hasło jest źle wpisane'
      alert.show = true
      console.log(error)
    }
  }
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <v-form ref="formularzLogowania" @submit.prevent="submit">
        <v-row class="justify-center my-6">
          <h1 class="gold">Zaloguj się</h1>
        </v-row>

        <v-text-field label="email" v-model="email" :rules="zasadyLogin" />
        <v-text-field
          label="hasło"
          v-model="haslo"
          :rules="zasadyHaslo"
          :type="widocznoscHasla ? 'text' : 'password'"
          :append-inner-icon="widocznoscHasla ? 'mdi-eye-off' : 'mdi-eye'"
          @click:append-inner="() => (widocznoscHasla = !widocznoscHasla)"
        />

        <v-row class="justify-center mt-5">
          <v-btn type="submit" color="#ebcc39"> zaloguj </v-btn>
        </v-row>
        <v-row class="justify-center">
          <RouterLink to="zmianaHasla" custom v-slot="{ navigate }">
            <v-btn size="x-small" variant="plain" @click="navigate"> zapomnałem hasła </v-btn>
          </RouterLink>
        </v-row>
      </v-form>
    </div>
  </div>
</template>
<style scoped>
@media screen and (max-width: 400px) {
  .okno {
    background-color: var(--okno);
    margin: 100px auto;
    border: 1px gray solid;
    width: 350px;
    padding: 30px;
    border-radius: 15px;
    box-shadow:
      0 8px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
  }
}
@media screen and (min-width: 401px) {
  .okno {
    background-color: var(--okno);
    margin: 100px auto;
    border: 1px gray solid;
    width: 400px;
    padding: 30px;
    border-radius: 15px;
    box-shadow:
      0 8px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
  }
}
</style>
