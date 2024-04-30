// Import Vuetify styles
import 'vuetify/styles';

// Import Vuetify and theme
import { createVuetify } from 'vuetify';
import spaceTheme from '../themes/spaceTheme'; // Import the space theme schema

export default createVuetify({
  theme: {
    defaultTheme: "spaceTheme",
    themes: {
      spaceTheme
    },
  },
});
