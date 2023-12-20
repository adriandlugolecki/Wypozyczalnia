<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
const listaPrzedluzen = ref()
onBeforeMount(async () => {
  var res = await axiosToken.get(`/Pracownik/DoPrzedluzenia`)
  listaPrzedluzen.value = res.data
})
const zatwierdz = async (id) => {
  await axiosToken.patch(`/Pracownik/ZaakceptujPrzedluzenie/${id}`)
  location.reload()
}
const odrzuc = async (id) => {
  await axiosToken.delete(`/Pracownik/UsunPrzedluzenie/${id}`)
  location.reload()
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <div class="tytul">Oczekujące przedłużenia</div>
      <div v-if="listaPrzedluzen.value == null" class="tytul">Lista jest pusta</div>
      <v-list-item v-for="przedluzenie in listaPrzedluzen" :key="listaPrzedluzen.id">
        <div>
          {{ przedluzenie.id }}|{{ przedluzenie.kwota }}zł
          <v-btn icon="mdi-check" color="green" @click="zatwierdz(przedluzenie.id)" />
          <v-btn icon="mdi-delete" color="red" @click="odrzuc(przedluzenie.id)" />
        </div>
      </v-list-item>
    </div>
  </div>
</template>
<style scoped>
.okno {
  width: 450px;
  border: 1px solid grey;
  min-height: 100px;
  border-radius: 15px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
  margin: 100px auto;
}
.tytul {
  height: 100px;
  width: 100%;
  text-align: center;
  font-size: 26px;
}
</style>
