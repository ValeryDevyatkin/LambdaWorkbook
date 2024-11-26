import { computed, ref } from 'vue'
import { defineStore } from 'pinia'

export const useHeightNormalizerStore = defineStore('height-normalizer', () => {
  const isCalculating = ref<boolean>(true)
  const maxHeight = ref<number | undefined>(undefined)
  const maxHeightString = computed(() => (maxHeight.value ? `${maxHeight.value}px` : 'unset'))

  function calculateContentHeight(delay?: number) {
    isCalculating.value = true

    setTimeout(() => {
      const tabContent = document.getElementById('tab-content-template')
      maxHeight.value = tabContent?.offsetHeight
      isCalculating.value = false
    }, delay ?? 0)
  }

  function resetMaxHeight() {
    maxHeight.value = undefined
  }

  return { isCalculating, maxHeightString, calculateContentHeight, resetMaxHeight }
})
