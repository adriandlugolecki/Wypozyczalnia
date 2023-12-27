<script setup>
import { onBeforeMount, ref } from 'vue'
import router from '../router'
import { alert, axioss } from '../main'
const kod = ref()

const sprawdz = async () => {
  try {
    var id = router.currentRoute.value.params['id']
    var res = await axioss.patch(`/Autoryzacja/PotwierdzenieKonta/${id}/${kod.value}`)
    if (res.data == 'Aktywowano Konto') {
      alert.tekst = res.data
      alert.show = true
      router.push('/')
    }
  } catch (error) {
    alert.tekst = 'Kod jest niepoprawny'
    alert.error = true
    alert.show = true
  }
}
</script>
<template>
  <div class="tlo">
    <div class="okno">
      <div class="tytul">Wpisz kod</div>
      <div>
        <input class="poleKod" v-model="kod" placeholder="Wpisz kod" />
      </div>
      <div>kod został wysłany na maila</div>

      <v-btn @click="sprawdz"> sprawdz</v-btn>
    </div>
  </div>
</template>
<style scoped>
.okno {
  text-align: center;
  margin: 100px auto;
  border: 1px gray solid;
  width: 400px;
  padding: 30px;
  border-radius: 15px;
  box-shadow:
    0 8px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.tytul {
  font-size: xx-large;
}
.poleKod {
  border: 1px solid gray;
  border-radius: 15px;
  text-align: center;
}
</style>
