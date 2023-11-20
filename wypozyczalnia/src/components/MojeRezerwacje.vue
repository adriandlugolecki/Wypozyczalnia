<script setup>
    import { onBeforeMount, ref } from 'vue';
    import { axiosToken } from '../main';
    const listaWypozyczen = ref([]);
    onBeforeMount(async ()=> {
        try{
            var res = await axiosToken.get(`/Klient/WypozyczeniaKlienta`)
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
        {{ wypozyczenie }}
    </v-list-item>
</template>