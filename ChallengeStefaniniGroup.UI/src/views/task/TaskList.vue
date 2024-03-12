<script setup>
    import { onMounted, ref } from 'vue';
    import axios from 'axios';

    const taskCollection = ref([])

    onMounted(() => {
        axios.get("https://localhost:44380/api/Task")
        .then((response) => {
            taskCollection = response.data.data;
        })
    })
</script>
<template>
<div class="container">
    <h1>Olá lista de tarefas</h1>
</div>
</template>
<style>
</style>