<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
import Przedluzenie from './Przedluzenie.vue'
import { RouterLink } from 'vue-router'
const data = new Date().toISOString().split('T')[0]
console.log(data)
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

const przedluz = async (id) => {
  try {
    var res = await axiosToken.get(`/Klient/DostepnePrzedluzenia/${id}`)
    console.log(res.data)
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
  <div>
    <v-list-item v-for="wypozyczenie in listaWypozyczen" :key="wypozyczenie.id">
      <div class="MojeRezerwacje">
        <div class="MojeRezerwacjeTytul">
          OD {{ DataBezGodziny(wypozyczenie.data) }} DO
          {{ DataBezGodziny(wypozyczenie.dataZakonczenia) }}
          <v-btn
            icon="mdi-delete"
            color="red"
            v-if="wypozyczenie.data > data"
            @click="usun(wypozyczenie.id)"
          />
          
          <Przedluzenie :wypozyczenia="wypozyczenie" v-if="wypozyczenie.dataZakonczenia > data"/>
          <!-- <RouterLink :to="'/przedluzenie/' + wypozyczenie.id" custom v-slot="{ navigate }">
            <v-btn
              icon="mdi-arrow-right"
              color="grey"
              v-if="wypozyczenie.dataZakonczenia > data"
              @click="navigate"
            />
          </RouterLink> -->
          
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
