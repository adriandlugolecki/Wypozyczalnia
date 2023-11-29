<script setup>
import { axioss } from '../main'
import { ref } from 'vue'
import router from '../router'
import { onBeforeMount } from 'vue'
const strona = ref(1)
onBeforeMount(() => {
  localStorage.setItem('auto', router.currentRoute.value.params['id'])
})

const wybierz = () => {
  localStorage.setItem('ubezpieczenie', strona.value)
  router.push('/podsumowanie')
}
</script>

<template>
  <div class="tlo">
    <div class="ubezpieczenieTytul">Wybierz ubezpieczenie</div>
    <div class="ubezpieczenieOkno">
      <div class="lewyPrzycisk">
        <v-btn
          align-self="center"
          class="wysrodkujPionowo"
          icon="mdi-arrow-left"
          v-if="strona != 1"
          @click="strona--"
        ></v-btn>
      </div>
      <div class="ubezpieczenia">
        <v-window v-model="strona" direction="horizontal" :touch="false">
          <v-window-item :value="1">
            <div class="oknoTytul">Pakiet bez ochrony</div>
            <div class="oknoTytul">Podstawowy</div>

            <div class="oknoTresc">kradzież</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-close"></v-icon></div>
            <div class="oknoTresc">Uszkodzenie pojazdu</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-close"></v-icon></div>
            <div class="oknoTresc">Uszkodzenie Szyby</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-close"></v-icon></div>
            <div class="oknoTresc">Uszkodzenie Opony</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-close"></v-icon></div>
            <div class="oknoTresc">Auto zastępcze</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-check"></v-icon></div>
            <div class="oknoTresc">Kaucja</div>
            <div class="oknoZnaczek">2000 zł</div>
            <div class="oknoTresc">Udział własny w szkodzie</div>
            <div class="oknoZnaczek">2000 zł</div>

            cena
          </v-window-item>
          <v-window-item :value="2">
            <div class="oknoTytul">Pakiet z ochroną</div>
            <div class="oknoTytul">Komfort</div>

            <div class="oknoTresc">kradzież</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-check"></v-icon></div>
            <div class="oknoTresc">Uszkodzenie pojazdu</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-check"></v-icon></div>
            <div class="oknoTresc">Uszkodzenie Szyby</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-check"></v-icon></div>
            <div class="oknoTresc">Uszkodzenie Opony</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-check"></v-icon></div>
            <div class="oknoTresc">Auto zastępcze</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-check"></v-icon></div>
            <div class="oknoTresc">Kaucja</div>
            <div class="oknoZnaczek">500 zł</div>
            <div class="oknoTresc">Udział własny w szkodzie</div>
            <div class="oknoZnaczek">0 zł</div>
            cena
          </v-window-item>
          <v-window-item :value="3">
            <div class="oknoTytul">Pakiet z ochroną</div>
            <div class="oknoTytul">Premium</div>

            <div class="oknoTresc">kradzież</div>

            <div class="oknoZnaczek"><v-icon icon="mdi-check"></v-icon></div>
            <div class="oknoTresc">Uszkodzenie pojazdu</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-check"></v-icon></div>
            <div class="oknoTresc">Uszkodzenie Szyby</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-check"></v-icon></div>
            <div class="oknoTresc">Uszkodzenie Opony</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-check"></v-icon></div>
            <div class="oknoTresc">Auto zastępcze</div>
            <div class="oknoZnaczek"><v-icon icon="mdi-check"></v-icon></div>
            <div class="oknoTresc">Kaucja</div>
            <div class="oknoZnaczek">1 zł</div>
            <div class="oknoTresc">Udział własny w szkodzie</div>
            <div class="oknoZnaczek">0 zł</div>
            cena
          </v-window-item>
        </v-window>
      </div>
      <div class="prawyPrzycisk">
        <v-btn icon="mdi-arrow-right" v-if="strona != 3" @click="strona++" class="wysrodkujPionowo">
        </v-btn>
      </div>
      <div class="przyciskWybierz">
        <v-btn @click="wybierz"> wybierz </v-btn>
      </div>
    </div>
  </div>
  <!-- <v-card height="100vh" width="100vw" class="d-flex justify-center align-center">
    <v-window v-model="strona" direction="horizontal" :touch="false">
      <v-card-title class="mb-10"> Wybierz ubezpieczenie </v-card-title>

      <v-window-item :value="1">
        <v-row>
            <v-col>
                <v-card class="d-flex justify-center align-center">
            <v-container class="d-flex justify-center align-center">
              Podstawowe
              <br />kradzież Nie
            </v-container>
          </v-card>
            </v-col>
          <v-col>
            <v-btn icon="mdi-arrow-right" @click="strona++"> </v-btn>
          </v-col>

          
        </v-row>
      </v-window-item>
      <v-window-item :value="2">
        <v-row>
          <v-col>
            <v-btn align-self="center" icon="mdi-arrow-left" @click="strona--"></v-btn>
          </v-col>
          <v-col>
            <v-card class="d-flex justify-center align-center"> Komfort </v-card>
          </v-col>
          <v-col>
            <v-btn align-self="center" icon="mdi-arrow-right" @click="strona++"></v-btn>
          </v-col>
        </v-row>
      </v-window-item>
      <v-window-item :value="3">
        <v-row
          ><v-col>
            <v-btn align-self="center" icon="mdi-arrow-left" @click="strona--"></v-btn>
          </v-col>
          <v-col>
            <v-card class="d-flex justify-center align-center"> Premium </v-card>
          </v-col>
          <v-col></v-col>
        </v-row>
      </v-window-item>
      <v-btn class="mt-5 mb-5 ml-5 mr-5" @click="wybierz"> wybierz </v-btn>
    </v-window>
  </v-card> -->
</template>
<style>
.tlo {
  height: 100vh;
  width: 100vw;
}
.ubezpieczenieTytul {
  height: 100px;
  width: 100vw;
  margin-top: 100px;
  text-align: center;
  font-size: 26px;
}
.ubezpieczenieOkno {
  height: 500px;
  width: 400px;
  margin: 0 auto;
}
.lewyPrzycisk {
  float: left;
  width: 50px;
  height: 400px;
  margin: auto;
  vertical-align: middle;
}
.ubezpieczenia {
  float: left;
  width: 298px;
  height: 400px;
  border: 1px solid black;
  border-radius: 15px;
  box-shadow:
    0 4px 8px 0 rgba(0, 0, 0, 0.2),
    0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.prawyPrzycisk {
  float: right;
  width: 50px;
  height: 400px;
}
.przyciskWybierz {
  padding-top: 10px;
  height: 100px;
  width: fit-content;
  text-align: center;
  margin: auto;
  display: flex;
}
.oknoTytul {
  font-size: 22px;
  text-align: center;
}
.oknoTresc {
  margin-top: 4px;
  float: left;
  width: 230px;
  font-size: 16px;
  text-align: center;
}
.oknoZnaczek {
  margin-top: 5px;
  float: left;
  width: 60px;
}
.wysrodkujPionowo {
  top: 50%;
  transform: translateY(-50%);
}
</style>
