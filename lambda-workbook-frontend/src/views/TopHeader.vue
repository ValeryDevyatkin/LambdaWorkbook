<script setup lang="ts">
import { Client, LogInRequest } from '@/client'

async function logIn() {
  const client = new Client('https://localhost:7096')

  try {
    // TODO: generic message
    const result = await client.login(new LogInRequest({ login: 'admin', password: 'minerale' }))
    alert(JSON.stringify(result))
  } catch (error) {
    // TODO: generic alert
    alert(JSON.stringify(error))
  }
}
</script>

<template>
  <div class="top-header-grid-container">
    <h1 class="top-header-title">Лаборатория Марины</h1>
    <div class="login-grid-cell">
      <div class="login-input-container">
        <span>Логин:</span>
        <input class="login-input" />
        <span>Пароль:</span>
        <input class="login-input" />
      </div>
    </div>
    <button @click="logIn">Вход</button>
  </div>
</template>

<style scoped>
.top-header-grid-container {
  display: grid;
  place-items: center;
  grid-template-columns: auto 1fr auto auto;
  column-gap: 10px;
}

.login-grid-cell {
  grid-column-start: 3;
  grid-column-end: 4;
}

.login-input-container {
  display: grid;
  grid-template-columns: auto auto;
  grid-template-rows: auto auto;
  column-gap: 5px;
  row-gap: 5px;
}

.login-input {
  width: 100px;
}

.top-header-title {
  margin: 0;
  display: flex;
  align-items: center;
}
</style>
