<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
import Pracownik from './Pracownik.vue'
const listaPracownikow = ref([])
const dodaj = ref(false)
const imie = ref()
const nazwisko = ref()
const dataUrodzenia = ref()
const pesel = ref()
const email = ref()
const haslo = ref()
const czyAdmin = ref(false)
const telefon = ref()
onBeforeMount(async () => {
  try {
    var res = await axiosToken.get(`/Admin/ListaPracownikow`)
    listaPracownikow.value = res.data
  } catch (error) {
    console.error('Błąd', error)
  }
})
const submit = async () => {
  await axiosToken.post(`/Autoryzacja/PracownikRejestracja`, {
    imie: imie.value,
    nazwisko: nazwisko.value,
    dataUrodzenia: dataUrodzenia.value,
    pesel: pesel.value,
    email: email.value,
    haslo: haslo.value,
    czyAdmin: czyAdmin.value,
    numerTelefonu: telefon.value
  })
  location.reload()
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <v-btn elevation="0" class="dodanie" icon="mdi-plus-circle" @click="dodaj = !dodaj"> </v-btn>
      <h1 class="tytul">Pracownicy</h1>
      <div v-if="dodaj" class="formularz">
        <v-form @submit.prevent>
          <div>
            <input type="text" v-model="imie" placeholder="Imię" class="wybor" />
            <input type="text" v-model="nazwisko" placeholder="Nazwisko" class="wybor" />
            <input type="date" v-model="dataUrodzenia" placeholder="DataUrodzenia" class="wybor" />
            <input type="number" v-model="pesel" placeholder="Pesel" class="wybor" />
            <input type="email" v-model="email" placeholder="Email" class="wybor" />
            <input type="text" v-model="haslo" placeholder="Hasło" class="wybor" />
            <input type="tel" v-model="telefon" placeholder="Numer Telefonu" class="wybor" />
          </div>
          <v-btn @click="submit()" class="mt-5" color="#ebcc39">Dodaj </v-btn>
        </v-form>
      </div>
      <v-list-item v-for="pracownik in listaPracownikow" :key="pracownik.id">
        <Pracownik :pracownik="pracownik" />
      </v-list-item>
    </div>
  </div>
</template>
<style scoped>
.dodanie {
  float: right;
}
.okno {
  width: 450px;
  border: 1px solid grey;
  background-color: var(--okno);
  border-radius: 15px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
  margin: 100px auto;
}
.tytul {
  float: left;
  height: 100px;
  width: 100%;
  text-align: center;
}
.formularz {
  text-align: center;
}
</style>
