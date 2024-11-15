<script setup lang="ts">
import { RouterView } from 'vue-router'
import TopHeader from './views/TopHeader.vue'
import Sidebar from './views/SidebarLeft.vue'
import UserMessage from './views/UserMessage.vue'
</script>

<template>
  <div class="app-grid">
    <div class="top-header-root">
      <TopHeader class="view-root" />
      <UserMessage />
    </div>

    <Sidebar class="view-root" />

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
  column-gap: 10px;
  row-gap: 10px;
  margin: 10px;
  height: 100%;
}

.top-header-root {
  grid-column-start: 1;
  grid-column-end: 3;
}
</style>
