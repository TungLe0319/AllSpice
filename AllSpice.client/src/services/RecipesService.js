import { AppState } from "../AppState.js";
import { Comment } from "../models/Comment.js";
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
    const res = await api.get(`api/recipes/${recipeId}/ingredients`);

    AppState.ingredients = res.data.map((i) => new Ingredient(i));
    console.log(AppState.ingredients);
  }

  async getCommentsByRecipeId(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/comments`);
    console.log(res.data);
    AppState.comments = res.data.map((c) => new Comment(c));
    console.log(AppState.comments);
  }

  async getRecipeById(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}`);
    AppState.activeRecipe = new Recipe(res.data);
  }
  setActiveRecipe(recipeData) {
    AppState.activeRecipe = recipeData;
  }

  async createRecipe(recipeData) {
    const res = await api.post("api/recipes", recipeData);
    console.log("[createRecipe]", res.data);
    const newRecipe = new Recipe(res.data);
    AppState.activeRecipe = newRecipe
    AppState.recipes = [newRecipe, ...AppState.recipes];

  }
  async removeRecipe(recipeId) {
    await api.delete(`api/recipes/${recipeId}`);
    let recipe = AppState.recipes.findIndex((r) => r.id == recipeId);
    AppState.recipes.splice(recipe, 1);
  }

  async editRecipe(recipeId, recipeData) {
    const res = await api.put(`api/recipes/${recipeId}`, recipeData);
    AppState.activeRecipe = new Recipe(res.data);
  }
  getMyRecipes() {
    console.log("Hi");
    AppState.recipes = AppState.recipes.filter(
      (r) => r.creator.id == AppState.account.id
    );
    console.log(AppState.account.id);
  }

  async getRecipesByAccountId() {
    const res = await api.get("api/recipes");
    console.log(res.data);
    AppState.recipes = res.data.map((r) => new Recipe(r));
    AppState.recipes = AppState.recipes.filter(
      (r) => r.creator.id == AppState.account.id
    );
  }

  async searchByQuery(query) {
    const res = await api.get("api/recipes");
    console.log(res.data);

    AppState.recipes = res.data.map((r) => new Recipe(r));

    AppState.recipes = AppState.recipes.filter((f) =>
      f.title.toUpperCase().includes(query.toUpperCase())
    );
  }
}
export const recipesService = new RecipesService();
