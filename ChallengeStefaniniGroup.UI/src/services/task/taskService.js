import * as taskResource from './taskResource';

export const getTask = () => {
    return taskResource.getTask().then(({
        data
    }) => data)
}

export const getTaskById = (id) => {
    return taskResource.getTaskById(id).then(({
        data
    }) => data)
}

export const postTask = (object) => {
    return taskResource.postTask(object).then(({
        data
    }) => data)
}

export const putTask = (object) => {
    return taskResource.putTask(object).then(({
        data
    }) => data)
}

export const deleteTask = (id) => {
    return taskResource.deleteTask(id).then(({
        data
    }) => data)
}

