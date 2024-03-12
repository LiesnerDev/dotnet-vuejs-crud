<script setup>
import axios from 'axios';
import { reactive } from 'vue';
import { useRouter } from 'vue-router';

let newTask = reactive({
    title: "",
    description: "",
});

const router = useRouter();

const addTask = () => {
    console.log(newTask);
    axios.post("https://localhost:44380/api/Task", newTask)
        .then(() => {
            router.push("/tasks");
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