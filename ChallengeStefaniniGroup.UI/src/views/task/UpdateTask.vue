<script setup>
import axios from 'axios';
import { reactive, onMounted, ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';

let updateTask = reactive({
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
    axios.get(`https://localhost:44380/api/Task/${route.params.id}`)
        .then((response) => {
            updateTask.id = response.data.data.id;
            updateTask.title = response.data.data.title;
            updateTask.description = response.data.data.description;
            updateTask.status = response.data.data.status;
        });
});
const UpdateTask = () => {
    axios.put("https://localhost:44380/api/Task", updateTask)
        .then((response) => {
            if(!response.data.success){
                alert(response.data.message);
            }
            router.push("/tasks");
        })
        .catch(error => {
            alert(error.response.data.message);
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
                    <input type="text" class="form-control" id="inputTitle" v-model="updateTask.title" required />
                </div>
                <div class="mt-3">
                    <label for="inputDescription" class="form-label">Descrição</label>
                    <input type="text" class="form-control" id="inputDescription" v-model="updateTask.description" required />
                </div>
                <div class="mt-3">
                    <label for="selectStatus" class="form-label">Descrição</label>
                    <select id="selectStatus" class="form-select" v-model="updateTask.status">
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