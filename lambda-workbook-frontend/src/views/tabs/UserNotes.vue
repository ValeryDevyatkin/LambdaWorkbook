<script setup lang="ts">
import UserNoteCard from '@/components/UserNoteCard.vue'
import { useAuthStore } from '@/store/auth-store'
import { useUserNoteStore } from '@/store/user-note-store'
import { onMounted } from 'vue'

const authStore = useAuthStore()
const noteStore = useUserNoteStore()

onMounted(async () => {
  if (authStore.isAuthorized) {
    await noteStore.loadNotes(authStore.currentUser?.id ?? -1)
  }
})
</script>

<template>
  <div>
    <h1>Заметки</h1>
    <div class="tab-content">
      <div v-if="authStore.isAuthorized">
        <UserNoteCard v-for="note in noteStore.notes" :key="note?.id" :user-note="note" />
      </div>
      <div v-else class="center-message">Войдите, чтобы просмотреть.</div>
    </div>
  </div>
</template>

<style scoped></style>
