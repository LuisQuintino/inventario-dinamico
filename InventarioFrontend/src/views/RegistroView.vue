<template>
  <div class="page">
    <div class="card">
      <button class="back" @click="$router.back()">&#8592; Voltar</button>
      <h2>REGISTRO</h2>

      <button class="menu-btn" @click="$router.push('/registro/adicionar')">ADICIONAR</button>
      <button class="menu-btn" @click="$router.push('/registro/retirar')">RETIRAR</button>
      <button class="menu-btn" @click="$router.push('/registro/atualizar')">ATUALIZAR</button>
    </div>
  </div>
</template>

<script setup></script>

<style scoped>
.page {
  min-height: 100vh;
  background: #1f1f1f;
  display: flex;
  justify-content: center;
  align-items: center;
}

.card {
  background: #111;
  color: #fff;
  padding: 32px 48px;
  border-radius: 8px;
  text-align: center;
}

.back {
  background: transparent;
  border: none;
  color: #fff;
  margin-bottom: 16px;
  cursor: pointer;
}

.menu-btn {
  display: block;
  width: 220px;
  margin: 10px auto;
  padding: 10px;
  border: none;
  background: #222;
  color: #fff;
  cursor: pointer;
}
</style>
