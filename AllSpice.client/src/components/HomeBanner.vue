<template>
  <div class="card banner mt-2 border-0 mb-5 elevation-3">

<Login />
<div class="categoryBar position-absolute bg-light elevation-5 p-2 rounded ">
  <div  class="d-flex justify-content-between ">

    <span> <button class="btn btn-primary"> Cheese</button></span>
    <span> <button class="btn btn-primary"> Cheese</button></span>
    <span> <button class="btn btn-primary"> Cheese</button></span>
    <span> <button class="btn btn-primary"> Cheese</button></span>
  </div>
</div>
  </div>
</template>


<script>
import Login from "./Login.vue";

export default {
    setup() {
        return {};
    },
    components: { Login }
}
</script>


<style lang="scss" scoped>
.banner{
position: relative;
  height: 200px;
  width: 95vw;
  background-image: url(http://yesofcorsa.com/wp-content/uploads/2018/06/4K-Kitchen-Herbs-Best-Wallpaper.jpg);
  background-size: cover;
  background-position: top;

}

.categoryBar{

width: 40vw;
bottom: -20px;
left: 26vw;
}
</style>