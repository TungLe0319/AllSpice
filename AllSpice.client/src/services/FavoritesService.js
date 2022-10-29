import { AppState } from "../AppState.js";
import { FavRecipe } from "../models/FavRecipe.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js";
import { recipesService } from "./RecipesService.js";

class FavoritesService {
  async favoriteRecipe(recipeId,recipeIdString) {
    console.log(recipeId);
    const res = await api.post("api/favorites", recipeId);
    // let recipe = AppState.recipes.find(r => r.id == recipeIdString)
    // console.log(recipe);
    // recipe.favorited = true
    let favRecipe = new FavRecipe(res.data);
    favRecipe.favorited = true
    console.log(res.data);
    AppState.favorites = [favRecipe, ...AppState.favorites];
    console.log(AppState.favorites);
  }
  async removeFavoriteRecipe(favoriteId, recipeId) {
    await api.delete(`api/favorites/${favoriteId}`);
    AppState.favorites = AppState.favorites.filter((f) => f.id != favoriteId);
    AppState.recipes = AppState.recipes.filter(
      (r) => r.favoriteId != favoriteId
    );
  }

  async getAllFavorites(){
const res = await api.get;
  }
}
export const favoritesService = new FavoritesService();
