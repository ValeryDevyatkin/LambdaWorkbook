import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/page1',
      name: 'page1',
      component: () => import('../views/tabs/Page1View.vue'),
    },
    {
      path: '/page2',
      name: 'page2',
      component: () => import('../views/tabs/Page2View.vue'),
    },
    {
      path: '/page3',
      name: 'page3',
      component: () => import('../views/tabs/Page3View.vue'),
    },
    {
      path: '/page4',
      name: 'page4',
      component: () => import('../views/tabs/Page4View.vue'),
    },
    {
      path: '/notes',
      name: 'notes',
      component: () => import('../views/tabs/UserNotes.vue'),
    },
  ],
})

export default router
