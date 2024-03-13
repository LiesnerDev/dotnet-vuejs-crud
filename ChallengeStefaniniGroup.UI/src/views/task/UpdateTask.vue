<script setup>
import { reactive, onMounted, ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import Swal from 'sweetalert2';
import { getTaskById, putTask } from '../../services/task/taskService';

let updateTaskModel = reactive({
    id: "",
    title: "",
    description: "",
    status: "",
});
const statusOptions = ref([
    { text: 'Pedente', value: 0 },
    { text: 'Em Andamento', value: 1 },
    { text: 'Concluído', value: 2 }
])

const route = useRoute();
const router = useRouter();

onMounted(() => {
    getTaskById(route.params.id).then((response) => {
        updateTaskModel.id = response.data.id;
        updateTaskModel.title = response.data.title;
        updateTaskModel.description = response.data.description;
        updateTaskModel.status = response.data.status;
        });
});
const UpdateTask = () => {
    putTask(updateTaskModel).then((response) => {
            if(!response.success){
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
            <h2 class="mt-2 me-4">Alterar Tarefa</h2>
        </div>
        <form @submit.prevent="UpdateTask">
            <div class="m-2">
                <div class="mt-3">
                    <label for="inputTitle" class="form-label">Título</label>
                    <input type="text" class="form-control" id="inputTitle" v-model="updateTaskModel.title" required />
                </div>
                <div class="mt-3">
                    <label for="inputDescription" class="form-label">Descrição</label>
                    <input type="text" class="form-control" id="inputDescription" v-model="updateTaskModel.description" required />
                </div>
                <div class="mt-3">
                    <label for="selectStatus" class="form-label">Situação</label>
                    <select id="selectStatus" class="form-select" v-model="updateTaskModel.status">
                        <option v-for="option in statusOptions" :value="option.value">
                            {{ option.text }}
                        </option>
                    </select>
                </div>
                <div class="mt-3">
                    <button type="submit" class="btn btn-primary">
                        Alterar
                    </button>
                </div>
            </div>
        </form>
    </div>
</template>