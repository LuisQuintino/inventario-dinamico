<template>
  <div class="page">
    <div class="card">
      <button class="back" @click="$router.back()">&#8592;</button>
      <h2>Criar perfil</h2>

      <form @submit.prevent="criar">
        <div class="field">
          <label>Nome</label>
          <input v-model="form.nome" required />
        </div>

        <div class="field">
          <label>E-mail</label>
          <input v-model="form.email" type="email" required />
        </div>

        <div class="field">
          <label>Função (ex.: Professor, Coordenador)</label>
          <input v-model="form.funcao" />
        </div>

        <div class="field">
          <label>Senha</label>
          <input v-model="form.senha" type="password" required />
        </div>

        <div class="field">
          <label>Confirmar senha</label>
          <input v-model="form.confirmarSenha" type="password" required />
        </div>

        <button type="submit" class="btn-primary">Registrar</button>
      </form>
    </div>
  </div>
</template>

<script setup>
import { reactive } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()

const form = reactive({
  nome: '',
  email: '',
  funcao: '',
  senha: '',
  confirmarSenha: '',
})

const criar = () => {
  if (form.senha !== form.confirmarSenha) {
    alert('As senhas não conferem.')
    return
  }

  // depois integra com backend
  console.log('Novo usuário', form)
  alert('Perfil criado (simulação).')
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
