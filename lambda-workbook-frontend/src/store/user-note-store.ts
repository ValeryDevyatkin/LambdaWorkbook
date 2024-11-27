import { ref } from 'vue'
import { defineStore } from 'pinia'
import { UserNoteDto } from '@/api/client'
import { apiClient } from '@/api/client-provider'

export const useUserNoteStore = defineStore('user-note', () => {
  const notes = ref<Array<UserNoteDto | null>>([null])

  async function loadNotes(userId?: number) {
    const loadedNotes: (UserNoteDto | null)[] = await apiClient.getUserNotes(userId ?? -1)
    loadedNotes.unshift(null)
    notes.value = loadedNotes
  }

  async function updateNote(note: UserNoteDto) {
    await apiClient.updateUserNote(note)
  }

  async function createNote(note: UserNoteDto) {
    const createdNote = await apiClient.createUserNote(note)
    notes.value.splice(1, 0, createdNote)

    return createdNote
  }

  async function deleteNote(noteId?: number) {
    await apiClient.deleteUserNote(noteId ?? -1)
    notes.value = notes.value.filter((x) => x?.id !== noteId || !x)
  }

  return {
    notes,
    loadNotes,
    createNote,
    updateNote,
    deleteNote,
  }
})
