<script setup lang="ts">
import { navigateTo } from '#app'

const authStore = useAuthStore()

function handleLogout() {
  authStore.logout()
  navigateTo('/')
}
</script>

<template>
  <div class="flex h-screen bg-gray-900 text-gray-100">

    <aside class="w-64 flex-shrink-0 bg-gray-800 p-4">
      <h1 class="text-2xl font-bold text-white mb-6 text-center">
        Inventario
      </h1>
      
      <nav>
        <ul>
          <li>
            <NuxtLink 
              to="/dashboard" 
              class="flex items-center py-2 px-3 rounded text-gray-300 hover:bg-gray-700 hover:text-white"
              active-class="bg-gray-700 text-white"
            >
              <span class="ml-2">Dashboard</span>
            </NuxtLink>
          </li>
          <li class="mt-2" v-if="authStore.isAdmin" >
            <NuxtLink 
              to="/operadores" 
              class="flex items-center py-2 px-3 rounded text-gray-300 hover:bg-gray-700 hover:text-white"
              active-class="bg-gray-700 text-white"
            >
              <span class="ml-2">Operadores</span>
            </NuxtLink>
          </li>
          <li class="mt-2">
            <NuxtLink 
              to="/categorias" 
              class="flex items-center py-2 px-3 rounded text-gray-300 hover:bg-gray-700 hover:text-white"
              active-class="bg-gray-700 text-white"
            >
              <span class="ml-2">Categorias</span>
            </NuxtLink>
          </li>
          <li class="mt-2">
            <NuxtLink 
              to="/audittrail" 
              class="flex items-center py-2 px-3 rounded text-gray-300 hover:bg-gray-700 hover:text-white"
              active-class="bg-gray-700 text-white"
            >
              <span class="ml-2">Audit Trail</span>
            </NuxtLink>
          </li>
        </ul>
      </nav>
    </aside>

    <div class="flex-1 flex flex-col overflow-hidden">

      <header class="flex justify-between items-center p-6 bg-gray-800 shadow-md">
        <div></div> 
        
        <button 
          @click="handleLogout"
          class="py-2 px-4 text-sm font-medium text-gray-900 bg-white hover:bg-gray-200 rounded-md"
        >
          Log Out
        </button>
      </header>

      <main class="flex-1 p-8 overflow-y-auto">
        <slot />
      </main>

    </div>
  </div>
</template>