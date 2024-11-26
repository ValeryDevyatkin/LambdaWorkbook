<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps<{
  element: string
  longText?: boolean
}>()
</script>

<template>
  <div class="chem-element-box" :class="{ 'long-chem-element-box': longText }">
    {{ props.element }}
  </div>
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

  --box-element-size: 50px;
  width: var(--box-element-size);
  height: var(--box-element-size);
}

.long-chem-element-box {
  font-size: 25px;
  padding: 0;

  text-align: unset;
  align-items: unset;

  background-color: unset;
  border: unset;
  height: unset;

  width: 140px;
}
</style>
