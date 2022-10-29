<template>



  <div class="card text-bg-dark my-2">
 <img :src="recipe.img" :alt="recipe.title" :title="recipe.title + 'Img'"  class="forcedImg card-img" />
  <div class="card-img-overlay flex-column d-flex justify-content-end align-items-start" >
    <span class=" cardText p-2 rounded">

      <p class="card-title">{{recipe.title}}</p>
    </span>
    
  </div>
</div>
</template>

<script>
import { Recipe } from "../models/Recipe.js";

export default {
  props: {
    recipe: { type: Recipe, required: true },
  },

  setup(props) {
    return {};
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
  width: auto;
  object-fit: cover;
}
.cardText{
  display: flex;
  justify-content: end;
  background-color: rgba(0, 0, 0, 0.331);
backdrop-filter: blur(3px);
}
</style>
