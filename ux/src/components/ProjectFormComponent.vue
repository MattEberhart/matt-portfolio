<template>
<v-col cols="3">
    <v-card>
        <v-form v-model="valid">
            <v-title class="font-weight-black">Add Project</v-title>
            <v-row class="fields-grid">
                <v-col>
                    <v-text-field v-model="projctName" :rules="projectNameRules" label="Project Name" hide-details required class="bg-surface-light pt-4"></v-text-field>
                </v-col>

                <v-col>
                    <v-text-field v-model="projectDescription" :rules="projectDescriptionRules" label="Description" hide-details required class="bg-surface-light pt-4"></v-text-field>
                </v-col>

                <v-col>
                    <v-text-field v-model="linkOne" :rules="linkRules" label="Primary Link" hide-details required class="bg-surface-light pt-4"></v-text-field>
                </v-col>

                <v-col>
                    <v-text-field v-model="linkTwo" :rules="linkRules" label="Secondary Link" hide-details required class="bg-surface-light pt-4"></v-text-field>
                </v-col>

                <v-col>
                    <v-file-input v-model="image" label="Image" hide-details required class="bg-surface-light pt-4"></v-file-input>
                </v-col>
            </v-row>
        </v-form>
    </v-card>
</v-col>
</template>

<script>
export default {
    data: () => ({
        valid: false,
        projectName: '',
        projectDescription: '',
        projectNameRules: [
            value => {
                if (value) return true

                return 'Project name is required.'
            }
        ],
        projectDescriptionRules: [
            value => {
                if (value) return true
                return 'Project description is required.'
            }
        ],
        linkOne: '',
        linkTwo: '',
        linkRules: [
            value => {
                if (value) return true

                return 'Links are requred.'
            }
        ],
    }),
}
</script>

<style scoped>

.fields-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    /* Automatically adjust columns */
    gap: 20px;
    /* Adjust as needed */
}

</style>
