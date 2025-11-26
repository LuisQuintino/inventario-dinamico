<template>
  <div class="page">
    <div class="card">
      <button class="back" @click="$router.back()">&#8592;</button>
      <h2>Perfil</h2>

      <form @submit.prevent="salvar">
        <div class="field">
          <label>Nome</label>
          <input v-model="form.nome" />
        </div>

        <div class="field">
          <label>E-mail</label>
          <input v-model="form.email" type="email" />
        </div>

        <div class="field">
          <label>Função</label>
          <input v-model="form.funcao" />
        </div>

        <button type="submit" class="btn-primary">Salvar alterações</button>
      </form>
    </div>
  </div>
</template>

<script setup>
import { reactive, onMounted } from 'vue'

const form = reactive({
  nome: '',
  email: '',
  funcao: '',
})

onMounted(() => {
  // Simulação de carregar dados (depois vem da API)
  form.nome = 'Usuário Inventário'
  form.email = 'usuario@escola.com'
  form.funcao = 'Coordenador'
})

const salvar = () => {
  console.log('Perfil atualizado', form)
  alert('Perfil atualizado (simulação).')
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
  width: 360px;
}

.back {
  background: transparent;
  border: none;
  font-size: 20px;
  cursor: pointer;
}

h2 {
  margin: 8px 0 16px;
}

.field {
  display: flex;
  flex-direction: column;
  margin-bottom: 10px;
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
  background: #e53935;
  color: #fff;
  font-weight: bold;
  cursor: pointer;
}
</style>
