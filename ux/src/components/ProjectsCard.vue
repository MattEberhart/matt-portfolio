<template>
    <div class="main-container">
        <div class="project-card" v-for="item in portfolioApiData" v-bind:key="item.id">
            <h2>{{ item.title }}</h2>
            <img :src="item.image" alt="">
            <p>{{ item.about }}</p>
            <div class="links">
                <a v-if="item.linkOne !== ''" :href="item.Link1" target="_blank"><img src="../assets/github-icon.svg" alt="Github repository if public"></a>
                <a v-if="item.linkTwo !== ''" :href="item.Link2" target="_blank"><img src="../assets/link-arrow.png" alt="Related link"></a>
            </div>
        </div>
    </div> 
</template>

<script>
import jsonData from "../assets/projects.json"
import axios from 'axios'
export default {
    data(){
        return{
            projectData: jsonData,
            portfolioApiData: {}
        }
    },
    methods: {
        GetProjects(){
            axios.get('https://matt-portfolio-api.azurewebsites.net/projects', {
                headers: {
                    'Access-Control-Allow-Origin' : '*'
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
    .main-container{
        margin-top: 5%;
        display:flex;
        justify-content: center;
        align-items: center;
        flex-wrap: wrap;
    }

    .project-card{
        margin:10px;
        flex-wrap: 0 0 40%;
        background-color: #fff;
        border-radius: 20px;
        box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        max-width: 40%;
        flex-grow: 1;
    }

    .project-card img{
        height: 20rem;
    }

    .project-card p{
        overflow: hidden;
        text-overflow: ellipsis;
    }

    .links{
        display:flex;
        flex-direction:row;
        align-items: center;
        justify-content:flex-end;
    }

    .links img{
        height: 2rem;
        margin: 5px;
    }

</style>