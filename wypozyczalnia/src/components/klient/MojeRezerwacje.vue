<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'

import ORezerwacji from './ORezerwacji.vue'
const data = new Date(new Date().getTime() + 172800000).toISOString().split('T')[0]
const listaWypozyczen = ref([])
onBeforeMount(async () => {
  try {
    var res = await axiosToken.get(`/Klient/WypozyczeniaKlienta`)
    listaWypozyczen.value = res.data
  } catch (error) {}
})
</script>
<template>
  <div class="tlo">
    <div class="MojeRezerwacje">
      <h1>Twoje Rezerwacje</h1>
      <div class="MojeRezerwacjeTytul" v-if="listaWypozyczen.length == 0">Brak wypożyczeń</div>
      <v-list-item v-for="wypozyczenie in listaWypozyczen" :key="wypozyczenie.id">
        <ORezerwacji :wypozyczenie="wypozyczenie" :data="data" />
      </v-list-item>
    </div>
  </div>
</template>
<style>
.wypozyczenie {
  border: 1px solid grey;
  border-radius: 10px;
  color: black;
}
.MojeRezerwacje {
  background-color: var(--okno);
  border-radius: 15px;
  border: 1px solid gray;
  margin: 0 auto;
  width: 600px;
  text-align: center;
  box-shadow:
    0 2px 8px 0 rgba(0, 0, 0, 0.2),
    0 2px 20px 0 rgba(0, 0, 0, 0.19);
}
.MojeRezerwacjeTytul {
  font-size: x-large;
  border-radius: 10px;
  background-color: #d3d3d3;
}
</style>
