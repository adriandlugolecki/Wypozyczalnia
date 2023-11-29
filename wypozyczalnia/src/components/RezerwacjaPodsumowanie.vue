<script setup>
import { axiosToken } from '../main'
import { ref } from 'vue'
import router from '../router'
import { onBeforeMount } from 'vue'
const auto = localStorage.getItem('auto')
const ubezpieczenie = localStorage.getItem('ubezpieczenie')
const data = localStorage.getItem('data')
const dataZakonczenia = localStorage.getItem('dataZakonczenia')
const token = localStorage.getItem('token')
const cos = ref()
const zarezerwuj = async () => {
  await axiosToken.post(
    `/klient/wypozyczeniesamochodu`,
    {
      samochodId: auto,
      klientId: 'id',
      data: data,
      dataZakonczenia: dataZakonczenia
    },
    { Authorization: `Bearer ${token}` }
  )
  router.push('/')
}
</script>

<template>
  <div class="tlo">
    <div class="PodsumowanieTytul">Podsumowanie</div>
    <div class="podsumowanieSamochod">O Samochodzie model marka rodzaj skrzyni typ silnika rok ile osob </div>
    <div class="podsumowanieKlient">Dane klienta imię nazwisko ulica telefon </div>
    <div class="podsumowanieKwota">
      <div>samochód: 1000zł</div>
      
      <div>ubezpieczenie: 500zł</div>
      
      <div>całkowita kwota: 1500zł</div>
      <RouterLink to="/podsumowanie" custom v-slot="{ navigate }">
        <v-btn class="mt-5 mb-5" type="submit" @click="zarezerwuj"> zarezerwuj </v-btn>
      </RouterLink>
    </div>
    <div class="podsumowanieUbezpieczenie"> ubezpieczenie wariant np premium ile warte </div>
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
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.podsumowanieKlient {
  float: left;
  height: 300px;
  width: 500px;
  border: 1px solid black;
  padding: 20px;
  border-radius: 15px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.podsumowanieKwota {
  float: left;
  height: 300px;
  width: 500px;
  border: 1px solid black;
  padding: 20px;
  border-radius: 15px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.podsumowanieUbezpieczenie {
  float: left;
  height: 300px;
  width: 500px;
  border: 1px solid black;
  padding: 20px;
  border-radius: 15px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
</style>
