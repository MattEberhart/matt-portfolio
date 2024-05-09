<template>
<v-col>
    <v-row>
        <v-card>
            <v-card-title>
                Auth0 Integration
            </v-card-title>
            <v-card-text>
                <p>
                    Here you are able to authenticate with your Google or Apple account. Once authenticated you will see your user profile on this page. You will also see a 'Create Project' form in the 'Projects' page - though the submit project calls should fail unless you are me.
                </p>
            </v-card-text>
        </v-card>
    </v-row>
    <v-row>
        <UserProfileComponent />
    </v-row>
</v-col>
</template>

<script>
import UserProfileComponent from '../components/UserProfileComponent.vue';

export default {
    components: {
        UserProfileComponent
    }
}
</script>

<style scoped>
/* Add any necessary scoped CSS styles */
</style>
