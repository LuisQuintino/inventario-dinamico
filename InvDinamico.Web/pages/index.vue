<script setup lang="ts">
import { ref } from 'vue'
import { navigateTo } from '#app'
import { apiFetch } from '~/composables/useApi'

const authStore = useAuthStore()

definePageMeta({
  layout: false
})

if (authStore.isAuthenticated) {
  navigateTo('/dashboard')
}

const email = ref()
const senha = ref()
const error = ref<string | null>(null)

async function handleLogin() {
  error.value = null
  try {
    await authStore.login({
      email: email.value,
      senha: senha.value,
    })
    navigateTo('/dashboard') 
  } catch (e: any) {
    const errorMessage = e.data?.message || 'Login failed.'
    error.value = errorMessage
  }
}
</script>

<template>
  <div class="flex items-center justify-center min-h-screen bg-gray-950 text-gray-100">
    <div class="w-full max-w-sm p-8">
      <h2 class="text-3xl font-light text-center text-gray-50">
        Sign In
      </h2>
      <form @submit.prevent="handleLogin" class="mt-8 space-y-7">
        <div>
          <label for="email" class="sr-only">Email address</label>
          <input 
            id="email" 
            v-model="email"
            required 
            placeholder="Email address"
            class="w-full px-4 py-3 bg-transparent border-b border-gray-700 focus:border-white focus:outline-none placeholder-gray-500"
            :disabled="authStore.isLoading"
          />
        </div>
        <div>
          <label for="password" class="sr-only">Password</label>
          <input 
            id="password" 
            v-model="senha" 
            type="password" 
            required 
            placeholder="Password"
            class="w-full px-4 py-3 bg-transparent border-b border-gray-700 focus:border-white focus:outline-none placeholder-gray-500"
            :disabled="authStore.isLoading"
          />
        </div>
        <div v-if="error" class="text-sm text-center text-red-400">
          {{ error }}
        </div>
        <div>
          <button
            type="submit"
            :disabled="authStore.isLoading"
            class="w-full flex justify-center py-3 px-4 text-sm font-medium text-gray-900 bg-white hover:bg-gray-200 focus:outline-none disabled:opacity-50"
          >
            <span v-if="authStore.isLoading">...</span>
            <span v-else>Sign In</span>
          </button>
        </div>
      </form>
    </div>
  </div>
</template>