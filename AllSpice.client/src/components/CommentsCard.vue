<template>
  
  <div class="card elevation-4 border-0">
    <div
      class="card-title bg-custom p-1 mb-0 rounded-top elevation-1 text-center"
    >
      <h3 class="p-md-0 m-md-0 text-light">Comments</h3>
    </div>
    <div class="card-body  text-dark ">
      {{ comment.body }}
    </div>
  </div>
  
</template>

<script>
import { Comment } from "../models/Comment.js";

export default {
  props: {
    comment: { type: Comment, required: true },
  },

  setup(props) {
    return {};
  },
};
</script>

<style lang="scss" scoped>
.text-shadow {
  color: aliceblue;
  text-shadow: 1px 1px black, 0px 0px 5px salmon;
  font-weight: bold;
  letter-spacing: 0.08rem;
  /* Second Color  in text-shadow is the blur */
}
.forcedImg {
  height: 300px;
  width: 300px;
  object-fit: cover;
}
</style>
