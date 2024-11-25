<script setup lang="ts">
import { useHeightNormalizerStore } from '@/store/height-normalizer-store'

const heightStore = useHeightNormalizerStore()
</script>

<template>
  <div v-if="heightStore.isCalculating" class="tab-content" id="tab-content-template">
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
