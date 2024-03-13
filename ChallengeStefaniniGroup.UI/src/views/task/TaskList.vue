<script setup>
import { onMounted, ref } from 'vue';
import axios from 'axios';
import { RouterLink } from 'vue-router';

const taskCollection = ref([])

onMounted(() => {
    axios.get("https://localhost:44380/api/Task")
        .then((response) => {
            taskCollection.value = response.data.data;
        })
})
</script>
<template>
    <div class="container">
        <div class="x_title">
            <h2 class="mt-2 me-4">Tarefas</h2>
        </div>
        <div class="row mb-2 mt-2 d-flex justify-content-end">
            <div class="col d-md-flex justify-content-md-end">
                <RouterLink class="btn btn-success" to="/task/add">Nova Tarefa</RouterLink>
            </div>
        </div>
        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th>Título</th>
                    <th>Descrição</th>
                    <th>Data de criação</th>
                    <th>Situação</th>
                    <th>Ação</th>
                </tr>
            </thead>
            <tbody v-for="item in taskCollection" :key="item.id">
                <tr>
                    <th>{{ item.title }}</th>
                    <td>{{ item.description }}</td>
                    <td>{{ item.dateCreatedFormated }}</td>
                    <td>{{ item.statusDisplayName }}</td>
                    <td><RouterLink class="btn btn-primary" :to="`/task/update/${item.id}`">Alterar</RouterLink></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>
<style></style>