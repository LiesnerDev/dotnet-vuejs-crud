export const create = (idModal) => {
    return new window.bootstrap.Modal(document.getElementById(idModal));
}

export const open = (modal) => {
    modal.show();
}

export const close = (modal) => {
    modal.hide();
}

