import { api } from "./AxiosService.js";

class FavoritesService {
  async favoriteRecipe(favoritedRecipe) {
    const res = await api.post("api/favorites");
  }
}
export const favoritesService = new FavoritesService();
