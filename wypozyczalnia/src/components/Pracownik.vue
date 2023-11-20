<script setup>
    import { onBeforeMount, ref } from 'vue';
    import { axioss } from '../main';
    const listaWypozyczen = ref([]);
    onBeforeMount(async ()=> {
        try{
            var res = await axioss.get(`/Pracownik/ListaWypozyczenNaDzis`)
            listaWypozyczen.value = res.data;
        }
        catch(error){
            console.error('Błąd',error)
        }
        
    }
    )
</script>
<template>
    <br/>
    <br/>
    <v-list-item v-for="wypozyczenie in listaWypozyczen" :key="wypozyczenie.id" >
        <div>
            <div>
                id:{{ wypozyczenie.id }}
                Id Samochodu:{{ wypozyczenie.samochodId }}
            </div>
        </div>
            
        
        
    </v-list-item>
</template>