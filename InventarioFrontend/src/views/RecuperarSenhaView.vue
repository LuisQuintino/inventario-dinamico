<template>
  <div class="page">
    <div class="card">
      <button class="back" @click="$router.back()">&#8592;</button>
      <h2>Recuperação de conta</h2>

      <p class="texto">Informe o seu e-mail cadastrado para recuperar o acesso à conta.</p>

      <form @submit.prevent="recuperar">
        <div class="field">
          <label>E-mail</label>
          <input v-model="email" type="email" required />
        </div>

        <button type="submit" class="btn-primary">Enviar link de recuperação</button>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'

const email = ref('')

const recuperar = () => {
  // depois você chama o backend aqui
  alert(`Se este e-mail estiver cadastrado, enviaremos instruções para: ${email.value}`)
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

.texto {
  font-size: 13px;
  margin-bottom: 16px;
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
  padding: 10px;
  border: none;
  background: #e53935;
  color: #fff;
  font-weight: bold;
  cursor: pointer;
}
</style>
