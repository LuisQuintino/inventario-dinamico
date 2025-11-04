<script setup lang="ts">
import { ref, watch } from 'vue'

interface IOperador {
  Codigo: string
  Email: string
  DtSituacao: string
  Situacao: number
  TipoOperador: number
}
type OperadorForm = Partial<IOperador> & { email: string, senha?: string }

const props = defineProps<{
  modelValue: boolean
  operador: OperadorForm
  mode: 'create' | 'edit'
}>()

const emit = defineEmits(['update:modelValue', 'update:operador', 'save'])

const formData = ref<OperadorForm>({ ...props.operador })

watch(() => props.operador, (newVal) => {
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
            {{ mode === 'create' ? 'Novo Operador' : 'Editar Operador' }}
          </h2>
          <button @click="close" type="button" class="text-gray-400 hover:text-white">&times;</button>
        </header>

        <main class="space-y-6 p-6">
          <div>
            <label for="email" class="block text-sm font-medium text-gray-300">Email</label>
            <input 
              v-model="formData.email"
              id="email" 
              required 
              class="mt-1 block w-full rounded-md border-gray-600 bg-gray-700 text-white shadow-sm focus:border-blue-500 focus:ring-blue-500"
            />
          </div>
          
          <div>
            <label for="senha" class="block text-sm font-medium text-gray-300">
              Senha 
              <span v-if="mode === 'edit'" class="text-xs text-gray-400">(Deixe em branco para não alterar)</span>
            </label>
            <input 
              v-model="formData.senha" 
              type="password" 
              id="senha" 
              :required="mode === 'create'" 
              class="mt-1 block w-full rounded-md border-gray-600 bg-gray-700 text-white shadow-sm focus:border-blue-500 focus:ring-blue-500"
            />
          </div>
          
          <div class="grid grid-cols-2 gap-6">
            <div>
              <label for="tipo" class="block text-sm font-medium text-gray-300">Tipo Operador</label>
              <select v-model.number="formData.tipoOperador" id="tipo" required class="mt-1 block w-full rounded-md border-gray-600 bg-gray-700 text-white shadow-sm focus:border-blue-500 focus:ring-blue-500">
                <option :value="1">Admin</option>
                <option :value="2">Operador</option>
              </select>
            </div>
            
            <div>
              <label for="situacao" class="block text-sm font-medium text-gray-300">Situação</label>
              <select v-model.number="formData.situacao" id="situacao" required class="mt-1 block w-full rounded-md border-gray-600 bg-gray-700 text-white shadow-sm focus:border-blue-500 focus:ring-blue-500">
                <option :value="1">Ativo</option>
                <option :value="0">Inativo</option>
                <option :value="2">Bloqueado</option>
              </select>
            </div>
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