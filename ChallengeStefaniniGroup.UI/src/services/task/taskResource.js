import api from '../../utils/api';

export const getTask = () => {
    return api.get("/Task");
};

export const getTaskById = (id) => {
    return api.get(`/Task/${id}`);
}

export const postTask = (object) => {
    return api.post("/Task", object);
}

export const putTask = (object) => {
    return api.put("/Task", object);
}

export const deleteTask = (id) => {
    return api.delete(`/Task/${id}`);
}