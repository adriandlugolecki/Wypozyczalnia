import './assets/main.css'
import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'
import { createApp, reactive, ref, watch, computed } from 'vue'

import App from './App.vue'
import * as VueRouter from 'vue-router'
import router from './router'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import axios from 'axios'

const prefix = 'https://localhost:7122'

export const axioss = axios.create({
  baseURL: `${prefix}/api`,
  timeout: 5000
})
export const axiosToken = axios.create({
  baseURL: `${prefix}/api`,
  timeout: 5000
})

axiosToken.interceptors.request.use((config) => {
  config.headers.Authorization = `Bearer ${localStorage.getItem('token')}`
  return config
})

export const alert = reactive({
  tekst: '',
  show: true,
  error: false
})

export const uzytkownik = reactive({
  uprawnienia: localStorage.getItem('uprawnienia') ? localStorage.getItem('uprawnienia') : null
})

export const getToken = () => {
  return localStorage.getItem('token') ? localStorage.getItem('token') : null
}

const vuetify = createVuetify({ components, directives })

const app = createApp(App)

app.use(router)
app.use(vuetify)

app.mount('#app')
