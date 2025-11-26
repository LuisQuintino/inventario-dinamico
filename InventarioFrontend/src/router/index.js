import { createRouter, createWebHistory } from 'vue-router'

import SplashView from '../views/SplashView.vue'
import LoginView from '../views/LoginView.vue'
import MenuView from '../views/MenuView.vue'
import RegistroView from '../views/RegistroView.vue'
import AdicionarProdutoView from '../views/AdicionarProdutoView.vue'
import RetirarProdutoView from '../views/RetirarProdutoView.vue'
import AtualizarProdutoView from '../views/AtualizarProdutoView.vue'
import RelatorioView from '../views/RelatorioView.vue'
import PerfilView from '../views/PerfilView.vue'
import CriarPerfilView from '../views/CriarPerfilView.vue'
import RecuperarSenhaView from '../views/RecuperarSenhaView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: '/', name: 'splash', component: SplashView },
    { path: '/login', name: 'login', component: LoginView },
    { path: '/menu', name: 'menu', component: MenuView },
    { path: '/registro', name: 'registro', component: RegistroView },
    { path: '/registro/adicionar', name: 'registro-adicionar', component: AdicionarProdutoView },
    { path: '/registro/retirar', name: 'registro-retirar', component: RetirarProdutoView },
    { path: '/registro/atualizar', name: 'registro-atualizar', component: AtualizarProdutoView },
    { path: '/relatorio', name: 'relatorio', component: RelatorioView },
    { path: '/perfil', name: 'perfil', component: PerfilView },
    { path: '/perfil/criar', name: 'perfil-criar', component: CriarPerfilView },
    { path: '/recuperar-senha', name: 'recuperar-senha', component: RecuperarSenhaView },
  ],
})

export default router
