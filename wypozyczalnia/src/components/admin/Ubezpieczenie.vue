<script setup>
import { ref } from 'vue'
import { axiosToken } from '../../main'
import router from '../../router'
const props = defineProps({
  ubezpieczenie: Object
})
const kwota = ref(props.ubezpieczenie.kwota)
const rozwin = ref(false)
const zmienKwote = async () => {
  try {
    var res = await axiosToken.patch(`/Admin/EdytujUbezpieczenie`, {
      id: props.ubezpieczenie.id,
      nazwa: props.ubezpieczenie.nazwa,
      kwota: kwota.value
    })
    alert.tekst = res.data
    alert.show = true
    location.reload()
  } catch (error) {
    alert.text = 'Wpisz liczbę'
    alert.error = true
    alert.show = true
  }
}
</script>
<template>
  <div>
    {{ ubezpieczenie.id }} {{ ubezpieczenie.nazwa }} {{ kwota }} zł
    <v-btn icon="mdi-currency-usd" elevation="0" @click="rozwin = !rozwin" />
    <div v-if="rozwin" class="kwota">
      <h2>Zmień Kwotę</h2>
      <input type="number" v-model="kwota" class="wybor" />zł
      <div><v-btn @click="zmienKwote" color="#ebcc39">zmień</v-btn></div>
    </div>
  </div>
</template>
<style scoped>
.kwota {
  text-align: center;
}
</style>
