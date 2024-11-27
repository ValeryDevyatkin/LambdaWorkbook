<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps<{
  text: string
  isDisabled?: boolean
}>()
</script>

<template>
  <div class="tooltip-container">
    <slot></slot>
    <span class="tooltip-text" :class="{ 'tooltip-disabled': isDisabled }">{{ props.text }}</span>
  </div>
</template>

<style scoped>
.tooltip-container {
  position: relative;
}

.tooltip-container .tooltip-text {
  visibility: collapse;
  background-color: var(--black-color);
  color: rgba(214, 214, 202, 1);
  text-align: center;
  padding: 10px;
  border-radius: var(--border-radius);

  z-index: 999;
  position: absolute;
  top: 100%;
  right: 0;

  text-decoration: none;
  font-size: var(--regular-font-size);
  font-family: var(--font-family);
}

.tooltip-container:hover .tooltip-text {
  visibility: visible;
}

.tooltip-container:hover .tooltip-disabled {
  visibility: collapse;
}
</style>
