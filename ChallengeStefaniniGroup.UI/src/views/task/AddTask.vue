<script setup>
import { reactive } from 'vue';
import { useRouter } from 'vue-router';
import Swal from 'sweetalert2';
import { postTask } from '../../services/task/taskService';

let newTask = reactive({
    title: "",
    description: "",
});

const router = useRouter();

const addTask = () => {
    postTask(newTask).then((response) => {
            if (!response.success) {
                Swal.fire({
                    text: response.message,
                    icon: "error"
                });
            }
            router.push("/tasks");
            Swal.fire({
                position: "top",
                icon: "success",
                title: response.message,
                showConfirmButton: false,
                timer: 800
            });
        })
        .catch(error => {
            Swal.fire({
                text: error.response.message,
                icon: "error"
            });
        });
};
</script>
<template>
    <div class="container mt-4">
        <div class="x_title">
            <h2 class="mt-2 me-4">Nova Tarefa</h2>
        </div>
        <form @submit.prevent="addTask">
            <div class="m-2">
                <div class="mt-3">
                    <label for="inputTitle" class="form-label">Título</label>
                    <input type="text" class="form-control" id="inputTitle" v-model="newTask.title" required />
                </div>
                <div class="mt-3">
                    <label for="inputDescription" class="form-label">Descrição</label>
                    <input type="text" class="form-control" id="inputDescription" v-model="newTask.description"
                        required />
                </div>
                <div class="mt-3">
                    <button type="submit" class="btn btn-success">
                        Adicionar
                    </button>
                </div>
            </div>
        </form>
    </div>
</template>