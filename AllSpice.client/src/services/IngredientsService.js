import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { api } from "./AxiosService.js";

class IngredientsService {
  async addIngredient(ingredientData) {
    const res = await api.post("api/ingredients", ingredientData);
    console.log(res.data);

    let newIngredient = new Ingredient(res.data);
    AppState.ingredients = [newIngredient, ...AppState.ingredients];
  }

  async removeIngredient(ingredientId) {
    const res = await api.delete(`api/ingredients/${ingredientId}`);
    console.log(res.data);
    let index = AppState.ingredients.findIndex(i => i.id == ingredientId)
    AppState.ingredients.splice(index,1)
  }
}
export const ingredientsService = new IngredientsService();
