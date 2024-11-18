<script setup lang="ts">
import { RouterView } from 'vue-router'
import HeaderView from './views/HeaderView.vue'
import SidebarView from './views/SidebarView.vue'
import UserMessage from './views/UserMessage.vue'
</script>

<template>
  <div class="app-grid">
    <div class="top-header-root">
      <HeaderView class="view-root" />
      <UserMessage />
    </div>

    <SidebarView class="view-root" />

    <div class="view-root router-container">
      <RouterView />
    </div>
  </div>
</template>

<style scoped>
.router-container div {
  width: 100%;
  height: 100%;
}

.app-grid {
  display: grid;
  grid-template-columns: 1fr 6fr;
  grid-template-rows: auto 1fr;
  column-gap: var(--grid-outter-gap);
  row-gap: var(--grid-outter-gap);
  margin: 10px;
  height: 100%;
}

.top-header-root {
  grid-column-start: 1;
  grid-column-end: 3;
}
</style>
