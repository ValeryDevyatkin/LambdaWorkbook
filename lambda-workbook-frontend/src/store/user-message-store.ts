import { ref } from 'vue'
import { defineStore } from 'pinia'

export const useUserMessageStore = defineStore('user-message', () => {
  const message = ref('')
  const isHidden = ref(true)
  const isError = ref(false)

  function show(msg: string, isEror: boolean) {
    message.value = msg
    isHidden.value = false
    isError.value = isEror

    setTimeout(hideMessage, 9999)
  }

  function showMessage(msg: string) {
    show(msg, false)
  }

  function showEror(msg: string) {
    show(msg, true)
  }

  function hideMessage() {
    message.value = ''
    isHidden.value = true
    isError.value = false
  }

  return { isHidden, isError, message, showMessage, showEror, hideMessage }
})
