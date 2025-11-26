<template>
  <div class="page">
    <div class="card">
      <button class="back" @click="$router.back()">&#8592;</button>
      <h2>Retirar produto</h2>

      <form @submit.prevent="retirar">
        <div class="field">
          <label>Nome do produto</label>
          <input v-model="form.nome" required />
        </div>

        <div class="field">
          <label>Quantidade a retirar</label>
          <input v-model.number="form.quantidade" type="number" min="1" required />
        </div>

        <div class="field">
          <label>Justificativa / Observação</label>
          <textarea v-model="form.justificativa" rows="3"></textarea>
        </div>

        <button type="submit" class="btn-primary">Confirmar retirada</button>
      </form>
    </div>
  </div>
</template>

<script setup>
import { reactive } from 'vue'

const form = reactive({
  nome: '',
  quantidade: 1,
  justificativa: '',
})

const retirar = () => {
  console.log('Retirada registrada', form)
  alert('Retirada registrada (simulação).')
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
  width: 380px;
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

input,
textarea {
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
