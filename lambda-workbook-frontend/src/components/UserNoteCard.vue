<script setup lang="ts">
import { UserNoteDto } from '@/api/client'
import { computed, defineProps, ref } from 'vue'
import CustomTooltip from './CustomTooltip.vue'
import { useAuthStore } from '@/store/auth-store'
import { useUserNoteStore } from '@/store/user-note-store'
import CustomLabel from './CustomLabel.vue'
import { useUserMessageStore } from '@/store/user-message-store'

const authStore = useAuthStore()
const noteStore = useUserNoteStore()
const messageStore = useUserMessageStore()

const props = defineProps<{
  userNote: UserNoteDto | null
}>()

const currentNote = ref<UserNoteDto | null>(props.userNote)
const currentNoteTitle = computed(() => `Заметка #${currentNote.value?.id}`)

function addNote() {
  const currentUserId = authStore.currentUser?.id

  const emptyNote = new UserNoteDto({
    userId: currentUserId,
    id: undefined,
  })

  currentNote.value = emptyNote
}

function cancelAddNote() {
  currentNote.value = null
}

async function saveNote() {
  if (currentNote.value === null) return
  const currentUserId = authStore.currentUser?.id
  const currentNoteId = currentNote.value?.id

  try {
    if (currentNoteId) {
      await noteStore.updateNote(currentNote.value)
      messageStore.showMessage(`Заметка #${currentNoteId} обновлена.`)
    } else {
      const createdNote = await noteStore.createNote(currentNote.value)
      cancelAddNote()
      messageStore.showMessage(`Новая заметка #${createdNote.id} сохранена.`)
    }

    await noteStore.loadNotes(currentUserId)

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
  } catch (error: any) {
    messageStore.showEror(error?.response)
  }
}

async function deleteNote() {
  const currentNoteId = currentNote.value?.id
  const currentUserId = authStore.currentUser?.id

  try {
    await noteStore.deleteNote(currentNoteId)
    await noteStore.loadNotes(currentUserId)
    messageStore.showMessage(`Заметка #${currentNoteId} удалена.`)

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
  } catch (error: any) {
    messageStore.showEror(error?.response)
  }
}
</script>

<template>
  <CustomTooltip v-if="currentNote === null" text="Добавить заметку" class="add-user-note-button">
    <button @click="addNote">
      <img src="..\assets\icons\add-50.png" />
    </button>
  </CustomTooltip>

  <div v-else-if="!currentNote.id" class="user-note-grid">
    <CustomLabel text="Новая заметка" />
    <CustomTooltip text="Сохранить" class="icon-button">
      <button @click="saveNote">
        <img src="..\assets\icons\save-50.png" />
      </button>
    </CustomTooltip>
    <CustomTooltip text="Отмена" class="icon-button">
      <button @click="cancelAddNote">
        <img src="..\assets\icons\cancel-50.png" />
      </button>
    </CustomTooltip>
    <textarea v-model="currentNote.text" class="user-note-textarea"></textarea>
  </div>

  <div v-else class="user-note-grid">
    <CustomLabel :text="currentNoteTitle" />
    <CustomTooltip text="Сохранить" class="icon-button">
      <button @click="saveNote">
        <img src="..\assets\icons\save-50.png" />
      </button>
    </CustomTooltip>
    <CustomTooltip text="Удалить" class="icon-button">
      <button @click="deleteNote">
        <img src="..\assets\icons\delete-50.png" />
      </button>
    </CustomTooltip>
    <textarea v-model="currentNote.text" class="user-note-textarea"></textarea>
  </div>
</template>

<style scoped>
.user-note-grid {
  display: grid;
  grid-template-columns: 1fr auto auto;
  grid-template-rows: var(--icon-button-size) auto;
  column-gap: var(--grid-inner-gap);
  row-gap: var(--grid-inner-gap);
}

.user-note-textarea {
  grid-column-start: 1;
  grid-column-end: 4;
  resize: vertical;
  min-height: 43.4px;
}

.add-user-note-button,
.add-user-note-button button {
  width: 100px;
  height: 100px;
}
</style>
