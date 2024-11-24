<script setup lang="ts">
import UserNoteCard from '@/components/UserNoteCard.vue'
import { useAuthStore } from '@/store/auth-store'
import { useHeightNormalizerStore } from '@/store/height-normalizer-store'
import { useUserNoteStore } from '@/store/user-note-store'
import { computed, onMounted, watch } from 'vue'

const authStore = useAuthStore()
const noteStore = useUserNoteStore()
const heightStore = useHeightNormalizerStore()
const isAuthorized = computed(() => authStore.isAuthorized)
const shouldReloadNotes = computed(() => noteStore.shouldReloadNotes)

async function loadNotes() {
  const currentUserId = authStore.currentUser?.id
  await noteStore.loadNotes(currentUserId)
}

async function calculateHeightAndLoadNotes(delay: number) {
  if (isAuthorized.value) {
    heightStore.calculateContentHeight(delay)
    await loadNotes()
  } else {
    heightStore.resetMaxHeight()
  }
}

onMounted(async () => {
  await calculateHeightAndLoadNotes(0)
})

watch(isAuthorized, async () => {
  await calculateHeightAndLoadNotes(100)
})

watch(shouldReloadNotes, async () => {
  if (shouldReloadNotes.value) {
    await calculateHeightAndLoadNotes(0)
  }
})
</script>

<template>
  <div class="tab-content-root">
    <h1>Заметки</h1>
    <div v-if="heightStore.isCalculating" class="tab-content" id="tab-content-template">
      <div class="center-message">Загрузка...</div>
    </div>
    <div
      v-else
      class="tab-content"
      :style="{
        height: heightStore.maxHeightString,
      }"
    >
      <div v-if="isAuthorized" class="user-notes-grid">
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
  grid-template-columns: 1fr 1fr;
}
</style>
