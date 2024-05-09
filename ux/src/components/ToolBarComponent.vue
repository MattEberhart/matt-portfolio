<template>
<v-app-bar>
    <v-row justify="center">
        <c-col cols="12">
            <v-tabs v-model="tab" align-tabs="center" color="deep-purple-accent-4">
                <v-tab to="/">Home</v-tab>
                <v-tab to="/projects">Projects</v-tab>
                <v-tab to="/resume">Resume</v-tab>
                <v-tab to="/user">Auth0</v-tab>
            </v-tabs>
        </c-col>
    </v-row>

</v-app-bar>
</template>

<script>

export default {
    data: () => ({
        tab: null,
    })
}
</script>

<style>
/* Define a transition for the tab content */
.tab-slide-enter-active, .tab-slide-leave-active {
  transition: transform 0.5s;
}

.tab-slide-enter, .tab-slide-leave-to {
  transform: translateX(100%);
}
</style>
