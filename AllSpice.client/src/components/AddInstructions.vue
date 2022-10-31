<template>
  <div class="container">

    <form @submit.prevent="editInstruction()" >
       <div class="p-1 px-0  d-flex ">
  
      <textarea type="text" name="instructions" class="rounded  px-5" v-model="editable.instructions"></textarea>
      <button class="btn editBtn" type="submit">Edit</button>
    </div>
    </form>
  </div>
 
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
  const yes = await Pop.confirm(` <div class="container">
<p>  ${this.recipe.instructions}</p>


  </div>`,'','Edit','warning')
        if (!yes) {
          return
        }
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


.editBtn:hover {
  transform: scale(1.03);
  transition: all 0.25s ease;

}
</style>
