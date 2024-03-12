<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <nav class="navbar bg-dark navbar-expand-sm" data-bs-theme="dark">
    <div class="container-fluid">
      <a class="navbar-brand" to="/">Challenge StefaniniGroup</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup"
        aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
        <div class="navbar-nav">
          <RouterLink class="nav-link active" to="/tasks">Tarefas</RouterLink>
        </div>
      </div>
    </div>
  </nav>
  <div class="container">
    <RouterView />
  </div>
</template>
