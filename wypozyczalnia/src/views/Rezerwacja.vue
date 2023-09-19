<script setup>

</script>
<template>
    <v-card width="100vw" height="100vh" class="d-flex justify-center align-center">
        
        <v-container elevation="10" >
            <v-row class="mb-5">
                
                <v-card elevation="5" width="500">
                    <v-card-title>
                        BMW X5
                    </v-card-title>
                    <v-row class="mb-5 ml-5 mr-5">
                        <v-col>
                            <v-img src="https://cdn.vuetifyjs.com/images/cards/halcyon.png"></v-img>
                        </v-col>
                        <v-col>
                            <v-row class="pl-5">
                        skrzynia : manual 
                        </v-row>
                        <v-row class="pl-5">
                            ilość miejsc:5
                        </v-row>
                        <v-row class="pl-5">
                            rodzaj : suv
                        </v-row>
                        </v-col>
                        <v-col>
                            cena : 1000 zł
                            <v-btn class="mt-5 mb-5">
                            zarezerwuj
                            </v-btn>
                        </v-col>
                        
                        

                    </v-row>
                    
                    
                </v-card>
                    
                
                
            </v-row>
            <v-row>
                
                <v-card elevation="5">
                    <v-card-title>
                        Audi A4
                    </v-card-title>
                    <v-btn>
                        zarezerwuj
                    </v-btn>
                </v-card>
                    
                
            
            </v-row>
            
        </v-container>
    </v-card>
</template>