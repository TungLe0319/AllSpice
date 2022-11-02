import { AppState } from "../AppState";
import { FavoriteIds } from "../models/FavoriteIds.js";
import { FavoriteRecipe } from "../models/FavoriteRecipe.js";

import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class AccountService {
  async getAccount() {
    try {
      const res = await api.get("/account");
      AppState.account = res.data;
    } catch (err) {
      logger.error("HAVE YOU STARTED YOUR SERVER YET???", err);
    }
  }

  async getFavoriteRecipes() {
    let offSetNum = AppState.offSet;
    const res = await api.get(`/account/favorites/infiniteScroll`, {
      params: {
        offSet: offSetNum,
      },
    });
    console.log(res.data);
    let recipes = res.data.map((r) => new Recipe(r));
    // AppState.recipes =[]
    AppState.offSet += recipes.length;
    AppState.recipes = [...AppState.recipes, ...recipes];

    console.log(AppState.recipes);
  }

  async getAllFavorites() {
    const res = await api.get("/account/favorites/ids");
    console.log(res.data);
    AppState.favorites = res.data.map((f) => new FavoriteIds(f));

    AppState.recipes.forEach((r) => {
      let fav = AppState.favorites.find((f) => f.recipeId == r.id);
      if (fav) {
        r.favorited = true;
        r.favoriteId = fav.favoriteId;
      }
    });

    console.log(AppState.favorites);
  }

  async getMyRecipes(offSet) {
    const res = await api.get("account/recipes", {
      params: {
        offSet: offSet
      },
    });
console.log(res.data);
    let recipes = res.data.map((r) => new Recipe(r));
    AppState.offSet += recipes.length;
    AppState.recipes = [...AppState.recipes, ...recipes];
  }
}
export const accountService = new AccountService();
