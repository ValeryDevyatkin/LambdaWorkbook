<script setup lang="ts">
import { UserMessageItemDto } from '@/api/client'
import { defineProps } from 'vue'
import CustomLabel from './CustomLabel.vue'

const props = defineProps<{
  userMessage: UserMessageItemDto
}>()
</script>

<template>
  <div class="user-message-grid">
    <CustomLabel :text="props.userMessage.userLogin ?? ''" />
    <CustomLabel :text="props.userMessage.text ?? ''" />
  </div>
</template>

<style scoped>
.user-message-grid {
  display: grid;
  grid-template-columns: auto 300px;
  column-gap: var(--grid-inner-gap);
}
.user-message-grid div {
  overflow: auto;
}
</style>
