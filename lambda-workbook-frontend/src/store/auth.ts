import { computed, ref } from 'vue'
import { defineStore } from 'pinia'
import type { IIdentityUserDto } from '@/api/client'

export const useAuthStore = defineStore('auth', () => {
  const currentUserRef = ref<IIdentityUserDto | null>(null)

  function setCurrentUser(user: IIdentityUserDto | null) {
    currentUserRef.value = user
  }

  const currentUser = computed(() => currentUserRef.value)
  const isAuthorized = computed(() => currentUser.value !== null)

  return { currentUser, setCurrentUser, isAuthorized }
})
