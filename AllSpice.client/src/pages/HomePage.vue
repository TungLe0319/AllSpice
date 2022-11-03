<template>
  <div
    class="container-fluid sticky-top top-0 left-0 searchTest"
    id="searchBar22"
  >
    <div class="row justify-content-end">
      <div class="col-md-4 p-0">
        <SearchBar />
      </div>
    </div>
  </div>
  <div
    class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center container"
  >
    <div class="row">
      <div class="col-md-12">
        <HomeBanner />

        <div
          class="fixed-bottom d-flex align-items-end flex-column justify-content-center me-2 mb-1"
        >
          <div>
            <h4
              class="no-select ms-1 text-white fw-bold"
              title="Amount of Current Recipes"
            >
              {{ recipes.length }}
            </h4>

            <button
              data-bs-target="#recipeFormModal"
              data-bs-toggle="modal"
              class="btn addBtn"
            >
              <i class="mdi mdi-food fs-6"></i><i class="mdi mdi-plus fs-6"></i>
            </button>
          </div>
        </div>
      </div>
      <div class="col-md-12"></div>
    </div>
    <div class="row" v-if="recipes">
      <TransitionGroup
        name="fade"
        enterActiveClass="animate__fadeIn animate__animated"
        leaveActiveClass="animate__animate__fadeOut animate__animated"
      >
        <div
          class="col-10 col-md-3 recipeCard"
          v-for="r in recipes"
          :key="r.id"
        >
          <RecipeCard :recipe="r" />
        </div>
      </TransitionGroup>
    </div>
  </div>
  <RecipeModal :recipe="activeRecipe" />
  <RecipeForm />
  <InstructionsModal />
  <IngredientModal />
</template>

<script>
import { onAuthLoaded } from "@bcwdev/auth0provider-client";
import { computed } from "@vue/reactivity";
import { onMounted, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import IngredientModal from "../components/IngredientModal.vue";
import InstructionsModal from "../components/InstructionsModal.vue";
import LoadingSpinner from "../components/LoadingSpinner.vue";

import RecipeForm from "../components/RecipeForm .vue";
import SearchIcon from "../components/SearchIcon.vue";
import { accountService } from "../services/AccountService.js";
import { favoritesService } from "../services/FavoritesService.js";

import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    async function getRecipesInfiniteScroll() {
      try {
        let offSet = AppState.offSet;
        await recipesService.getRecipesInfiniteScroll(offSet);
      } catch (error) {
        Pop.error(error);
      }
    }
    async function getAllFavorites() {
      try {
        if (AppState.account) {
          await accountService.getAllFavorites();
        }
      } catch (error) {
        Pop.error(error);
      }
    }

    onMounted(() => {
      getRecipesInfiniteScroll();
      infiniteScroll();
      // hideOnScrollTest();
    });

    onAuthLoaded(() => {
      getAllFavorites();
    });

    async function getCurrentRecipes() {
      // setTimeout(3000)
      let infinite = AppState.infinite;

      let offSet = AppState.offSet;
      if (infinite == 0) {
        getRecipesInfiniteScroll(offSet);
      }
      if (infinite == 1) {
        await accountService.getFavoriteRecipes(offSet);
      }
      if (infinite == 2) {
        await accountService.getMyRecipes(offSet);
      }
    }

    function infiniteScroll() {
      window.onscroll = () => {
        let bottomOfWindow =
          document.documentElement.scrollTop + window.innerHeight ===
          document.documentElement.offsetHeight;
        if (bottomOfWindow) {
          getCurrentRecipes();
        }
      };
    }

    function hideOnScrollTest() {
      let nav = document.querySelector("#searchBar22");
      let prevScrollpos = window.scrollY;
      console.log(["prev"], prevScrollpos);
      window.onscroll = function () {
        let currentScrollPos = window.scrollY;
        console.log(["current"], currentScrollPos);
        if (prevScrollpos > currentScrollPos) {
          // nav.style.top="0"
          nav.classList.remove("hiddenOnScroll");
        } else {
          nav.classList.add("hiddenOnScroll");
          //  nav.style.top="-50px"
        }
        prevScrollpos = currentScrollPos;
      };
    }
    watchEffect(() => {
      // document.addEventListener('scroll', () => {
      //   console.log('hi');
      // }, true);
    });
    return {
      offSet: computed(() => AppState.offSet),
      recipes: computed(() => AppState.recipes),
      activeRecipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.ingredients),
      toggleSearchBar() {
        document.getElementById("searchBar22").classList.toggle("d-none");

        document.getElementById("searchBar22").focus();
      },
    };
  },
  components: {
    RecipeForm,
    InstructionsModal,
    IngredientModal,
    LoadingSpinner,
    SearchIcon,
  },
};
</script>

<style scoped lang="scss">
.hiddenOnScroll {
  opacity: 0;
  transition: all 0.25s ease;
}
.showOnScroll {
  opacity: 1;
  transition: all 0.5s;
}
.masonry-with-columns {
  columns: 6 200px;
  column-gap: 1rem;
  div {
    width: 150px;
    background: #ec985a;
    color: white;
    margin: 0 1rem 1rem 0;
    display: inline-block;
    width: 100%;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 2rem;
  }
  @for $i from 1 through 36 {
    div:nth-child(#{$i}) {
      $h: (random(400) + 100) + px;
      height: $h;
      line-height: $h;
    }
  }
}

.bricks {
  columns: 4;
}

.masonry {
  /* Masonry container */
  column-count: 4;
  column-gap: 1em;
}

.item {
  /* Masonry bricks or child elements */
  background-color: #eee;
  display: inline-block;
  margin: 0 0 1em;
  width: 100%;
}
.no-select {
  cursor: default !important;
}
//when screen is 700px OR LESS
@media only screen and (max-width: 700px) {
  .recipeCard {
  }
}
</style>
