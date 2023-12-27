<script setup>
import { axiosToken } from '../../main'
import { ref } from 'vue'
import router from '../../router'
import { onBeforeMount } from 'vue'
const auto = localStorage.getItem('auto')
const ubezpieczenie = localStorage.getItem('ubezpieczenie')
const wiek = localStorage.getItem('wiek')
const data = new Date(localStorage.getItem('data'))
const dataZakonczenia = new Date(localStorage.getItem('dataZakonczenia'))
const token = localStorage.getItem('token')
const Samochod = ref()
const Ubezpieczenie = ref()
const Id = JSON.parse(atob(token.split('.')[1])).id.toString()
const ileDni = Math.ceil(Math.abs(dataZakonczenia - data) / (1000 * 3600 * 24))
const odbior = ref(false)
const samochodInfo = ref(false)
const ubezpieczenieInfo = ref(false)
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
  const kwota = ileDni * (Ubezpieczenie.value.kwota + Samochod.value.cena)
  console.log(kwota)
  console.log(Id)
  await axiosToken.post(
    `/klient/wypozyczeniesamochodu`,
    {
      samochodId: Samochod.value.id,
      klientId: Id,
      data: data,
      dataZakonczenia: dataZakonczenia,
      ubezpieczenieId: Ubezpieczenie.value.id,
      wiek: wiek,
      kwota: kwota
    },
    { Authorization: `Bearer ${token}` }
  )
  router.push('/')
}
const pozyskanieDaty = (data) => {
  return `${data.getDate()}.${data.getMonth() + 1}.${data.getFullYear()}`
}
</script>

<template>
  <div class="tlo">
    <div class="PodsumowanieTytul">Podsumowanie</div>
    <div class="podsumowanie">
      <div>
        odbiór i zwrot
        <v-btn elevation="0" icon="mdi-book-open" @click="odbior = !odbior"></v-btn>
      </div>
      <div v-if="odbior">
        {{ pozyskanieDaty(data) }} od godziny 12:00 <br />{{ pozyskanieDaty(dataZakonczenia) }} do
        godziny 10:00
      </div>
      <div>
        Samochod
        <v-btn icon="mdi-book-open" elevation="0" @click="samochodInfo = !samochodInfo"></v-btn>
      </div>
      <div v-if="samochodInfo">
        O Samochodzie model marka rodzaj skrzyni typ silnika rok ile osob
        {{ ileDni }}
      </div>

      <div>
        Ubezpieczenie
        <v-btn
          icon="mdi-book-open"
          elevation="0"
          @click="ubezpieczenieInfo = !ubezpieczenieInfo"
        ></v-btn>
      </div>
      <div v-if="ubezpieczenieInfo">ubezpieczenie wariant np premium ile warte</div>
    </div>
    <div class="podsumowanieKwota">
      Podsumowanie
      <div>
        samochód: {{ ileDni }} x {{ Samochod ? Samochod.cena : '' }} =
        {{ ileDni * (Samochod ? Samochod.cena : '') }} zł
      </div>

      <div>
        ubezpieczenie: {{ ileDni }} x {{ Ubezpieczenie ? Ubezpieczenie.kwota : '' }} =
        {{ ileDni * (Ubezpieczenie ? Ubezpieczenie.kwota : '') }} zł
      </div>

      <div>
        całkowita kwota:
        {{
          ileDni * ((Ubezpieczenie ? Ubezpieczenie.kwota : '') + (Samochod ? Samochod.cena : ''))
        }}
        zł
      </div>
      <div v-if="ubezpieczenie == 1">Kaucja: 2000zł</div>
      <div v-if="ubezpieczenie == 2">Kaucja: 500zł</div>
      <div v-if="ubezpieczenie == 3">Kaucja: 1zł</div>
      <RouterLink to="/podsumowanie" custom v-slot="{ navigate }">
        <v-btn class="mt-5 mb-5" type="submit" @click="zarezerwuj"> zarezerwuj </v-btn>
      </RouterLink>
    </div>

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
.podsumowanie {
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
</style>
