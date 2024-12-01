<script setup lang="ts">
import CalculatedTabContent from '@/components/CalculatedTabContent.vue'
import ChemElementInfoBlock from '@/components/ChemElementInfoBlock.vue'
</script>

<template>
  <div class="tab-content-root">
    <h1>Справочник</h1>
    <CalculatedTabContent class="chem-info-table">
      <ChemElementInfoBlock element="H" image="/src/assets/elements/vodorod.jpg">
        <span>Водород</span>
        Самый распространенный элемент на Земле.<br />Атомы в молекуле связаны одинарной связью.<br />Имеет
        низкие температуры кипения и плавления.<br />Незначительно расстворяется в воде при
        комнатной температуре.<br />Самый легкий газ.<br />Может восстанавливать некоторые металлы
        из их оксидов.<br />Является экологически чистым топливом.<br />Образуется в результате
        реакции раскаленного железа с парами воды.<br />В химических реакциях пероксид водорода
        может выступать как в роли окислителя(с металлами), так и восстановителя(с неметаллами).<br />При
        взаимодействии азота с водородом образуется аммиак.<br />Реагирует с кислородом с
        образованием воды.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="B" image="/src/assets/elements/bor.jpg">
        <span>Бор</span>
        <div>Имеет атомную кристаллическую решетку.</div>
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="C" image="/src/assets/elements/carbon.jpg">
        <span>Углерод</span>
        Имеет аллотропные модификации, к которым относятся алмаз и графит, при этом атомы углерода в
        графите и алмазе имеют одинаковую степень окисления.<br />В алмазе атом углерода имеет
        степень окисления 0, 4 ковалентные связи с другими атомами углерода, а валентность 4.<br />
        Твердость алмаза значительно выше, чем графита.<br />В соединениях проявляет как
        окислительные(карбины), так и восстановительные свойства(органические вещества, оксид
        углерода(II), оксид углерода(IV)).
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="N" image="/src/assets/elements/nitrogen.jpg">
        <span>Азот</span>
        В молекуле имеется кратная(тройная) связь.<br />Связь в молекуле азота прочнее, чем в
        молекулах H2 и O2, т.к. она тройная.<br />В природе встречается в составе как простого, так
        и сложных веществ.<br />Используется для создания инертной среды.<br />Молекула азота не
        имеет аллотропных модификаций, составляет основную часть воздуха(78%) и состоит из
        неполярных единиц.<br />
        Образуется при горении аммиака в кислороде.<br />Является газом(н.у.) без цвета и запаха.<br />
        При сгорании аминов в кислороде в качестве одного из продуктов окисления образуется азот.<br />
        С кислородом взаимодействует при очень высоких температурах, при этом образуется NO.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="O" image="/src/assets/elements/oxygen.jpg">
        <span>Кислород</span>
        Плохо расстворим в воде.<br />Образуется в процессе фотосинтеза.<br />Объемная доля в
        воздухе составляет 21%.<br />Образует две аллотропные модификации - кислород(O2) и
        озон(O3).<br />Кислород - бесцветный газ, а озон имеет голубой цвет.<br />Температура
        кипения озона выше, чем кислорода.<br />
        Плотность кислорода ниже, чем озона(при н.у.).<br />В отличие от кислорода озон реагирует с
        серебром при комнатной температуре.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="Si" image="/src/assets/elements/silicon.jpg">
        <span>Кремний</span>
        Является полупроводником.<br />Встречается в природе как в виде простого вещества, так и в
        соединениях.<br />Простое вещество имеет атомную кристаллическую решетку(немолекулярное
        строение).<br />При комнатной температуре не расстворяется в воде.<br />Реагирует как с
        металлами, так и с неметаллами.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="S" image="/src/assets/elements/serum.jpg">
        <span>Сера</span>
        Моноклинная и ромбическая сера состоят из молекул S8.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="Cl" image="/src/assets/elements/chlor.jpg">
        <span>Хлор</span>
        При н.у. является желто-зеленым газом с резким запахом.<br />Вытесняет йод и бром из
        солей.<br />Не встречается в природе в виде простого вещества.<br />Существует только в виде
        двух атомных молекул.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="Br" image="/src/assets/elements/brom.jpg">
        <span>Бром</span>
        При н.у. - красно-бурая жидкость с резким запахом.<br />Встречается в морской воде.<br />Не
        встречается в природе в виде простого вещества.<br />Существует в виде двух атомных молекул.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="I" image="/src/assets/elements/iodine.png">
        <span>Йод</span>
        При н.у. - кристаллы черно-фиолетового цвета.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="Hg" image="/src/assets/elements/hidrargium.jpg">
        <span>Ртуть</span>
        Один из самых легкоплавких металлов.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="азотная кислота" longText>
        <span>HNO3</span>
        В концентрированном виде пассивирует аллюминий, хром, железо, свинец, бериллий и никель.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="анилин" longText>
        <span>C6H5NH2</span>
        Относится к ароматическим соединениям, но не к углеводородам.<br />Не реагирует с водными
        расстворами щелочей(т.к. сам обладает основными свойствами).<br />Ограниченно расстворим в
        воде.<br />
        В реакции с расствором брома в воде образуется белый осадок(2,4,6 - триброманилин).<br />Вступает
        в реакцию замещения с бромной водой.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="глицин" longText>
        <span>CH2NH2COOH</span>
        Хорошо расстворяется в воде.<br />Реагирует как с кислотами, так и с щелочами.<br />Взаимодействует
        с другими аминокислотами.<br />Можно получить ферментативным гидролизом пептидов.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="изопрен" longText>
        <span>C5H8</span>
        Относится к ненасыщенным углеводородам.<br />Является мономером каучука.<br />Имеет название
        2-метилбутадиен-1,3.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="крахмал" longText>
        <span>(C6H10O5)n</span>
        Не имеет альдегидной группы, поэтому не окисляется гидроксидом меди и оксидом серебра.<br />В
        результате кислотного гидролиза превращается в глюкозу.<br />Образует синий комплекс с
        йодом.<br />
        Относится к природным полимерам.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="оксид кремния(IV)" longText>
        <span>SiO2</span>
        Имеет атомную кристаллическую решетку.<br />Несолеобразующий оксид.<br />Является кислотным
        оксидом.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="сахароза" longText>
        <span>C12H22O11</span>
        Дисахарид, состоящий из остатков фруктозы и глюкозы.<br />Вступает в реакцию кислотного
        гидролиза, распадаясь на глюкозу и сахарозу.<br />Относится к невосстанавливающим углеводам.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="сернистый газ" longText>
        <span>H2S</span>
        Имеет характерный запах тухлых яиц.<br />Молекула имеет угловое строение.<br />Его водный
        расствор является слабым электролитом.<br />Может образовывать два типа солей: среднюю и
        кислую.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="соляная кислота" longText>
        <span>HCl</span>
        Представляет собой смесь веществ.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="угарный газ" longText>
        <span>CO</span>
        Образуется при неполном сгорании углерода.<br />Используется в качестве восстановителя
        металлов.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="уксусная кислота" longText>
        <span>CH3COOH</span>
        Изменяет окраску водного расствора лакмуса на красную.<br />Является слабой органической
        кислотой.<br />Смешивается с водой в любых соотношениях.<br />Используется при производстве
        искуственного шелка.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="фенол" longText>
        <span>C6H5OH</span>
        Имеет твердое агрегатное состояние(при н.у.).<br />Относится к ароматическим соединениям, но
        не к углеводородам.<br />Не реагирует с водными расстворами щелочей(т.к. сам обладает
        основными свойствами).<br />В реакции с расствором брома в воде образуется белый
        осадок(2,4,6 - трибромфенол).<br />Вступает в реакцию замещения с бромной водой.<br />Реагирует
        с водными расстворами щелочей.<br />Используется в производстве пластмасс.
      </ChemElementInfoBlock>
      <ChemElementInfoBlock element="фосфорная кислота" longText>
        <span>H3PO4</span>
        В водном расстворе диссоциирует с образованием трех видов анионов.
      </ChemElementInfoBlock>
      <div>
        <div class="center-text bold-text">Общая информация</div>
        <ul>
          <li>Солеобразующие оксиды: SO2, SO3, CO2, SiO2, P2O5, N2O5, NO2, Cl2O7, Cl2O3.</li>
          <li>Несолеобразующие оксиды: CO, NO, N2O, SiO.</li>
          <li>
            Методом вытеснения воды можно собрать газы, которые в ней не расстворяются(H2, O2, CH4,
            N2, PH3, CO, NO, N2O).
          </li>
          <li>
            Если газ легче воздуха, то сосуд для его собирания закрепляют дном вверх, а если газ
            тяжелее воздуха - дном вниз.
          </li>
          <li>
            Водородная связь образуется между молекулами спиртов и воды, фтороводорода и воды,
            аммиака и воды.
          </li>
          <li>
            В окислительно-восстановительных реакциях не расписываются осадки, оксиды, вода,
            слабодиссоциирующие соединения(H2S, HNO2, H3PO4), а гидроксид кальция расписывается
            только до стрелки, т.к. является малорастворимым веществом. Сернистая кислота(H2SO3)
            расадается на SO2 и H2O, угольная кислота(H2CO3) - н CO2 и H2O, а гидроксид аммония - на
            NH3 и H2O.
          </li>
          <li>
            Температура кипения зависит от агрегатного состояния вещества в следующей
            последовательности: газ - жидкость - твердое вещество, температура кипения возрастает
            соответственно.
          </li>
        </ul>
      </div>
    </CalculatedTabContent>
  </div>
</template>

<style scoped>
.chem-info-table span {
  font-weight: bold;
  font-size: var(--navigation-font-size);
}

.chem-info-table ul {
  margin: 0;
  padding-left: 30px;
  list-style: none;
}

.chem-info-table li {
  list-style-image: url(../../assets/icons/benzene-24.png);
}

.chem-info-table li,
.chem-info-table div {
  margin-bottom: var(--outter-padding);
}

.chem-info-table li:last-child,
.chem-info-table div:last-child {
  margin-bottom: 0;
}
</style>
