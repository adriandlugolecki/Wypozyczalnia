<script setup>
import { ref } from 'vue'
import { zasadyHaslo, zasadyImie, zasadyLogin, zasadyNumer, zasadyPesel } from '../zasady'
import { alert, axioss } from '../main'
import router from '../router'

const imie = ref()
const nazwisko = ref()
const dataUrodzenia = ref()
const pesel = ref()
const email = ref()
const haslo = ref()
const telefon = ref()
const widocznoscHasla = ref(false)
const submit = async () => {
  try {
    var res = await axioss.post('/autoryzacja/rejestracja', {
      imie: imie.value,
      nazwisko: nazwisko.value,
      dataUrodzenia: dataUrodzenia.value,
      pesel: pesel.value,
      numerTelefonu: telefon.value,
      email: email.value,
      haslo: haslo.value
    })
    alert.tekst = 'konto zostało utworzone'
    alert.show = true
    router.push(`/potwierdzenieKonta/${res.data.Id}`)
  } catch (error) {
    alert.tekst = 'Wypełnij pola'
    alert.error = true
    alert.show = true
  }
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <v-form ref="formularzLogowania" @submit.prevent="submit">
        <v-row class="justify-center my-6">
          <h1 class="gold">Zarejestruj się</h1>
        </v-row>
        <v-text-field label="Imię" v-model="imie" :rules="zasadyImie" />
        <v-text-field label="Nazwisko" v-model="nazwisko" :rules="zasadyImie" />

        <v-text-field type="Date" label="Data urodzenia" v-model="dataUrodzenia" />
        <v-text-field label="Pesel" v-model="pesel" :rules="zasadyPesel" />
        <v-text-field label="Numer Telefonu" v-model="telefon" :rules="zasadyNumer" />
        <v-text-field label="Email" v-model="email" :rules="zasadyLogin" />
        <v-text-field
          label="Hasło"
          v-model="haslo"
          :rules="zasadyHaslo"
          :type="widocznoscHasla ? 'text' : 'password'"
          :append-inner-icon="widocznoscHasla ? 'mdi-eye-off' : 'mdi-eye'"
          @click:append-inner="() => (widocznoscHasla = !widocznoscHasla)"
        />
        <v-row class="justify-center mt-5 mb-5">
          <v-btn type="submit" color="#ebcc39">Zarejestruj</v-btn>
        </v-row>
      </v-form>
    </div>
  </div>
</template>
<style>
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
