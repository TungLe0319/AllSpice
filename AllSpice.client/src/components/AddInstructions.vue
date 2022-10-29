<template>
  <form @submit.prevent="addInstruction()">
     <div class="input-group">

    <textarea type="text" name="instructions" class="rounded" v-model="editable.instructions"></textarea>
    <button class="btn btn-success" type="submit">submit</button>
  </div>
  </form>
 
</template>

<script>
import { computed ,ref} from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {

  },

  setup(props) {

    const editable =  ref({})
    return {
      editable,
      recipe : computed(()=> AppState.activeRecipe),
async addInstruction(){
  try {
   let recipe = AppState.activeRecipe
   let test = editable.value
console.log(editable.value);
      // await recipesService.editRecipe(recipe.id,editable.value)
      await recipesService.addInstruction(editable.value)
    } catch (error) {
      Pop.error(error)
    }
}
    };
  },
};
</script>

<style lang="scss" scoped>

.text-shadow{
  color: aliceblue;
  text-shadow: 1px 1px black, 0px 0px 5px salmon;
  font-weight: bold;
  letter-spacing: 0.08rem
  /* Second Color  in text-shadow is the blur */
}
.forcedImg{
  height: 300px;
  width: 300px;
  object-fit: cover;
}


</style>
