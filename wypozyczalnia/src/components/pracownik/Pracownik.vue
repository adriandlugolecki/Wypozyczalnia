<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
const listaWypozyczen = ref()
const listaZakonczen = ref()
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
      <h2>Wybierz dzień</h2>
      <input type="date" class="kalendarz" v-model="data" />
      <v-btn @click="ZmianaDnia" elevation="0" icon="mdi-car-search"></v-btn>
    </div>
    <div class="okno">
      <h1 class="tytul">Do Wydania</h1>
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
      <h1 class="tytul">Do odbioru</h1>

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
@media screen and (max-width: 500px) {
  .data {
    background-color: var(--okno);
    margin-top: 0px;
    margin-left: auto;
    margin-right: auto;
    height: 100px;
    width: 350px;
    text-align: center;
    border: 1px solid grey;
    border-radius: 15px;
    box-shadow:
      0 8px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
    padding-top: 10px;
  }
}

@media screen and (min-width: 501px) {
  .data {
    background-color: var(--okno);
    margin-top: 0px;
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
}
.kalendarz {
  border: 1px solid grey;
  border-radius: 8px;
  padding: 5px;
  background-color: white;
  margin: 5px;
  box-shadow:
    0 2px 8px 0 rgba(0, 0, 0, 0.2),
    0 2px 20px 0 rgba(0, 0, 0, 0.19);
}

.tekst {
  margin: 10px;
  font-size: 20px;
}

@media screen and (max-width: 500px) {
  .okno {
    background-color: var(--okno);
    float: left;
    min-width: 300px;
    width: 40vw;
    border: 1px solid grey;
    border-radius: 15px;
    box-shadow:
      0 8px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
    margin: 5px 5px 5px 50px;
    text-align: center;
  }
}
@media screen and (min-width: 501px) {
  .okno {
    background-color: var(--okno);
    float: left;
    min-width: 300px;
    width: 40vw;
    border: 1px solid grey;
    border-radius: 15px;
    box-shadow:
      0 8px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
    margin: 50px 5px 5px 100px;
    text-align: center;
  }
}

.tytul {
  float: left;
  height: 50px;
  margin-top: 10px;
  width: 100%;
  text-align: center;
  font-size: 26px;
}
</style>
