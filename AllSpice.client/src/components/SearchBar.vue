<template>
  <div class="card bg-dark">

    <form @keyup="searchRecipes()" class="">
      <div class="d-flex" >
        <input
          v-model="editable"
          type="text"
          class="form-control phtext"
          placeholder="Search for recipes . . ."
          aria-label="Search"
          aria-describedby="button-addon2"
        />
        <button
          class="btn btn-danger py-1 px-2 "
          type="submit"
          id="button-addon2"
        >
          <i class="mdi mdi-magnify mx-2" alt="" title="search By Name"></i>
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted, ref, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";


export default {
  setup() {
    const editable = ref("");
    watchEffect(()=>{
      // editable.value = [...AppState.recipes]
    })
    // events: computed(() => AppState.events.filter(a => a.name.toUpperCase().includes(editable.value.toUpperCase()))),
    return {
      editable,
      // recipes : computed(()=> AppState.recipes.filter(f => f.title.toUpperCase().includes(editable.value.toUpperCase()))),
      async searchRecipes() {
        try {
        // AppState.recipes =  AppState.recipes.filter(f => f.title.toUpperCase().includes(editable.value.toUpperCase()))
          await recipesService.searchByQuery(editable.value);
          // if (editable.value = "") {
          //   await recipesService.getAllRecipes()
          // }
          // editable.value = "";
        } catch (error) {
          console.error("dfd", error);
        }
      },
    };
  },
};
</script>

<style lang="scss" scoped>
.phtext {
  font-size: 12px;
}
</style>
