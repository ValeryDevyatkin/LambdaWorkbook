<script setup lang="ts">
import UserNoteCard from '@/components/UserNoteCard.vue'
import { useAuthStore } from '@/store/auth-store'
import { useUserNoteStore } from '@/store/user-note-store'
import { onMounted } from 'vue'

const authStore = useAuthStore()
const noteStore = useUserNoteStore()

onMounted(async () => {
  if (authStore.isAuthorized) {
    const currentUserId = authStore.currentUser?.id
    await noteStore.loadNotes(currentUserId)
  }
})
</script>

<template>
  <div>
    <h1>Заметки</h1>
    <div class="tab-content">
      <div v-if="authStore.isAuthorized" class="user-notes-grid">
        <UserNoteCard v-for="note in noteStore.notes" :key="note?.id" :user-note="note" />
      </div>
      <div v-else class="center-message">Войдите, чтобы просмотреть</div>
    </div>
  </div>
</template>

<style scoped>
.user-notes-grid {
  display: grid;
  column-gap: var(--outter-padding);
  row-gap: var(--outter-padding);
  grid-template-columns: 1fr 1fr 1fr;
}
</style>
