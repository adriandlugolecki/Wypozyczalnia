<script setup>
import { axiosToken } from '../main'
import { ref } from 'vue'
import router from '../router'
import { onBeforeMount } from 'vue'
const strona = ref(1)
const listaUbezpieczen = ref()
onBeforeMount(async () => {
  try {
    localStorage.setItem('auto', router.currentRoute.value.params['id'])
    var res = await axiosToken.get(`/Ubezpieczenie/ListaUbezpieczen`)
    listaUbezpieczen.value = res.data
    console.log(listaUbezpieczen.value)
  } catch (error) {
    console.error('Błąd', error)
  }
})

const wybierz = (id) => {
  localStorage.setItem('ubezpieczenie', id)
  router.push('/podsumowanie')
}
</script>

<template>
  <div class="tlo">
    <div class="ubezpieczenieTytul">Wybierz ubezpieczenie</div>
    <div class="okno">
      <table>
        <tr>
          <th width="300px">Co obejmuje ubezpiecznie</th>
          <th width="150px">Podstawowe</th>
          <th width="150px" class="gold">Rozszerzone</th>
        </tr>
        <tr>
          <td>Standardowa polisa AC</td>
          <td>
            <v-icon icon="mdi-check"> </v-icon>
          </td>
          <td>
            <v-icon color="#EBCC39" icon="mdi-check"> </v-icon>
          </td>
        </tr>
        <tr>
          <td>Auto Zastępcze na terenie RP</td>
          <td>
            <v-icon icon="mdi-check"> </v-icon>
          </td>
          <td>
            <v-icon icon="mdi-check" color="#EBCC39"> </v-icon>
          </td>
        </tr>
        <tr>
          <td>Kradzież</td>
          <td>
            <v-icon icon="mdi-close"> </v-icon>
          </td>
          <td>
            <v-icon icon="mdi-check" color="#EBCC39"> </v-icon>
          </td>
        </tr>
        <tr>
          <td>Uszkodzenie Karoserii</td>
          <td>
            <v-icon icon="mdi-close"> </v-icon>
          </td>
          <td>
            <v-icon icon="mdi-check" color="#EBCC39"> </v-icon>
          </td>
        </tr>
        <tr>
          <td>Uszkodzenie Szyby</td>
          <td>
            <v-icon icon="mdi-close"> </v-icon>
          </td>
          <td>
            <v-icon icon="mdi-check" color="#EBCC39"> </v-icon>
          </td>
        </tr>
        <tr>
          <td>Uszkodzenie Opony</td>
          <td>
            <v-icon icon="mdi-close"> </v-icon>
          </td>
          <td>
            <v-icon icon="mdi-check" color="#EBCC39"> </v-icon>
          </td>
        </tr>
        <tr>
          <td>Opłaty administracyjne i koszt naprawy</td>
          <td>
            <v-icon icon="mdi-close"> </v-icon>
          </td>
          <td>
            <v-icon icon="mdi-check" color="#EBCC39"> </v-icon>
          </td>
        </tr>
        <tr>
          <td>Kaucja</td>
          <td>2000 zł</td>
          <td class="gold">1 zł</td>
        </tr>
        <tr>
          <td>Cena za 1 dzień</td>
          <td v-for="ubezpieczenie in listaUbezpieczen" :key="ubezpieczenie.id">
            {{ ubezpieczenie.kwota }} zł
          </td>
        </tr>

        <tr>
          <td></td>

          <td>
            <v-btn @click="wybierz(1)" variant="outlined" color="#EBCC39"> wybierz </v-btn>
          </td>
          <td>
            <v-btn @click="wybierz(2)" color="#EBCC39"> wybierz </v-btn>
          </td>
        </tr>
      </table>
    </div>
  </div>
</template>
<style scoped>
.ubezpieczenieTytul {
  height: 100px;
  width: 100vw;
  margin-top: 100px;
  text-align: center;
  font-size: 26px;
}
@media screen and (max-width: 500px) {
  .okno {
    
    background-color: var(--okno);
    padding: 10px;
    text-align: center;
    border: 1px solid gray;
    border-radius: 15px;
    height: 600px;
    width: 350px;
    margin: 0 auto;

    box-shadow:
      0 4px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
  }
}
@media screen and (min-width: 501px) {
  .okno {
    background-color: var(--okno);
    padding: 10px;
    text-align: center;
    border: 1px solid gray;
    border-radius: 15px;
    height: 400px;
    width: 700px;
    margin: 0 auto;

    box-shadow:
      0 4px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
  }
}
.ubezpieczenia {
  float: left;
  width: 298px;
  height: 400px;
  border: 1px solid black;
  border-radius: 15px;
  box-shadow:
    0 4px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.prawyPrzycisk {
  float: right;
  width: 50px;
  height: 400px;
}
.przyciskWybierz {
  padding-top: 10px;
  height: 100px;
  width: fit-content;
  text-align: center;
  margin: auto;
  display: flex;
}
.oknoTytul {
  font-size: 22px;
  text-align: center;
}
.oknoTresc {
  margin-top: 4px;
  float: left;
  width: 230px;
  font-size: 16px;
  text-align: center;
}
.oknoZnaczek {
  margin-top: 5px;
  float: left;
  width: 100px;
}
.wysrodkujPionowo {
  top: 50%;
  transform: translateY(-50%);
}
</style>
