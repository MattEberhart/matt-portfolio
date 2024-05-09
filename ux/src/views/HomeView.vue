<template>
  <v-app>
    <v-main>
      <v-row>
        <v-col :cols="profileCols">
          <ProfileComponent />
        </v-col>
        <v-col cols="infoCols">
          <v-row>
            <AboutMeComponent />
          </v-row>
          <v-row>
            <SkillsComponent />
          </v-row>
          <v-row>
            <ProjectsComponent />
          </v-row>
        </v-col>
      </v-row>
    </v-main>
  </v-app>
</template>

<script>
import ProfileComponent from '../components/ProfileComponent'
import AboutMeComponent from '../components/AboutMeComponent'
import SkillsComponent from '../components/SkillsComponent'
import ProjectsComponent from '../components/ProjectsComponent'

export default {
  components: {
    ProfileComponent,
    AboutMeComponent,
    SkillsComponent,
    ProjectsComponent,
  },
  data() {
    return {
      profileCols: 3, // Initial number of columns for ProfileComponent
      infoCols: 8
    };
  },
  mounted() {
    window.addEventListener('resize', this.handleResize);
    this.handleResize(); // Call handleResize once when component is mounted
  },
  beforeDestroy() {
    window.removeEventListener('resize', this.handleResize);
  },
  methods: {
    handleResize() {
      // Adjust the number of cols for ProfileComponent based on window width
      if (window.innerWidth < 600) {
        this.profileCols = 12; // Set to full screen when window width is less than 600px
        this.infoCols = 12;
      } else {
        this.profileCols = 3; // Set to quarter of the width on full screen
        this.infoCols = 8;
      }
    },
  },
};
</script>

<style scoped>
/* Add any necessary scoped CSS styles */
</style>
