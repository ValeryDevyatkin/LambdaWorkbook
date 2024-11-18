import { ref } from 'vue'
import { defineStore } from 'pinia'
import { UserNoteDto } from '@/api/client'
import { apiClient } from '@/api/client-provider'

export const useUserNoteStore = defineStore('user-note', () => {
  const notes = ref<Array<UserNoteDto | null>>([null])

  async function loadNotes(userId: number) {
    const loadedNotes = await apiClient.usernoteAll(userId)
    notes.value = new Array<UserNoteDto | null>(null).concat(loadedNotes)
  }

  async function save(note: UserNoteDto) {
    if (note.id === null) {
    } else {
    }
  }

  return { notes, loadNotes, save }
})
