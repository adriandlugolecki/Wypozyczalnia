<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken, telefon, alert } from '../../main'
const props = defineProps({
  wypozyczenia: Object
})
const dataZakonczenia = props.wypozyczenia.dataZakonczenia
const dataMinimalna = new Date(dataZakonczenia)
dataMinimalna.setDate(dataMinimalna.getDate())
const kwota = props.wypozyczenia.kwota / props.wypozyczenia.ileDni
const dataMaksymalna = ref()
const wyborDaty = ref(false)
const dataPrzedluzenia = ref()
const konto = ref(false)
const przedluzenie = ref()
onBeforeMount(async () => {
  try {
    var res = await axiosToken.get(`/Klient/DostepnePrzedluzenia/${props.wypozyczenia.id}`)
    if (res.data == 'brak terminu') {
      dataMaksymalna.value = 'brak terminu'
    } else {
      dataMaksymalna.value = new Date(res.data)
    }
  } catch (error) {
    console.error('Błąd', error)
  }
})
const ileDni = () => {
  const jedenDzien = 24 * 60 * 60 * 1000
  console.log(dataPrzedluzenia.value)
  console.log(dataMaksymalna.value)
  const roznica = Math.round((Date.parse(dataPrzedluzenia.value) - dataMinimalna) / jedenDzien)
  return roznica
}
const anuluj = async () => {
  try {
    var res = await axiosToken.delete(`/Klient/AnulujPrzedluzenie/${przedluzenie.value.id}`)
    alert.tekst = res.data
    alert.show = true
    location.reload()
  } catch (error) {
    alert.tekst = error.response.data
    alert.error = true
    alert.show = true
  }
}
const przedluz = async () => {
  var res = await axiosToken.post(
    `/Klient/PrzedluzWypozyczenie/${props.wypozyczenia.id}/${dataPrzedluzenia.value}`
  )
  przedluzenie.value = res.data
  wyborDaty.value = false
}
const oplacono = () => {
  location.reload()
}
</script>
<template>
  <div v-if="dataMaksymalna != 'brak terminu' && konto == false">
    <span style="color: brown">!! Możliwe przedłużenie wypożyczenia !! &#10140; </span>
    <v-btn icon="mdi-calendar-month" color="grey" @click="wyborDaty = !wyborDaty" />
    <div v-if="wyborDaty">
      <div>Kiedy chcesz oddać?</div>
      <input
        class="wybor"
        type="date"
        v-model="dataPrzedluzenia"
        :min="new Date(dataMinimalna.getTime() + 172800000).toJSON().slice(0, 10)"
        :max="new Date(dataMaksymalna.getTime() + 86400000).toJSON().slice(0, 10)"
      />
      kwota: {{ ileDni() * kwota }} zł
      <div>
        <v-btn color="grey" @click="konto = true && przedluz()">Przedluż</v-btn>
      </div>
    </div>
  </div>
  <div v-if="konto">
    <div>Wypozyczenie zostało wstępnie wydłużone</div>
    Wykonaj przelew na konto <br />
    53 1240 3767 3168 3276 4028 0639 <br />lub na numer telefonu <br />{{ telefon }}<br />
    o tytule przelewu: {{ props.wypozyczenia.id }}|{{ props.wypozyczenia.samochod.marka
    }}{{ props.wypozyczenia.samochod.model }}
    <br />
    kwota {{ kwota }} zł
    <div>Data zwrotu zmieni się po zaakceptowaniu przez pracownika</div>

    <div>
      <v-btn color="red" @click="anuluj()">Anuluj</v-btn>
      <v-btn color="green" @click="oplacono()">Opłacone</v-btn>
    </div>
  </div>
</template>
<style scoped>
.wybor {
  border: 1px solid gray;
  border-radius: 10px;
  text-align: center;
  width: 300px;

  margin: 0px 5px 5px 5px;
  box-shadow:
    0 2px 8px 0 rgba(0, 0, 0, 0.2),
    0 1px 20px 0 rgba(0, 0, 0, 0.19);
}
</style>
