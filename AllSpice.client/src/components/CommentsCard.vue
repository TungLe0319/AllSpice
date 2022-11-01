<template>
  
  <div class="card elevation-4 border-0 my-1">
    
   
    <div class="card-body  text-dark  p-1">
      <div class="ms-2 mt-1">
 <div>
  <img :src="comment.creator.picture" alt=""  class="rounded-circle elevation-3 me-2" height="30">
  <small> {{comment.creator.name.split("@")[0]}} </small>
 </div>
        <p class="ms-2 mt-2"> {{ comment.body }}</p>
      </div>
    </div>
  </div>
  
</template>

<script>
import { Account } from "../models/Account.js";
import { Comment } from "../models/Comment.js";

export default {
  props: {
    profile: {type: Account},
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
