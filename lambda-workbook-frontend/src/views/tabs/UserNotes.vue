<script setup lang="ts">
import UserNoteCard from '@/components/UserNoteCard.vue'
import { useAuthStore } from '@/store/auth-store'
import { useUserNoteStore } from '@/store/user-note-store'
import { computed, onMounted, ref, watch } from 'vue'

const authStore = useAuthStore()
const noteStore = useUserNoteStore()
const isLoading = ref(true)
const maxHeight = ref<number | undefined>(undefined)
const isAuthorized = computed(() => authStore.isAuthorized)

function calculateContentHeight() {
  isLoading.value = true
  const tabContent = document.getElementById('tab-content-template')
  maxHeight.value = tabContent?.offsetHeight
  isLoading.value = false
}

async function loadNotes() {
  if (isAuthorized.value) {
    const currentUserId = authStore.currentUser?.id
    await noteStore.loadNotes(currentUserId)
  }
}

onMounted(async () => {
  calculateContentHeight()
  await loadNotes()
})

watch(isAuthorized, async () => {
  if (isAuthorized.value) {
    isLoading.value = true

    setTimeout(async () => {
      calculateContentHeight()
      await loadNotes()
    }, 300)
  } else {
    maxHeight.value = undefined
  }
})
</script>

<template>
  <div class="tab-content-root">
    <h1>Заметки</h1>
    <div v-if="isLoading" class="tab-content" id="tab-content-template">
      <div class="center-message">Загрузка...</div>
    </div>
    <div
      v-else
      class="tab-content"
      :style="{
        height: maxHeight ? `${maxHeight}px` : 'unset',
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
