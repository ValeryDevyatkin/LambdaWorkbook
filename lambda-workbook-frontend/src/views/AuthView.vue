<script setup lang="ts">
import CustomButton from '@/components/CustomButton.vue'
import CustomLabel from '@/components/CustomLabel.vue'
import CustomTooltip from '@/components/CustomTooltip.vue'
import { useAuthStore } from '@/store/auth-store'
import { usePopupMessageStore } from '@/store/popup-message-store'
import { computed, ref } from 'vue'

const authStore = useAuthStore()
const popupStore = usePopupMessageStore()

const login = ref('')
const password = ref('')

const isRegisterMode = ref(false)
const isLogInMode = ref(false)

const isGuestMode = computed(
  () => !authStore.isAuthorized && !isRegisterMode.value && !isLogInMode.value,
)

async function logIn() {
  try {
    await authStore.logIn(login.value, password.value)
    cancelLogIn()
    popupStore.showMessage('Успешный вход.')

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
  } catch (error: any) {
    popupStore.showEror(error?.response)
  }
}

async function register() {
  try {
    const user = await authStore.registerPublic(login.value, password.value)
    cancelRegister()
    login.value = user.login ?? ''
    startLogIn()
    popupStore.showMessage('Пользователь создан.')

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
  } catch (error: any) {
    popupStore.showEror(error?.response)
  }
}

function clearUserData() {
  login.value = ''
  password.value = ''
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
    <CustomTooltip class="icon-button" text="Чат">
      <RouterLink to="/chat">
        <img src="..\assets\icons\chat-50.png" />
      </RouterLink>
    </CustomTooltip>
    <CustomTooltip class="icon-button" text="Заметки">
      <RouterLink to="/notes">
        <img src="..\assets\icons\notes-32.png" />
      </RouterLink>
    </CustomTooltip>
    <CustomLabel v-bind:text="authStore.currentUser?.login ?? ''" />
    <CustomTooltip class="icon-button" text="Выход">
      <button class="icon-button" @click="authStore.logOut">
        <img src="..\assets\icons\logout-50.png" />
      </button>
    </CustomTooltip>
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
  column-gap: var(--grid-inner-gap);
  row-gap: var(--grid-inner-gap);
}

.rgister-grid {
  display: grid;
  grid-template-columns: auto auto auto;
  column-gap: var(--grid-inner-gap);
  row-gap: var(--grid-inner-gap);
}

.guest-grid {
  display: grid;
  grid-template-columns: auto auto auto;
  column-gap: var(--grid-inner-gap);
}

.authorized-grid {
  display: grid;
  grid-template-columns: auto auto auto auto;
  column-gap: var(--grid-inner-gap);
}

.login-input {
  width: 100px;
}
</style>
