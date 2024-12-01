<script setup lang="ts">
import { useDialogWindowStore } from '@/store/dialog-winow-store'
import { ref } from 'vue'

const dialogStore = useDialogWindowStore()
const isFrontImage = ref(true)

function switchImage() {
  isFrontImage.value = !isFrontImage.value
}
</script>

<template>
  <div v-if="dialogStore.isOpened" class="dialog-window" @click="switchImage">
    <img v-if="isFrontImage" src="/src/assets/chem-table.jpg" />
    <img v-else src="/src/assets/mixture-table.jpg" />
  </div>
</template>

<style scoped>
.dialog-window {
  z-index: 1000;
  position: absolute;
  padding: 0;
  overflow: hidden;

  border: var(--border-thickness) solid var(--black-color);
  border-radius: var(--border-radius);
}

.dialog-window img {
  object-fit: contain;
  margin: 0;
  padding: 0;
  vertical-align: bottom;

  --dialog-window-size: 710px;
  height: var(--dialog-window-size);
}
</style>
