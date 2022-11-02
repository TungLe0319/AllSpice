<template> 
  <div class=" hover2 bg-light p-1  " v-if="instruction">
    <div class="d-flex justify-content-between">
      <img src="https://cdn-icons-png.flaticon.com/512/1094/1094675.png" alt=""  width="30" height="30">
      <p class="mb-0  d-flex align-items-center">{{instruction.step}}</p>
      <button  @click="removeInstruction()" class="btn deleteButton"> 
        <img src="https://cdn-icons-png.flaticon.com/512/458/458594.png" alt="" width="25"  height="25">
      </button>
    </div>
  </div>
</template>

<script>
import { Instruction } from "../models/Instruction.js";
import { instructionsService } from "../services/InstructionsService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
instruction: {type: Instruction}
  },

  setup(props) {

    return {
async removeInstruction(){
  try {
    let id = props.instruction.id
      await instructionsService.removeInstruction(id)
    } catch (error) {
      Pop.error(error)
    }
}
    };
  },
};
</script>

<style lang="scss" scoped>



</style>
