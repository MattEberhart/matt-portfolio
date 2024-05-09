<template>
<v-col>
    <v-progress-linear v-if="isLoading" indeterminate color="primary"></v-progress-linear>

    <v-row v-else>
        <v-col>
            <v-row>
                <v-col>
                        <v-btn v-if="!isAuthenticated" @click="login" color="primary">Log in</v-btn>
                        <v-btn v-else @click="logout" color="primary">Log out</v-btn>
                </v-col>
            </v-row>

            <v-row>
                <v-col>
                    <v-card>
                        <v-pre v-if="isAuthenticated">
                            <code>{{ user }}</code>
                        </v-pre>
                    </v-card>
                </v-col>
            </v-row>
        </v-col>
    </v-row>
</v-col>
</template>

<script>
import {
    useAuth0
} from '@auth0/auth0-vue';

export default {
    setup() {
        const auth0 = useAuth0();

        const login = () => auth0.loginWithRedirect();
        const logout = () => {
            auth0.logout({
                logoutParams: {
                    returnTo: window.location.origin
                }
            });
        };

        return {
            login,
            logout,
            user: auth0.user,
            isAuthenticated: auth0.isAuthenticated,
            isLoading: auth0.isLoading,
        };
    }
};
</script>
