<template>
  <form @submit.prevent="editInstruction()">
     <div class="input-group">

    <textarea type="text" name="instructions" class="rounded" v-model="editable.instructions"></textarea>
    <button class="btn btn-success rounded" type="submit">Edit</button>
  </div>
  </form>
 
</template>

<script>
import { computed ,ref} from "@vue/reactivity";
import { watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {

  },

  setup(props) {

    
    watchEffect(()=>{
    //  editable.value
    //  console.log(editable.value);
      // AppState.activeRecipe.instructions = editable.value
    })
    const editable =  ref({})
    return {
      editable,
      recipe : computed(()=> AppState.activeRecipe),
async editInstruction(){
  try {
   let recipe = AppState.activeRecipe
//    let test = editable.value
// console.log(editable.value);
      // await recipesService.editRecipe(recipe.id,editable.value)
      await recipesService.editRecipe(recipe.id,editable.value)
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
