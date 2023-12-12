<script setup>
import { axiosToken } from '../../main'
import { ref } from 'vue'
import router from '../../router'
import { onBeforeMount } from 'vue'
const auto = localStorage.getItem('auto')
const ubezpieczenie = localStorage.getItem('ubezpieczenie')
const data = new Date(localStorage.getItem('data'))
const dataZakonczenia = new Date(localStorage.getItem('dataZakonczenia'))
const token = localStorage.getItem('token')
const Samochod = ref()
const Ubezpieczenie = ref()
const Id = JSON.parse(atob(token.split('.')[1])).id.toString()
const ileDni = Math.ceil(Math.abs(dataZakonczenia - data) / (1000 * 3600 * 24))
onBeforeMount(async () => {
  try {
    var res = await axiosToken.get(`/Samochod/${auto}`)
    var res2 = await axiosToken.get(`/Ubezpieczenie/${ubezpieczenie}`)

    Samochod.value = res.data
    Ubezpieczenie.value = res2.data
    console.log(auto)
    console.log(Samochod.value.id)
  } catch (error) {
    console.error('Błąd', error)
  }
})
const zarezerwuj = async () => {
  const kwota = ileDni * Ubezpieczenie.value.kwota + Samochod.value.cena
  console.log(kwota)
  console.log(Id)
  await axiosToken.post(
    `/klient/wypozyczeniesamochodu`,
    {
      samochodId: Samochod.value.id,
      klientId: Id,
      data: data,
      dataZakonczenia: dataZakonczenia,
      kwota: kwota
    },
    { Authorization: `Bearer ${token}` }
  )
  router.push('/')
}
</script>

<template>
  <div class="tlo">
    <div class="PodsumowanieTytul">Podsumowanie</div>
    <div class="podsumowanieSamochod">
      O Samochodzie model marka rodzaj skrzyni typ silnika rok ile osob
      {{ ileDni }}
    </div>
    <div class="podsumowanieKlient">Dane klienta imię nazwisko ulica telefon</div>
    <div class="podsumowanieKwota">
      <div>samochód: 1000zł</div>

      <div>ubezpieczenie: 500zł</div>

      <div>całkowita kwota: 1500zł</div>
      <RouterLink to="/podsumowanie" custom v-slot="{ navigate }">
        <v-btn class="mt-5 mb-5" type="submit" @click="zarezerwuj"> zarezerwuj </v-btn>
      </RouterLink>
    </div>
    <div class="podsumowanieUbezpieczenie">ubezpieczenie wariant np premium ile warte</div>
    <!-- <v-card elevation="5">
      samochód
      {{ auto }}
      ubezpieczenie
      {{ ubezpieczenie }}
      <RouterLink to="/podsumowanie" custom v-slot="{ navigate }">
        <v-btn class="mt-5 mb-5" type="submit" @click="zarezerwuj"> zarezerwuj </v-btn>
      </RouterLink>
    </v-card> -->
  </div>
</template>
<style>
.tlo {
  height: 100vh;
  width: 100vw;
}
.PodsumowanieTytul {
  height: 100px;
  width: 100vw;
  margin-top: 100px;
  text-align: center;
  font-size: 26px;
}
.podsumowanieSamochod {
  float: left;
  height: 300px;
  width: 500px;
  border: 1px solid black;
  padding: 20px;
  border-radius: 15px;
  box-shadow:
    0 4px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.podsumowanieKlient {
  float: left;
  height: 300px;
  width: 500px;
  border: 1px solid black;
  padding: 20px;
  border-radius: 15px;
  box-shadow:
    0 4px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.podsumowanieKwota {
  float: left;
  height: 300px;
  width: 500px;
  border: 1px solid black;
  padding: 20px;
  border-radius: 15px;
  box-shadow:
    0 4px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.podsumowanieUbezpieczenie {
  float: left;
  height: 300px;
  width: 500px;
  border: 1px solid black;
  padding: 20px;
  border-radius: 15px;
  box-shadow:
    0 4px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
</style>
