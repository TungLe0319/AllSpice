<template>
  <div
    class="modal fade"
    id="recipeModal"
    tabindex="-1"
    aria-labelledby="Label"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content bg-dark">
        <div class="modal-body FORM">
          <!-- -------------------SECTION FORM----------------------------------- -->
          <form @submit.prevent="handleSubmit" class="">
            <div class="row">
              <div class="col-md-8">
                <div class="mt-3 inputBox">
                  <span>CoverImg</span>
                  <input
                    type="url"
                   
                    name="coverImg"
                  />
                </div>
                <div class="mt-3 inputBox">
                  <span>UserName</span>
                  <input
                    type="text"
               
                    required
                    name="Username"
                  />
                </div>
                <div class="mt-3 inputBox">
                  <span>Profile Picture</span>
                  <input
                    type="url"
              
                    required
                    name="Profile Picture"
                  />
                </div>
              </div>
            </div>

            <div class="my-3">
              <button
                class="btn btn-success selectable"
                type="submit"
                data-bs-dismiss="modal"
              >
                Submit
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, watchEffect } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const editable = ref({});

    watchEffect(() => {
      // editable.value = { ...AppState.account };
    });
    return {
      async handleSubmit() {
        try {
          // await accountService.editAccount();
        } catch (error) {
          console.error(error);
          Pop.error(error, '[handleSubmit]');
        }
      },
    };
  },
};
</script>

<style lang="scss" scoped>
.modal-body {
  //background-image: url();
 // background-size: cover;
  //background-position: center;
  box-shadow: 1px 1px 10px rgba(243, 236, 236, 0.308);
}

</style>
