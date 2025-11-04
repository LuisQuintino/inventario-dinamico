<script setup lang="ts">
import { navigateTo } from '#app'
import { ref } from 'vue'
import { apiFetch, useApi } from '~/composables/useApi'

interface IOperador {
  codigo: string
  email: string
  dtInclusao: string
  dtSituacao: string
  situacao: number
  tipoOperador: number
}
type OperadorForm = Partial<IOperador> & { email?: string, senha?: string }

const authStore = useAuthStore()
if (!authStore.isAuthenticated) {
  navigateTo('/')
}

const { data, pending, error, refresh } = await useApi<IOperador[]>('/Operador')

const isModalOpen = ref(false)
const modalMode = ref<'create' | 'edit'>('create')
const currentOperador = ref<OperadorForm>({})
const apiError = ref<string | null>(null)
const isLoading = ref(false)

const defaultOperador: OperadorForm = {
  email: '',
  senha: '',
  situacao: 1,
  tipoOperador: 0
}

function openCreateModal() {
  currentOperador.value = { ...defaultOperador }
  modalMode.value = 'create'
  isModalOpen.value = true
}

function openEditModal(operador: IOperador) {
  currentOperador.value = {
    codigo: operador.codigo,
    email: operador.email,
    situacao: operador.situacao,
    tipoOperador: operador.tipoOperador,
    senha: ''
  }
  modalMode.value = 'edit'
  isModalOpen.value = true
}

async function handleSave(formData: OperadorForm) {
  isLoading.value = true
  apiError.value = null
  
  const payload = { ...formData }
  if (modalMode.value === 'edit' && !payload.senha) {
    delete payload.senha
  }
  
  try {
    if (modalMode.value === 'create') {
      await apiFetch('/Operador', {
        method: 'POST',
        body: payload
      })
    } else {
      console.log("passou aqui")
      
      console.log(payload)
      await apiFetch(`/Operador`, {
        method: 'PUT',
        body: payload
      })
    }

    isModalOpen.value = false
    await refresh()
    
  } catch (err: any) {
    apiError.value = err.data?.message || 'Ocorreu um erro ao salvar.'
  } finally {
    isLoading.value = false
  }
}

function formatDate(dateString: string) {
  if (!dateString) return 'N/A'
  return new Date(dateString).toLocaleDateString('pt-BR')
}
function formatSituacao(situacao: number) {
  switch (situacao) {
    case 0: return 'Inativo'
    case 1: return 'Ativo'
    default: return 'Bloqueado'
  }
}
function formatTipo(tipo: number) {
  switch (tipo) {
    case 1: return 'Admin'
    default: return 'Operador'
  }
}
</script>

<template>
  <div>
    <div class="flex justify-between items-center mb-6">
      <h1 class="text-3xl font-bold text-white">Operadores</h1>
      <button @click="openCreateModal" class="py-2 px-4 text-sm font-medium text-gray-900 bg-white hover:bg-gray-200 rounded-md">
        + Novo Operador
      </button>
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
                <th scope="col" class="py-3 px-6">Email</th>
                <th scope="col" class="py-3 px-6">Tipo</th>
                <th scope="col" class="py-3 px-6">Situação</th>
                <th scope="col" class="py-3 px-6">Data Inclusão</th>
                <th scope="col" class="py-3 px-6">Ações</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="op in data" :key="op.codigo" class="border-b border-gray-700 hover:bg-gray-700">
                <td class="py-4 px-6 font-medium text-white">{{ op.email }}</td>
                <td class="py-4 px-6">{{ formatTipo(op.tipoOperador) }}</td>
                <td class="py-4 px-6">
                  <span :class="op.situacao === 1 ? 'text-green-400' : 'text-red-400'" class="font-semibold">
                    {{ formatSituacao(op.situacao) }}
                  </span>
                </td>
                <td class="py-4 px-6">{{ formatDate(op.dtInclusao) }}</td>
                <td class="py-4 px-6">
                  <button @click="openEditModal(op)" class="font-medium text-blue-400 hover:underline">
                    Editar
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
      <div v-else class="p-6 text-center text-gray-300">
        <p>Nenhum operador encontrado.</p>
      </div>
    </div>
    
    <OperadorModal 
      v-model="isModalOpen"
      v-model:operador="currentOperador"
      :mode="modalMode"
      @save="handleSave"
    />
    
    <div v-if="apiError" class="mt-4 p-3 text-sm text-red-400 bg-red-900 border border-red-700 rounded-md">
      <strong>Erro ao salvar:</strong> {{ apiError }}
    </div>
    
  </div>
</template>