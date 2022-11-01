import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { Instruction } from "../models/Instruction.js";
import { api } from "./AxiosService.js";

class InstructionsService {
  async addInstruction(instructionsData) {
    const res = await api.post("api/instructions", instructionsData);
        console.log('[instructions]',res.data);
       

    let newInstruction = new Instruction(res.data);
    AppState.instructions = [...AppState.instructions, newInstruction];
  }

  async removeInstruction(instructionId) {
    const res = await api.delete(`api/instructions/${instructionId}`);
    console.log(res.data);
    let index = AppState.instructions.findIndex((i) => i.id == instructionId);
    AppState.instructions.splice(index, 1);
  }
}
export const instructionsService = new InstructionsService();
