<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
import Ubezpieczenie from './Ubezpieczenie.vue'
const listaUbezpieczen = ref([])

onBeforeMount(async () => {
  try {
    var res = await axiosToken.get(`/Admin/ListaUbezpieczen`)
    listaUbezpieczen.value = res.data
  } catch (error) {}
})
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <h1 class="tytul">Ubezpieczenia</h1>
      <v-list-item v-for="ubezpieczenie in listaUbezpieczen" :key="ubezpieczenie.id">
        <Ubezpieczenie :ubezpieczenie="ubezpieczenie" />
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
    padding-top: 40px;
    width: 350px;
    border: 1px solid grey;
    background-color: var(--okno);
    border-radius: 15px;
    box-shadow:
      0 8px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
    margin: 0 auto;
  }
}

@media screen and (min-width: 500px) {
  .okno {
    text-align: center;
    padding-top: 40px;
    width: 450px;
    border: 1px solid grey;
    min-height: 200px;
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
.dodanie {
  float: right;
}
</style>
