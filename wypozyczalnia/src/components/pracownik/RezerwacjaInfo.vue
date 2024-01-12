<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken, alert } from '../../main'
import router from '../../router'

const wypozyczenie = ref()
const czyWydano = ref(false)
const czyOddano = ref(false)
const idWypozyczenia = ref()
const zrodlo = ref('')
const notatka = ref()
onBeforeMount(async () => {
  try {
    idWypozyczenia.value = router.currentRoute.value.params['id']
    var res = await axiosToken.get(`/Pracownik/WypozyczenieInfo/${idWypozyczenia.value}`)
    wypozyczenie.value = res.data
    zrodlo.value = 'https://localhost:7122/Photos/' + wypozyczenie.value.samochod.id + '.png'
  } catch (error) {}
})
const Wydaj = async (id) => {
  if (wypozyczenie.value.czyWydano == false) {
    czyWydano.value = true
  } else {
    czyWydano.value = false
  }
  await axiosToken.patch(`/Pracownik/ZmianaStatusuWypozyczenia/${id}`, {
    czyWydano: czyWydano.value,
    czyOddano: wypozyczenie.czyOddano
  })
  alert.tekst = 'wydano'
  alert.show = true
  router.push('/pracownik')
}
const Odbierz = async (id) => {
  if (wypozyczenie.value.czyOddano == false) {
    czyOddano.value = true
  } else {
    czyOddano.value = false
  }
  await axiosToken.patch(`/Pracownik/ZmianaStatusuWypozyczenia/${id}`, {
    czyWydano: true,
    czyOddano: czyOddano.value,
    Notatka: notatka.value
  })
  alert.tekst = 'Odebrano'
  alert.show = true
  router.push('/pracownik')
}
let DataBezGodziny = (Data) => {
  let temp = Data.split('T')
  return temp[0]
}
let kaucjaKwota = () => {
  if (wypozyczenie.value.ubezpieczenieId == 1) {
    return 2000
  }
  return 1
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <div class="tytul">
        Wypożyczenie NR: {{ wypozyczenie ? wypozyczenie.id : '' }} |
        {{ wypozyczenie ? DataBezGodziny(wypozyczenie.data) : '' }} -
        {{ wypozyczenie ? DataBezGodziny(wypozyczenie.dataZakonczenia) : '' }}
      </div>
      <div class="info">
        <div>
          <h3>klient:</h3>
          {{ wypozyczenie ? wypozyczenie.klient.imie : '' }}
          {{ wypozyczenie ? wypozyczenie.klient.nazwisko : '' }}<br />
          <h3>Pesel:</h3>
          {{ wypozyczenie ? wypozyczenie.klient.pesel : '' }}
          <h3>Telefon:</h3>
          {{ wypozyczenie ? wypozyczenie.klient.phoneNumber : '' }}
        </div>
        <div>
          <img width="150" :src="zrodlo" />
        </div>
        <div>
          <h3>samochod:</h3>
          Id: {{ wypozyczenie ? wypozyczenie.samochod.id : '' }}<br />
          {{ wypozyczenie ? wypozyczenie.samochod.marka : '' }}
          {{ wypozyczenie ? wypozyczenie.samochod.model : '' }}<br />
          [{{ wypozyczenie ? wypozyczenie.samochod.rejestracja : '' }}]
        </div>
        <div>
          <h3>Dane Kierowcy</h3>
          <div>
            {{ wypozyczenie ? wypozyczenie.imie : '' }}<br />
            {{ wypozyczenie ? wypozyczenie.nazwisko : '' }}
          </div>
          <div>telefon: {{ wypozyczenie ? wypozyczenie.telefon : '' }}</div>
        </div>
      </div>

      <div>Koszt wypożyczenia : {{ wypozyczenie ? wypozyczenie.kwota : '' }} zł</div>
      <div>kaucja : {{ wypozyczenie ? kaucjaKwota() : '' }} zł</div>
      <textarea
        style="background-color: white; border-radius: 30px; padding: 10px"
        cols="50"
        rows="5"
        type="text"
        placeholder="Notatka"
        v-model="notatka"
        v-if="wypozyczenie && wypozyczenie.czyWydano == true && wypozyczenie.czyOddano == false"
      ></textarea>
      <div>
        <v-btn
          v-if="wypozyczenie && wypozyczenie.czyWydano == false && wypozyczenie.czyOddano == false"
          @click="Wydaj(wypozyczenie.id)"
          color="#ebcc39"
          >Wydaj
        </v-btn>
        <v-btn
          v-if="wypozyczenie && wypozyczenie.czyWydano == true && wypozyczenie.czyOddano == false"
          @click="Odbierz(wypozyczenie.id)"
          color="#ebcc39"
          >Odbierz
        </v-btn>
      </div>
    </div>
  </div>
</template>
<style scoped>
.okno {
  background-color: var(--okno);
  width: 700px;
  border: 1px solid grey;
  border-radius: 15px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
  margin-left: auto;
  margin-right: auto;
  padding: 20px;
  text-align: center;
  font-size: 20px;
}
.tytul {
  height: 60px;
  width: 100%;
  text-align: center;
  font-size: 26px;
}
.info {
  display: flex;
  height: 100%;
  width: 100%;
  text-align: center;
}
</style>
