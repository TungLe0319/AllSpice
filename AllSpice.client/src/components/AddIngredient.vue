<template>
  <!-- <form @submit.prevent="addIngredient()" class="">
    <div class="form-group">
      <label for="name">Ingredient Name</label>
      <input type="text" required name="name" v-model="editable.name" />
    </div>
    <div class="mt-3 inputBox">
      <span>Quantity</span>
      <input type="text" required name="quantity" v-model="editable.quantity" />
    </div>

    <div class="my-3">
      <button class="btn btn-outline-success selectable" type="submit">
        Add Ingredient
      </button>
    </div>
  </form> -->

<form  @submit.prevent="addIngredient()" class="mb-2 ">
 
  
  
  <div class="form-floating mb-3">
    <input type="text" class="form-control " id="floatingInput" placeholder="name" v-model="editable.name">
    <label for="floatingInput">Name</label>
  </div>
  <div class="form-floating">
    <input type="text" class="form-control" id="floatingPassword" placeholder="quantity" v-model="editable.quantity">
    <label for="floatingPassword">Quantity</label>
  </div>
  <button type="submit" class="btn btn-outline-dark mt-2">add Ingredient</button>
</form>


</template>

<script>
import { computed, ref } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { ingredientsService } from "../services/IngredientsService.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {},

  setup(props) {
    let editable = ref({});
    return {
      editable,
      recipe: computed(() => AppState.activeRecipe),
      async addIngredient() {
        try {
          editable.value.recipeId = AppState.activeRecipe.id;
          await ingredientsService.addIngredient(editable.value);
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

.forcedImg {
  height: 300px;
  width: 300px;
  object-fit: cover;
}
.modal-body {
  border: 10px solid orange;

  border-image: url("https://blog.williams-sonoma.com/wp-content/uploads/2020/04/zoom-template-food-alt3.jpg")
    /* source */ 100 / /* slice 
    8px / /* width */ 18px 14px 18px 14px
    /* outset */ repeat; /* repeat */

  box-shadow: 1px 1px 10px rgba(243, 236, 236, 0.308);
}

.text-shadow {
  color: aliceblue;
  text-shadow: 1px 1px black, 0px 0px 5px salmon;
  font-weight: bold;
  letter-spacing: 0.08rem;
  /* Second Color  in text-shadow is the blur */
}
.forcedImg {
  object-fit: cover;
}

.card {
  transition: all 0.5s ease;
}
.card:hover {
  filter: brightness(90%);
  transition: all 0.5s ease;
  box-shadow: rgba(240, 169, 46, 0.4) 5px 5px, rgba(240, 140, 46, 0.3) 10px 10px,
    rgba(240, 172, 46, 0.2) 15px 15px, rgba(240, 185, 46, 0.1) 20px 20px;
}
.cardText {
  display: flex;
  justify-content: end;
  background-color: rgba(0, 0, 0, 0.331);
  backdrop-filter: blur(3px);
  text-shadow: 2px 2px 0px rgba(0, 0, 0, 0.459);
  font-weight: 600;
  letter-spacing: 0.04rem;
}
.cardText:hover {
  filter: brightness(114%);
  border-bottom: 4px solid red;
  text-decoration: underline red;
  transition: all 0.5s ease;
}
.deleteIcon {
  z-index: 9999;
}
.category {
  background-color: rgba(0, 0, 0, 0.331);
}

.hoverOver {
  transition: all 0.75s ease;
}
.hoverOver:hover {
  transform: rotate(180deg) scale(1.1);
  transition: all 0.75s ease;
}
</style>
