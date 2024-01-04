<script setup>
import { RouterView } from 'vue-router'
import { alert, uzytkownik } from './main'
import { watch } from 'vue'
import NavBar from './components/NavBar.vue'
import { onBeforeMount } from 'vue'
var AudioSuccess = new Audio('../src/assets/success.mp3')
var AudioError = new Audio('../src/assets/error.mp3')
let timeout = null

onBeforeMount(() => {
  const token = localStorage.getItem('token')
  if (token != null) {
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
  <v-app>
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

<style>
:root {
  --okno: white;
}
/* #app {
  text-align: center;
} */
::-webkit-scrollbar {
  width: 10px;
}
::-webkit-scrollbar-thumb {
  border-radius: 15px;
  /* background-color: rgba(0,0,0,.5); */
  background-color: grey;
  color: white;
  -webkit-box-shadow: 0 0 1px rgba(255, 255, 255, 0.5);
}
.tlo {
  width: 100vw;
  min-height: 100vh;
  font-size: 16px;
  background-image: url('src/assets/fotor-ai-20240103203456.jpg');
}
.gold {
  color: #ebcc39;
}
/* header {
  line-height: 1.5;
  max-height: 100vh;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

nav {
  width: 100%;
  font-size: 12px;
  text-align: center;
  margin-top: 2rem;
}

nav a.router-link-exact-active {
  color: var(--color-text);
}

nav a.router-link-exact-active:hover {
  background-color: transparent;
}

nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }

  nav {
    text-align: left;
    margin-left: -1rem;
    font-size: 1rem;

    padding: 1rem 0;
    margin-top: 1rem;
  }
} */
</style>
