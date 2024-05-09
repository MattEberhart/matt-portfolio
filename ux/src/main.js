import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import vuetify from './plugins/vuetify'
import { loadFonts } from './plugins/webfontloader'
import { createAuth0 } from '@auth0/auth0-vue';

loadFonts()

createApp(App)
  .use(router)
  .use(vuetify)
  .use(
    createAuth0({
      domain: "dev-vwf3wzytscghedef.us.auth0.com",
      clientId: "1B3voL7wA7fXAYd6u6jP1EDLYGRn4kXB",
      authorizationParams: {
        redirect_uri: window.location.origin
      }
    })
  )
  .mount('#app')
