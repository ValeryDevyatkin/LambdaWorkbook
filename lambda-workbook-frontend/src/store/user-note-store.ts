import { ref } from 'vue'
import { defineStore } from 'pinia'
import { UserNoteDto } from '@/api/client'
import { apiClient } from '@/api/client-provider'

export const useUserNoteStore = defineStore('user-note', () => {
  const notes = ref<Array<UserNoteDto | null>>([null])

  async function loadNotes(userId?: number) {
    const loadedNotes = await apiClient.getUserNotes(userId ?? -1)
    notes.value = new Array<UserNoteDto | null>(null).concat(loadedNotes)
  }

  async function updateNote(note: UserNoteDto) {
    await apiClient.updateUserNote(note)
  }

  async function createNote(note: UserNoteDto) {
    return await apiClient.createUserNote(note)
  }

  async function deleteNote(noteId?: number) {
    await apiClient.deleteUserNote(noteId ?? -1)
  }

  return { notes, loadNotes, createNote, updateNote, deleteNote }
})
