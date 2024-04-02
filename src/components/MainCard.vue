<template>
    <div class="wrapper">
        <div class="main-container">
            <div class="container-one">
                <div class="profile">
                    <img src="../assets/profile-pic.jpeg" alt="">
                    <h1>Matt Eberhart</h1>
                    <p>Software Engineer</p>
                </div>
                <div class="social-links">
                    <div class="link">
                        <a href="https://github.com/MattEberhart">
                            <img src="../assets/github-icon.svg" alt="">
                            <h2>Github</h2>
                        </a>
                    </div>
                    <div class="link">
                        <a href="https://www.linkedin.com/in/carleberhart/">
                            <img src="../assets/linkedin-icon-3.svg" alt="">
                            <h2>LinkedIn</h2>
                        </a>
                    </div>
                    <div class="link">
                        <a href="https://www.instagram.com/matteberhart10/">
                            <img src="../assets/instagram-2016-5.svg" alt="">
                            <h2>Instagram</h2>
                        </a>
                    </div>
                    <div class="link">
                        <a href="https://twitter.com/MattEberhart10">
                            <img src="../assets/twitter-logo-2.svg" alt="">
                            <h2>Twitter</h2>
                        </a>
                    </div>
                </div>
            </div>
            <div class="container-two">
                <div class="about-me">
                    <h1>
                        About Me
                    </h1>
                    <p>Hey, I'm Matt. Originally from Loudoun County, Virginia, I pursued my passion for languages and technology at Virginia Tech, where I studied Spanish and Computer Science. After college, I made the move to Seattle to kickstart my career as a software engineer.</p>
                    <p>Professionally, I thrive on tackling complex challenges and finding innovative solutions in the tech world. I'm fluent in both English and Spanish, which has proven invaluable in my work and personal life.</p>
                    <p>Growing up, I was deeply involved in sports like baseball and basketball, as well as music, where I played the viola from childhood through high school. I still love to play basketball and I pickup the viola from time to time.</p>
                    <p>Outside the office, you'll find me hitting the slopes for skiing or snowboarding adventures, staying active with running and weight training, and exploring new places with friends. Oh, and fun fact—I'm also a dual citizen of Peru and the USA.</p>
                </div>
                <div class="technology">
                    <h1>Skills and Technologies</h1>
                    <div class="logos">
                        <img src="../assets/azure-2.svg" alt="">
                        <img src="../assets/c--4.svg" alt="">
                        <img src="../assets/git-bash.svg" alt="">                    
                    </div>
                    <div class="button-container">
                        <div class="projects-button">
                            <a href="">My Projects</a>
                        </div>
                        <div class="projects-button">
                            <a href="">My Resume</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</template>

<script>
    export default {
        
    }
</script>

<style scoped>

    .wrapper{
        display: flex;
        justify-content: center;

    }

    img{
        height: 40px
    }

    .main-container{
        display: flex;
        flex-direction: row;
        background-color: #A0D4FF;
        border-radius: 25px;
        width: 80%;
        box-shadow: rgba(0, 0, 0, .24) 0px 3px 8px
    }

    .container-one{
        background-color: #1292EE;
        padding: 2.5%;
        width: 30%;
        border-radius: 25px;
        box-shadow: rgba(0, 0, 0, .24) 0px 3px 8px
    }

    .container-two{
        width: 70%;
        margin: 2.5%;
    }

    .link a{
        text-decoration: none;
        font-size: 10px
    }

    .link img{
        height: 2rem;
    }

    .logos {
        
    }

    .profile img{
        height: 20rem;
        border-radius: 50%;
    }

    .about-me{
        text-align: left;
    }

    .logos img{
        height: 2.5rem;
        margin: 1rem;
    }

    .button-container{
        margin-top: 5%;
        display: flex;
        flex-direction: row;
        justify-content: center;
        align-items: center;
    }

    .projects-button{
        background-color: #005CA4;
        margin: 5px;
        padding: 5px;
        border-radius: 15px;
    }

    .projects-button a{
        text-decoration: none;
        color: #fff
    }


    
</style>