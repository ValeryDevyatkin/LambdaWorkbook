<script setup lang="ts"></script>

<template>
  <div class="tab-content tab-conent-outter">
    <div class="tab-content tab-content-inner">
      <slot></slot>
    </div>
  </div>
</template>

<style scoped>
.tab-content {
  position: relative;
  box-sizing: border-box;

  padding: var(--outter-padding);
  background-color: var(--tab-content-background-color);
  border-radius: var(--border-radius);
  border: var(--border-thickness) solid var(--black-color);
}

.tab-conent-outter {
  padding: 0;
}

.tab-content-inner {
  position: absolute;
  margin: 0;
  width: 100%;
  height: 100%;
  overflow: auto;
}
</style>
