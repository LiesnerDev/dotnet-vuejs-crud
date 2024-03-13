<template>
    <div class="modal fade" id="confirmDeleteModal" tabindex="-1" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Confirmação de exclusão</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    Realmente deseja excluir?
                </div>
                <div class="modal-footer">
                    <button type="button" @click="$event => $emit('confirm-delete-click')" class="btn btn-danger">
                        Confirmar exclusão
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>