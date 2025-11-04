<script setup lang="ts">
import { navigateTo } from '#app'

const authStore = useAuthStore()

if (!authStore.isAuthenticated) {
  navigateTo('/')
}
</script>

<template>
  <div>
    <h1 class="text-3xl font-bold text-white mb-6">
      Dashboard
    </h1>

    <div class="bg-gray-800 p-6 rounded-lg shadow-lg">
      <p>This is a protected area. You can only see this if you are logged in.</p>
      <p class="mt-4" v-if="authStore.user">
        Welcome, {{ authStore.user.name || authStore.user.email }}
      </p>
    </div>
  </div>
</template>