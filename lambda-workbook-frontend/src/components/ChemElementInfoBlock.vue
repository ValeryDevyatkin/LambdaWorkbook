<script setup lang="ts">
import { defineProps } from 'vue'
import ChemElementBox from './ChemElementBox.vue'

const props = defineProps<{
  element: string
  longText?: boolean
  image?: string
}>()
</script>

<template>
  <div class="chem-element-info-block">
    <ChemElementBox :element="props.element" :long-text="props.longText" :image="props.image" />
    <div class="chem-element-info-block-content">
      <slot></slot>
    </div>
  </div>
</template>

<style scoped>
.chem-element-info-block {
  display: grid;
  grid-template-columns: auto 1fr;
  column-gap: var(--outter-padding);
}

.chem-element-info-block-content {
  display: grid;
  grid-template-rows: auto 1fr;
}
</style>
