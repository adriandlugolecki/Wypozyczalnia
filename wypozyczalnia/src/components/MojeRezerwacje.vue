<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../main'
let props
const listaWypozyczen = ref([])
onBeforeMount(async () => {
  try {
    var res = await axiosToken.get(`/Klient/WypozyczeniaKlienta`)
    listaWypozyczen.value = res.data
    console.log(listaWypozyczen.value)
  } catch (error) {
    console.error('Błąd', error)
  }
})
const usun = async (id) => {
  try {
    await axiosToken.delete(`/Klient/UsunWypozyczenie/${id}`)
  } catch (error) {
    console.error('Błąd', error)
  }
}
let DataBezGodziny = (Data) => {
  let temp = Data.split('T')
  return temp[0]
}
</script>
<template>
  <br />
  <br />
  <div activator="{ props }">
    <v-list-item v-for="wypozyczenie in listaWypozyczen" :key="wypozyczenie.id" v-bind="props">
      <div class="MojeRezerwacje">
        <div class="MojeRezerwacjeTytul">
          OD {{ DataBezGodziny(wypozyczenie.data) }} DO
          {{ DataBezGodziny(wypozyczenie.dataZakonczenia) }}
          <v-btn icon="mdi-delete" color="red" @click="usun(wypozyczenie.id)" />
        </div>

        {{ wypozyczenie.samochod.marka }} {{ wypozyczenie.samochod.model }}
      </div>
    </v-list-item>
  </div>
</template>
<style>
.MojeRezerwacje {
  width: 100vw;
  align-items: center;
}
.MojeRezerwacjeTytul {
  font-size: x-large;
  margin-left: 0;
  margin-top: 0;
}
</style>
