<script setup>
import { RouterView } from 'vue-router'
import { alert, uzytkownik } from './main'
import { watch } from 'vue'
import NavBar from './components/NavBar.vue'
import { onBeforeMount } from 'vue'
import router from './router'
var AudioSuccess = new Audio('success.mp3')
var AudioError = new Audio('error.mp3')
let timeout = null

onBeforeMount(() => {
  const token = localStorage.getItem('token')
  if (token != null) {
    router.push('/pracownik')
    const wygasniecieTokenu = new Date(JSON.parse(atob(token.split('.')[1])).exp * 1000)
    if (wygasniecieTokenu < Date.now()) {
      localStorage.clear()
      uzytkownik.uprawnienia = null
    }
  }
})

watch(
  () => alert.show,
  (from, to) => {
    if (!from && to) {
      // z true na false
      timeout = setTimeout(() => {
        alert.tekst = ''
        alert.error = false
      }, 2000)
    }
    if (from && !to) {
      //z false na true
      if (alert.error) {
        AudioError.play()
      } else {
        AudioSuccess.play()
      }
      clearTimeout(timeout)
    }
  }
)
</script>

<template>
  <v-app style="background-color: transparent">
    <NavBar />
    <RouterView />

    <v-snackbar
      location="top"
      class="mt-2"
      v-model="alert.show"
      timeout="5000"
      :color="alert.error ? 'red' : 'green'"
    >
      {{ alert.tekst }}
    </v-snackbar>
  </v-app>
</template>

<style></style>
