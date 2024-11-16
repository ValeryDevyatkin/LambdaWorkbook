<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps<{
  text: string
}>()
</script>

<template>
  <button>{{ props.text }}</button>
</template>

<style scoped></style>
