import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js";

class RecipesService {
  async getAllRecipes() {
    const res = await api.get("api/recipes");
    console.log(res.data);
    AppState.recipes = res.data.map((r) => new Recipe(r));
  }

  async getIngredientsByRecipeId(recipeId) {
    const res = await api.get(`api/recipe/${recipeId}/ingredients`);
    console.log(res.data);
    AppState.ingredients = res.data.map((i) => new Ingredient(i));
  }

  async getRecipeById(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}`);
    AppState.activeRecipe = new Recipe(res.data);
  }
  setActiveRecipe(recipeData) {
    AppState.activeRecipe = recipeData;
  }

  async removeRecipe(recipeId) {
  //  const myModalEl = document.getElementById("recipeModal");
   
   const res = await api.delete(`api/recipes/${recipeId}`);
  //  myModalEl.classList.toggle("show")
    console.log(res.data);

    AppState.recipes = AppState.recipes.filter((r) => {
      r.id != recipeId;
    });
  }

  async editRecipe(recipeId, recipeData) {
    const res = await api.put(`api/recipes/${recipeId}`, recipeData);
    AppState.activeRecipe = new Recipe(res.data);
  }
}
export const recipesService = new RecipesService();
