<script setup>
import { ref } from 'vue'
import Przedluzenie from './Przedluzenie.vue'
const props = defineProps({
  wypozyczenie: Object,
  data: String
})
const rozwin = ref(false)
let DataBezGodziny = (Data) => {
  let temp = Data.split('T')
  return temp[0]
}
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
</script>
<template>
  <div class="wypozyczenie">
    <div class="MojeRezerwacjeTytul">
      <v-btn
        :icon="rozwin ? 'mdi-chevron-down' : 'mdi-chevron-right'"
        elevation="0"
        @click="rozwin = !rozwin"
      />
      OD {{ DataBezGodziny(wypozyczenie.data) }} DO
      {{ DataBezGodziny(wypozyczenie.dataZakonczenia) }}
      <v-btn
        icon="mdi-delete"
        color="red"
        v-if="wypozyczenie.data > data"
        @click="usun(wypozyczenie.id)"
      />

      <Przedluzenie :wypozyczenia="wypozyczenie" v-if="wypozyczenie.dataZakonczenia > data" />
      <!-- <RouterLink :to="'/przedluzenie/' + wypozyczenie.id" custom v-slot="{ navigate }">
            <v-btn
              icon="mdi-arrow-right"
              color="grey"
              v-if="wypozyczenie.dataZakonczenia > data"
              @click="navigate"
            />
          </RouterLink> -->
    </div>
    <div v-if="rozwin">
      {{ wypozyczenie.samochod.marka }} {{ wypozyczenie.samochod.model }}
      <img
        width="150"
        :src="'https://localhost:7122/Photos/' + wypozyczenie.samochod.id + '.png'"
      />
    </div>
  </div>
</template>
