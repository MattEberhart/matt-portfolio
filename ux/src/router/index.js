import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ManageProjectsView from '../views/ManageProjectsView.vue'
import ResumeView from '../views/ResumeView'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomeView
  },
  {
    path: '/projects',
    name: 'Manage Projects',
    component: ManageProjectsView
  },
  {
    path: '/resume',
    name: 'Resume',
    component: ResumeView
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
