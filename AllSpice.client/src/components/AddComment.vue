<template>
  <form @submit.prevent="addComment()" class="m-5">
    <div class="input-group">
      <input
        type="text"
        name="body"
        required
        class="rounded"
        placeholder="comment..."
        v-model="editable.body"
      />
    </div>
    <button class="btn btn-success" type="submit">submit</button>
  </form>
</template>

<script>
import { computed, ref } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { commentsService } from "../services/CommentsService.js";

import Pop from "../utils/Pop.js";

export default {
  props: {},

  setup(props) {
    let editable = ref({});
    return {
      editable,
      recipe: computed(() => AppState.activeRecipe),
      async addComment() {
        try {
          editable.value.recipeId = AppState.activeRecipe.id;
          await commentsService.addComment(editable.value);
          editable.value = {};
        } catch (error) {
          Pop.error(error);
        }
      },
    };
  },
};
</script>

<style lang="scss" scoped>
.text-shadow {
  color: aliceblue;
  text-shadow: 1px 1px black, 0px 0px 5px salmon;
  font-weight: bold;
  letter-spacing: 0.08rem;
  /* Second Color  in text-shadow is the blur */
}
.forcedImg {
  height: 300px;
  width: 300px;
  object-fit: cover;
}
</style>
