<script setup lang="ts">
import { computed, defineProps } from 'vue'

const props = defineProps<{
  element: string
  longText?: boolean
  image?: string
}>()

const boxStyle = computed(() => {
  const s = {
    backgroundImage: props.image ? `url('${props.image}')` : 'none',
  }
  return s
})
</script>

<template>
  <div
    :style="boxStyle"
    class="chem-element-box"
    :class="{ 'long-chem-element-box': props.longText }"
  >
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

  background-color: var(--button-background-color);
  background-size: cover;

  border-radius: var(--small-border-radius);
  border: var(--border-thickness) solid var(--black-color);

  font-size: 40px;
  font-family: var(--font-family);
  font-weight: bolder;
  color: var(--black-color);
  -webkit-text-stroke-color: white;
  -webkit-text-stroke-width: 1px;

  --box-element-size: 50px;
  width: var(--box-element-size);
  height: var(--box-element-size);
}

.long-chem-element-box {
  font-size: var(--large-font-size);
  padding: 0;

  text-align: unset;
  align-items: unset;

  -webkit-text-stroke-color: unset;
  -webkit-text-stroke-width: unset;
  background-color: unset;
  border: unset;
  height: unset;

  width: 145px;
}
</style>
