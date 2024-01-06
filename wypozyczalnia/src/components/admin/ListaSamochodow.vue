<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
const listaSamochodow = ref([])
const file = ref([])
const dodaj = ref(false)

const Marka = ref()
const Model = ref()
const Rejestracja = ref()
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
    console.log(listaSamochodow.value)
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
  location.reload()
}
const zablokujOdblokuj = async (id) => {
  await axiosToken.patch(`/Admin/ZablokujOdblokujSamochod/${id}`)
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <v-btn elevation="0" class="dodanie" icon="mdi-plus-circle" @click="dodaj = !dodaj"> </v-btn>
      <h1 class="tytul">Samochody</h1>
      <div v-if="dodaj" class="formularz">
        <v-form @submit.prevent>
          <v-card width="100%" height="50px" elevation="0">
            <v-file-input v-model="file" label="dodaj zdjęcie" />
          </v-card>
          <div>
            <input type="text" v-model="Marka" placeholder="Marka" class="wybor" />
            <input type="text" v-model="Model" placeholder="Model" class="wybor" />
            <input type="text" v-model="Rejestracja" placeholder="Rejestracja" class="wybor" />
            <input type="numer" v-model="rocznik" placeholder="Rocznik" class="wybor" />
            <input type="numer" v-model="liczbaDrzwi" placeholder="liczbaDrzwi" class="wybor" />
            <input type="numer" v-model="liczbaMiejsc" placeholder="liczbaMiejsc" class="wybor" />
            <input v-model="rodzajSkrzyni" placeholder="rodzajSkrzyni" class="wybor" />
            <input v-model="rodzajPaliwa" placeholder="rodzajPaliwa" class="wybor" />
            <input type="numer" v-model="Cena" placeholder="Cena" class="wybor" />
          </div>

          <v-btn @click="submit()" class="mt-5" color="#ebcc39">Dodaj </v-btn>
        </v-form>
      </div>
      <v-list-item v-for="samochod in listaSamochodow" :key="samochod.id">
        <div>
          {{ samochod.id }} {{ samochod.marka }} {{ samochod.model }} [{{ samochod.rejestracja }}]
          {{ samochod.czyZablokowany }}

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

.okno {
  width: 450px;
  border: 1px solid grey;
  background-color: var(--okno);
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
