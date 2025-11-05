<script setup lang="ts">
import { computed } from 'vue'

const props = defineProps<{
  modelValue: boolean
  oldJson: string | null | undefined
  newJson: string | null | undefined
}>()

const emit = defineEmits(['update:modelValue'])

const formatJson = (jsonString: string | null | undefined) => {
  if (!jsonString || jsonString.trim() === '') {
    return 'Nenhum dado'
  }
  try {
    const obj = JSON.parse(jsonString)
    return JSON.stringify(obj, null, 2)
  } catch (e) {
    return jsonString
  }
}

const formattedOldJson = computed(() => formatJson(props.oldJson))
const formattedNewJson = computed(() => formatJson(props.newJson))

function close() {
  emit('update:modelValue', false)
}
</script>

<template>
  <div v-if="modelValue" class="fixed inset-0 z-40 flex items-center justify-center bg-black bg-opacity-75">
    
    <div class="relative z-50 w-full max-w-4xl rounded-lg bg-gray-800 shadow-lg">
      
      <header class="flex items-center justify-between border-b border-gray-700 p-6">
        <h2 class="text-2xl font-bold text-white">Visualizador de Alterações</h2>
        <button @click="close" type="button" class="text-gray-400 hover:text-white">&times;</button>
      </header>
      
      <main class="max-h-[70vh] overflow-y-auto p-6">
        <div class="grid grid-cols-1 gap-6 md:grid-cols-2">
          
          <div>
            <h3 class="mb-2 text-lg font-semibold text-white">Valores Antigos</h3>
            <pre class="w-full rounded-md bg-gray-950 p-4 text-sm text-red-300">{{ formattedOldJson }}</pre>
          </div>
          
          <div>
            <h3 class="mb-2 text-lg font-semibold text-white">Valores Novos</h3>
            <pre class="w-full rounded-md bg-gray-950 p-4 text-sm text-green-300">{{ formattedNewJson }}</pre>
          </div>
          
        </div>
      </main>
      
      <footer class="flex justify-end space-x-4 rounded-b-lg bg-gray-700 p-6">
        <button @click="close" type="button" class="py-2 px-4 text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 rounded-md">
          Fechar
        </button>
      </footer>
      
    </div>
  </div>
</template>