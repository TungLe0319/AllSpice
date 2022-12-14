import { reactive } from "vue";

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  /** @type {import('./models/Recipe.js').Recipe[]} */
  recipes: [],

  /** @type {import('./models/FavoriteIds.js').FavoriteIds[]} */
  favorites: [],

  /** @type {import('./models/Recipe.js').Recipe || null} */
  activeRecipe: null,
  activeRecipeId: null,

  /** @type {import('./models/Ingredient.js').Ingredient[]} */
  ingredients: [],
  /** @type {import('./models/Instruction.js').Instruction[]} */
  instructions: [],

  /** @type {import('./models/Comment.js').Comment[]} */
  comments: [],

  infinite: 0,
  FavoriteNum: 0,
  test1: 0,
  focus: 0,
  offSet: 12,
  limit: 12,
  categories: [
    { name: "specialtyCoffee", id: 1 },
    { name: "asian ", id: 2 },
    { name: " mexican ", id: 3 },
    { name: "italian", id: 4 },
    { name: "mexican ", id: 5 },
  ],
});
