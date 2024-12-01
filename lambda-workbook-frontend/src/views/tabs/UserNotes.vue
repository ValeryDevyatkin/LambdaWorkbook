<script setup lang="ts">
import CalculatedTabContent from '@/components/CalculatedTabContent.vue'
import UserNoteCard from '@/components/UserNoteCard.vue'
import { useAuthStore } from '@/store/auth-store'
import { useUserNoteStore } from '@/store/user-note-store'
import { computed, onMounted, watch } from 'vue'

const authStore = useAuthStore()
const noteStore = useUserNoteStore()
const isAuthorized = computed(() => authStore.isAuthorized)

async function loadNotes() {
  if (isAuthorized.value) {
    const currentUserId = authStore.currentUser?.id
    await noteStore.loadNotes(currentUserId)
  }
}

onMounted(async () => {
  await loadNotes()
})

watch(isAuthorized, async () => {
  await loadNotes()
})
</script>

<template>
  <div class="tab-content-root">
    <h1>Заметки</h1>
    <CalculatedTabContent>
      <div v-if="isAuthorized" class="user-notes-grid">
        <UserNoteCard v-for="note in noteStore.notes" :key="note?.id" :user-note="note" />
      </div>
      <div v-else class="center-text">Войдите, чтобы просмотреть</div>
    </CalculatedTabContent>
  </div>
</template>

<style scoped>
.user-notes-grid {
  display: grid;
  column-gap: var(--outter-padding);
  row-gap: var(--outter-padding);
  grid-template-columns: 1fr 1fr;
}
</style>
