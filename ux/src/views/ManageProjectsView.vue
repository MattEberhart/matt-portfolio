<template>
<v-app>
    <v-main>
        <v-col>
            <v-row>
                <ProjectsComponent />
            </v-row>
            <v-row>
                <ProjectFormComponent />
            </v-row>
        </v-col>
    </v-main>
</v-app>
</template>

<script>
import ProjectsComponent from '../components/ProjectsComponent.vue'
import ProjectFormComponent from '../components/ProjectFormComponent.vue'

export default {
    components: {
        ProjectFormComponent,
        ProjectsComponent
    }
}
</script>

<style scoped>
/* Add any necessary scoped CSS styles */
</style>
