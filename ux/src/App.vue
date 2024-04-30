To set a margin for components rendered by router-view, you can apply styling directly to the router-view element or use a wrapper element around it. Here's how you can do it:

vue
Copy code
<template>
<v-app theme="spaceTheme">
    <v-main>
        <ToolBarComponent />
        <div class="router-view-wrapper">
            <router-view />
        </div>
    </v-main>
</v-app>
</template>

<script>
// Components
import ToolBarComponent from './components/ToolBarComponent'

export default {
    name: 'App',
    components: {
        ToolBarComponent
    },
    data: () => ({
        //
    }),
    directives: {
        externalBlank: {
            bind(el) {
                el.addEventListener('click', (event) => {
                    const href = el.getAttribute('href');
                    const isExternal = href.startsWith('http') && !href.includes(window.location.origin);

                    if (isExternal) {
                        event.preventDefault();
                        const newTab = document.createElement('a');
                        newTab.href = href;
                        newTab.target = '_blank';
                        newTab.click();
                    }
                });
            }
        }
    }
}
</script>

<style>
.router-view-wrapper {
    margin: 20px;
    /* Adjust the margin as needed */
}

</style>
