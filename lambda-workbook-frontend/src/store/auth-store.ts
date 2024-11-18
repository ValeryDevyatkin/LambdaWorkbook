import { computed, ref } from 'vue'
import { defineStore } from 'pinia'
import { LogInRequest, RegisterPublicUserRequest, type IIdentityUserDto } from '@/api/client'
import { apiClient } from '@/api/client-provider'

export const useAuthStore = defineStore('auth', () => {
  const currentUser = ref<IIdentityUserDto | null>(null)
  const isAuthorized = computed(() => currentUser.value !== null)

  function setCurrentUser(user: IIdentityUserDto | null) {
    currentUser.value = user
  }

  async function logIn(login: string, password: string) {
    const user = await apiClient.login(new LogInRequest({ login, password }))
    setCurrentUser(user)

    return user
  }

  async function registerPublic(login: string, password: string) {
    const user = await apiClient.registerpublic(new RegisterPublicUserRequest({ login, password }))

    return user
  }

  function logOut() {
    setCurrentUser(null)
  }

  return { currentUser, logIn, logOut, registerPublic, isAuthorized }
})
