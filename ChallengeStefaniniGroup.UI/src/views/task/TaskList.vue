<script setup>
import { onMounted, ref } from 'vue';
import ConfirmDelete from '../../components/ConfirmDelete.vue';
import Swal from 'sweetalert2';
import * as modal from '../../utils/modal';
import { getTask, deleteTask } from '../../services/task/taskService';

const taskCollection = ref([]);
const deleteItemId = ref(0);

let deleteModalInstance;

onMounted(() => {
    deleteModalInstance = modal.create('confirmDeleteModal');
    getTask().then((response) => {
        taskCollection.value = response.data;
    });
})

const openDeleteModal = (id) => {
    deleteItemId.value = id;
    modal.open(deleteModalInstance);
}

const confirmDelete = () => {
    deleteTask(deleteItemId.value).then((response) => {
            taskCollection.value = taskCollection.value.filter(_ => _.id !== deleteItemId.value);
            modal.close(deleteModalInstance);
            Swal.fire({
                title: response.message,
                icon: "success"
            })
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