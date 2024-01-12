<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken, alert } from '../../main'
const listaSamochodow = ref([])
const file = ref([])
const dodaj = ref(false)

const Marka = ref()
const Model = ref()
const Rejestracja = ref()
const rocznik = ref()
const liczbaDrzwi = ref()
const liczbaMiejsc = ref()
const rodzajSkrzyni = ref(0)
const rodzajPaliwa = ref(0)
const Cena = ref()

onBeforeMount(async () => {
  try {
    var res = await axiosToken.get(`/Admin/ListaSamochodow`)
    listaSamochodow.value = res.data
  } catch (error) {}
})

const submit = async () => {
  try {
    rodzajSkrzyni.value = parseInt(rodzajSkrzyni.value)
    rodzajPaliwa.value = parseInt(rodzajPaliwa.value)
    var res = await axiosToken.post(`/Admin/DodajSamochod`, {
      marka: Marka.value,
      model: Model.value,
      Rejestracja: Rejestracja.value,
      rocznik: rocznik.value,
      liczbaMiejsc: liczbaMiejsc.value,
      liczbaDrzwi: liczbaDrzwi.value,
      rodzajSkrzyni: rodzajSkrzyni.value,
      rodzajPaliwa: rodzajPaliwa.value,
      cena: Cena.value
    })
    let formData = new FormData()
    formData.append('zdjecie', file.value[0])
    await axiosToken.post(`/Admin/DodajZdjecie/${res.data.id}`, formData)

    alert.tekst = 'Dodano samochód'
    alert.show = true
    location.reload()
  } catch (error) {
    alert.tekst = 'Błąd'
    alert.error = true
    alert.show = true
    location.reload()
  }
}
const zablokujOdblokuj = async (id) => {
  await axiosToken.patch(`/Admin/ZablokujOdblokujSamochod/${id}`)
  location.reload()
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <v-btn elevation="0" class="dodanie" icon="mdi-plus-circle" @click="dodaj = !dodaj"> </v-btn>
      <h1 class="tytul">Samochody</h1>
      <div v-if="dodaj" class="formularz">
        <v-form @submit.prevent>
          <v-card width="80%" height="50px" elevation="0" class="center mr-10 ml-10 mb-10">
            <v-file-input v-model="file" label="dodaj zdjęcie" />
          </v-card>
          <div>
            <input type="text" v-model="Marka" placeholder="Marka" class="wybor" />
            <input type="text" v-model="Model" placeholder="Model" class="wybor" />
            <input type="text" v-model="Rejestracja" placeholder="Rejestracja" class="wybor" />
            <input type="numer" v-model="rocznik" placeholder="Rocznik" class="wybor" />
            <input type="numer" v-model="liczbaDrzwi" placeholder="liczbaDrzwi" class="wybor" />
            <input type="numer" v-model="liczbaMiejsc" placeholder="liczbaMiejsc" class="wybor" />
            <select v-model="rodzajPaliwa" required class="wybor">
              <option value="null" selected hidden>Wybierz</option>
              <option value="0">Benzyna</option>
              <option value="1">Diesel</option>
            </select>
            <select v-model="rodzajSkrzyni" required class="wybor">
              <option value="null" selected hidden>Wybierz</option>
              <option value="0">Manual</option>
              <option value="1">Automat</option>
            </select>

            <input type="numer" v-model="Cena" placeholder="Cena" class="wybor" />
          </div>

          <v-btn @click="submit()" class="mt-5" color="#ebcc39">Dodaj </v-btn>
        </v-form>
      </div>
      <v-list-item v-for="samochod in listaSamochodow" :key="samochod.id">
        <div>
          {{ samochod.id }} {{ samochod.marka }} {{ samochod.model }} [{{ samochod.rejestracja }}]

          <v-btn
            v-if="!samochod.czyZablokowany"
            elevation="0"
            @click="zablokujOdblokuj(samochod.id)"
            icon="mdi-lock-open-outline"
          ></v-btn>
          <v-btn
            v-if="samochod.czyZablokowany"
            elevation="0"
            @click="zablokujOdblokuj(samochod.id)"
            icon="mdi-lock-outline"
          ></v-btn>
        </div>
      </v-list-item>
    </div>
  </div>
</template>
<style scoped>
.tlo {
  height: 100vh;
  width: 100vw;
}
@media screen and (max-width: 500px) {
  .okno {
    text-align: center;
    width: 380px;
    border: 1px solid grey;
    background-color: var(--okno);
    border-radius: 15px;
    box-shadow:
      0 8px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
    margin: 0 auto;
  }
}

@media screen and (min-width: 501px) {
  .okno {
    text-align: center;
    width: 450px;
    border: 1px solid grey;
    background-color: var(--okno);
    border-radius: 15px;
    box-shadow:
      0 8px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
    margin: 0 auto;
  }
}

.tytul {
  float: left;
  height: 100px;
  width: 100%;
  text-align: center;
}
.zdjecie {
  position: relative !important;
}
.formularz {
  text-align: center;
}
.dodanie {
  float: right;
}
</style>
