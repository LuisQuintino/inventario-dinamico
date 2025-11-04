import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import { useCookie } from 'nuxt/app'
import { apiFetch } from '~/composables/useApi'

interface User {
  codigo: string
  email: string
  TipoOperador: Int16Array
}

interface LoginResponse {
  bearerToken: string
  operador: User
}

export const useAuthStore = defineStore('auth', () => {

  const token = useCookie<string | null>('auth_token', { 
    maxAge: 60 * 60 * 24 * 7
  }) 
  
  const user = ref<User | null>(null)
  const isLoading = ref(false)

  const isAuthenticated = computed(() => !!token.value)

 async function login(credentials: { email: string, password: string }) {
    isLoading.value = true
    user.value = null

    try {
      const data = await apiFetch<LoginResponse>('/Autenticacao', {
        method: 'POST',
        body: credentials
      })

      console.log(data)
      
      if (data) {
          token.value = data.bearerToken 
          user.value = data.operador
      }
    } catch (error) {
      console.log(error)
      token.value = null
      user.value = null
      throw error
    } finally {
      isLoading.value = false
    }
  }

  function logout() {
    token.value = null
    user.value = null
  }

  return {
    token,
    user,
    isLoading,
    isAuthenticated,
    login,
    logout,
  }
})