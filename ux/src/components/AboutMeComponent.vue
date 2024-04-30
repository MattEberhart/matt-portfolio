<template>
<v-col>
    <v-card class="container">
        <v-row>
            <v-card-title>
                <h1>About Me</h1>
            </v-card-title>
        </v-row>
            <v-row>
                <v-card-text class="text" color="">
                    <p>Hey, I'm Matt. Originally from Loudoun County, Virginia, I pursued my passion for languages and technology at Virginia Tech, where I studied Spanish and Computer Science. After college, I made the move to Seattle to kickstart my career as a software engineer.</p>
                    <p>Professionally, I thrive on tackling complex challenges and finding innovative solutions in the tech world. I'm fluent in both English and Spanish, which has proven invaluable in my work and personal life.</p>
                    <p>Growing up, I was deeply involved in sports like baseball and basketball, as well as music, where I played the viola from childhood through high school. I still love to play basketball and I pick up the viola from time to time.</p>
                    <p>Outside the office, you'll find me hitting the slopes for skiing or snowboarding adventures, staying active with running and weight training, and exploring new places with friends. Oh, and fun fact—I'm also a dual citizen of Peru and the USA.</p>
                </v-card-text>
            </v-row>
    </v-card>
</v-col>
</template>

<script>
export default {

}
</script>

<style scoped>
.container {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.text p {
    margin-bottom: 1em;
}

</style>
