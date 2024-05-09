<template>
  <v-col cols="4" v-if="isAuthenticated">
    <!-- Button activator for the dialog -->
    <v-btn @click="dialog = true">Add Project</v-btn>

    <!-- Dialog component -->
    <v-dialog v-model="dialog" max-width="500px">
      <v-card>
        <v-form v-model="valid">
          <v-title class="font-weight-black">Add Project</v-title>
          <v-row class="fields-grid">
            <v-col>
              <v-text-field v-model="projectData.title" :rules="titleRules" label="Project Name" hide-details required class="bg-surface-light pt-4"></v-text-field>
            </v-col>

            <v-col>
              <v-text-field v-model="projectData.about" :rules="aboutRules" label="Description" hide-details required class="bg-surface-light pt-4"></v-text-field>
            </v-col>

            <v-col>
              <v-text-field v-model="projectData.linkOne" :rules="linkRules" label="Primary Link" hide-details required class="bg-surface-light pt-4"></v-text-field>
            </v-col>

            <v-col>
              <v-text-field v-model="projectData.linkTwo" :rules="linkRules" label="Secondary Link" hide-details required class="bg-surface-light pt-4"></v-text-field>
            </v-col>

            <v-col>
              <v-file-input v-model="projectData.image" label="Image" hide-details required class="bg-surface-light pt-4"></v-file-input>
            </v-col>
            <v-col>
              <v-btn @click="PostProject" :disabled="!valid">
                Submit
              </v-btn>
            </v-col>
          </v-row>
        </v-form>
      </v-card>
    </v-dialog>
  </v-col>
</template>

<script>
import { useAuth0 } from '@auth0/auth0-vue';
import axios from 'axios';

export default {
  setup() {
    const auth0 = useAuth0();
    return {
      isAuthenticated: auth0.isAuthenticated
    }
  },
  data() {
    return {
      dialog: false, // Dialog control variable
      projectData: {
        title: '',
        about: '',
        image: '',
        linkOne: '',
        linkTwo: ''
      },
      valid: false,
      titleRules: [
        value => {
          if (value) return true
          return 'Project name is required.'
        }
      ],
      aboutRules: [
        value => {
          if (value) return true
          return 'Project description is required.'
        }
      ],
      linkRules: [
        value => {
          if (value) return true
          return 'Links are required.'
        }
      ],
    }
  },
  methods: {
    async PostProject() {
      axios.post('https://matt-portfolio-api.azurewebsites.net/projects', this.projectData, {
        headers: {
          'Access-Control-Allow-Origin': '*'
        }
      }).then(response => {
        console.log(response)
        window.location.reload()
      }).catch(err => {
        console.log(err)
      })
    }
  }
}
</script>

<style scoped>
.fields-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 20px;
}
</style>
