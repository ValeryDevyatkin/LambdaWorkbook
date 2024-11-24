<script setup lang="ts">
import { useAuthStore } from '@/store/auth-store'
import { useHeightNormalizerStore } from '@/store/height-normalizer-store'
import { useUserMessageStore } from '@/store/user-message-store'
import { computed, onMounted, watch } from 'vue'

const authStore = useAuthStore()
const messageStore = useUserMessageStore()
const heightStore = useHeightNormalizerStore()
const isAuthorized = computed(() => authStore.isAuthorized)

async function calculateHeightAndLoadMessages(delay: number) {
  if (isAuthorized.value) {
    heightStore.calculateContentHeight(delay)
    await messageStore.loadMessages()
  } else {
    heightStore.resetMaxHeight()
  }
}

onMounted(async () => {
  await calculateHeightAndLoadMessages(0)
})

watch(isAuthorized, async () => {
  await calculateHeightAndLoadMessages(300)
})
</script>

<template>
  <div class="tab-content-root">
    <h1>Чат</h1>
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
      <div v-if="isAuthorized">
        <UserMessageCard
          v-for="message in messageStore.messages"
          :key="message?.id"
          :user-message="message"
        />
      </div>
      <div v-else class="center-message">Войдите, чтобы просмотреть</div>
    </div>
  </div>
</template>

<style scoped></style>
