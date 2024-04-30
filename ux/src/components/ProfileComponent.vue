<template>
<!-- Profile Card -->
<v-card class="profile">
    <v-img :src="profilePicture" alt="Profile Picture" class="profile-pic"></v-img>
    <v-card-title>
        <h1 class="name">Matt Eberhart</h1>
        <p class="title">Software Engineer</p>
    </v-card-title>
    <!-- Social Links -->
    <v-list dense>
        <v-list-item-group>
            <v-list-item v-for="link in socialLinks" :key="link.name" :href="link.url" v-external-blank>
                <v-list-item-icon>
                    <v-img :src="link.icon" alt="Social Icon" class="social-pic"></v-img>
                </v-list-item-icon>
                <v-list-item-content>
                    <v-list-item-title>{{ link.name }}</v-list-item-title>
                </v-list-item-content>
            </v-list-item>
        </v-list-item-group>
    </v-list>
</v-card>
</template>

  
  
<script>
export default {
    data() {
        return {
            socialLinks: [{
                    name: 'Github',
                    url: 'https://github.com/MattEberhart',
                    icon: require('@/assets/github-icon.svg')
                },
                {
                    name: 'LinkedIn',
                    url: 'https://www.linkedin.com/in/carleberhart/',
                    icon: require('@/assets/linkedin-icon-3.svg')
                },
                {
                    name: 'Instagram',
                    url: 'https://www.instagram.com/matteberhart10/',
                    icon: require('@/assets/instagram-2016-5.svg')
                },
                {
                    name: 'Twitter',
                    url: 'https://twitter.com/MattEberhart10',
                    icon: require('@/assets/twitter-logo-2.svg')
                }
            ],
            profilePicture: require('@/assets/profile-pic.jpeg')
        };
    }
};
</script>
  
  
<style scoped>
.profile {
    display: flex;
    flex-direction: column;
    align-items: center;
    text-align: center;
    /* Center text */
}

.profile-pic {
    border-radius: 50%;
    width: 300px;
    /* Adjust width as needed */
    height: auto;
    object-fit: cover;
    /* Maintain aspect ratio */
}
</style>
