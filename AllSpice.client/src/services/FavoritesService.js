import { AppState } from "../AppState.js";
import { FavRecipe } from "../models/FavRecipe.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js";
import { recipesService } from "./RecipesService.js";

class FavoritesService {
  async favoriteRecipe(recipe) {
    let newFav = {};
    newFav.recipeId = recipe.id;

   
    const res = await api.post("api/favorites", newFav);

    recipe.favoriteId = res.data.id;
recipe.favorited= true
    AppState.favorites.push(recipe);

    console.log(AppState.favorites);
  }
  async removeFavoriteRecipe(favoriteId) {
    console.log(favoriteId,"service");
    await api.delete(`api/favorites/${favoriteId}`);

    let index = AppState.favorites.findIndex(f=> f.favoriteId == favoriteId)
    AppState.favorites.splice(index,1)
    // AppState.favorites = AppState.favorites.filter((f) => f.id != favoriteId);
    // AppState.recipes = AppState.recipes.filter(
    //   (r) => r.favoriteId != favoriteId
    // );
  }

  async getAllFavorites(recipeId) {
    const res = await api.get("api/favorites", recipeId);
    AppState.favoriteIds = res.data.map((f) => new FavRecipe(f));
  }
}
export const favoritesService = new FavoritesService();
