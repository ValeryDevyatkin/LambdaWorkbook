<script setup lang="ts">
import { LogInRequest, RegisterPublicUserRequest } from '@/api/client'
import { apiClient } from '@/api/client-provider'
import CustomButton from '@/components/CustomButton.vue'
import CustomLabel from '@/components/CustomLabel.vue'
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

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
  } catch (error: any) {
    messageStore.showEror(error?.response)
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

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
  } catch (error: any) {
    messageStore.showEror(error?.response)
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
  <div v-if="isGuestMode" class="guest-grid">
    <CustomLabel text="Гость" />
    <CustomButton @click="startLogIn" text="Вход" />
    <CustomButton @click="startRegister" text="Регистрация" />
  </div>

  <div v-if="authStore.isAuthorized" class="authorized-grid">
    <CustomLabel v-bind:text="authStore.currentUser?.login ?? '[NAME]'" />
    <CustomLabel v-bind:text="authStore.currentUser?.role?.name ?? '[ROLE]'" />
    <CustomButton @click="logOut" text="Выход" />
  </div>

  <div v-if="isLogInMode" class="login-grid">
    <CustomLabel text="Логин" />
    <input class="login-input" v-model="login" />
    <CustomButton @click="logIn" text="Войти" />
    <CustomLabel text="Пароль" />
    <input class="login-input" type="password" v-model="password" />
    <CustomButton @click="cancelLogIn" text="Отмена" />
  </div>

  <div v-if="isRegisterMode" class="rgister-grid">
    <CustomLabel text="Логин" />
    <input class="login-input" v-model="login" />
    <CustomButton @click="register" text="Создать" />
    <CustomLabel text="Пароль" />
    <input class="login-input" type="password" v-model="password" />
    <CustomButton @click="cancelRegister" text="Отмена" />
  </div>
</template>

<style scoped>
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
