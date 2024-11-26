<script setup lang="ts">
import { useAuthStore } from '@/store/auth-store'
import { useHeightNormalizerStore } from '@/store/height-normalizer-store'

const props = defineProps<{
  shouldAuthorize?: boolean
}>()

const heightStore = useHeightNormalizerStore()
const authStore = useAuthStore()
</script>

<template>
  <div
    v-if="heightStore.isCalculating && (authStore.isAuthorized || !props.shouldAuthorize)"
    class="tab-content"
    id="tab-content-template"
  >
    <div class="center-message">Загрузка...</div>
  </div>
  <div
    v-else
    class="tab-content"
    :style="{
      height: heightStore.maxHeightString,
    }"
  >
    <slot></slot>
  </div>
</template>
