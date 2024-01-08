<script setup>
import { axioss, alert } from '../main'
import router from '../router'
import { zasadyHaslo, zasadyLogin } from '../zasady'
import { ref } from 'vue'
const email = ref()
const haslo = ref()
const kod = ref()
const widocznoscHasla = ref(false)
const formularzHasla = ref()
const wyslij = async () => {
  if (email.value == null) {
    alert.tekst = 'Wypełnij pole email'
    alert.error = true
    alert.show = true
    return
  }
  try {
    var res = await axioss.post('/autoryzacja/WyslijMaila', {
      Email: email.value
    })
    alert.tekst = res.data
    alert.error = true
    alert.show = true
  } catch (error) {
    alert.tekst = error.response.data
    alert.error = true
    alert.show = true
  }
}
const submit = async (event) => {
  await event
  const dane = await formularzHasla.value?.validate()
  if (dane && dane.valid) {
    try {
      var res = await axioss.patch('/autoryzacja/ZmianaHasla', {
        Email: email.value,
        Kod: kod.value,
        Haslo: haslo.value
      })
      alert.tekst = res.data
      alert.show = true
      router.push('/logowanie')
    } catch (error) {
      alert.tekst = error.response.data
      alert.error = true
      alert.show = true
    }
  }
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <v-form ref="formularzHasla" @submit.prevent="submit">
        <h1 class="gold">Zmiana Hasła</h1>
        <br />
        <v-text-field type="email" label="Email" v-model="email" :rules="zasadyLogin" />
        <div>
          Wyślij kod na maila

          <v-btn
            elevation="0"
            @click="wyslij"
            icon="mdi-email-fast-outline"
            color="#eeeee7"
          ></v-btn>

          <v-text-field type="number" label="Kod Weryfikujący" v-model="kod" />

          <v-text-field
            label="Nowe hasło"
            v-model="haslo"
            :rules="zasadyHaslo"
            :type="widocznoscHasla ? 'text' : 'password'"
            :append-inner-icon="widocznoscHasla ? 'mdi-eye-off' : 'mdi-eye'"
            @click:append-inner="() => (widocznoscHasla = !widocznoscHasla)"
          />
          <div class="przycisk"><v-btn type="submit" color="#ebcc39">Zmień Hasło</v-btn></div>
        </div>
      </v-form>
    </div>
  </div>
</template>
<style scoped>
.okno {
  background-color: var(--okno);
  margin: 0px auto;
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
