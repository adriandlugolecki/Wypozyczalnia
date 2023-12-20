<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
const listaWypozyczen = ref([])
const listaZakonczen = ref([])
const data = ref()
onBeforeMount(async () => {
  try {
    data.value = new Date().toJSON().slice(0, 10)
    var res = await axiosToken.get(`/Pracownik/ListaWypozyczenNaDzis/${data.value}`)
    var res2 = await axiosToken.get(`/Pracownik/ListaZakonczenNaDzis/${data.value}`)
    listaWypozyczen.value = res.data
    listaZakonczen.value = res2.data
  } catch (error) {
    console.error('Błąd', error)
  }
  console.log(listaWypozyczen.value)
})
const ZmianaDnia = async () => {
  try {
    var res = await axiosToken.get(`/Pracownik/ListaWypozyczenNaDzis/${data.value}`)
    var res2 = await axiosToken.get(`/Pracownik/ListaZakonczenNaDzis/${data.value}`)
    listaWypozyczen.value = res.data
    listaZakonczen.value = res2.data
  } catch (error) {
    console.error('Błąd', error)
  }
}
</script>
<template>
  <div class="tlo">
    <div class="data">
      <input type="date" class="kalendarz" v-model="data" />
      <v-btn @click="ZmianaDnia" elevation="0" icon="mdi-car-search"></v-btn>
    </div>
    <div class="okno">
      <div class="tytul">Do Wydania</div>
      <v-list-item v-for="wypozyczenie in listaWypozyczen" :key="wypozyczenie.id">
        <div class="tekst">
          NR: {{ wypozyczenie.id }} | {{ wypozyczenie.samochod.marka }}
          {{ wypozyczenie.samochod.model }} [{{ wypozyczenie.samochod.rejestracja }}]

          <RouterLink :to="'/rezerwacja/' + wypozyczenie.id + '/info'" custom v-slot="{ navigate }">
            <v-btn v-if="!wypozyczenie.czyWydano" @click="navigate" icon="mdi-car-side"></v-btn>
            <v-btn
              v-if="wypozyczenie.czyWydano"
              @click="navigate"
              color="black"
              icon="mdi-car-side"
            ></v-btn>
          </RouterLink>
        </div>
      </v-list-item>
    </div>
    <div class="okno">
      <div class="tytul">Do odbioru</div>
      <v-list-item v-for="wypozyczenie in listaZakonczen" :key="wypozyczenie.id">
        <div class="tekst">
          NR: {{ wypozyczenie.id }} | {{ wypozyczenie.samochod.marka }}
          {{ wypozyczenie.samochod.model }} [{{ wypozyczenie.samochod.rejestracja }}]

          <RouterLink :to="'/rezerwacja/' + wypozyczenie.id + '/info'" custom v-slot="{ navigate }">
            <v-btn
              v-if="!wypozyczenie.czyOddano"
              @click="navigate"
              icon="mdi-garage-open-variant"
            ></v-btn>
            <v-btn
              v-if="wypozyczenie.czyOddano"
              @click="navigate"
              color="black"
              icon="mdi-garage-lock"
            ></v-btn>
          </RouterLink>
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
.kalendarz {
  border: 1px solid grey;
  border-radius: 8px;
  padding: 5px;
  margin: 5px;
  box-shadow:
    0 2px 8px 0 rgba(0, 0, 0, 0.2),
    0 2px 20px 0 rgba(0, 0, 0, 0.19);
}
.data {
  margin-top: 100px;
  margin-left: auto;
  margin-right: auto;
  height: 100px;
  width: 400px;
  text-align: center;
  border: 1px solid grey;
  border-radius: 15px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
  padding-top: 10px;
}
.tekst {
  margin: 10px;
  font-size: 20px;
}
.okno {
  float: left;
  width: 40vw;
  border: 1px solid grey;
  border-radius: 15px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
  margin: 50px 5px 5px 100px;
}
.tytul {
  float: left;
  height: 100px;
  width: 100%;
  text-align: center;
  font-size: 26px;
}
</style>
