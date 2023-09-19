<script setup>

</script>

<template>
    <v-app-bar :elevaton="5" color="primary" height="50">
            <v-tabs 
            :mandatory="false">
                <RouterLink to="/rezerwacja" custom v-slot="{ navigate }">
                    <v-tab @click="navigate">rezerwacje</v-tab>
                </RouterLink>
                
                <v-tab>moje rezerwacje</v-tab>
            </v-tabs>
            <template v-slot:append>
                witaj adam
                <v-btn icon="mdi-dots-vertical"></v-btn>
            </template>
            
    </v-app-bar>
</template>
