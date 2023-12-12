<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
const listaSamochodow = ref([])
const file = ref([])
const dodaj = ref(false)

const Marka = ref()
const Model = ref()
const rocznik = ref()
const liczbaDrzwi = ref()
const liczbaMiejsc = ref()
const rodzajSkrzyni = ref()
const rodzajPaliwa = ref()
const Cena = ref()

onBeforeMount(async () => {
  try {
    var res = await axiosToken.get(`/Admin/ListaSamochodow`)
    listaSamochodow.value = res.data
    console.log(listaSamochodow)
  } catch (error) {
    console.error('Błąd', error)
  }
})

const submit = async () => {
  rodzajSkrzyni.value = parseInt(rodzajSkrzyni.value)
  rodzajPaliwa.value = parseInt(rodzajPaliwa.value)
  var res = await axiosToken.post(`/Admin/DodajSamochod`, {
    marka: Marka.value,
    model: Model.value,
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
  location.reload()
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <div class="tytul">
        Samochody
        <v-btn elevation="0" class="dodanie" icon="mdi-plus-circle" @click="dodaj = true"> </v-btn>
      </div>
      <div v-if="dodaj" class="formularz">
        <v-form @submit.prevent>
          <div>
            <v-file-input v-model="file" />
            <input type="text" v-model="Marka" placeholder="Marka" />
            <input type="text" v-model="Model" placeholder="Model" />
            <input type="numer" v-model="rocznik" placeholder="Rocznik" />
            <input type="numer" v-model="liczbaDrzwi" placeholder="liczbaDrzwi" />
            <input type="numer" v-model="liczbaMiejsc" placeholder="liczbaMiejsc" />
            <input v-model="rodzajSkrzyni" placeholder="rodzajSkrzyni" />
            <input v-model="rodzajPaliwa" placeholder="rodzajPaliwa" />
            <input type="numer" v-model="Cena" placeholder="Cena" />
          </div>
          <v-btn @click="submit()" class="mt-5">Dodaj </v-btn>
        </v-form>
      </div>
      <v-list-item v-for="samochod in listaSamochodow" :key="samochod.id">
        <div>
          {{ samochod.id }} {{ samochod.marka }} {{ samochod.model }}
          <v-btn elevation="0" icon="mdi-lock-open-outline"></v-btn>
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

.okno {
  width: 450px;
  border: 1px solid grey;

  border-radius: 15px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
  margin: 100px auto;
}
.tytul {
  float: left;
  height: 100px;
  width: 100%;
  text-align: center;
  font-size: 26px;
}
.formularz {
  text-align: center;
}
.dodanie {
  float: right;
}
</style>
