<script setup lang="ts">
import { RouterView } from 'vue-router'
import TopHeader from './views/TopHeader.vue'
import Sidebar from './views/SidebarLeft.vue'
</script>

<template>
  <TopHeader class="view-root" />

  <Sidebar class="view-root" />

  <div class="view-root navigation-root">
    <RouterView />
  </div>
</template>
