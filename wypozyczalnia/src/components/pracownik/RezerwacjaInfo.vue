<script setup>
import { onBeforeMount, ref } from 'vue'
import { axiosToken } from '../../main'
import router from '../../router'

const wypozyczenie = ref()
const czyWydano = ref(false)
const czyOddano = ref(false)
const idWypozyczenia = ref()
onBeforeMount(async () => {
  try {
    idWypozyczenia.value = router.currentRoute.value.params['id']
    var res = await axiosToken.get(`/Pracownik/WypozyczenieInfo/${idWypozyczenia.value}`)
    wypozyczenie.value = res.data
    console.log(wypozyczenie.value)
  } catch (error) {
    console.error('Błąd', error)
  }
})
const Wydaj = async (id) => {
  if (wypozyczenie.value.czyWydano == false) {
    czyWydano.value = true
  } else {
    czyWydano.value = false
  }
  await axiosToken.patch(`/Pracownik/ZmianaStatusuWypozyczenia/${id}`, {
    czyWydano: czyWydano.value,
    czyOddano: wypozyczenie.czyOddano
  })
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <div class="tytul">
        Informacje o czywydano {{ wypozyczenie ? wypozyczenie.czyWydano : '' }} Informacje o
        czyOdebrano {{ wypozyczenie ? wypozyczenie.czyOddano : 'xd' }}
      </div>

      <v-btn v-if="wypozyczenie && wypozyczenie.czyWydano == false" @click="Wydaj(wypozyczenie.id)"
        >Wydaj
      </v-btn>
      <v-btn v-if="wypozyczenie && wypozyczenie.czyWydano == true" @click="Wydaj(wypozyczenie.id)"
        >Odbierz
      </v-btn>
    </div>
  </div>
</template>
<style scoped>
.tlo {
  height: 100vh;
  width: 100vw;
}
.okno {
  float: left;
  width: 450px;
  border: 1px solid grey;
  border-radius: 15px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
  margin: 100px 5px 5px 5px;
}
.tytul {
  float: left;
  height: 100px;
  width: 100%;
  text-align: center;
  font-size: 26px;
}
</style>
