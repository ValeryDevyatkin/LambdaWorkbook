<script setup lang="ts">
import ChemElementInfoBlock from '@/components/ChemElementInfoBlock.vue'
</script>

<template>
  <div class="tab-content-root">
    <h1>Химические реакции</h1>
    <div class="tab-content chem-info-table">
      <ChemElementInfoBlock element="H">
        lorem ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf lorem
        ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="He">
        lorem ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf lorem
        ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="Li">
        lorem ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf lorem
        ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="Be">
        lorem ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf lorem
        ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="B">
        lorem ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf lorem
        ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="C">
        lorem ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf lorem
        ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="N">
        lorem ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf lorem
        ipsum pipsum furefturef hipoertyn bifrtykip acertum popiki limertyb lopikuf
      </ChemElementInfoBlock>
    </div>
  </div>
</template>

<style scoped>
.chem-info-table div {
  margin-bottom: var(--grid-inner-gap);
}

.chem-info-table div:last-child {
  margin-bottom: 0;
}
</style>
