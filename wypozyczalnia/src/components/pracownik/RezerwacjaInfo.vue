<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
import router from '../../router'

const wypozyczenie = ref()
const czyWydano = ref(false)
const czyOddano = ref(false)
const idWypozyczenia = ref()
const source = ref("")

onBeforeMount(async () => {
  try {
    idWypozyczenia.value = router.currentRoute.value.params['id']
    var res = await axiosToken.get(`/Pracownik/WypozyczenieInfo/${idWypozyczenia.value}`)
    wypozyczenie.value = res.data
    source.value = "https://localhost:7122/Photos/" + wypozyczenie.value.samochod.id + ".png"
    console.log(wypozyczenie.value)
  } catch (error) {
    console.error('Błąd', error)
  }
  
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
  router.push('/pracownik')
}
const Odbierz = async (id) => {
  if (wypozyczenie.value.czyOddano == false) {
    czyOddano.value = true
  } else {
    czyOddano.value = false
  }
  await axiosToken.patch(`/Pracownik/ZmianaStatusuWypozyczenia/${id}`, {
    czyWydano: wypozyczenie.czyWydano,
    czyOddano: czyOddano.value
  })
  router.push('/pracownik')
}
let DataBezGodziny = (Data) => {
  let temp = Data.split('T')
  return temp[0]
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

      <div>
        klient: {{ wypozyczenie ? wypozyczenie.klient.imie : '' }}
        {{ wypozyczenie ? wypozyczenie.klient.nazwisko : '' }} Pesel:[{{
          wypozyczenie ? wypozyczenie.klient.pesel : ''
        }}]
      </div>
      <div>
        <img width="150" :src="source" />
      </div>
      <div>
        samochod: Id [{{ wypozyczenie ? wypozyczenie.samochod.id : '' }}]
        {{ wypozyczenie ? wypozyczenie.samochod.marka : '' }}
        {{ wypozyczenie ? wypozyczenie.samochod.model : '' }} [{{
          wypozyczenie ? wypozyczenie.samochod.rejestracja : ''
        }}]
      </div>
      <div>Koszt wypozyczenia : {{ wypozyczenie ? wypozyczenie.kwota : '' }} zł</div>
      <v-btn
        v-if="wypozyczenie && wypozyczenie.czyWydano == false && wypozyczenie.czyOddano == false"
        @click="Wydaj(wypozyczenie.id)"
        >Wydaj
      </v-btn>
      <v-btn
        v-if="wypozyczenie && wypozyczenie.czyWydano == true && wypozyczenie.czyOddano == false"
        @click="Odbierz(wypozyczenie.id)"
        >Odbierz
      </v-btn>
    </div>
  </div>
</template>
<style scoped>
.tlo {
  height: 100vh;
  width: 100vw;
}
.okno {
  width: 700px;
  border: 1px solid grey;
  border-radius: 15px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
  margin-top: 100px;
  margin-left: auto;
  margin-right: auto;
  padding: 20px;
  text-align: center;
  font-size: 20px;
}
.tytul {
  float: left;
  height: 60px;
  width: 100%;
  text-align: center;
  font-size: 26px;
}
</style>
