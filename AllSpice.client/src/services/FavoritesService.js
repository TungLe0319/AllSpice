import { AppState } from "../AppState.js";
import { FavoriteIds } from "../models/FavoriteIds.js";

import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js";
import { recipesService } from "./RecipesService.js";

class FavoritesService {
  async favoriteRecipe(recipe) {
    let newFav = {};
    newFav.recipeId = recipe.id;
    const res = await api.post("api/favorites", newFav);
    AppState.favorites.push(new FavoriteIds(res.data));
    console.log(AppState.favorites);
  }
  
  async removeFavoriteRecipe(favoriteId) {
    console.log(favoriteId, "service");
    await api.delete(`api/favorites/${favoriteId}`);
    let index = AppState.favorites.findIndex((f) => f.favoriteId == favoriteId);
    AppState.favorites.splice(index, 1);
    if (AppState.infinite == 1) {
      AppState.recipes = AppState.recipes.filter(
        (r) => r.favoriteId != favoriteId
      );
    }
  }
}
export const favoritesService = new FavoritesService();
