<template>
  <div class="test">
    <Popper arrow content="This is the Popper content 🍿">
      <button>Trigger element</button>
    </Popper>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import Popper from "vue3-popper";

export default defineComponent({
  components: {
    Popper,
  },
});
</script>

<style scoped>
.test {
  z-index: 9999;
}
</style>
