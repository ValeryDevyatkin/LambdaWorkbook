<script setup lang="ts">
import AuthView from './AuthView.vue'
</script>

<template>
  <div class="top-header-grid">
    <h1 class="top-header-title">Протоника</h1>

    <div class="auth-container">
      <AuthView />
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
</style>
