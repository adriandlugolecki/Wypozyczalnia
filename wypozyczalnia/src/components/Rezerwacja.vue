<script setup>
    import {axioss} from "../main"
    import { ref } from "vue";
    const data = ref();
    const dataZakonczenia = ref();
    const zapytanie = ref([]);
    const wiek = ref();
    const submit = async () => {
    var res = await axioss.get(`/samochod/wolnesamochody/${data.value}/${dataZakonczenia.value}`
    );
        localStorage.setItem("data", data.value);
        localStorage.setItem("dataZakonczenia", dataZakonczenia.value);
       console.log(wiek)
       console.log(res.data)
       zapytanie.value = res.data
       
    }
    
</script>

<template>
   
        <v-form @submit.prevent="submit">
        
             <div class="daty">
                <v-card elevation="5" width="400"  class="datyElementy">
                    <div>
                        <input type="date" v-model="data"/>
                        <input type="date" v-model="dataZakonczenia"/>
                    </div>

                    <div >
                        <div>
                           wiek kierowcy 
                           <select v-model="wiek">
                                <option value="0">25 lat i mniej</option>
                                <option value="1" checked>26 - 69lat</option>
                                <option value="2">70 lat i więcej</option>
                           </select>
                           <v-btn class="mt-5 mb-5" type="submit">
                            szukaj
                            </v-btn>
                        </div>
                        
                        
                    </div>
                    
                </v-card>
            </div> 
        </v-form>
     
    <div>

    
                <div class="filtrowanie">
                <v-card elevation="10" class="ml-10 mr-10" height="100" >
                    filtr
                </v-card>
                </div>
                     
                <div class="listaSamochod">
                    <v-list-item v-for="samochod in zapytanie" :key="samochod.id" >
                        
                           <div>
                            <v-card class="samochod" elevation="10" >
                                <div class="nazwaSamochodu">
                                    {{ samochod.marka }} {{ samochod.model }}
                                </div>
                                
                                
                                <div class="infoSamochod">
                                    <div class="zdjecieSamochodu"><img width="200" src="../assets/samochod.png"/> </div>
                                    <div class="oSamochodzie" style="float:left">
                                        rocznik: {{ samochod.rocznik }}<br/>
                                        rodzaj paliwa: {{ samochod.rodzajPaliwa }}<br/>
                                        rodzaj skrzyni: {{ samochod.rodzajSkrzyni }}<br/>
                                        liczba drzwi: {{ samochod.liczbaDrzwi }}<br/>
                                        liczba miejsc: {{ samochod.liczbaMiejsc }}
                                    </div>
                                
                                    <div class="cenaSamochodu">{{ samochod.cena }} zł<br/>
                                    <RouterLink :to="'/rezerwacja/'+ samochod.id +'/ubezpieczenia'" custom v-slot="{ navigate }">
                                        <v-tab @click="navigate">Wybieram</v-tab>
                                    </RouterLink>
                                    </div>
                                    
                                </div>
                                
                                
                            </v-card>
                        </div>
                                
                           
                        
                    </v-list-item>
                </div>
                
                
            </div>    
            
            
        
        
    
</template>
<style>
.daty{
    width:100vw;
    height:35vh;
    text-align: center;
    padding-top:10vh;
    
}
.datyElementy{
    margin: auto;
}
.filtrowanie{
    width:25vw;
    text-align: center;
    height: 600px;
    float: left;
}
.listaSamochod{
    width: 70vw;
    float: left;
}
.samochod{
    
font-size:larger;
}
.nazwaSamochodu{
    text-align: center;
}

.infoSamochod{
    width: 100%;
}
.zdjecieSamochodu{
    width: 20%;
    float: left;
}
.oSamochodzie{
    width: 60%;
}
.cenaSamochodu{
    text-align: right;
    
}
</style>