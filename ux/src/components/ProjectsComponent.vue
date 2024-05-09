<template>
<v-col>
    <v-container>
        <v-row class="portfolio-grid">
            <!-- Iterate over portfolio items -->
            <v-col v-for="(item, index) in portfolioApiData" :key="index" class="portfolio-item">
                <v-card :href="item.linkOne">
                    <template v-slot:title>
                        <span class="font-weight-black">{{ item.title }}</span>
                    </template>
                    <v-card-text class="bg-surface-light pt-4">
                        {{ item.about }}
                    </v-card-text>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</v-col>
</template>

<script>
import axios from 'axios'
export default {
    data() {
        return {
            portfolioApiData: []
        }
    },
    methods: {
        GetProjects() {
            axios.get('https://matt-portfolio-api.azurewebsites.net/projects', {
                headers: {
                    'Access-Control-Allow-Origin': '*'
                }
            }).then(response => {
                console.log(response)
                this.portfolioApiData = response.data
            }).catch(err => {
                console.log(err)
            })
        }
    },
    mounted() {
        this.GetProjects()
    }
}
</script>

<style scoped>
.portfolio-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    /* Automatically adjust columns */
    gap: 20px;
    /* Adjust as needed */
}

.portfolio-item {
    width: 100%;
}
</style>
