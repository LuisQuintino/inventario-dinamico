<script setup lang="ts">
import { ref, watch } from 'vue'

interface ICategoria {
  codigo: string
  nome: string
  situacao: number
}
type CategoriaForm = Partial<ICategoria> & { nome?: string }

const props = defineProps<{
  modelValue: boolean
  categoria: CategoriaForm
  mode: 'create' | 'edit'
}>()

const emit = defineEmits(['update:modelValue', 'update:categoria', 'save'])

const formData = ref<CategoriaForm>({ ...props.categoria })

watch(() => props.categoria, (newVal) => {
  formData.value = { ...newVal }
})

function close() {
  emit('update:modelValue', false)
}

function handleSubmit() {
  emit('save', formData.value)
}
</script>

<template>
  <div v-if="modelValue" class="fixed inset-0 z-40 flex items-center justify-center bg-black bg-opacity-75">
    
    <div class="relative z-50 w-full max-w-lg rounded-lg bg-gray-800 shadow-lg">
      <form @submit.prevent="handleSubmit">
        
        <header class="flex items-center justify-between border-b border-gray-700 p-6">
          <h2 class="text-2xl font-bold text-white">
            {{ mode === 'create' ? 'Nova Categoria' : 'Editar Categoria' }}
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
          
          <div v-if="mode === 'edit'">
            <label for="situacao" class="block text-sm font-medium text-gray-300">Situação</label>
            <select v-model.number="formData.situacao" id="situacao" required class="mt-1 block w-full rounded-md border-gray-600 bg-gray-700 text-white shadow-sm focus:border-blue-500 focus:ring-blue-500">
              <option :value="1">Ativo</option>
              <option :value="0">Inativo</option>
            </select>
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