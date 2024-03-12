import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import TaskList from '../views/task/TaskList.vue'
import AddTask from '../views/task/AddTask.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/tasks',
      name: 'taskList',
      component: TaskList
    },
    {
      path: '/task/add',
      name: 'addTask',
      component: AddTask
    }
  ]
})

export default router
