<script setup lang="ts">
import type { UserNoteDto } from '@/api/client'
import { defineProps } from 'vue'
import CustomTooltip from './CustomTooltip.vue'

const props = defineProps<{
  userNote: UserNoteDto | null
}>()
</script>

<template>
  <CustomTooltip
    v-if="props.userNote === null"
    text="Добавить заметку."
    class="add-user-note-button"
  >
    <button class="add-user-note-button">
      <img src="..\assets\icons\add-50.png" />
    </button>
  </CustomTooltip>
  <div v-else class="user-note-card">
    {{ props.userNote?.text }}
  </div>
</template>

<style scoped>
.add-user-note-button {
  width: 100px;
  height: 100px;
}

.user-note-card {
  width: 100px;
  height: 100px;
  background-color: yellow;
}
</style>
