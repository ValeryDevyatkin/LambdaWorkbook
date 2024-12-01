<script setup lang="ts">
import CalculatedTabContent from '@/components/CalculatedTabContent.vue'
import ChemElementInfoBlock from '@/components/ChemElementInfoBlock.vue'
</script>

<template>
  <div class="tab-content-root">
    <h1>Тривиальные названия</h1>
    <CalculatedTabContent>
      <div class="trivial-names-grid">
        <ChemElementInfoBlock element="барит" longText>
          <span>BaSO4</span>
          Осадок белого цвета.
        </ChemElementInfoBlock>
        <ChemElementInfoBlock element="белый фосфор" longText>
          <span>P4</span>
          Одна из основных аллотропных модификаций фосфора.
        </ChemElementInfoBlock>
        <ChemElementInfoBlock element="бертолетова соль" longText>
          <span>KClO3</span>
          Является сильным окислителем. Реакция разложения идет с выделением тепла.
        </ChemElementInfoBlock>
        <ChemElementInfoBlock element="бромная вода" longText>
          <span>Br2</span>
          Используется в качественных реакция на кратные(двойные, тройные) связи.
        </ChemElementInfoBlock>
        <ChemElementInfoBlock element="аммофос" longText>
          <span>NH4H2PO4 + (NH4)2HPO4</span>
          Минеральное удобрение.
        </ChemElementInfoBlock>
        <ChemElementInfoBlock element="гашеная известь" longText>
          <span>Ca(OH)2</span>
          Образуется в результате реакции негашеной извести с водой.
        </ChemElementInfoBlock>
        <ChemElementInfoBlock element="горькая (английская) соль" longText>
          <span>MgSo4 * 7H2O</span>
          Внешне очень похожа на поваренную(она тоже белая и состоит из елких кристаллов).
        </ChemElementInfoBlock>
        <ChemElementInfoBlock element="двойной суперфосфат" longText>
          <span>CaH2(PO4)2</span>
          Минеральное удобрение.
        </ChemElementInfoBlock>
        <ChemElementInfoBlock element="пирит" longText>
          <span>FeS2</span>
          Серный колчедан, железный колчедан.
        </ChemElementInfoBlock>
        <ChemElementInfoBlock element="жидкое стекло" longText>
          <span>Na2SiO3, K2SiO3</span>
          Используется для склеивания различных материалов.
        </ChemElementInfoBlock>
        <ChemElementInfoBlock element="известковая вода" longText>
          <span>Ca(OH)2</span>
          Насыщенный водный раствор гашеной извести.
        </ChemElementInfoBlock>
        <ChemElementInfoBlock element="мел, мрамор" longText>
          <span>CaCO3</span>
          В реакциях представляет собой осадок белого цвета.
        </ChemElementInfoBlock>
      </div>
    </CalculatedTabContent>
  </div>
</template>

<style scoped>
.trivial-names-grid {
  width: 100%;
  display: grid;
  grid-template-columns: 1fr 1fr;
  column-gap: var(--outter-padding);
  row-gap: var(--outter-padding);
}

.trivial-names-grid span {
  font-weight: bold;
  font-size: var(--navigation-font-size);
}
</style>
