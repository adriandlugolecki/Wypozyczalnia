<script setup>
    import {axiosToken} from "../main"
    import { ref } from "vue";
    import router from "../router";
    import { onBeforeMount } from "vue";
    const auto = localStorage.getItem("auto");
    const ubezpieczenie = localStorage.getItem("ubezpieczenie");
    const data = localStorage.getItem("data");
    const dataZakonczenia = localStorage.getItem("dataZakonczenia");
    const token = localStorage.getItem("token");
    const cos = ref();
    const zarezerwuj = async () =>{
        await axiosToken.post(`/klient/wypozyczeniesamochodu`,{
            samochodId: auto,
            klientId: "id",
            data: data,
            dataZakonczenia: dataZakonczenia,

        }, {Authorization: `Bearer ${token}`}
        );
    router.push("/");
}
</script>

<template>
    <v-card width="100vw" height="100vh" class="d-flex justify-center align-center">
        
        
            <div>
                Podsumowanie 
                <v-card elevation="5" >
                    samochód
                    {{auto}}
                    ubezpieczenie
                    {{ubezpieczenie}}
                    <RouterLink to="/podsumowanie" custom v-slot="{ navigate }">
                    <v-btn class="mt-5 mb-5" type="submit" @click="zarezerwuj">
                            zarezerwuj
                    </v-btn>
                    </RouterLink>
                    
                </v-card>
            </div>
          
                
                
            
            
            
        
        
    </v-card>
</template>