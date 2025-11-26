<template>
  <div class="page">
    <div class="menu-card">
      <h1>MENU</h1>

      <button class="menu-btn" @click="$router.push('/registro')">REGISTRO</button>
      <button class="menu-btn" @click="$router.push('/relatorio')">RELATÓRIO</button>
      <button class="menu-btn" @click="$router.push('/perfil')">PERFIL</button>

      <button class="logout-btn" @click="logout">LOGOUT</button>
    </div>
  </div>
</template>

<script setup>
import { useRouter } from 'vue-router'
const router = useRouter()

const logout = () => {
  // limpar token depois, se tiver
  router.push('/login')
}
</script>

<style scoped>
.page {
  min-height: 100vh;
  background: #1f1f1f;
  display: flex;
  justify-content: center;
  align-items: center;
}

.menu-card {
  background: #111;
  color: #fff;
  padding: 40px 60px;
  border-radius: 8px;
  text-align: center;
}

.menu-btn {
  display: block;
  width: 200px;
  margin: 12px auto;
  padding: 10px;
  border: none;
  background: transparent;
  border-bottom: 1px solid #fff;
  color: #fff;
  cursor: pointer;
}

.logout-btn {
  margin-top: 24px;
  padding: 8px 16px;
  border: none;
  background: #e53935;
  color: #fff;
  cursor: pointer;
}
</style>
