<template>
    <v-col>
        <v-row>
            <ProjectsComponent/>
        </v-row>
        <v-row>
            <ProjectFormComponent/>
        </v-row>
    </v-col>
</template>

<script>
import ProjectsComponent from '../components/ProjectsComponent'
import ProjectFormComponent from '../components/ProjectFormComponent.vue'

export default {
    components: {
        ProjectFormComponent,
        ProjectsComponent
    }
}
</script>
