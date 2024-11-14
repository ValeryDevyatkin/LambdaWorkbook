<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <div>
    <h1>Навигация</h1>
    <nav class="nav-container">
      <RouterLink to="/page1">Первая страница</RouterLink>
      <RouterLink to="/page2">Вторая страница</RouterLink>
      <RouterLink to="/page3">Третья страница</RouterLink>
      <RouterLink to="/page4">Не поверите, но ...</RouterLink>
    </nav>
  </div>
</template>

<style scoped>
.nav-container a {
  display: block;
  font-size: large;
  font-weight: bold;
  background-color: #3a9555;
  border-radius: 10px;
  padding: 15px 0;
  margin-top: 10px;
  margin-bottom: 10px;
  color: black;
  text-decoration: none;
  text-align: center;

  outline: 1px solid #114d17;
  border: 1px solid transparent;
  transition: all 0.4s ease-in-out;
}

.nav-container a:hover {
  outline: 0px solid transparent;
  border: 1px solid #114d17;
  box-shadow: 0 0 10px green;
  transition: all 0.4s ease-in-out;
}

.nav-container :first-child {
  margin-top: 0px;
}
</style>
