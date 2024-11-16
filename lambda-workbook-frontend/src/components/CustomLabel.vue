<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps<{
  text: string
}>()
</script>

<template>
  <div class="default-input">{{ props.text }}</div>
</template>
