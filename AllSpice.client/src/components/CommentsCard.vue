<template>
  <div class="card elevation-4 border-0 my-1">
    <div class="card-body text-dark p-1">
      <div class="ms-2 mt-1">
        <div class="d-flex justify-content-between">
          <div>
            <img
              :src="comment.creator.picture"
              alt=""
              class="rounded-circle elevation-3 me-2"
              height="30"
            />
          </div>
          <div>
            <p class="mb-0">{{ comment.creator.name.split("@")[0] }}</p>
            <span class="badge text-bg-warning">favorited</span>
          </div>
          <div>
            <small class="text-dark lighten-50 createdTime p-0 m-0">{{commentTime}} </small>
          </div>
        </div>
        <p class="mb-0 mt-1">{{ comment.body }}</p>
       
      </div>
    </div>
  </div>
</template>

<script>
import { ref } from "vue";
import { Account } from "../models/Account.js";
import { Comment } from "../models/Comment.js";
import { useTimeAgo } from '@vueuse/core'
import { format, render, cancel, register } from 'timeago.js';
// const timeAgo = useTimeAgo(new Date(2021, 0, 1))

import Pop from "../utils/Pop.js";

export default {
  props: {
    profile: { type: Account },
    comment: { type: Comment, required: true },
  },
  test: ref({ test: true }),
  setup(props) {
const commentTime = format(props.comment.createdAt)
    return {
   commentTime,

      hover: false,
      hoverMe() {
        console.log(this.hover);
      },
    };
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

.card:hover {
  .createdTime {
    visibility: visible;
    opacity: 1;

    transition: all 0.5s ease-in;
  }
}
.createdTime {
  transition: all 0.5s ease-in;

  z-index: 9999;

  opacity: 0;
}
</style>
