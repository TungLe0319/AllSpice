import { AppState } from "../AppState";
import { FavRecipe } from "../models/FavRecipe.js";
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
    const res = await api.get(`/account/favorites`);
    // console.log(res.data);
// AppState.recipes =[]
    AppState.recipes  = res.data.map((r) => new Recipe(r));
    


    // console.log(AppState.recipes);
  }
  async getAllFavorites() {
    const res = await api.get('/account/favorites')
    AppState.favoriteIds = res.data.map(f=> new FavRecipe(f))
    // console.log(AppState.favoriteIds);
  }
}

export const accountService = new AccountService();
