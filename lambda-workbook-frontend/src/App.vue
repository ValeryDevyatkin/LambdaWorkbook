<script setup lang="ts">
import { RouterView } from 'vue-router'
import TopHeader from './views/TopHeader.vue'
import Sidebar from './views/SidebarLeft.vue'
</script>

<template>
  <div class="app-grid-container">
    <TopHeader class="view-root header-grid-cell" />

    <Sidebar class="view-root" />

    <div class="view-root">
      <RouterView />
    </div>
  </div>
</template>

<style scoped>
.app-grid-container {
  display: grid;
  grid-template-columns: 1fr 6fr;
  grid-template-rows: auto 1fr;
  column-gap: 10px;
  row-gap: 10px;
  margin: 10px;
  height: 100%;
}

.header-grid-cell {
  grid-column-start: 1;
  grid-column-end: 3;
}
</style>
