<script setup lang="ts">
import { navigateTo } from '#app'
import { ref, computed } from 'vue'
import { useApi } from '~/composables/useApi'

interface IAuditTrail {
  codigo: string
  emailOperador: string
  nomeEntidade: string
  acao: string
  jsonAntigo: string
  jsonNovo: string
  dtAlteracao: string
}

const authStore = useAuthStore()
if (!authStore.isAuthenticated) {
  navigateTo('/')
}

const searchInput = ref('')
const activeFiltro = ref('')

const queryParams = computed(() => {
  if (activeFiltro.value) {
    return { filtro: activeFiltro.value }
  }
  return {}
})

const { data, pending, error } = await useApi<IAuditTrail[]>(
  '/AuditTrail',
  { 
    query: queryParams,
    watch: [queryParams],
    lazy: true
  }
)

const isModalOpen = ref(false)
const selectedAudit = ref<IAuditTrail | null>(null)

function openJsonModal(item: IAuditTrail) {
  selectedAudit.value = item
  isModalOpen.value = true
}

function formatDate(dateString: string) {
  if (!dateString) return 'N/A'
  try {
    return new Date(dateString).toLocaleString('pt-BR', {
      day: '2-digit',
      month: '2-digit',
      year: 'numeric',
      hour: '2-digit',
      minute: '2-digit'
    })
  } catch (e) {
    return dateString
  }
}
</script>

<template>
  <div>
    <div class="flex justify-between items-center mb-6">
      <h1 class="text-3xl font-bold text-white">
        Audit Trail
      </h1>
      
      <form @submit.prevent="performSearch" class="flex items-center space-x-2">
        <input 
          v-model="searchInput"
          type="text" 
          placeholder="Buscar por Entidade"
          class="w-80 px-3 py-2 rounded-md border-gray-600 bg-gray-700 text-white shadow-sm focus:border-blue-500 focus:ring-blue-500"
        />
        <button type="submit" class="py-2 px-4 text-sm font-medium text-gray-900 bg-white hover:bg-gray-200 rounded-md">
          Buscar
        </button>
      </form>
    </div>

    <div class="bg-gray-800 rounded-lg shadow-lg overflow-hidden">
      
      <div v-if="pending" class="p-6 text-center text-gray-300">
        <p>Carregando...</p>
      </div>
      
      <div v-else-if="error" class="p-6 text-center text-red-400">
        <p>Falha ao carregar dados: {{ error.message }}</p>
      </div>

      <div v-else-if="data && data.length > 0">
        <div class="overflow-x-auto">
          <table class="w-full min-w-full text-left text-gray-300">
            <thead class="bg-gray-700 uppercase text-xs text-gray-400">
              <tr>
                <th scope="col" class="py-3 px-6">Data/Hora</th>
                <th scope="col" class="py-3 px-6">Usuário</th>
                <th scope="col" class="py-3 px-6">nome Entidade</th>
                <th scope="col" class="py-3 px-6">Ação</th>
                <th scope="col" class="py-3 px-6">Alterações</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in data" :key="item.codigo" class="border-b border-gray-700 hover:bg-gray-700">
                <td class="py-4 px-6">{{ formatDate(item.dtAlteracao) }}</td>
                <td class="py-4 px-6 font-medium text-white">{{ item.emailOperador }}</td>
                <td class="py-4 px-6">{{ item.nomeEntidade }}</td>
                <td class="py-4 px-6">
                  <span 
                    :class="{
                      'text-green-400': item.acao === 'INSERT', 
                      'text-yellow-400': item.acao === 'UPDATE', 
                      'text-red-400': item.acao === 'DELETE'
                    }" 
                    class="font-semibold"
                  >
                    {{ item.acao }}
                  </span>
                </td>
                <td class="py-4 px-6">
                  <button @click="openJsonModal(item)" class="font-medium text-blue-400 hover:underline">
                    Visualizar
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
      
      <div v-else class="p-6 text-center text-gray-300">
        <p>Nenhum registro encontrado.</p>
      </div>

    </div>

    <AuditTrailModal
      v-model="isModalOpen"
      :oldJson="selectedAudit?.jsonAntigo"
      :newJson="selectedAudit?.jsonNovo"
    />

  </div>
</template>