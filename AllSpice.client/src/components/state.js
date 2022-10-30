//npm i @vueuse/core to install  node module dependencies for this...
import { ref, computed } from 'vue'
import { useMouseInElement } from '@vueuse/core' 
 export   const targetCard = ref(null) //as ClassName for the target Div/Card I want to apply this too. 
export  const { elementX, elementY, isOutside, elementHeight, elementWidth } =
  useMouseInElement(targetCard)
export  const cardTransform = computed(() => {
  const MAX_ROTATION = 6
  const rX = (
    MAX_ROTATION / 2 -
    (elementY.value / elementHeight.value) * MAX_ROTATION
  ).toFixed(2) // handles x-axis
  const rY = (
    (elementX.value / elementWidth.value) * MAX_ROTATION -
    MAX_ROTATION / 2
  ).toFixed(2) // handles y-axis
  return isOutside.value
    ? ''
    : `perspective(${elementWidth.value}px) rotateX(rXdeg) rotateY(rYdeg)`
})
