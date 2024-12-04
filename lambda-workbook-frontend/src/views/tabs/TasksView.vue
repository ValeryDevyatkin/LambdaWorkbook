<script setup lang="ts">
import CalculatedTabContent from '@/components/CalculatedTabContent.vue'
import CustomTooltip from '@/components/CustomTooltip.vue'
import { ref } from 'vue'

const isClarificationVisible = ref(false)

function showClarification() {
  isClarificationVisible.value = true
}

function hideClarification() {
  isClarificationVisible.value = false
}
</script>

<template>
  <div class="tab-content-root">
    <h1>Решение задач</h1>
    <CalculatedTabContent>
      <div class="bold-text">B21</div>
      Образец соли, массовые доли элементов в которой равны: [w(K) = 24,68 %], [w(Mn) = 34.81 %],
      [w(O) = 40,51 %], выдерживали при температуре 300 °C до постоянной массы. В результате
      выделилась теплота количеством 39 кДж. Рассчитайте, на сколько изменилась исходная масса (г)
      взятого образца, если известно, что при разложении 1 моль этой соли выделяется 26 кДж теплоты.
      <br />
      (2023г.)
      <div class="tasks-clarify-grid">
        <div v-if="isClarificationVisible">
          Определить соль из условия задачи можно с помощью массовой доли одного из составляющих ее
          элементов. Для примера возьмем калий. Обозначив массу соли как x, получим уравнение: [w(K)
          = 39 / Mr(соли)]. Значит молярная масса соли - [39 / w(K) = 158], что соответствует
          молярной массе перманганата калия(KMnO4). Составим пропорцию: [39 кДж / x = 26 кДж / 1],
          тогда [n(KMnO4) = 1,5 моль]. Составим уравнение реакции KMnO4: [2KMnO4 = K2MnO4 + MnO2 +
          O2], т.е. масса соли уменьшилась в результате выделения кислорода: [m(O2) = Mr(O2) *
          n(O2)]. По коэффициентам в уравнении химической реакции видно, что n(O2) в 2 раза меньше,
          чем n(KMnO4). Тогда [m(O2) = 16 * 2 * 0,75 = 24 г].
          <br />
          <div class="answer-text">Ответ: 24 г.</div>
        </div>
        <div v-else></div>
        <CustomTooltip v-if="!isClarificationVisible" class="icon-button" text="Пояснение">
          <button @click="showClarification">
            <img src="/src/assets/icons/light-50.png" />
          </button>
        </CustomTooltip>
        <CustomTooltip v-else class="icon-button" text="Скрыть">
          <button @click="hideClarification">
            <img src="/src/assets/icons/light-off-50.png" />
          </button>
        </CustomTooltip>
      </div>
    </CalculatedTabContent>
  </div>
</template>

<style scoped>
.tasks-clarify-grid {
  margin-top: var(--outter-padding);
  grid-template-columns: 1fr auto;
  column-gap: var(--outter-padding);
  display: grid;
}

.answer-text {
  margin-top: var(--outter-padding);
  font-weight: bold;
  font-size: var(--navigation-font-size);
}
</style>
