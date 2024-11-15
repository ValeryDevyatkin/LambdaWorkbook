import { computed, ref } from 'vue'
import { defineStore } from 'pinia'
import type { IIdentityUserDto } from '@/api/client'

export const useAuthStore = defineStore('auth', () => {
  const currentUser = ref<IIdentityUserDto | null>(null)
  const isAuthorized = computed(() => currentUser.value !== null)

  function setCurrentUser(user: IIdentityUserDto | null) {
    currentUser.value = user
  }

  return { currentUser, setCurrentUser, isAuthorized }
})
