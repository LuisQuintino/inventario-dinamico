<script setup lang="ts">
import { navigateTo } from '#app'
import { ref } from 'vue'
import { apiFetch, useApi } from '~/composables/useApi'

interface ICategoria {
  codigo: string
  nome: string
  situacao: number
}
type CategoriaForm = Partial<ICategoria> & { nome?: string }

const authStore = useAuthStore()
if (!authStore.isAuthenticated) {
  navigateTo('/')
}

const { data, pending, error, refresh } = await useApi<ICategoria[]>('/Categoria')

const isModalOpen = ref(false)
const modalMode = ref<'create' | 'edit'>('create')
const currentCategoria = ref<CategoriaForm>({})
const apiError = ref<string | null>(null)
const isLoading = ref(false)

const defaultCategoria: CategoriaForm = {
  nome: '',
  situacao: 1
}

function openCreateModal() {
  currentCategoria.value = { ...defaultCategoria }
  modalMode.value = 'create'
  isModalOpen.value = true
}

function openEditModal(categoria: ICategoria) {
  currentCategoria.value = {
    codigo: categoria.codigo,
    nome: categoria.nome,
    situacao: categoria.situacao
  }
  modalMode.value = 'edit'
  isModalOpen.value = true
}

async function handleSave(formData: CategoriaForm) {
  isLoading.value = true
  apiError.value = null
  
  try {
    if (modalMode.value === 'create') {
      const payload = { nome: formData.nome }
      await apiFetch('/Categoria', {
        method: 'POST',
        body: payload
      })
    } else {
      const payload = { ...formData }
      await apiFetch(`/Categoria`, {
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

function formatSituacao(situacao: number) {
  switch (situacao) {
    case 0: return 'Inativo'
    case 1: return 'Ativo'
    default: return 'Desconhecido'
  }
}
</script>

<template>
  <div>
    <div class="flex justify-between items-center mb-6">
      <h1 class="text-3xl font-bold text-white">Categorias</h1>
      <button @click="openCreateModal" class="py-2 px-4 text-sm font-medium text-gray-900 bg-white hover:bg-gray-200 rounded-md">
        + Nova Categoria
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
                <th scope="col" class="py-3 px-6">Nome</th>
                <th scope="col" class="py-3 px-6">Situação</th>
                <th scope="col" class="py-3 px-6">Ações</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="cat in data" :key="cat.codigo" class="border-b border-gray-700 hover:bg-gray-700">
                <td class="py-4 px-6 font-medium text-white">{{ cat.nome }}</td>
                <td class="py-4 px-6">
                  <span :class="cat.situacao === 1 ? 'text-green-400' : 'text-red-400'" class="font-semibold">
                    {{ formatSituacao(cat.situacao) }}
                  </span>
                </td>
                <td class="py-4 px-6">
                  <button @click="openEditModal(cat)" class="font-medium text-blue-400 hover:underline">
                    Editar
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
      <div v-else class="p-6 text-center text-gray-300">
        <p>Nenhuma categoria encontrada.</p>
      </div>
    </div>
    
    <CategoriaModal 
      v-model="isModalOpen"
      v-model:categoria="currentCategoria"
      :mode="modalMode"
      @save="handleSave"
    />
    
    <div v-if="apiError" class="mt-4 p-3 text-sm text-red-400 bg-red-900 border border-red-700 rounded-md">
      <strong>Erro ao salvar:</strong> {{ apiError }}
    </div>
    
  </div>
</template>