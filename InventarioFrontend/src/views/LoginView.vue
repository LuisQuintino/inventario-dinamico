<template>
  <div class="page">
    <div class="card">
      <h1 class="title">Inventário Dinâmico</h1>

      <form @submit.prevent="login">
        <div class="field">
          <label>E-mail</label>
          <input v-model="email" type="email" required />
        </div>

        <div class="field">
          <label>Senha</label>
          <input v-model="senha" type="password" required />
        </div>

        <button type="submit" class="btn-primary">Entrar</button>
      </form>

      <div class="links">
        <router-link to="/recuperar-senha">Esqueceu a senha?</router-link>
        <router-link to="/perfil/criar">Criar perfil</router-link>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const email = ref('')
const senha = ref('')
const router = useRouter()

const login = () => {
  // aqui você vai chamar o backend depois
  // por enquanto só faz o redirect:
  router.push('/menu')
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

.card {
  background: #f5f5f5;
  padding: 32px;
  border-radius: 8px;
  width: 320px;
}

.title {
  text-align: center;
  margin-bottom: 24px;
}

.field {
  display: flex;
  flex-direction: column;
  margin-bottom: 12px;
}

input {
  padding: 8px;
  border-radius: 4px;
  border: 1px solid #ccc;
}

.btn-primary {
  width: 100%;
  margin-top: 8px;
  padding: 10px;
  border: none;
  background: #e53935; /* vermelho */
  color: white;
  font-weight: bold;
  cursor: pointer;
}

.links {
  margin-top: 16px;
  display: flex;
  justify-content: space-between;
  font-size: 12px;
}
</style>
