<script setup lang="ts">
import CalculatedTabContent from '@/components/CalculatedTabContent.vue'
import UserMessageCard from '@/components/UserMessageCard.vue'
import { useAuthStore } from '@/store/auth-store'
import { useHeightNormalizerStore } from '@/store/height-normalizer-store'
import { usePopupMessageStore } from '@/store/popup-message-store'
import { useUserMessageStore } from '@/store/user-message-store'
import { computed, onMounted, ref, watch } from 'vue'

const authStore = useAuthStore()
const messageStore = useUserMessageStore()
const heightStore = useHeightNormalizerStore()
const popupStore = usePopupMessageStore()
const isAuthorized = computed(() => authStore.isAuthorized)
const chatMessage = ref<string | null>(null)
const chatMessageComputed = computed(() => chatMessage.value?.trim() ?? null)

async function sendMessage() {
  const currentUserId = authStore.currentUser?.id

  try {
    await messageStore.createMessage(chatMessageComputed.value, currentUserId)
    await calculateHeightAndLoadMessages()
    chatMessage.value = null
    popupStore.showMessage('Сообщение отправлено.')

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
  } catch (error: any) {
    popupStore.showEror(error?.response)
  }
}

function scrollToLatestMessage(delay: number) {
  setTimeout(() => {
    const messages = document?.getElementsByClassName('user-message-grid')
    messages[messages.length - 1].scrollIntoView()
  }, delay)
}

async function calculateHeightAndLoadMessages(delay: number = 0) {
  if (isAuthorized.value) {
    heightStore.calculateContentHeight(delay)
    await messageStore.loadMessages()
    scrollToLatestMessage(delay)
  } else {
    heightStore.resetMaxHeight()
  }
}

onMounted(async () => {
  await calculateHeightAndLoadMessages()
})

watch(isAuthorized, async () => {
  await calculateHeightAndLoadMessages(100)
})
</script>

<template>
  <div class="tab-content-root chat-tab-content-root">
    <h1>Чат</h1>
    <CalculatedTabContent>
      <div v-if="isAuthorized" class="chat-grid">
        <div class="chat-message-grid">
          <UserMessageCard
            v-for="message in messageStore.messages"
            :key="message?.id"
            :user-message="message"
          />
        </div>
        <div class="chat-input-grid">
          <input v-model="chatMessage" />
          <button
            class="icon-button"
            @click="sendMessage"
            :class="{ disabled: !chatMessageComputed }"
          >
            <img src="../../assets/icons/send-32.png" />
          </button>
        </div>
      </div>
      <div v-else class="center-message">Войдите, чтобы просмотреть</div>
    </CalculatedTabContent>
  </div>
</template>

<style scoped>
.chat-tab-content-root {
  max-width: 400px;
}

.chat-grid {
  position: relative;
  height: 100%;
  display: grid;
  row-gap: var(--grid-inner-gap);
  grid-template-rows: 1fr auto;
}

.chat-message-grid div {
  margin-bottom: var(--grid-inner-gap);
}
.chat-message-grid div:last-child {
  margin-bottom: var(--outter-padding);
}

.chat-input-grid {
  position: sticky;
  bottom: 0;
  display: grid;
  column-gap: var(--grid-inner-gap);
  grid-template-columns: 1fr auto;
}
</style>
