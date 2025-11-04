// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2025-07-15',
  devtools: { enabled: true },

  runtimeConfig: {
    public: {
      apiBaseUrl: process.env.NUXT_PUBLIC_API_BASE_URL || 'https://localhost:44332/',
    }
  },

  modules: ['@pinia/nuxt', '@nuxtjs/tailwindcss'],
  css: [
    '../assets/css/tailwind.css', 
  ]
})