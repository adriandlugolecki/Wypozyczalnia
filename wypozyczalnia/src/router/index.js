import { createRouter, createWebHistory } from 'vue-router'
import { uzytkownik } from '../main'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'rezerwacja',
      component: () => import('../components/Rezerwacja.vue'),
      meta: { uprawnienia: null }
    },
    {
      path: '/logowanie',
      name: 'logowanie',
      component: () => import('../components/StronaLogowania.vue'),
      meta: { uprawnienia: null }
    },
    {
      path: '/rejestracja',
      name: 'rejestracja',
      component: () => import('../components/Rejestracja.vue'),
      meta: { uprawnienia: null }
    },
    {
      path: '/brakDostepu',
      name: 'brakdostepu',
      component: () => import('../components/BrakDostepu.vue'),
      meta: { uprawnienia: null }
    },
    {
      path: '/mojeRezerwacje',
      name: 'mojeRezerwacje',
      component: () => import('../components/klient/MojeRezerwacje.vue'),
      meta: { uprawnienia: null }
    },
    {
      path: '/rezerwacja/:id/ubezpieczenia',
      name: 'rezerwacjaUbezpieczenie',
      component: () => import('../components/RezerwacjaUbezpieczenie.vue'),
      meta: { uprawnienia: null }
    },
    {
      path: '/podsumowanie',
      name: 'podsumowanie',
      component: () => import('../components/klient/RezerwacjaPodsumowanie.vue'),
      meta: { uprawnienia: ['klient'] }
    },
    // Pracownik
    {
      path: '/pracownik',
      name: 'pracownik',
      component: () => import('../components/pracownik/Pracownik.vue'),
      meta: { uprawnienia: ['pracownik', 'admin'] }
    },
    {
      path: '/rezerwacja/:id/info',
      name: 'rezerwacje',
      component: () => import('../components/pracownik/RezerwacjaInfo.vue'),
      meta: { uprawnienia: ['pracownik', 'admin'] }
    },
    //admin

    {
      path: '/listaPracownikow',
      name: 'listaPracownikow',
      component: () => import('../components/admin/ListaPracownikow.vue'),
      meta: { uprawnienia: ['admin'] }
    },
    {
      path: '/listaSamochodow',
      name: 'listaSamochodow',
      component: () => import('../components/admin/ListaSamochodow.vue'),
      meta: { uprawnienia: ['admin'] }
    },
    {
      path: '/listaUbezpieczen',
      name: 'listaUbezpieczen',
      component: () => import('../components/admin/ListaUbezpieczen.vue'),
      meta: { uprawnienia: ['admin'] }
    }
  ]
})

export default router

router.beforeEach((to, from) => {
  if (to.meta.uprawnienia != null && !to.meta.uprawnienia.includes(uzytkownik.uprawnienia)) {
    return {
      path: '/brakDostepu',
      query: { redirect: to.fullPath }
    }
  }
})
