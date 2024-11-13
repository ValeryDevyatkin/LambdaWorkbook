<script setup lang="ts">
import { LogInRequest, RegisterPublicUserRequest } from '@/api/client'
import { apiClient } from '@/api/client-provider'
import { useAuthStore } from '@/store/auth'
import { computed, ref } from 'vue'

const { currentUser, setCurrentUser, isAuthorized } = useAuthStore()

const isRegisterMode = ref(false)
const isLogInMode = ref(false)
const isGuestMode = computed(() => !isAuthorized && !isRegisterMode.value && !isLogInMode.value)

async function logIn() {
  try {
    const response = await apiClient.login(
      new LogInRequest({ login: 'admin', password: 'minerale' }),
    )

    setCurrentUser(response.result ?? null)
    isLogInMode.value = false
    alert(JSON.stringify(response.result))
  } catch (error) {
    // TODO: generic alert
    alert(JSON.stringify(error))
  }
}

async function register() {
  try {
    const response = await apiClient.registerpublic(
      new RegisterPublicUserRequest({ login: 'XXX', password: 'XXX' }),
    )

    alert(response)
    isRegisterMode.value = false
  } catch (error) {
    // TODO: generic alert
    alert(JSON.stringify(error))
  }
}

function logOut() {
  setCurrentUser(null)
}

function startLogIn() {
  isLogInMode.value = true
}

function startRegister() {
  isRegisterMode.value = true
}

function cancelLogIn() {
  isLogInMode.value = false
}

function cancelRegister() {
  isRegisterMode.value = false
}
</script>

<template>
  <div class="top-header-grid">
    <h1 class="top-header-title">Лаборатория Марины</h1>

    <div class="auth-container">
      <div v-if="isGuestMode" class="guest-grid">
        <span class="guest-title">Гость</span>
        <button @click="startLogIn">Вход</button>
        <button @click="startRegister">Регистрация</button>
      </div>

      <div v-if="isAuthorized" class="authorized-grid">
        <span class="guest-title">{{ currentUser?.login }}</span>
        <span class="guest-title">({{ currentUser?.role?.name }})</span>
        <button @click="logOut">Выход</button>
      </div>

      <div v-if="isLogInMode" class="login-grid">
        <span>Логин:</span>
        <input class="login-input" />
        <button @click="logIn">Войти</button>
        <span>Пароль:</span>
        <input class="login-input" />
        <button @click="cancelLogIn">Отмена</button>
      </div>

      <div v-if="isRegisterMode" class="rgister-grid">
        <span>Логин:</span>
        <input class="login-input" />
        <button @click="register">Создать</button>
        <span>Пароль:</span>
        <input class="login-input" />
        <button @click="cancelRegister">Отмена</button>
      </div>
    </div>
  </div>
</template>

<style scoped>
.top-header-grid {
  display: grid;
  grid-template-columns: auto 1fr auto;
}

.top-header-title {
  margin: 0;
  height: 100%;
  display: flex;
  align-items: center;
}

.auth-container {
  grid-column-start: 3;

  height: 100%;
  display: flex;
  align-items: center;
}

.login-grid {
  display: grid;
  grid-template-columns: auto auto auto;
  column-gap: 5px;
  row-gap: 5px;
}

.rgister-grid {
  display: grid;
  grid-template-columns: auto auto auto;
  column-gap: 5px;
  row-gap: 5px;
}

.guest-grid {
  display: grid;
  grid-template-columns: auto auto auto;
  column-gap: 5px;
}

.authorized-grid {
  display: grid;
  grid-template-columns: auto auto auto;
  column-gap: 5px;
}

.login-input {
  width: 100px;
}
</style>
