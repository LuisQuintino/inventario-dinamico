<template>
  <div class="page">
    <div class="card">
      <button class="back" @click="$router.back()">&#8592;</button>
      <h2>Adicionar Produto</h2>

      <form @submit.prevent="salvar">
        <div class="field">
          <label>Nome</label>
          <input v-model="form.nome" required />
        </div>

        <div class="field">
          <label>Categoria</label>
          <input v-model="form.categoria" required />
        </div>

        <div class="field">
          <label>Quantidade</label>
          <input v-model.number="form.quantidade" type="number" min="0" required />
        </div>

        <div class="field">
          <label>Data de Validade</label>
          <input v-model="form.dataValidade" type="date" />
        </div>

        <button type="submit" class="btn-confirmar">Confirmar</button>
      </form>
    </div>
  </div>
</template>

<script setup>
import { reactive } from 'vue'

const form = reactive({
  nome: '',
  categoria: '',
  quantidade: 0,
  dataValidade: '',
})

const salvar = () => {
  // aqui depois você integra com o backend (axios/fetch)
  console.log('Enviando produto', form)
  alert('Produto salvo (fictício por enquanto)')
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

.field {
  display: flex;
  flex-direction: column;
  margin-bottom: 10px;
}

.btn-confirmar {
  width: 100%;
  padding: 10px;
  border: none;
  background: #e53935;
  color: #fff;
  cursor: pointer;
  margin-top: 8px;
}
</style>
