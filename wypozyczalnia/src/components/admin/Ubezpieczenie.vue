<script setup>
import { ref } from 'vue'
import { axiosToken } from '../../main'
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
  } catch (error) {}
}
</script>
<template>
  <div>
    {{ ubezpieczenie.id }} {{ ubezpieczenie.nazwa }} {{ ubezpieczenie.kwota }} zł
    <v-btn icon="mdi-pencil" elevation="0" @click="rozwin = !rozwin" />
    <div v-if="rozwin">
      Zmień Kwotę na<input v-model="kwota" />zł <v-btn @click="zmienKwote">zmień</v-btn>
    </div>
  </div>
</template>
<style></style>
