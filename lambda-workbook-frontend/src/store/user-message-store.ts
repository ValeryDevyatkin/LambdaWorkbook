import { ref } from 'vue'
import { defineStore } from 'pinia'
import { UserMessageDto, UserMessageItemDto } from '@/api/client'
import { apiClient } from '@/api/client-provider'

export const useUserMessageStore = defineStore('user-message', () => {
  const messages = ref<Array<UserMessageItemDto>>([])

  async function loadMessages() {
    const loadedMessages = await apiClient.getUserMessages()
    messages.value = loadedMessages
  }

  async function createMessage(text?: string | null, userId?: number) {
    return await apiClient.createUserMessage(
      new UserMessageDto({ text: text ?? '', userId: userId ?? -1 }),
    )
  }

  return { messages, loadMessages, createMessage }
})
