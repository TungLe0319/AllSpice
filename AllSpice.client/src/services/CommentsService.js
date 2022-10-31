import { AppState } from "../AppState.js";
import { Comment } from "../models/Comment.js";
import { Ingredient } from "../models/Ingredient.js";
import { api } from "./AxiosService.js";

class CommentsService {
  async addComment(commentData) {
    const res = await api.post("api/comments", commentData);
    console.log(res.data);

    let newComment = new Comment(res.data)
    AppState.comments = [newComment, ...AppState.comments];
  }

  async removeComment(commentId) {
    const res = await api.delete(`api/comments/${commentId}`);
    console.log(res.data);
    let index = AppState.comments.findIndex((c) => {
      c.id == commentId;
    });

    AppState.comments.splice(index, 1);
  }
}
export const commentsService = new CommentsService();
