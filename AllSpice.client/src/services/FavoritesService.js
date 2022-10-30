import { AppState } from "../AppState.js";
import { FavRecipe } from "../models/FavRecipe.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js";
import { recipesService } from "./RecipesService.js";

class FavoritesService {
  async favoriteRecipe(recipeId) {
    console.log(recipeId);
    const res = await api.post("api/favorites", recipeId);

    let favRecipe = new FavRecipe(res.data);

    AppState.favorites = [favRecipe, ...AppState.favorites];

    console.log(AppState.favorites);
  }
  async removeFavoriteRecipe(favoriteId) {
    await api.delete(`api/favorites/${favoriteId}`);
    AppState.favorites = AppState.favorites.filter((f) => f.id != favoriteId);
    AppState.recipes = AppState.recipes.filter(
      (r) => r.favoriteId != favoriteId
    );
  }

  async getAllFavorites(recipeId) {
    const res = await api.get('api/favorites',recipeId);
    AppState.favoriteIds = res.data.map(f=> new FavRecipe(f))

  }
}
export const favoritesService = new FavoritesService();
