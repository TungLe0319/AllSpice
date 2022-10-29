import { api } from "./AxiosService.js";

class IngredientsService {
  async addIngredient(ingredientData) {
    const res = await api.put("api/ingredients", ingredientData);
    console.log(res.data);
  }

  async removeIngredient(ingredientId) {
    const res = await api.delete(`api/ingredients/${ingredientId}`);
    console.log(res.data);
  }
}
export const ingredientsService = new IngredientsService();
