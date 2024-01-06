<script setup>
import { onBeforeMount } from 'vue'
import { axioss, alert } from '../main'
import { ref } from 'vue'

const listaSamochodow = ref()
const cenaMin = ref(null)
const cenaMax = ref(null)
const rodzajPaliwa = ref(null)
const rodzajSkrzyni = ref(null)
const data = ref()
const dataZakonczenia = ref()
const zapytanie = ref([])
const samochody = ref([])
const wiek = ref(1)
const strona = ref(false)
const ileDni = ref(0)
onBeforeMount(async () => {
  try {
    var res = await axioss.get(`/samochod`)
    listaSamochodow.value = res.data
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
    localStorage.setItem('wiek', wiek.value)
    console.log(new Date(dataZakonczenia.value))
    console.log(res.data)
    zapytanie.value = res.data
    samochody.value = [...zapytanie.value]
    strona.value = true
    console.log(strona.value)
    console.log(zapytanie.value)
    ileDni.value = Math.ceil(
      Math.abs(new Date(dataZakonczenia.value) - new Date(data.value)) / (1000 * 3600 * 24)
    )
  } else {
    alert.error = true
    alert.tekst = 'Data zwrotu nie może być mniejsza od daty odbioru'
    alert.show = true
  }
}
const filtruj = () => {
  // if (rodzajPaliwa.value != null) rodzajPaliwa.value = parseInt(rodzajPaliwa.value, 10)
  if (
    cenaMax.value != null &&
    cenaMin.value != null &&
    rodzajSkrzyni.value != null &&
    rodzajPaliwa.value != null
  ) {
    samochody.value = zapytanie.value.filter(
      (s) =>
        s.cena >= cenaMin.value &&
        s.cena <= cenaMax.value &&
        s.rodzajSkrzyni == rodzajSkrzyni.value &&
        s.rodzajPaliwa == rodzajPaliwa.value
    )
  } else if (cenaMax.value != null && cenaMin.value != null && rodzajSkrzyni.value != null) {
    samochody.value = zapytanie.value.filter(
      (s) =>
        s.cena >= cenaMin.value && s.cena <= cenaMax.value && s.rodzajSkrzyni == rodzajSkrzyni.value
    )
  } else if (cenaMax.value != null && cenaMin.value != null && rodzajPaliwa.value != null) {
    samochody.value = zapytanie.value.filter(
      (s) =>
        s.cena >= cenaMin.value && s.cena <= cenaMax.value && s.rodzajPaliwa == rodzajPaliwa.value
    )
  } else if (cenaMax.value != null && rodzajSkrzyni.value != null && rodzajPaliwa.value != null) {
    samochody.value = zapytanie.value.filter(
      (s) =>
        s.cena <= cenaMax.value &&
        s.rodzajSkrzyni == rodzajSkrzyni.value &&
        s.rodzajPaliwa == rodzajPaliwa.value
    )
  } else if (cenaMin.value != null && rodzajSkrzyni.value != null && rodzajPaliwa.value != null) {
    samochody.value = zapytanie.value.filter(
      (s) =>
        s.cena >= cenaMin.value &&
        s.rodzajSkrzyni == rodzajSkrzyni.value &&
        s.rodzajPaliwa == rodzajPaliwa.value
    )
  } else if (rodzajPaliwa.value != null && rodzajSkrzyni.value != null) {
    samochody.value = zapytanie.value.filter(
      (s) => s.rodzajPaliwa == rodzajPaliwa.value && s.rodzajSkrzyni == rodzajSkrzyni.value
    )
  } else if (cenaMin.value != null && cenaMax.value != null) {
    samochody.value = zapytanie.value.filter(
      (s) => s.cena >= cenaMin.value && s.cena <= cenaMax.value
    )
  } else if (rodzajPaliwa.value != null) {
    samochody.value = zapytanie.value.filter((s) => s.rodzajPaliwa == rodzajPaliwa.value)
  } else if (rodzajSkrzyni.value != null) {
    samochody.value = zapytanie.value.filter((s) => s.rodzajSkrzyni == rodzajSkrzyni.value)
  } else if (cenaMin.value != null) {
    samochody.value = zapytanie.value.filter((s) => s.cena >= cenaMin.value)
  } else if (cenaMax.value != null) {
    samochody.value = zapytanie.value.filter((s) => s.cena <= cenaMax.value)
  } else {
    samochody.value = zapytanie.value
  }
}
const wyczysc = () => {
  cenaMax.value = null
  cenaMin.value = null
  rodzajSkrzyni.value = null
  rodzajPaliwa.value = null
  samochody.value = zapytanie.value
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
  <div class="tlo">
    <v-form @submit.prevent="submit">
      <div class="daty">
        <div class="datyElementy">
          <div>
            <label>Odbiór</label>
            <input
              class="kalendarz"
              type="date"
              v-model="data"
              :min="new Date().toJSON().slice(0, 10)"
              :max="new Date(Date.now() + 2592000000).toJSON().slice(0, 10)"
              onkeydown="return false"
            />
            <label>Zwrot</label>
            <input
              class="kalendarz"
              type="date"
              v-model="dataZakonczenia"
              :min="new Date().toJSON().slice(0, 10)"
              :max="new Date(Date.now() + 2800000000).toJSON().slice(0, 10)"
              onkeydown="return false"
            />
          </div>

          <div>
            <div>
              wiek kierowcy
              <select v-model="wiek" required class="wybor">
                <option value="0">25 lat i mniej</option>
                <option value="1">26 - 69lat</option>
                <option value="2">70 lat i więcej</option>
              </select>
              <v-btn class="mt-5 mb-5" type="submit" color="#EBCC39"> szukaj </v-btn>
            </div>
          </div>
        </div>
      </div>
    </v-form>
    <div v-if="!strona" class="o">
      <div class="oNasTytul"><h1>Co nas wyróżnia</h1></div>
      <div class="oNas">
        <div class="oNasLewo">
          <div>
            <div class="oNasTytul"><h2>Samochody</h2></div>

            <div>Nowe i zabytkowe</div>
          </div>
          <div>
            <div class="oNasTytul"><h2>Rezygnacja</h2></div>

            <div>Możliwość rezygnacji do 48 h przed datą odbioru</div>
          </div>
        </div>
        <div class="oNasPrawo">
          <div>
            <div class="oNasTytul"><h2>Płatność</h2></div>

            <div>U nas płacisz przy odbiorze samochodu</div>
          </div>
          <div>
            <div class="oNasTytul"><h2>Przedłużenia</h2></div>

            <div>Jeżeli samochód nie będzie zarezerwowany przedłużymy ci go</div>
          </div>
        </div>
      </div>
    </div>

    <div class="o" v-if="!strona">
      <div class="oNasTytul">
        <h1>Nasze auta</h1>
      </div>
      <div class="oNas">
        <div></div>
        <div class="oNasSamochody" v-for="samochod in listaSamochodow" :key="samochod.id">
          <img width="150" :src="'https://localhost:7122/Photos/' + samochod.id + '.png'" />
          <div>{{ samochod.marka }} {{ samochod.model }}</div>
        </div>
      </div>
    </div>

    <div v-if="strona">
      <div class="filtrowanie">
        <div class="filtr">
          <h2>Filtry</h2>
          <div>
            Rodzaj paliwa
            <br />
            <select v-model="rodzajPaliwa" required class="wybor">
              <option value="null" selected hidden>Wybierz</option>
              <option value="0">Benzyna</option>
              <option value="1">Diesel</option>
              <option :value="null" checked>Benzyna i Diesel</option>
            </select>
          </div>
          <div>
            Skrzynia biegów
            <br />
            <select v-model="rodzajSkrzyni" required class="wybor">
              <option value="null" selected hidden>Wybierz</option>
              <option value="0">Manual</option>
              <option value="1">Automat</option>
              <option :value="null" checked>Manual i Automat</option>
            </select>
          </div>
          <div>
            Cena za dzień
            <div>od <input type="number" :min="0" v-model="cenaMin" class="wybor" /></div>
            <div>do <input type="number" v-model="cenaMax" class="wybor" /></div>
          </div>
          <div>
            <v-btn @click="filtruj" color="#EBCC39"> filtruj </v-btn>
          </div>
          <v-btn @click="wyczysc" variant="plant" color="#EBCC39"> wyczyść </v-btn>
        </div>
      </div>

      <div class="listaSamochod">
        <v-list-item v-for="samochod in samochody" :key="samochod.id">
          <div>
            <div class="samochod">
              <div class="nazwaSamochodu">
                <h3>{{ samochod.marka }} {{ samochod.model }}</h3>
              </div>

              <div class="infoSamochod">
                <div class="zdjecieSamochodu">
                  <img
                    width="150"
                    style="border-radius: 10px"
                    :src="'https://localhost:7122/Photos/' + samochod.id + '.png'"
                  />
                </div>
                <div class="oSamochodzie" style="float: left">
                  rocznik: {{ samochod.rocznik }}<br />
                  rodzaj paliwa: {{ typPaliwa(samochod.rodzajPaliwa) }}<br />
                  rodzaj skrzyni: {{ typSkrzyni(samochod.rodzajSkrzyni) }}<br />
                  liczba drzwi: {{ samochod.liczbaDrzwi }}<br />
                  liczba miejsc: {{ samochod.liczbaMiejsc }}
                </div>

                <div class="cenaSamochodu">
                  {{ samochod.cena }} zł za dzień<br />
                  {{ samochod.cena * ileDni }} zł za {{ ileDni }}dni<br />
                  <RouterLink
                    :to="'/rezerwacja/' + samochod.id + '/ubezpieczenia'"
                    custom
                    v-slot="{ navigate }"
                  >
                    <v-btn @click="navigate" color="#EBCC39">Wybieram</v-btn>
                  </RouterLink>
                </div>
              </div>
            </div>
          </div>
        </v-list-item>
      </div>
    </div>
  </div>
</template>
<style>
.o {
  width: 100vw;
  background-color: transparent;
}
@media screen and (max-width: 500px) {
  .oNas {
    display: flex;
    flex-wrap: wrap;
    text-align: center;
    width: 400px;
    flex-direction: column;
    float: center;
    margin: 0 auto;
    justify-content: center;
  }
}
@media screen and (min-width: 501px) {
  .oNas {
    display: flex;
    flex-wrap: wrap;
    text-align: center;
    width: 700px;
    float: center;
    margin: 0 auto;
  }
}

.oNasTytul {
  color: #e3b60b;
  margin-top: 30px;
  text-align: center;
}

.oNasLewo {
  width: 350px;

  height: 250px;
}
.oNasPrawo {
  width: 350px;

  height: 250px;
}
.oNasSamochody {
  width: 230px;
  height: 200px;
}
.daty {
  width: 100vw;
  height: 300px;
  text-align: center;
  padding-top: 100px;
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
.wybor {
  border: 1px solid gray;
  border-radius: 10px;
  text-align: center;
  min-width: 150px;
  max-width: 100px;
  margin: 0px 5px 5px 5px;
  box-shadow:
    0 2px 8px 0 rgba(0, 0, 0, 0.2),
    0 1px 20px 0 rgba(0, 0, 0, 0.19);
}
.datyElementy {
  background-color: var(--okno);
  margin: auto;
  width: 400px;
  border: 1px solid grey;
  border-radius: 15px;
  box-shadow:
    0 2px 8px 0 rgba(0, 0, 0, 0.2),
    0 2px 20px 0 rgba(0, 0, 0, 0.19);
}
.filtrowanie {
  margin-top: 10px;
  width: 370px;
  text-align: center;
  height: 400px;
  float: left;
}
.filtr {
  background-color: var(--okno);
  border: 1px solid grey;
  margin: 0px 30px;
  padding: 10px 0px;
  border-radius: 15px;
  box-shadow:
    0 2px 8px 0 rgba(0, 0, 0, 0.2),
    0 2px 20px 0 rgba(0, 0, 0, 0.19);
}
.listaSamochod {
  min-width: 400px;
  width: 70vw;
  float: left;
}
.samochod {
  background-color: var(--okno);
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
  width: 160px;
  float: left;
}
.oSamochodzie {
  width: 200px;
}
.cenaSamochodu {
  text-align: right;
}
</style>
