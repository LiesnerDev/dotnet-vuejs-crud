<script setup>
import { onMounted, ref } from 'vue';
import axios from 'axios';
import ConfirmDelete from '../../components/ConfirmDelete.vue';

const taskCollection = ref([]);
const deleteItemId = ref(0);

let deleteModalInstance;

onMounted(() => {
    deleteModalInstance = new window.bootstrap.Modal(document.getElementById('confirmDeleteModal'));
    axios.get("https://localhost:44380/api/Task")
        .then((response) => {
            taskCollection.value = response.data.data;
        });
})

const openDeleteModal = (id) => {
    deleteItemId.value = id;
    deleteModalInstance.show();
}


const confirmDelete = () => {
    console.log(deleteItemId.value);
    axios.delete(`https://localhost:44380/api/Task/${deleteItemId.value}`)
        .then(() => {
            taskCollection.value = taskCollection.value.filter(_ => _.id !== deleteItemId.value);
            deleteModalInstance.hide();
        })
}

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
        <table class="table table-hover table-bordered">
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
                    <td class="d-grid gap-2 d-md-flex justify-content-center">
                        <RouterLink class="btn btn-primary btn-sm" :to="`/task/update/${item.id}`">Alterar</RouterLink>
                        <button type="button" class="btn btn-danger btn-sm" @click="($event) => openDeleteModal(item.id)">
                            Excluir
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <ConfirmDelete @confirm-delete-click="confirmDelete"></ConfirmDelete>
</template>
<style></style>