import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'rezerwacja',
      component: () => import('../components/Rezerwacja.vue'),
      meta:{ uprawnienia: null }
    },
    {
      path: '/logowanie',
      name: 'logowanie',
      component: () => import('../components/StronaLogowania.vue'),
      meta:{ uprawnienia: null }
    },
    {
      path: '/rejestracja',
      name: 'rejestracja',
      component: () => import('../components/Rejestracja.vue'),
      meta:{ uprawnienia: null }
    },
    {
      path: '/brak',
      name: 'brakdostepu',
      component: () => import('../components/BrakDostepu.vue'),
      meta:{ uprawnienia: null }
    },
    {
      path: '/rezerwacja/:id/ubezpieczenia',
      name: 'rezerwacjaUbezpieczenie',
      component: () => import('../components/RezerwacjaUbezpieczenie.vue'),
      meta:{ uprawnienia: null }
    },
    {
      path: '/podsumowanie',
      name: 'podsumowanie',
      component: () => import('../components/RezerwacjaPodsumowanie.vue'),
      meta:{ uprawnienia: "klient" }
    },
  ]
})

export default router

router.beforeEach((to,from)=> {
  if(to.meta.uprawnienia != null && to.meta.uprawnienia != uzytkownik.uprawnienia ){
    return {
      path:"/logowanie",
      query: { redirect: from.fullPath },
    }
  }
});