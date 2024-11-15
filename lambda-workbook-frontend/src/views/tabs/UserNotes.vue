<script setup lang="ts">
import { apiClient } from '@/api/client-provider'
import { useAuthStore } from '@/store/auth-store'
import { onMounted } from 'vue'

const authStore = useAuthStore()

async function loadNotes() {
  if (!authStore.isAuthorized) return

  const notes = await apiClient.usernoteAll(authStore.currentUser?.id ?? -1)
  alert(JSON.stringify(notes))
}

onMounted(async () => await loadNotes())
</script>

<template>
  <div>
    <h1>Заметки</h1>
    <div class="tab-content">
      <div v-if="authStore.isAuthorized"></div>
      <div v-else class="center-message">Войдите, чтобы просмотреть.</div>
    </div>
  </div>
</template>

<style scoped></style>
