import { useAuthStore } from '@/store/auth-store'

export class ClientBase {
  protected transformOptions = async (options: RequestInit): Promise<RequestInit> => {
    const authStore = useAuthStore()
    const token = authStore.currentUser?.jwtToken

    if (token) {
      options.headers = {
        ...options.headers,
        Authorization: `Bearer ${token}`,
      }
    }

    return Promise.resolve(options)
  }
}
