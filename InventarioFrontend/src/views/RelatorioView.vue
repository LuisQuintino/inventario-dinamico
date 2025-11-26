<template>
  <div class="page">
    <div class="card">
      <button class="back" @click="$router.back()">&#8592; Voltar</button>
      <h2>Relatório</h2>

      <table>
        <thead>
          <tr>
            <th>Categoria</th>
            <th>Nome</th>
            <th>Quantidade</th>
            <th>Data Entrada</th>
            <th>Data Validade</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in itens" :key="item.id">
            <td>{{ item.categoria }}</td>
            <td>{{ item.nome }}</td>
            <td>{{ item.quantidade }}</td>
            <td>{{ item.dataEntrada }}</td>
            <td>{{ item.dataValidade }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
const itens = [
  { id: 1, categoria: 'Alimentos', nome: 'Arroz', quantidade: 10, dataEntrada: '10/12/2025', dataValidade: '10/12/2026' },
  { id: 2, categoria: 'Higiene', nome: 'Sabonete', quantidade: 5, dataEntrada: '05/11/2025', dataValidade: '05/11/2026' },
  // Depois isso vem da API
]
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
  background: #fff;
  padding: 24px;
  border-radius: 8px;
  width: 80%;
  max-width: 900px;
}

.back {
  background: transparent;
  border: none;
  margin-bottom: 12px;
  cursor: pointer;
}

table {
  width: 100%;
  border-collapse: collapse;
  font-size: 13px;
}

th, td {
  border: 1px solid #ddd;
  padding: 8px;
}

th {
  background: #f0f0f0;
}
</style>
