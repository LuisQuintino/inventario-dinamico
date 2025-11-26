<template>
  <div class="splash">
    <img :src="logo" alt="Inventário Dinâmico" class="logo" />
  </div>
</template>

<script setup>
import { onMounted } from 'vue'
import { useRouter } from 'vue-router'
import logo from '../assets/inventario-dinamico.png' // usa caminho relativo

const router = useRouter()

onMounted(() => {
  // espera 2 segundos e vai para o login
  setTimeout(() => {
    router.push('/login')
  }, 2000)
})
</script>

<style scoped>
.splash {
  min-height: 100vh;
  background: #1f1f1f;
  display: flex;
  justify-content: center;
  align-items: center;
}

.logo {
  max-width: 90%;
  max-height: 80vh;
  border-radius: 8px;
}
</style>
