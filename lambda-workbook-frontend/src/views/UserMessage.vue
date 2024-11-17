<script setup lang="ts">
import { useUserMessageStore } from '@/store/user-message-store'

const messageStore = useUserMessageStore()
</script>

<template>
  <div
    @click="messageStore.hideMessage"
    class="user-message"
    :class="{
      'user-message-hidden': messageStore.isHidden,
      'user-message-error': messageStore.isError,
    }"
  >
    {{ messageStore.message }}
  </div>
</template>

<style scoped>
.user-message-hidden {
  display: none;
}

.user-message {
  cursor: pointer;
  background-color: var(--green-alert-color);
  border-radius: var(--border-radius);
  position: absolute;
  padding: 10px 40px;
  margin-left: 10px;
  right: 10px;
  max-width: 300px;

  animation: green-pulse 2s infinite alternate-reverse;
}

.user-message-error {
  background-color: var(--red-alert-color);
  animation: red-pulse 0.4s infinite alternate-reverse;
}

@keyframes red-pulse {
  0% {
    box-shadow: 0 0 5px var(--red-alert-color);
  }
  100% {
    box-shadow: 0 0 20px var(--red-alert-color);
  }
}

@keyframes green-pulse {
  0% {
    box-shadow: 0 0 5px var(--green-alert-color);
  }
  100% {
    box-shadow: 0 0 20px var(--green-alert-color);
  }
}
</style>
