<script setup>
import { axioss } from '../main'
import { zasadyHaslo, zasadyLogin } from '../zasady'
import { ref } from 'vue'
const email = ref()
const haslo = ref()
const kod = ref()
const widocznoscHasla = ref(false)
const wyslij = async () => {
  var res = await axioss.post('/autoryzacja/WyslijMaila', {
    Email: email.value
  })
  console.log(res.data)
}
const zmien = async () => {
  var res = await axioss.patch('/autoryzacja/ZmianaHasla', {
    Email: email.value,
    Kod: kod.value,
    Haslo: haslo.value
  })
  console.log(res.data)
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <h1>Zmiana Hasła</h1>
      <br />
      <v-text-field type="email" label="Email" v-model="email" :rules="zasadyLogin" />
      <div>
        Wyślij kod na maila

        <v-btn elevation="0" @click="wyslij" icon="mdi-email-fast-outline"></v-btn>

        <v-text-field type="number" label="Kod Weryfikujący" v-model="kod" :rules="zasadyLogin" />

        <v-text-field
          label="Nowe hasło"
          v-model="haslo"
          :rules="zasadyHaslo"
          :type="widocznoscHasla ? 'text' : 'password'"
          :append-inner-icon="widocznoscHasla ? 'mdi-eye-off' : 'mdi-eye'"
          @click:append-inner="() => (widocznoscHasla = !widocznoscHasla)"
        />
        <div class="przycisk"><v-btn @click="zmien">Zmień Hasło</v-btn></div>
      </div>
    </div>
  </div>
</template>
<style scoped>
.okno {
  margin: 200px auto;
  border: 1px gray solid;
  width: 400px;
  height: 500px;
  padding: 30px;
  border-radius: 15px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
  text-align: center;
}
.przycisk {
  margin-top: 20px;
}
</style>
