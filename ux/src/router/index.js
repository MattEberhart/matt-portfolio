import { createRouter, createWebHistory } from 'vue-router'
import HomeCard from '../components/HomeCard'
import PostProject from '../components/PostProject.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomeCard
  },
  {
    path: '/PostProject',
    name: 'PostProject',
    component: PostProject
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
