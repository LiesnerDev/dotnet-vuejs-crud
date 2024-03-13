import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import TaskList from '../views/task/TaskList.vue'
import AddTask from '../views/task/AddTask.vue'
import UpdateTask from '../views/task/UpdateTask.vue'

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
    },
    {
      path: '/task/update/:id',
      name: 'updateTask',
      component: UpdateTask
    }
  ]
})

export default router
