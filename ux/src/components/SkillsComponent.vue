<template>
<v-col>
    <v-card class="container">
        <v-row>
            <v-card-title>
                <h1>Skills and Technologies</h1>
            </v-card-title>
        </v-row>
        <v-row>
            <v-card-text class="logos">
                <v-img :src="azureIcon" alt="" class="logos-image"></v-img>
                <v-img :src="cSharpIcon" alt="" class="logos-image"></v-img>
                <v-img :src="gitBashIcon" alt="" class="logos-image"></v-img>
            </v-card-text>
        </v-row>
    </v-card>
</v-col>
</template>

    
      
      
    
<script>
export default {
    data() {
        return {
            azureIcon: require('@/assets/azure-2.svg'),
            cSharpIcon: require('@/assets/c--4.svg'),
            gitBashIcon: require('@/assets/git-bash.svg')
        }
    }
}
</script>
      
      
    
<style scoped>
.container {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.text p {
    margin-bottom: 1em;
}

.logos {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
}

.logos-image {
    width: 50px;
    height: auto;
    object-fit: cover;
    margin: 0 10px;
    /* Adjust spacing between icons */
}
</style>
