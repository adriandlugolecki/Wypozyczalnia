<script setup>
import { ref } from 'vue'
import { alert, axiosToken } from '../../main'
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
    var res = await axiosToken.delete(`/Klient/UsunWypozyczenie/${id}`)
    alert.tekst = res.data
    alert.show = true
    location.reload()
  } catch (error) {
    alert.tekst = "Błąd"
    alert.error = true
    alert.show = true
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
        v-if="wypozyczenie.data > props.data"
        @click="usun(wypozyczenie.id)"
      />

      <Przedluzenie :wypozyczenia="wypozyczenie" v-if="wypozyczenie.dataZakonczenia > data" />
    </div>
    <div v-if="rozwin" class="oRezerwacji">
      <div class="kiedy">
        <h3>Odbiór</h3>
        <div>Słoneczna 54, Olsztyn</div>
        {{ DataBezGodziny(wypozyczenie.data) }} o godzinie 12:00

        <h3>Zwrot</h3>
        <div>Słoneczna 54, Olsztyn</div>
        {{ DataBezGodziny(wypozyczenie.dataZakonczenia) }} o godzinie 10:00
      </div>

      <div class="samochod2">
        <h3>{{ wypozyczenie.samochod.marka }} {{ wypozyczenie.samochod.model }}</h3>

        <img
          width="150"
          :src="'https://localhost:7122/Photos/' + wypozyczenie.samochod.id + '.png'"
        />
      </div>
    </div>
  </div>
</template>
<style scoped>
.kiedy {
  height: fit-content;
  text-align: left;
  padding: 20px;
  width: fit-content;
}
.samochod2 {
  height: fit-content;
  width: fit-content;
  padding: 20px;
}
.oRezerwacji {
  display: flex;
  color: white;
}
</style>
