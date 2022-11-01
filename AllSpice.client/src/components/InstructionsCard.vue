<template> 
  <div class=" instructionCard  bg-light p-1  " v-if="instruction">
    <div class="d-flex justify-content-between">
      <p class="ms-3">{{instruction.step}}</p>
      <button  @click="removeInstruction()" class="btn"> <i class="mdi mdi-minus-box fs-6 text-danger"></i></button>
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


.instructionCard:hover {
  transform: scale(1.01);
  transition: all 0.5s ease;

  filter: brightness(90%);
}


</style>
