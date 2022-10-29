import { reactive } from "vue";

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  /** @type {import('./models/Recipe.js').Recipe[]} */
  recipes: [],
  
  /** @type {import('./models/Recipe.js').Recipe || null} */
  activeRecipe:null,
  activeRecipeId :null,

  /** @type {import('./models/Ingredient.js').Ingredient[]} */
  ingredients: [],

  /** @type {import('./models/FavRecipe.js').FavRecipe[]} */
  favorites: [],
  
  /** @type {import('./models/FavRecipe.js').FavRecipe[]} */
  favoriteIds:[],
});
