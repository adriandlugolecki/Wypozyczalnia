<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
const listaUbezpieczen = ref([])

onBeforeMount(async () => {
  try {
    var res = await axiosToken.get(`/Admin/ListaUbezpieczen`)
    listaUbezpieczen.value = res.data
    console.log(listaUbezpieczen)
  } catch (error) {
    console.error('Błąd', error)
  }
})
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <div class="tytul">
        Ubezpieczenia
        <v-btn elevation="0" class="dodanie" icon="mdi-plus-circle"> </v-btn>
      </div>
      <v-list-item v-for="ubezpieczenie in listaUbezpieczen" :key="ubezpieczenie.id">
        <div>{{ ubezpieczenie.id }} {{ ubezpieczenie.nazwa }} {{ ubezpieczenie.kwota }} zł</div>
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
.dodanie {
  float: right;
}
</style>
