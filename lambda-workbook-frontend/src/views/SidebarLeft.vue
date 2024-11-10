<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <div>
    <span>This is navigation</span>
    <nav>
      <RouterLink to="/page1">Page 1</RouterLink>
      <RouterLink to="/page2">Page 2</RouterLink>
      <RouterLink to="/page3">Page 3</RouterLink>
      <RouterLink to="/page4">Page 4</RouterLink>
    </nav>
  </div>
</template>

<style scoped></style>
