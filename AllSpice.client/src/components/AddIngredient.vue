<template>
     <form @submit.prevent="addIngredient()" class="">
                  <div class="mt-3 inputBox">
                    <span>Ingredient Name</span>
                    <input
                      type="text"
                      required
                      name="name"
                      v-model="editable.name"
                    />
                  </div>
                  <div class="mt-3 inputBox">
                    <span>Quantity</span>
                    <input
                      type="text"
                      required
                      name="quantity"
                      v-model="editable.quantity"
                    />
                  </div>
                 

                  <div class="my-3">
                    <button
                      class="btn btn-outline-success selectable"
                      type="submit"
                  
                    >
                     Add Ingredient
                    </button>
                 
                  </div>
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
editable.value.recipeId = AppState.activeRecipe.id
           await ingredientsService.addIngredient(editable.value)
           editable.value = {}
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
.modal-body {
 


  border: 10px solid orange;


  border-image: url("https://blog.williams-sonoma.com/wp-content/uploads/2020/04/zoom-template-food-alt3.jpg") /* source */ 100 / /* slice 
    8px / /* width */ 18px 14px 18px 14px /* outset */ repeat; /* repeat */
  //background-image: url();
  // background-size: cover;
  //background-position: center;
  box-shadow: 1px 1px 10px rgba(243, 236, 236, 0.308);
}

.inputBox {
  position: relative;
  width: 250px;
}

.inputBox input {
  width: 100%;
  padding: 10px;
  border: 1px solid #ffbb00;
  border-bottom: 3px solid #ff5e00;
  border-radius: 5px;
  outline: none;
  color: rgb(0, 0, 0);
  font-size: 1em;
  background-color: transparent;
  transition: all 1.5s ease;
  box-shadow: 0.25px 0.25px 10px rgba(243, 236, 236, 0.308);
}

.inputBox span {
  position: absolute;
  left: 0;
  bottom: 35px;
  padding: 10px;
  pointer-events: none;
  font-size: 1em;
  text-transform: uppercase;
  color: #13121380;
  transition: all 1s ease;
}

.inputBox input:valid ~ span,
.inputBox input:required ~ span,
.inputBox input:focus ~ span {
  color: #27132a;
  transform: translateX(10px) translateY(-7px);
  padding: 0 10px;
  font-size: 0.65em;
  border-radius: 4px;
  font-weight: bold;
  background: #ffbb00;
  border-left: 1px solid #ff5e00;
  border-right: 1px solid #ff5e00;
  letter-spacing: 0.2em;
  transition: all 1s ease;
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
