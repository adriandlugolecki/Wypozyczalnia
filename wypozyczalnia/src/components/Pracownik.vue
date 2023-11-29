<script setup>
import { onBeforeMount, ref } from 'vue'
import { axioss } from '../main'
const listaWypozyczen = ref([])
onBeforeMount(async () => {
  try {
    var res = await axioss.get(`/Pracownik/ListaWypozyczenNaDzis`)
    listaWypozyczen.value = res.data
  } catch (error) {
    console.error('Błąd', error)
  }
  console.log(listaWypozyczen.value)
})
</script>
<template>
  <br />
  <br />
  <v-list-item v-for="wypozyczenie in listaWypozyczen" :key="wypozyczenie.id">
    <div>
      <div> Numer Wypożyczenia: [{{ wypozyczenie.id }}] Numer Samochodu:{{ wypozyczenie.samochodId }}</div>
      <div>klient</div>
    </div>
  </v-list-item>
</template>
