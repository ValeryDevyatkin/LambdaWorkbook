import { ref } from 'vue'
import { defineStore } from 'pinia'
import { UserMessageDto } from '@/api/client'
import { apiClient } from '@/api/client-provider'

export const useUserMessageStore = defineStore('user-message', () => {
  const messages = ref<Array<UserMessageDto>>([])

  async function loadMessages() {
    const loadedMessages = await apiClient.getUserMessages()
    messages.value = loadedMessages
  }

  async function createMessage(message: UserMessageDto) {
    return await apiClient.createUserMessage(message)
  }

  return { messages, loadMessages, createMessage }
})
