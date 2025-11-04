<script setup lang="ts">
import { ref, watch } from 'vue'

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
  dtValidadeMedia: string
}
type EstoqueForm = Partial<IEstoque> & { nome?: string }

const props = defineProps<{
  modelValue: boolean
  estoque: EstoqueForm
  mode: 'create' | 'edit'
  categorias: ICategoria[]
}>()

const emit = defineEmits(['update:modelValue', 'update:estoque', 'save'])

const formData = ref<EstoqueForm>({ ...props.estoque })

watch(() => props.estoque, (newVal) => {
  formData.value = { ...newVal }
})

function close() {
  emit('update:modelValue', false)
}

function handleSubmit() {
  const payload = { ...formData.value }
  
  if (!payload.perecivel) {
    payload.dtValidadeMedia = null
  }
  
  emit('save', payload)
}
</script>

<template>
  <div v-if="modelValue" class="fixed inset-0 z-40 flex items-center justify-center bg-black bg-opacity-75">
    
    <div class="relative z-50 w-full max-w-lg rounded-lg bg-gray-800 shadow-lg">
      <form @submit.prevent="handleSubmit">
        
        <header class="flex items-center justify-between border-b border-gray-700 p-6">
          <h2 class="text-2xl font-bold text-white">
            {{ mode === 'create' ? 'Novo Item de Estoque' : 'Editar Item de Estoque' }}
          </h2>
          <button @click="close" type="button" class="text-gray-400 hover:text-white">&times;</button>
        </header>

        <main class="space-y-6 p-6">
          <div>
            <label for="nome" class="block text-sm font-medium text-gray-300">Nome</label>
            <input 
              v-model="formData.nome" 
              type="text"
              id="nome" 
              required 
              class="mt-1 block w-full rounded-md border-gray-600 bg-gray-700 text-white shadow-sm focus:border-blue-500 focus:ring-blue-500"
            />
          </div>

          <div class="grid grid-cols-2 gap-6">
            <div>
              <label for="categoria" class="block text-sm font-medium text-gray-300">Categoria</label>
              <select v-model="formData.codigoCategoria" id="categoria" required class="mt-1 block w-full rounded-md border-gray-600 bg-gray-700 text-white shadow-sm focus:border-blue-500 focus:ring-blue-500">
                <option v-if="!categorias || categorias.length === 0" disabled value="">
                  Carregando...
                </option>
                <option v-for="cat in categorias" :key="cat.codigo" :value="cat.codigo">
                  {{ cat.nome }}
                </option>
              </select>
            </div>
            
            <div>
              <label for="qtd" class="block text-sm font-medium text-gray-300">Quantidade</label>
              <input 
                v-model.number="formData.qtdEmEstoque" 
                type="number"
                id="qtd" 
                required 
                class="mt-1 block w-full rounded-md border-gray-600 bg-gray-700 text-white shadow-sm focus:border-blue-500 focus:ring-blue-500"
              />
            </div>
          </div>
          
          <div>
            <label for="perecivel" class="flex items-center text-sm font-medium text-gray-300">
              <input 
                v-model="formData.perecivel" 
                type="checkbox"
                id="perecivel" 
                class="h-4 w-4 rounded border-gray-600 bg-gray-700 text-blue-600 focus:ring-blue-500"
              />
              <span class="ml-2">É Perecível?</span>
            </label>
          </div>

          <div v-if="formData.perecivel">
            <label for="dtValidade" class="block text-sm font-medium text-gray-300">Data de Validade Média</label>
            <input 
              v-model="formData.dtValidadeMedia" 
              type="date"
              id="dtValidade" 
              class="mt-1 block w-full rounded-md border-gray-600 bg-gray-700 text-white shadow-sm focus:border-blue-500 focus:ring-blue-500"
            />
          </div>
        </main>
        
        <footer class="flex justify-end space-x-4 rounded-b-lg bg-gray-700 p-6">
          <button @click="close" type="button" class="py-2 px-4 text-sm font-medium text-gray-300 bg-gray-600 hover:bg-gray-500 rounded-md">
            Cancelar
          </button>
          <button type="submit" class="py-2 px-4 text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 rounded-md">
            Salvar
          </button>
        </footer>
        
      </form>
    </div>
  </div>
</template>