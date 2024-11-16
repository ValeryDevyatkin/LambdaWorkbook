<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps<{
  text: string
}>()
</script>

<template>
  <div>{{ props.text }}</div>
</template>

<style scoped></style>
