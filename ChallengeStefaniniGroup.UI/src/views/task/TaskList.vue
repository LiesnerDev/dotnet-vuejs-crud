<script setup>
import { onMounted, ref } from 'vue';
import axios from 'axios';

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
        <table class="table table-hover table-striped table-bordered table-bordered">
            <thead>
                <tr>
                    <th scope="col">Título</th>
                    <th scope="col">Descrição</th>
                    <th scope="col">Data de criação</th>
                    <th scope="col">Situação</th>
                </tr>
            </thead>
            <tbody v-for="item in taskCollection" :key="item.id">
                <tr>
                    <th>{{ item.title }}</th>
                    <td>{{ item.description }}</td>
                    <td>{{ item.dateCreatedFormated }}</td>
                    <td>{{ item.statusDisplayName }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>
<style></style>