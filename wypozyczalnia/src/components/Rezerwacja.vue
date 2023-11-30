<script setup>
import { onBeforeMount } from 'vue'
import { axioss } from '../main'
import { ref } from 'vue'
const cenaMin = ref(null)
const cenaMax = ref(null)
const rodzajSkrzyni = ref(null)
const data = ref()
const dataZakonczenia = ref()
const zapytanie = ref([])
const samochody = ref([])
const wiek = ref()
const strona = ref(false)
console.log(strona.value)
onBeforeMount(() => {
  try {
    if (localStorage.getItem('data') && localStorage.getItem('dataZakonczenia')) {
      data.value = localStorage.getItem('data')
      dataZakonczenia.value = localStorage.getItem('dataZakonczenia')
    }
  } catch (error) {}
})
const submit = async () => {
  if (dataZakonczenia.value > data.value) {
    var res = await axioss.get(`/samochod/wolnesamochody/${data.value}/${dataZakonczenia.value}`)
    localStorage.setItem('data', data.value)
    localStorage.setItem('dataZakonczenia', dataZakonczenia.value)
    console.log(wiek)
    console.log(res.data)
    zapytanie.value = res.data
    samochody.value = [...zapytanie.value]
    strona.value = true
    console.log(strona.value)
    console.log(zapytanie.value)
  } else {
    console.log('błąd z datą')
  }
}
const filtruj = () => {
  // if (rodzajSkrzyni.value != null) rodzajSkrzyni.value = parseInt(rodzajSkrzyni.value, 10)
  samochody.value = zapytanie.value.filter(
    (s) =>
      s.cena >= cenaMin.value && s.cena <= cenaMax.value && s.rodzajSkrzyni == rodzajSkrzyni.value
  )
}

const typSkrzyni = (skrzynia) => {
  if (skrzynia == 0) {
    return 'Manual'
  }
  return 'Automat'
}

const typPaliwa = (paliwo) => {
  if (paliwo == 0) {
    return 'Benzyna'
  }
  return 'Diesel'
}
</script>

<template>
  <v-form @submit.prevent="submit">
    <div class="daty">
      <v-card elevation="5" width="400" class="datyElementy">
        <div>
          <input
            class="kalendarz"
            type="date"
            v-model="data"
            :min="new Date().toJSON().slice(0, 10)"
            :max="new Date(Date.now() + 2592000000).toJSON().slice(0, 10)"
          />
          <input
            class="kalendarz"
            type="date"
            v-model="dataZakonczenia"
            :min="new Date().toJSON().slice(0, 10)"
            :max="new Date(Date.now() + 2800000000).toJSON().slice(0, 10)"
          />
        </div>

        <div>
          <div>
            wiek kierowcy
            <select v-model="wiek">
              <option value="0">25 lat i mniej</option>
              <option value="1" checked>26 - 69lat</option>
              <option value="2">70 lat i więcej</option>
            </select>
            <v-btn class="mt-5 mb-5" type="submit"> szukaj </v-btn>
          </div>
        </div>
      </v-card>
    </div>
  </v-form>
  <div v-if="!strona">xd</div>
  <div v-if="strona">
    <div class="filtrowanie">
      <v-card elevation="10" class="ml-10 mr-10">
        filtr
        <div>
          Skrzynia biegów
          <br />
          <select v-model="rodzajSkrzyni" required>
            <option value="null" selected hidden>Wybierz</option>
            <option value="0">Manual</option>
            <option value="1">Automat</option>
            <option value="2" checked>Manual i Automat</option>
          </select>
        </div>
        <div>
          Cena za dzień
          <div>od <input type="number" v-model="cenaMin" /></div>
          <div>do <input type="number" v-model="cenaMax" /></div>
        </div>

        <v-btn @click="filtruj"> filtruj </v-btn>
      </v-card>
    </div>

    <div class="listaSamochod">
      <v-list-item v-for="samochod in samochody" :key="samochod.id">
        <div>
          <div class="samochod">
            <div class="nazwaSamochodu">{{ samochod.marka }} {{ samochod.model }}</div>

            <div class="infoSamochod">
              <div class="zdjecieSamochodu"><img width="170" src="../assets/samochod.png" /></div>
              <div class="oSamochodzie" style="float: left">
                rocznik: {{ samochod.rocznik }}<br />
                rodzaj paliwa: {{ typPaliwa(samochod.rodzajPaliwa) }}<br />
                rodzaj skrzyni: {{ typSkrzyni(samochod.rodzajSkrzyni) }}<br />
                liczba drzwi: {{ samochod.liczbaDrzwi }}<br />
                liczba miejsc: {{ samochod.liczbaMiejsc }}
              </div>

              <div class="cenaSamochodu">
                {{ samochod.cena }} zł<br />
                <RouterLink
                  :to="'/rezerwacja/' + samochod.id + '/ubezpieczenia'"
                  custom
                  v-slot="{ navigate }"
                >
                  <v-tab @click="navigate">Wybieram</v-tab>
                </RouterLink>
              </div>
            </div>
          </div>
        </div>
      </v-list-item>
    </div>
  </div>
</template>
<style>
.daty {
  width: 100vw;
  height: 35vh;
  text-align: center;
  padding-top: 10vh;
}
.kalendarz {
  border: 1px solid grey;
  border-radius: 8px;
  padding: 5px;
  margin: 5px;
  box-shadow:
    0 2px 8px 0 rgba(0, 0, 0, 0.2),
    0 2px 20px 0 rgba(0, 0, 0, 0.19);
}
.datyElementy {
  margin: auto;
}
.filtrowanie {
  margin-top: 10px;
  width: 25vw;
  text-align: center;
  height: 600px;
  float: left;
}
.listaSamochod {
  width: 70vw;
  float: left;
}
.samochod {
  font-size: larger;
  width: 90%;
  height: 200px;
  padding: 10px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
  margin: auto;
  margin-bottom: 20px;
  margin-top: 10px;
  border: 1px solid gray;
  border-radius: 15px;
}
.nazwaSamochodu {
  text-align: center;
}

.infoSamochod {
  width: 100%;
}
.zdjecieSamochodu {
  width: 20%;
  float: left;
}
.oSamochodzie {
  width: 60%;
}
.cenaSamochodu {
  text-align: right;
}
</style>
