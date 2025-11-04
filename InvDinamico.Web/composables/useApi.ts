
import { type UseFetchOptions, useFetch, useRuntimeConfig } from 'nuxt/app'
import { $fetch, type FetchOptions } from 'ofetch'
import { defu } from 'defu'
import { useAuthStore } from '~/stores/auth'

const getApiDefaults = (options: FetchOptions = {}): FetchOptions => {
  const config = useRuntimeConfig()
  
  const defaults: FetchOptions = {
    baseURL: config.public.apiBaseUrl as string,
    headers: {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
    },

    onRequest({ options }) {
      const authStore = useAuthStore()
      if (authStore.token) {
        options.headers = {
          ...options.headers,
          Authorization: `Bearer ${authStore.token}`
        }
      }
    },

    onResponseError({ response }) {
      if (response.status === 401) {
        console.error('Authentication error: Not Authorized')
        navigateTo('/')
      }
    },
  }

  return defu(options, defaults)
}

export type CustomUseFetchOptions<T> = Omit<UseFetchOptions<T>, 'baseURL'>
export function useApi<T>(
  url: string,
  options: CustomUseFetchOptions<T> = {}
) {
  const finalOptions = getApiDefaults(options) as UseFetchOptions<T>
  finalOptions.key = finalOptions.key || url
  return useFetch(url, finalOptions)
}

export const apiFetch = <T>(
  url: string,
  options: FetchOptions = {}
) => {
  const finalOptions = getApiDefaults(options)
  return $fetch<T>(url, finalOptions)
}