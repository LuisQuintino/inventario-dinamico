<script setup lang="ts">
import { navigateTo } from '#app'
import { ref, computed } from 'vue'
import { apiFetch, useApi } from '~/composables/useApi'

interface ICategoria {
  codigo: string
  nome: string
  situacao: number
}

interface IEstoque {
  codigo: string
  codigoCategoria: string
  qtdEmEstoque: number
  nome: string
  perecivel: boolean
  dtValidadeMedia: string | null
}
type EstoqueForm = Partial<IEstoque> & { nome?: string }

const authStore = useAuthStore()
if (!authStore.isAuthenticated) {
  navigateTo('/')
}

const { data: estoqueData, pending: estoquePending, error: estoqueError, refresh: refreshEstoque } = await useApi<IEstoque[]>('/Estoque')
const { data: categoriasData, error: categoriasError } = await useApi<ICategoria[]>('/Categoria')

const isModalOpen = ref(false)
const modalMode = ref<'create' | 'edit'>('create')
const currentEstoque = ref<EstoqueForm>({})
const apiError = ref<string | null>(null)
const isLoading = ref(false)

const defaultEstoque: EstoqueForm = {
  nome: '',
  codigoCategoria: '',
  qtdEmEstoque: 0,
  perecivel: false,
  dtValidadeMedia: null
}

const categoriasAtivas = computed(() => {
  if (!categoriasData.value) return []
  return categoriasData.value.filter(cat => cat.situacao === 1)
})

const getCategoriaNome = (codigo: string) => {
  if (!categoriasData.value) return '...';
  const cat = categoriasData.value.find(c => c.codigo === codigo);
  return cat ? cat.nome : 'Desconhecido';
}

function openCreateModal() {
  currentEstoque.value = { ...defaultEstoque }
  modalMode.value = 'create'
  isModalOpen.value = true
}

function openEditModal(estoque: IEstoque) {
  currentEstoque.value = {
    ...estoque,
    dtValidadeMedia: estoque.dtValidadeMedia ? estoque.dtValidadeMedia.split('T')[0] : null
  }
  modalMode.value = 'edit'
  isModalOpen.value = true
}

async function handleSave(formData: EstoqueForm) {
  isLoading.value = true
  apiError.value = null
  
  const payload = { ...formData }
  
  try {
    if (modalMode.value === 'create') {
      await apiFetch('/Estoque', {
        method: 'POST',
        body: payload
      })
    } else {
      await apiFetch(`/Estoque`, {
        method: 'PUT',
        body: payload
      })
    }

    isModalOpen.value = false
    await refreshEstoque()
    
  } catch (err: any) {
    apiError.value = err.data?.message || 'Ocorreu um erro ao salvar.'
  } finally {
    isLoading.value = false
  }
}

function formatDate(dateString: string | null) {
  if (!dateString) return 'N/A'
  try {
    return new Date(dateString).toLocaleDateString('pt-BR')
  } catch (e) {
    return dateString
  }
}

function formatPerecivel(isPerecivel: boolean) {
  return isPerecivel ? 'Sim' : 'Não'
}
</script>

<template>
  <div>
    <div class="flex justify-between items-center mb-6">
      <h1 class="text-3xl font-bold text-white">Estoque</h1>
      <button @click="openCreateModal" class="py-2 px-4 text-sm font-medium text-gray-900 bg-white hover:bg-gray-200 rounded-md">
        + Novo Item
      </button>
    </div>

    <div class="bg-gray-800 rounded-lg shadow-lg overflow-hidden">
      
      <div v-if="estoquePending" class="p-6 text-center text-gray-300">
        <p>Carregando...</p>
      </div>
      <div v-else-if="estoqueError" class="p-6 text-center text-red-400">
        <p>Falha ao carregar dados do estoque: {{ estoqueError.message }}</p>
      </div>
      <div v-else-if="categoriasError" class="p-6 text-center text-red-400">
        <p>Falha ao carregar dados de categorias: {{ categoriasError.message }}</p>
      </div>
      <div v-else-if="estoqueData && estoqueData.length > 0">
        <div class="overflow-x-auto">
          <table class="w-full min-w-full text-left text-gray-300">
            <thead class="bg-gray-700 uppercase text-xs text-gray-400">
              <tr>
                <th scope="col" class="py-3 px-6">Nome</th>
                <th scope="col" class="py-3 px-6">Categoria</th>
                <th scope="col" class="py-3 px-6">Quantidade</th>
                <th scope="col" class="py-3 px-6">Perecível</th>
                <th scope="col" class="py-3 px-6">Validade Média</th>
                <th scope="col" class="py-3 px-6">Ações</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in estoqueData" :key="item.codigo" class="border-b border-gray-700 hover:bg-gray-700">
                <td class="py-4 px-6 font-medium text-white">{{ item.nome }}</td>
                <td class="py-4 px-6">{{ getCategoriaNome(item.codigoCategoria) }}</td>
                <td class="py-4 px-6">{{ item.qtdEmEstoque }}</td>
                <td class="py-4 px-6">
                  <span :class="item.perecivel ? 'text-yellow-400' : 'text-gray-400'">
                    {{ formatPerecivel(item.perecivel) }}
                  </span>
                </td>
                <td class="py-4 px-6">{{ formatDate(item.dtValidadeMedia) }}</td>
                <td class="py-4 px-6">
                  <button @click="openEditModal(item)" class="font-medium text-blue-400 hover:underline">
                    Editar
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
      <div v-else class="p-6 text-center text-gray-300">
        <p>Nenhum item em estoque encontrado.</p>
      </div>
    </div>
    
    <EstoqueModal 
      v-model="isModalOpen"
      v-model:estoque="currentEstoque"
      :mode="modalMode"
      :categorias="categoriasAtivas"
      @save="handleSave"
    />
    
    <div v-if="apiError" class="mt-4 p-3 text-sm text-red-400 bg-red-900 border border-red-700 rounded-md">
      <strong>Erro ao salvar:</strong> {{ apiError }}
    </div>
    
  </div>
</template>