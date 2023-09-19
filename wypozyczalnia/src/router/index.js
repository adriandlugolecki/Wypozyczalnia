import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/logowanie',
      name: 'logowanie',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/StronaLogowania.vue')
    },
    {
      path: '/rejestracja',
      name: 'rejestracja',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Rejestracja.vue')
    },
    {
      path: '/brak',
      name: 'brakdostepu',
      component: () => import('../views/BrakDostepu.vue')
    },
    {
      path: '/rezerwacja',
      name: 'rezerwacja',
      component: () => import('../views/Rezerwacja.vue')
    }
  ]
})

export default router
