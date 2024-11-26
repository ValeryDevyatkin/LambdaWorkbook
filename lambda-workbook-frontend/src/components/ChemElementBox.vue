<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps<{
  element: string
}>()
</script>

<template>
  <div class="chem-element-box">{{ props.element }}</div>
</template>

<style scoped>
.chem-element-box {
  user-select: none;
  display: grid;
  align-items: center;
  text-align: center;
  text-decoration: none;

  color: var(--black-color);
  background-color: var(--button-background-color);

  border-radius: var(--small-border-radius);
  border: var(--border-thickness) solid var(--black-color);

  font-size: 40px;
  font-family: var(--font-family);
  font-weight: bolder;

  --box-element-size: 60px;
  width: var(--box-element-size);
  height: var(--box-element-size);
}
</style>
