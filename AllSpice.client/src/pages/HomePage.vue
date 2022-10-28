<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
      <button data-bs-target="#recipeModal" data-bs-toggle="modal" class="btn btn-success">
    modal
   </button>
   <RecipeModal />
 
  </div>
</template>

<script>


export default {
    setup() {
        return {};
    },
    components: { }
}
</script>

<style scoped lang="scss">

</style>
