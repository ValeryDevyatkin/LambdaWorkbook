<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps<{
  text: string
  isDisabled?: boolean
}>()
</script>

<template>
  <div class="tooltip">
    <slot></slot>
    <span class="tooltip-text" :class="{ 'tooltip-disabled': isDisabled }">{{ props.text }}</span>
  </div>
</template>

<style scoped>
.tooltip {
  position: relative;
}

.tooltip .tooltip-text {
  visibility: collapse;
  background-color: var(--black-color);
  color: rgba(214, 214, 202, 1);
  text-align: center;
  padding: 10px;
  border-radius: var(--border-radius);

  position: absolute;
  bottom: 0;
  left: 100%;

  text-decoration: none;
  font-size: var(--regular-font-size);
  font-family: var(--font-family);
}

.tooltip:hover .tooltip-text {
  visibility: visible;
}

.tooltip:hover .tooltip-disabled {
  visibility: collapse;
}
</style>
