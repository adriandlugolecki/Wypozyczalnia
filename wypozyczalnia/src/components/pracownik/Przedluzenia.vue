<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken, alert } from '../../main'
const listaPrzedluzen = ref()
onBeforeMount(async () => {
  var res = await axiosToken.get(`/Pracownik/DoPrzedluzenia`)
  listaPrzedluzen.value = res.data
})
const zatwierdz = async (id) => {
  try {
    var res = await axiosToken.patch(`/Pracownik/ZaakceptujPrzedluzenie/${id}`)
    location.reload()
    alert.tekst = res.data
    alert.show = true
  } catch (error) {
    alert.tekst = error.response.data
    alert.error = true
    alert.show = true
  }
}
const odrzuc = async (id) => {
  try {
    var res = await axiosToken.delete(`/Pracownik/UsunPrzedluzenie/${id}`)
    location.reload()
    alert.tekst = res.data
    alert.show = true
  } catch (error) {}
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <h1 class="tytul">Oczekujące przedłużenia</h1>
      <div v-if="listaPrzedluzen == null" class="tytul">Lista jest pusta</div>
      <v-list-item v-for="przedluzenie in listaPrzedluzen" :key="listaPrzedluzen.id">
        <div class="element">
          <div class="info">{{ przedluzenie.wypozyczenieId }}|{{ przedluzenie.kwota }}zł</div>

          <div class="przyciski">
            <v-btn icon="mdi-check" color="green" @click="zatwierdz(przedluzenie.id)" />
            <v-btn icon="mdi-delete" color="red" @click="odrzuc(przedluzenie.id)" />
          </div>
        </div>
      </v-list-item>
    </div>
  </div>
</template>
<style scoped>
@media screen and (max-width: 500px) {
  .okno {
    background-color: var(--okno);
    width: 350px;
    border: 1px solid grey;
    min-height: 100px;
    border-radius: 15px;
    box-shadow:
      0 8px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
    margin: 0px auto;
  }
}
@media screen and (min-width: 501px) {
  .okno {
    background-color: var(--okno);
    width: 450px;
    border: 1px solid grey;
    min-height: 100px;
    border-radius: 15px;
    box-shadow:
      0 8px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
    margin: 0px auto;
  }
}

.tytul {
  margin-top: 20px;
  height: 100px;
  width: 100%;
  text-align: center;
  font-size: 26px;
}
.element {
  display: flex;
  border-radius: 15px;
  text-align: center;
  height: 60px;
}
.info {
  align-self: center;
  width: 60%;
  float: left;
  margin: 0;
}
.przyciski {
  align-self: center;
  width: 40%;
  float: left;
  text-align: right;
}
</style>
