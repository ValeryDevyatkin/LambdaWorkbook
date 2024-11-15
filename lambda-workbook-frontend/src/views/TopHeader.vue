<script setup lang="ts">
import { LogInRequest, RegisterPublicUserRequest } from '@/api/client'
import { apiClient } from '@/api/client-provider'
import { useAuthStore } from '@/store/auth-store'
import { useUserMessageStore } from '@/store/user-message-store'
import { computed, ref } from 'vue'

const authStore = useAuthStore()
const messageStore = useUserMessageStore()

const login = ref('')
const password = ref('')

const isRegisterMode = ref(false)
const isLogInMode = ref(false)

const isGuestMode = computed(
  () => !authStore.isAuthorized && !isRegisterMode.value && !isLogInMode.value,
)

async function logIn() {
  try {
    const user = await apiClient.login(
      new LogInRequest({ login: login.value, password: password.value }),
    )

    cancelLogIn()
    authStore.setCurrentUser(user)
    messageStore.showMessage('Успешный вход.')
  } catch (error) {
    messageStore.showEror(error?.response) // TODO
  }
}

async function register() {
  try {
    const user = await apiClient.registerpublic(
      new RegisterPublicUserRequest({ login: login.value, password: password.value }),
    )

    cancelRegister()
    login.value = user.login ?? ''
    startLogIn()
    messageStore.showMessage('Пользователь создан.')
  } catch (error) {
    messageStore.showEror(error?.response) //TODO
  }
}

function clearUserData() {
  login.value = ''
  password.value = ''
}

function logOut() {
  authStore.setCurrentUser(null)
  clearUserData()
}

function cancelLogIn() {
  isLogInMode.value = false
  clearUserData()
}

function cancelRegister() {
  isRegisterMode.value = false
  clearUserData()
}

function startLogIn() {
  isLogInMode.value = true
}

function startRegister() {
  isRegisterMode.value = true
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

      <div v-if="authStore.isAuthorized" class="authorized-grid">
        <span class="guest-title">{{ authStore.currentUser?.login }}</span>
        <span class="guest-title">({{ authStore.currentUser?.role?.name }})</span>
        <button @click="logOut">Выход</button>
      </div>

      <div v-if="isLogInMode" class="login-grid">
        <span>Логин:</span>
        <input class="login-input" v-model="login" />
        <button @click="logIn">Войти</button>
        <span>Пароль:</span>
        <input class="login-input" type="password" v-model="password" />
        <button @click="cancelLogIn">Отмена</button>
      </div>

      <div v-if="isRegisterMode" class="rgister-grid">
        <span>Логин:</span>
        <input class="login-input" v-model="login" />
        <button @click="register">Создать</button>
        <span>Пароль:</span>
        <input class="login-input" type="password" v-model="password" />
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
