<script setup>
import { axiosToken, alert } from '../../main'
import { ref } from 'vue'
import router from '../../router'
import { onBeforeMount } from 'vue'
import { zasadyImie, zasadyNumer, zasadyWymagane } from '../../zasady'
const auto = localStorage.getItem('auto')
const ubezpieczenie = localStorage.getItem('ubezpieczenie')
const wiek = localStorage.getItem('wiek')
const data = new Date(localStorage.getItem('data'))
const dataZakonczenia = new Date(localStorage.getItem('dataZakonczenia'))
const Samochod = ref()
const Ubezpieczenie = ref()
const ileDni = Math.ceil(Math.abs(dataZakonczenia - data) / (1000 * 3600 * 24))
const odbior = ref(true)
const samochodInfo = ref(true)
const zrodlo = ref('')
const imie = ref()
const nazwisko = ref()
const telefon = ref()
const adres = ref()
const miejscowosc = ref()
const kod = ref()
const formularz = ref()
onBeforeMount(async () => {
  try {
    var res = await axiosToken.get(`/Samochod/${auto}`)
    var res2 = await axiosToken.get(`/Ubezpieczenie/${ubezpieczenie}`)

    Samochod.value = res.data
    Ubezpieczenie.value = res2.data
    zrodlo.value = 'https://localhost:7122/Photos/' + Samochod.value.id + '.png'
  } catch (error) {
    console.error('Błąd', error)
  }
})
const submit = async (event) => {
  await event
  const dane = await formularz.value?.validate()
  if (dane && dane.valid) {
    try {
      const kwota = ileDni * (Ubezpieczenie.value.kwota + Samochod.value.cena + OplataZaWiek(wiek))
      console.log(kwota)
      await axiosToken.post(`/klient/wypozyczeniesamochodu`, {
        samochodId: Samochod.value.id,
        klientId: 'id',
        data: data,
        dataZakonczenia: dataZakonczenia,
        ileDni: ileDni,
        ubezpieczenieId: Ubezpieczenie.value.id,
        wiek: wiek,
        kwota: kwota,
        imie: imie.value,
        nazwisko: nazwisko.value,
        telefon: telefon.value,
        adres: adres.value,
        miejscowosc: miejscowosc.value,
        kodPocztowy: kod.value
      })
      router.push('/')
      alert.tekst = 'Samochód został zarezerwowany'
      alert.show = true
    } catch (error) {
      alert.tekst = error.response.data
      alert.error = true
      alert.show = true
    }
  }
}
const pozyskanieDaty = (data) => {
  return `${data.getDate()}.${data.getMonth() + 1}.${data.getFullYear()}`
}
const OplataZaWiek = (wiek) => {
  if (wiek == 1) return 0
  else return 20
}
</script>

<template>
  <div class="tlo">
    <div class="PodsumowanieTytul"><h1>Podsumowanie</h1></div>
    <div class="okno">
      <div class="podsumowanie">
        <div>
          <h2>
            odbiór i zwrot
            <v-btn elevation="0" icon="mdi-book-open" @click="odbior = !odbior"></v-btn>
          </h2>
        </div>
        <div v-if="odbior">
          <div>
            <div>Odbiór</div>
            <div>Słoneczna 54, Olsztyn</div>
            {{ pozyskanieDaty(data) }} od godziny 12:00
          </div>
          <div>
            <div>Zwrot</div>
            <div>Słoneczna 54, Olsztyn</div>
            {{ pozyskanieDaty(dataZakonczenia) }} do godziny 10:00
          </div>
        </div>
        <div>
          <h2>
            Samochod<v-btn
              icon="mdi-book-open"
              elevation="0"
              @click="samochodInfo = !samochodInfo"
            ></v-btn>
          </h2>

          <div v-if="samochodInfo">
            <div class="samochodZdjecie">
              <img width="150" :src="zrodlo" />
            </div>
            <div class="samochodOpis">
              {{ Samochod ? Samochod.marka : '' }} {{ Samochod ? Samochod.model : '' }}
            </div>
          </div>
        </div>

        <div>
          <h2>Ubezpieczenie</h2>
          {{ Ubezpieczenie ? Ubezpieczenie.nazwa : '' }}
        </div>
      </div>

      <div class="podsumowanieKwota">
        <h2>Kosztorys</h2>
        <div>
          <span class="gold2">Samochód </span>
          {{ ileDni }} x {{ Samochod ? Samochod.cena : '' }} =
          {{ ileDni * (Samochod ? Samochod.cena : '') }} zł
        </div>

        <div>
          <span class="gold2">Ubezpieczenie</span>
          {{ ileDni }} x {{ Ubezpieczenie ? Ubezpieczenie.kwota : '' }} =
          {{ ileDni * (Ubezpieczenie ? Ubezpieczenie.kwota : '') }} zł
        </div>
        <div>
          <span class="gold2">Wiek Kierowcy</span>
          {{ ileDni }} x {{ OplataZaWiek(wiek) }} = {{ ileDni * OplataZaWiek(wiek) }} zł
        </div>
        <div>
          <span class="gold2">Całkowita kwota</span>
          {{
            ileDni *
            ((Ubezpieczenie ? Ubezpieczenie.kwota : '') +
              (Samochod ? Samochod.cena : '') +
              OplataZaWiek(wiek))
          }}
          zł
        </div>
        <div v-if="ubezpieczenie == 1">Kaucja: 2000 zł</div>
        <div v-if="ubezpieczenie == 2">Kaucja: 1 zł</div>
        <img
          src="/src/assets/fotor-ai-20240107215829.jpg"
          height="200"
          style="border-radius: 30px; margin-top: 50px"
        />
      </div>
      <div class="podsumowanieKierowca">
        <v-form ref="formularz" @submit.prevent="submit">
          <h2>Dane kierowcy</h2>
          <v-text-field label="Imie" v-model="imie" :rules="zasadyImie" />
          <v-text-field label="Nazwisko" v-model="nazwisko" :rules="zasadyImie" />
          <v-text-field label="Numer telefonu" v-model="telefon" :rules="zasadyNumer" />
          <v-text-field label="Adres" v-model="adres" :rules="zasadyWymagane" />
          <v-text-field label="Miejscowość" v-model="miejscowosc" :rules="zasadyImie" />
          <v-text-field label="Kod pocztowy" v-model="kod" :rules="zasadyWymagane" />

          <RouterLink to="/podsumowanie" custom v-slot="{ navigate }">
            <v-btn class="mt-5 mb-5" type="submit" color="yellow"> zarezerwuj </v-btn>
          </RouterLink>
        </v-form>
      </div>
    </div>
  </div>
</template>
<style scoped>
.tlo {
  height: 100vh;
  width: 100vw;
}
.PodsumowanieTytul {
  height: 100px;
  width: 100vw;
  text-align: center;
  font-size: 26px;
  text-shadow: 3px 3px black;
}
@media screen and (max-width: 450px) {
  .okno {
    background-color: var(--okno);
    display: flex;
    flex-direction: column;
    margin: 0 auto;
    width: fit-content;
    height: fit-content;
    border-radius: 15px;
    box-shadow:
      0 4px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
    border: 1px solid black;
  }
}
@media screen and (min-width: 450px) {
  .okno {
    background-color: var(--okno);
    display: flex;
    margin: 0 auto;
    width: 900px;
    height: fit-content;
    border-radius: 15px;
    box-shadow:
      0 4px 8px 0 rgba(0, 0, 0, 0.2),
      0 6px 20px 0 rgba(0, 0, 0, 0.19);
    border: 1px solid black;
  }
}
.podsumowanie {
  min-height: 300px;
  width: 300px;
  padding: 20px;
}
.podsumowanieKierowca {
  text-align: center;
  width: 350px;
  padding: 20px;
}
.podsumowanieKwota {
  height: 450px;
  width: 350px;
  padding: 20px;
}
.samochodZdjecie {
  height: 150px;
}
.samochodOpis {
  width: 150px;
  height: 50px;
}
</style>
