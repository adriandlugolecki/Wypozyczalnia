<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
const props = defineProps({
  wypozyczenia: Object
})
const dataZakonczenia = props.wypozyczenia.dataZakonczenia
const dataMinimalna = new Date(dataZakonczenia)
console.log(dataMinimalna)
dataMinimalna.setDate(dataMinimalna.getDate())
const kwota = ref(0)
const dataMaksymalna = ref()
const wyborDaty = ref(false)
const dataPrzedluzenia = ref()
const konto = ref(false)
onBeforeMount(async () => {
  try {
    var res = await axiosToken.get(`/Klient/DostepnePrzedluzenia/${props.wypozyczenia.id}`)
    dataMaksymalna.value = new Date(res.data)
    console.log(dataMaksymalna.value)
    console.log(props.wypozyczenia.id)
  } catch (error) {
    console.error('Błąd', error)
  }
})
const ileDni = () => {
  const jedenDzien = 24 * 60 * 60 * 1000
  console.log(typeof dataPrzedluzenia.value)
  const roznica = Math.round((Date.parse(dataPrzedluzenia.value) - dataMinimalna) / jedenDzien)
  return roznica
}
</script>
<template>
  <div v-if="dataMaksymalna != 'brak terminu'">
    Możliwe przedłużenie wypożyczenia
    <v-btn icon="mdi-arrow-right" color="grey" @click="wyborDaty = !wyborDaty" />
    <div v-if="wyborDaty">
      <div>Kiedy chcesz oddać?</div>
      <input
        type="date"
        v-model="dataPrzedluzenia"
        :min="dataMinimalna.toJSON().slice(0, 10)"
        :max="dataMaksymalna.toJSON().slice(0, 10)"
      />
      kwota: {{ kwota }}
      <div><v-btn color="grey" @click="konto = true">Wybierz</v-btn></div>

      <div v-if="konto">
        <div>Wypozyczenie zostało wstępnie wydłużone</div>

        Wykonaj przelew na konto xx xxxx xxxx xxxx xxxx lub na numer telefonu xxx - xxx - xxx o
        tytule przelewu:
        {{ props.wypozyczenia.id }}|{{ props.wypozyczenia.samochod.marka
        }}{{ props.wypozyczenia.samochod.model }} {{ ileDni() }}
        <div>Data zakończenia zmieni się po zaakceptowaniu przez pracownika</div>

        <div>
          <v-btn color="red" @click="konto = false">Anuluj</v-btn>
          <v-btn color="green" @click="konto = false">Opłacone</v-btn>
        </div>
      </div>
    </div>
  </div>
</template>
<style></style>
