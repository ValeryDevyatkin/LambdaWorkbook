import { ref } from 'vue'
import { defineStore } from 'pinia'

export const useDialogWindowStore = defineStore('dialog-window', () => {
  const isOpened = ref(false)

  function switchIsOpened() {
    isOpened.value = !isOpened.value
  }

  return { isOpened, switchIsOpened }
})
