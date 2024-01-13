import { createRouter, createWebHistory } from 'vue-router'
import { uzytkownik } from '../main'

import {
  BrakDostepu,
  zmianaHasla,
  StronaLogowania,
  Rezerwacja,
  Rejestracja,
  PotwierdzenieKonta,
  RezerwacjaUbezpieczenie
} from '../components'

import { Pracownik, Przedluzenia, RezerwacjaInfo } from '../components/pracownik'
import { MojeRezerwacje, Przedluzenie, RezerwacjaPodsumowanie } from '../components/klient'
import { ListaPracownikow, ListaSamochodow, ListaUbezpieczen } from '../components/admin'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'rezerwacja',
      component: Rezerwacja,
      meta: { uprawnienia: null }
    },
    {
      path: '/logowanie',
      name: 'logowanie',
      component: StronaLogowania,
      meta: { uprawnienia: null }
    },
    {
      path: '/rejestracja',
      name: 'rejestracja',
      component: Rejestracja,
      meta: { uprawnienia: null }
    },
    {
      path: '/potwierdzenieKonta/:id',
      name: 'potwierdzenieKonta',
      component: PotwierdzenieKonta,
      meta: { uprawnienia: null }
    },
    {
      path: '/brakDostepu',
      name: 'brakdostepu',
      component: BrakDostepu,
      meta: { uprawnienia: null }
    },
    {
      path: '/zmianaHasla',
      name: 'zmianaHasla',
      component: zmianaHasla,
      meta: { uprawnienia: null }
    },
    {
      path: '/mojeRezerwacje',
      name: 'mojeRezerwacje',
      component: MojeRezerwacje,
      meta: { uprawnienia: null }
    },
    {
      path: '/przedluzenie/:id',
      name: 'przedluzenie',
      component: Przedluzenie,
      meta: { uprawnienia: null }
    },
    {
      path: '/rezerwacja/:id/ubezpieczenia',
      name: 'rezerwacjaUbezpieczenie',
      component: RezerwacjaUbezpieczenie,
      meta: { uprawnienia: null }
    },
    {
      path: '/podsumowanie',
      name: 'podsumowanie',
      component: RezerwacjaPodsumowanie,
      meta: { uprawnienia: ['klient'] }
    },
    // Pracownik
    {
      path: '/pracownik',
      name: 'pracownik',
      component: Pracownik,
      meta: { uprawnienia: ['pracownik', 'admin'] }
    },
    {
      path: '/przedluzenia',
      name: 'przedluzenia',
      component: Przedluzenia,
      meta: { uprawnienia: ['pracownik', 'admin'] }
    },
    {
      path: '/rezerwacja/:id/info',
      name: 'rezerwacje',
      component: RezerwacjaInfo,
      meta: { uprawnienia: ['pracownik', 'admin'] }
    },
    //admin

    {
      path: '/listaPracownikow',
      name: 'listaPracownikow',
      component: ListaPracownikow,
      meta: { uprawnienia: ['admin'] }
    },
    {
      path: '/listaSamochodow',
      name: 'listaSamochodow',
      component: ListaSamochodow,
      meta: { uprawnienia: ['admin'] }
    },
    {
      path: '/listaUbezpieczen',
      name: 'listaUbezpieczen',
      component: ListaUbezpieczen,
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
