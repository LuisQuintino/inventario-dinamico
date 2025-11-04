import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import { useCookie } from 'nuxt/app'
import { apiFetch } from '~/composables/useApi'

interface User {
  codigo: string
  email: string
  tipoOperador: number
}

interface LoginResponse {
  bearerToken: string
  operador: User
}

export const useAuthStore = defineStore('auth', () => {

  const token = useCookie<string | null>('auth_token', { 
    maxAge: 60 * 5
  }) 
  const administrator = useCookie<boolean | null>('isAdmin', { 
    maxAge: 60 * 5
  }) 
  
  const user = ref<User | null>(null)
  const isLoading = ref(false)

  const isAuthenticated = computed(() => !!token.value)
  const isAdmin = computed(() => !!administrator.value)

 async function login(credentials: { email: string, password: string }) {
    isLoading.value = true
    user.value = null

    try {
      const data = await apiFetch<LoginResponse>('/Autenticacao', {
        method: 'POST',
        body: credentials
      })

      console.log(data)
      console.log(data.operador.tipoOperador)
      
      if (data) {
          token.value = data.bearerToken 
          user.value = data.operador
          administrator.value = data.operador.tipoOperador == 1
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
    administrator.value = null
  }

  return {
    token,
    user,
    isLoading,
    isAuthenticated,
    isAdmin,
    login,
    logout,
  }
})