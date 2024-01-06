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
let redirectParam = null

onBeforeMount(() => {
  redirectParam = route.query.redirect
})

const submit = async () => {
  try {
    var zapytanie = await axioss.post('/autoryzacja/logowanie', {
      email: email.value,
      password: haslo.value
    })
    localStorage.setItem('token', zapytanie.data.token)
    localStorage.setItem('uprawnienia', zapytanie.data.role)
    uzytkownik.uprawnienia = zapytanie.data.role
    if (redirectParam) {
      router.push(`${redirectParam}`)
    } else {
      router.push('/')
    }
  } catch (error) {}
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <v-form ref="formularzLogowania" @submit.prevent="submit">
        <v-row class="justify-center my-6">
          <h1>Zaloguj się</h1>
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
          <v-btn type="submit" color="#ebcc39"> zaloguj </v-btn>
        </v-row>
        <v-row class="justify-center mt-5" s>
          <RouterLink to="zmianaHasla" custom v-slot="{ navigate }">
            <v-btn size="x-small" variant="plain" @click="navigate"> zapomnałem hasła </v-btn>
          </RouterLink>
        </v-row>
      </v-form>
    </div>
  </div>
</template>
<style scoped>
.okno {
  background-color: var(--okno);
  margin: 200px auto;
  border: 1px gray solid;
  width: 400px;
  padding: 30px;
  border-radius: 15px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
</style>
