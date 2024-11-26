<script setup lang="ts">
import { defineProps } from 'vue'
import ChemElementBox from './ChemElementBox.vue'

const props = defineProps<{
  element: string
}>()
</script>

<template>
  <div class="chem-element-info-block">
    <ChemElementBox :element="props.element" />
    <slot></slot>
  </div>
</template>

<style scoped>
.chem-element-info-block {
  display: grid;
  grid-template-columns: auto 1fr;
  column-gap: var(--grid-inner-gap);
}
</style>
