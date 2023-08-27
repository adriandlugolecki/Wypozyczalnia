<script setup>
    import {zasadyHaslo, zasadyLogin} from "../zasady";
    

</script>
<template>
    <v-card width="100vw" height="100vh" class="d-flex justify-center align-center">
        <v-container class="d-flex justify-center align-center">
                <v-card elevation="10"
                        width="400px"
                        height="400px"
                        class="px-6 "
                        radius="200">
                    <v-row class="justify-center my-6">
                        <v-card-title>
                            zaloguj się
                        </v-card-title>
                    </v-row>
                    
                    <v-text-field label="login" :rules= "zasadyLogin"/>
                    <v-text-field label="hasło" :rules= "zasadyHaslo"/>
                    
                    <v-row class="justify-center mt-5">
                        <v-btn>
                            zaloguj
                        </v-btn>
                    </v-row>
                    <v-row class="justify-center">
                        <v-btn size="x-small" variant="plain">
                            zapomnałem hasła
                        </v-btn>
                    </v-row>  
                    
                    
                    
                </v-card>

            </v-container>
    </v-card>
    
    
</template>
<style>

</style>