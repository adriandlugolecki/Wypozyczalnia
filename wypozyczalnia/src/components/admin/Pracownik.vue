<script setup>
import { ref } from 'vue'
import { axiosToken, alert } from '../../main'
const props = defineProps({
  pracownik: Object
})
const rozwin = ref(false)
const haslo = ref('')
const zmien = async () => {
  if (
    haslo.value.toLowerCase() !== haslo.value &&
    /\d/.test(haslo.value) &&
    haslo.value.length >= 8 &&
    haslo.value != ''
  ) {
    // var res = await axiosToken.patch(`Autoryzacja/ZmianaHaslaPracownik`, {
    //   email: props.pracownik.email,
    //   haslo: haslo.value
    // })
    alert.tekst = res.data
    alert.show = true
  } else {
    alert.tekst = ' Hasło musi zawierać przynajmniej 8 znaków, małą literę, dużą literę i cyfrę '
    alert.error = true
    alert.show = true
  }
}
</script>
<template>
  <div>
    {{ props.pracownik.imie }} {{ props.pracownik.nazwisko }} {{ props.pracownik.phoneNumber }}

    <v-btn icon="mdi-key-variant" elevation="0" @click="rozwin = !rozwin" />
  </div>
  <div v-if="rozwin" class="zmianaHasla">
    <h2>Zmiana hasła</h2>

    <input placeholder="Wpisz nowe hasło" v-model="haslo" class="wybor" />
    <div>
      <v-btn @click="zmien" color="#ebcc39">zmień</v-btn>
    </div>
  </div>
</template>
<style scoped>
.zmianaHasla {
  text-align: center;
  padding: 10px;
}
.wybor {
  border: 1px solid gray;
  padding: 5px;
  border-radius: 10px;
  text-align: center;
  min-width: 150px;
  max-width: 100px;
  margin: 10px;
  box-shadow:
    0 2px 8px 0 rgba(0, 0, 0, 0.2),
    0 1px 20px 0 rgba(0, 0, 0, 0.19);
}
</style>
